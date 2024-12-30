using BotC_Custom_ScriptTool.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace BotC_Custom_ScriptTool.Classes
{
    internal class PDF_ImageCreator
    {
        public static float FontSizeRoleType = 8;
        public static float FontSizeRoles = 10;
        public static float FontSizeRoleAbility = 8;
        public static float FontSizeHeader = 12;

        public static bool PrintToPDF = false;

        private static List<Image> PrintImages = new List<Image>();


        //Image Variables!
        static float mmpi = 25.4f; //milli meter per inch (DO NOT TOUCH)
        static int dpi = 150; //dots per inch (Touch only if needed)

        static int ImageWidth = (int)(210 / mmpi * dpi);
        static int ImageHeight = (int)(297 / mmpi * dpi);

        static int padding = 50;
        static int imageIndex = 0;

        public static void CreateScript(Script script, List<CharacterRole> allRoles, string ScriptName, string Author, string PathToCustomImage, bool UseTwoColumns, bool printCharacterBorders)
        {
            imageIndex = 0;

            CreateCharacterSheet(script, allRoles, CreateA4Image(), ScriptName, Author, PathToCustomImage, UseTwoColumns, printCharacterBorders);
            CreateNightOrder(script, CreateA4Image(), allRoles, true);
            CreateNightOrder(script, CreateA4Image(), allRoles, false);

            if (script.Jinxes.Count > 0) { }

            //Save as PDF File and clean up!
            SaveAsPDF(Path.Combine(Application.StartupPath, "Scripts", $"{ScriptName}.pdf"));

            foreach (var img in PrintImages)
            {
                img.Dispose();
            }
            PrintImages.Clear();
        }

        private static Image CreateA4Image()
        {
            Bitmap A4 = new Bitmap(ImageWidth, ImageHeight);
            A4.SetResolution(dpi, dpi);

            return A4;
        }

        private static void CreateCharacterSheet(Script script, List<CharacterRole> allRoles, Image A4,
            string ScriptName, string Author, string PathToCustomImage,
            bool UseTwoColumns, bool printCharacterBorders)
        {
            var roles = allRoles.Where(n => script.Roles.Contains(n.RoleName)).ToList();

            var roleCount = UseTwoColumns == false ? roles.Count :
                RoundToNextEvenNumber(roles.Count(n => n.RoleType == ERoleType.Townsfolk)) +
                RoundToNextEvenNumber(roles.Count(n => n.RoleType == ERoleType.Outsider)) +
                RoundToNextEvenNumber(roles.Count(n => n.RoleType == ERoleType.Minion)) +
                RoundToNextEvenNumber(roles.Count(n => n.RoleType == ERoleType.Demon));

            var IconHeight = (ImageHeight - (2 * padding)) / (UseTwoColumns ? roleCount / 2 : roleCount);

            var graphics = Graphics.FromImage(A4);
            if (PathToCustomImage == "")
                graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, ImageWidth, ImageHeight));
            else
                graphics.DrawImage(Image.FromFile(PathToCustomImage), new Rectangle(0, 0, ImageWidth, ImageHeight));

            //ScriptName and Author
            DrawScriptNameAndAuthor(graphics, ScriptName, "",  Author, padding);

            int count = 0;
            //Max. 14 Townsfolk
            var townsfolk = roles.Where(n => n.RoleType == ERoleType.Townsfolk).ToList();
            DrawRolesOnImage(townsfolk, graphics, padding, IconHeight, count, ImageWidth, UseTwoColumns, printCharacterBorders);
            DrawLineOnImage(graphics, ImageWidth, padding, IconHeight, UseTwoColumns ? (int)Math.Round((decimal)count / 2) : count , ERoleType.Townsfolk);

            //Max 4 Outsiders
            count = UseTwoColumns ? RoundToNextEvenNumber(townsfolk.Count) : townsfolk.Count;
            var outsider = roles.Where(n => n.RoleType == ERoleType.Outsider).ToList();
            DrawRolesOnImage(outsider, graphics, padding, IconHeight, count, ImageWidth, UseTwoColumns, printCharacterBorders);
            DrawLineOnImage(graphics, ImageWidth, padding, IconHeight, UseTwoColumns ? (int)Math.Round((decimal)count / 2) : count, ERoleType.Outsider);

            //Max 4 Minions
            count = UseTwoColumns ? RoundToNextEvenNumber(townsfolk.Count) + RoundToNextEvenNumber(outsider.Count) :
                townsfolk.Count + outsider.Count;
            var minions = roles.Where(n => n.RoleType == ERoleType.Minion).ToList();
            DrawRolesOnImage(minions, graphics, padding, IconHeight, count, ImageWidth, UseTwoColumns, printCharacterBorders);
            DrawLineOnImage(graphics, ImageWidth, padding, IconHeight, UseTwoColumns ? (int)Math.Round((decimal)count / 2) : count, ERoleType.Minion);

            //Max 4 Demons
            count = UseTwoColumns ? RoundToNextEvenNumber(townsfolk.Count) + RoundToNextEvenNumber(outsider.Count) + RoundToNextEvenNumber(minions.Count) :
                townsfolk.Count + outsider.Count + minions.Count;
            var demons = roles.Where(n => n.RoleType == ERoleType.Demon).ToList();
            DrawRolesOnImage(demons, graphics, padding, IconHeight, count, ImageWidth, UseTwoColumns, printCharacterBorders);
            DrawLineOnImage(graphics, ImageWidth, padding, IconHeight, UseTwoColumns ? (int)Math.Round((decimal)count / 2) : count, ERoleType.Demon);

            //Draw Not First Night Information
            DrawNotFirstNightOnImage(graphics);

            PrintImages.Add(A4);
        }

        private static void CreateNightOrder(Script script, Image A4, List<CharacterRole> allRoles, bool firstNight)
        {
            var graphics = Graphics.FromImage(A4);
            graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, ImageWidth, ImageHeight));

            DrawScriptNameAndAuthor(graphics, script.ScriptName, firstNight ? "First Night" : "Other Nights", script.ScriptAuthor, padding);

            List<NightInfo> info = firstNight ? script.NightOrder.FirstNight : script.NightOrder.OtherNights;

            var MaxGraphicLength = (int)info.Max(n => graphics.MeasureString(n.Rolename, new Font("Arial", FontSizeHeader)).Width) + padding;

            var MaxIconHeight = (ImageHeight - (2 * padding)) / 18;

            for (int i = 0; i < info.Count; i++)
            {
                NightInfo fi = info[i];
                var roleWithInfo = allRoles.FirstOrDefault(n => n.RoleName == fi.Rolename);
                Image roleIcon;
                if (fi.Rolename != "General Info")
                {
                    roleIcon = File.Exists($@"{Application.StartupPath}\Images\{roleWithInfo.RoleName}.png") ?
                        Image.FromFile($@"{Application.StartupPath}\Images\{roleWithInfo.RoleName}.png") : GetImageFromURL(roleWithInfo.RoleIconURL);
                }
                else
                {
                    roleIcon = Image.FromFile($@"{Application.StartupPath}\Images\{fi.Rolename}.png");
                }

                DrawRoleAndRoleInfoForNightOrder(graphics, fi, roleIcon, padding, new Point(0, i * MaxIconHeight), MaxIconHeight, MaxGraphicLength);
            }

            PrintImages.Add(A4);
        }

        private static int RoundToNextEvenNumber(int number)
        {
            if (number % 2 == 0) return number;
            else return number + 1;
        }

        private static void DrawScriptNameAndAuthor(Graphics graphics, string ScriptName, string AdditionalTopText, string Author, int padding)
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

            var additionalTopTextSize = graphics.MeasureString(AdditionalTopText,
                new Font("Arial", FontSizeHeader - 3, FontStyle.Italic));
            graphics.DrawString(AdditionalTopText,
                new Font("Arial", FontSizeHeader - 3, FontStyle.Italic),
                new SolidBrush(Color.FromArgb(255, 92, 31, 35)),
                new Point(
                    ImageWidth - padding - (int)additionalTopTextSize.Width,
                    20)
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
                if (useTwoColumns && i % 2 == 1)
                    DrawLeft = false;
                else
                    DrawLeft = true;

                //Calculate drawing Positions and Sizes
                var posX = DrawLeft ? padding : imageWidth / 2;
                var posY = padding +
                    (useTwoColumns ? ((int)Math.Round((decimal)offset / 2) * iconHeight) : (offset * iconHeight)) +
                    (useTwoColumns ? ((i / 2) * iconHeight) : (i * iconHeight));
                var drawWidth = (useTwoColumns ? (imageWidth - 2 * padding) / 2 - iconHeight : (imageWidth - 2 * padding) - iconHeight);
                var drawWidthRectangle = (useTwoColumns ? (imageWidth - 2 * padding) / 2 : (imageWidth - 2 * padding));

                //Get Role Informations
                var roleIcon = File.Exists($@"{Application.StartupPath}\Images\{roles[i].RoleName}.png") ?
                                Image.FromFile($@"{Application.StartupPath}\Images\{roles[i].RoleName}.png") : GetImageFromURL(roles[i].RoleIconURL);
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

        private static void DrawNotFirstNightOnImage(Graphics graphics)
        {
            var information = graphics.MeasureString("* nicht in der ersten Nacht",
                new Font("Arial", FontSizeRoleType, FontStyle.Italic));
            graphics.DrawString("* nicht in der ersten Nacht",
                new Font("Arial", FontSizeRoleType, FontStyle.Italic),
                new SolidBrush(Color.Gray),
                new Point(ImageWidth / 2 - (int)information.Width / 2, ImageHeight - padding));
        }

        private static void DrawRoleAndRoleInfoForNightOrder(Graphics graphics, NightInfo roleAndInformation, Image roleIcon, int padding, Point position, int IconHeight, int MaxLength)
        {
            var calculatedX = position.X + padding;
            var calculatedY = position.Y + padding;

            graphics.DrawImage(roleIcon, calculatedX, calculatedY, IconHeight, IconHeight);

            calculatedX += IconHeight;

            graphics.DrawString(roleAndInformation.Rolename, new Font("Arial", FontSizeHeader), new SolidBrush(Color.Black), new RectangleF(calculatedX, calculatedY, MaxLength, IconHeight));

            calculatedX += MaxLength;

            graphics.DrawString(roleAndInformation.NightInformation, new Font("Arial", FontSizeRoleAbility), new SolidBrush(Color.Black), new RectangleF(calculatedX, calculatedY,
                ImageWidth - (2 * padding) - IconHeight - MaxLength,
                IconHeight));

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

                    if (PrintToPDF == false)
                    {
                        PrintDialog pdi = new PrintDialog();
                        pdi.ShowDialog();
                        pd.PrinterSettings = pdi.PrinterSettings;
                    }
                    else
                    {
                        pd.PrinterSettings.PrintToFile = true;
                    }

                    //Print to File
                    if(pd.PrinterSettings.PrintToFile)
                        pd.PrinterSettings.PrintFileName = FileToSave;

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
            if (imageIndex < PrintImages.Count)
            {
                var img = PrintImages[imageIndex];
                ev.Graphics.DrawImage(img, new Rectangle(0, 0, (int)ev.Graphics.VisibleClipBounds.Width, (int)ev.Graphics.VisibleClipBounds.Height));
                img.Dispose();
                img = null;

                imageIndex++;

                if (imageIndex == PrintImages.Count)
                    ev.HasMorePages = false;
                else
                    ev.HasMorePages = true;
            }
            else
            {
                ev.HasMorePages = false;
            }
        }
    }
}