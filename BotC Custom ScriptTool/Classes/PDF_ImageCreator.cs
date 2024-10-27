using BotC_Custom_ScriptTool.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace BotC_Custom_ScriptTool.Classes
{
    internal class PDF_ImageCreator
    {
        public static float FontSizeRoleType = 8;
        public static float FontSizeRoles = 10;
        public static float FontSizeRoleAbility = 8;
        public static float FontSizeHeader = 12;

        private static string fileName;

        public static void CreateScriptImage(List<CharacterRole> roles, string ScriptName, string Author, string PathToCustomImage, bool UseTwoColumns, bool printCharacterBorders)
        {
            float mmpi = 25.4f; //milli meter per inch (DO NOT TOUCH)
            int dpi = 150; //dots per inch (Touch only if needed)

            var ImageWidth = (int)(210 / mmpi * dpi);
            var ImageHeight = (int)(297 / mmpi * dpi);

            var padding = 50;
            var IconHeight = (ImageHeight - (2 * padding)) / (UseTwoColumns ? 13 : 26);
            // 26 = 14 Town + 4 Outsider + 4 Minion + 4 Demon
            //With Two Columns, 13!

            Bitmap A4 = new Bitmap(ImageWidth, ImageHeight);
            A4.SetResolution(dpi, dpi);

            var graphics = Graphics.FromImage(A4);
            if (PathToCustomImage == "")
            {
                graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, ImageWidth, ImageHeight)); 
            }
            else
            {
                graphics.DrawImage(Image.FromFile(PathToCustomImage), new Rectangle(0, 0, ImageWidth, ImageHeight));
            }

            //ScriptName and Author
            DrawScriptNameAndAuthor(graphics, ScriptName, Author, padding);

            //Max. 14 Townsfolk
            var townsfolk = roles.Where(n => n.RoleType == ERoleType.Townsfolk).ToList();
            DrawRolesOnImage(townsfolk, graphics, padding, IconHeight, 0, ImageWidth, UseTwoColumns, printCharacterBorders);
            DrawLineOnImage(graphics, ImageWidth, padding, IconHeight, 0, ERoleType.Townsfolk);

            //Max 4 Outsiders
            var outsider = roles.Where(n => n.RoleType == ERoleType.Outsider).ToList();
            DrawRolesOnImage(outsider, graphics, padding, IconHeight, 14, ImageWidth, UseTwoColumns, printCharacterBorders);
            DrawLineOnImage(graphics, ImageWidth, padding, IconHeight, UseTwoColumns ? 7 : 14, ERoleType.Outsider);

            //Max 4 Minions
            var minions = roles.Where(n => n.RoleType == ERoleType.Minion).ToList();
            DrawRolesOnImage(minions, graphics, padding, IconHeight, 18, ImageWidth, UseTwoColumns, printCharacterBorders);
            DrawLineOnImage(graphics, ImageWidth, padding, IconHeight, UseTwoColumns ? 9 : 18, ERoleType.Minion);

            //Max 4 Demons
            var demons = roles.Where(n => n.RoleType == ERoleType.Demon).ToList();
            DrawRolesOnImage(demons, graphics, padding, IconHeight, 22, ImageWidth, UseTwoColumns, printCharacterBorders);
            DrawLineOnImage(graphics, ImageWidth, padding, IconHeight, UseTwoColumns ? 11 : 22, ERoleType.Demon);

            //Image-File, that will be Put on the Page
            fileName = Path.Combine(Application.StartupPath, $"{ScriptName}.png");

            //Save & clean up!
            var img = (Image)A4;
            img.Save(fileName);

            graphics.Dispose();
            img.Dispose();
            A4.Dispose();
            graphics = null;
            img = null;
            A4 = null;

            //Save as PDF File and clean up!
            SaveAsPDF(Path.Combine(Application.StartupPath, "Scripts", $"{ScriptName}.pdf"));
            GC.Collect();
            File.Delete(fileName);
        }

        private static void DrawScriptNameAndAuthor(Graphics graphics, string ScriptName, string Author, int padding)
        {
            var scriptNameSize = graphics.MeasureString(ScriptName,
                new Font("Arial", FontSizeHeader, FontStyle.Italic));
            graphics.DrawString(ScriptName,
                new Font("Arial", FontSizeHeader, FontStyle.Italic),
                new SolidBrush(Color.FromArgb(255, 92, 31, 35)),
                new Point(padding, 20));

            var authorSize = graphics.MeasureString($" by {Author}",
                new Font("Arial", FontSizeHeader - 3, FontStyle.Italic));
            graphics.DrawString($" by {Author}",
                new Font("Arial", FontSizeHeader - 3, FontStyle.Italic),
                new SolidBrush(Color.FromArgb(255, 92, 31, 35)),
                new Point(
                    padding + (int)scriptNameSize.Width + 10,
                    20 + ((int)scriptNameSize.Height / 2) - ((int)authorSize.Height / 2))
                );
        }

        private static void DrawLineOnImage(Graphics graphics, int imageWidth, int padding, int iconHeight, int offset, ERoleType roleType)
        {
            graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 2),
                new Point(padding, padding + (offset * iconHeight)),
                new Point(imageWidth - padding, padding + (offset * iconHeight)));

            var mesarued = graphics.MeasureString($"{roleType}", new Font("Arial", FontSizeRoleType));
            graphics.DrawString($"{roleType}",
                new Font("Arial", FontSizeRoleType),
                new SolidBrush(Color.FromArgb(255, 92, 31, 35)),
                new Point(
                    imageWidth - padding - (int)mesarued.Width,
                    padding + (offset * iconHeight) - (int)mesarued.Height));
        }

        private static void DrawRolesOnImage(List<CharacterRole> roles, Graphics graphics, int padding, int iconHeight, int offset, int imageWidth, bool useTwoColumns, bool printCharacterBorders)
        {
            bool DrawLeft = true;

            for (int i = 0; i < roles.Count; i++)
            {
                //Decide if Drawing Left or Right
                if(useTwoColumns && i % 2 == 1)
                    DrawLeft = false;
                else
                    DrawLeft = true;

                //Calculate drawing Positions and Sizes
                var posX = DrawLeft ? padding : imageWidth / 2;
                var posY = padding +
                    (useTwoColumns ? ((offset / 2) * iconHeight) : (offset * iconHeight)) +
                    (useTwoColumns ? ((i / 2) * iconHeight) : (i * iconHeight));
                var drawWidth = (useTwoColumns ? (imageWidth - 2 * padding) / 2 - iconHeight : (imageWidth - 2 * padding) - iconHeight);
                var drawWidthRectangle = (useTwoColumns ? (imageWidth - 2 * padding) / 2 : (imageWidth - 2 * padding));

                //Get Role Informations
                var roleIcon = GetImageFromURL(roles[i].RoleIconURL);
                var roleAbility = roles[i].RoleAbilityText;
                var roleName = roles[i].RoleName;

                //Measure Strings
                var measuredStringName = graphics.MeasureString(roleName, new Font("Arial", FontSizeRoles, FontStyle.Bold));

                //Draws The Role Image/Icon
                graphics.DrawImage(roleIcon, posX, posY, iconHeight, iconHeight);

                //Draws Role Name
                graphics.DrawString(roleName, new Font("Arial", FontSizeRoles, FontStyle.Bold),
                    new SolidBrush(Color.Black),
                    posX + iconHeight,
                    posY); // posY + iconHeight / 2 - measuredStringName.Height / 2

                //Draws Ability
                graphics.DrawString(roleAbility, new Font("Arial", FontSizeRoleAbility),
                    new SolidBrush(Color.Black),
                    new RectangleF(
                    posX + iconHeight, // posX + iconHeight + 250
                    posY + measuredStringName.Height,
                    drawWidth,
                    iconHeight));

                if (printCharacterBorders)
                {
                    //Draws Gray Rectangle
                    graphics.DrawRectangle(new Pen(new SolidBrush(Color.Gray), 1), new Rectangle(
                        posX,
                        posY,
                        drawWidthRectangle,
                        iconHeight)); 
                }
            }
        }

        private static Image GetImageFromURL(string URL)
        {
            using (WebClient webClient = new WebClient())
            {
                using (Stream stream = webClient.OpenRead(URL))
                {
                    return Image.FromStream(stream);
                }
            }
        }

        private static void SaveAsPDF(string FileToSave)
        {
            try
            {
                try
                {
                    PrintDocument pd = new PrintDocument();

                    //Print to File
                    var pds = pd.PrinterSettings;
                    pds.PrintFileName = FileToSave;
                    pds.PrintToFile = true;

                    pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                    // Print the document.
                    pd.Print();
                }
                finally
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            var img = Image.FromFile(fileName);
            ev.Graphics.DrawImage(img, new Rectangle(0, 0, (int)ev.Graphics.VisibleClipBounds.Width, (int)ev.Graphics.VisibleClipBounds.Height));
            img.Dispose();
            img = null;
        }
    }
}