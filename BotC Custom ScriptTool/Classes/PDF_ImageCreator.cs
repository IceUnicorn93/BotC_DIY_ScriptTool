using BotC_Custom_ScriptTool.Enums;

using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;

namespace BotC_Custom_ScriptTool.Classes
{
    internal class PDF_ImageCreator
    {
        static float FontSizeRoleType = 8;
        static float FontSizeRoles = 10;
        static float FontSizeHeader = 12;

        public static void CreateScriptImage(List<CharacterRole> roles, string ScriptName, string Author)
        {
            float mmpi = 25.4f; //milli meter per inch (DO NOT TOUCH)
            int dpi = 150; //dots per inch (Touch only if needed)

            var ImageWidth = (int)(210 / mmpi * dpi);
            var ImageHeight = (int)(297 / mmpi * dpi);

            var padding = 50;
            var IconHeight = (ImageHeight - (2 * padding)) / 26;
            // 26 = 14 Town + 4 Outsider + 4 Minion + 4 Demon

            Bitmap A4 = new Bitmap(ImageWidth, ImageHeight);
            A4.SetResolution(dpi, dpi);

            var graphics = Graphics.FromImage(A4);
            graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, ImageWidth, ImageHeight));

            //ScriptName and Author
            DrawScriptNameAndAuthor(graphics, ScriptName, Author, padding);

            //Max. 14 Townsfolk
            var townsfolk = roles.Where(n => n.RoleType == Enums.ERoleType.Townsfolk).ToList();
            DrawLineOnImage(graphics, ImageWidth, padding, IconHeight, 0, ERoleType.Townsfolk);
            DrawRolesOnImage(townsfolk, graphics, padding, IconHeight, 0, ImageWidth);

            //Max 4 Outsiders
            var outsider = roles.Where(n => n.RoleType == Enums.ERoleType.Outsider).ToList();
            DrawLineOnImage(graphics, ImageWidth, padding, IconHeight, 14, ERoleType.Outsider);
            DrawRolesOnImage(outsider, graphics, padding, IconHeight, 14, ImageWidth);

            //Max 4 Minions
            var minions = roles.Where(n => n.RoleType == Enums.ERoleType.Minion).ToList();
            DrawLineOnImage(graphics, ImageWidth, padding, IconHeight, 18, ERoleType.Minion);
            DrawRolesOnImage(minions, graphics, padding, IconHeight, 18, ImageWidth);

            //Max 4 Demons
            var demons = roles.Where(n => n.RoleType == Enums.ERoleType.Demon).ToList();
            DrawLineOnImage(graphics, ImageWidth, padding, IconHeight, 22, ERoleType.Demon);
            DrawRolesOnImage(demons, graphics, padding, IconHeight, 22, ImageWidth);


            //Save & clean up!
            var img = (System.Drawing.Image)A4;
            img.Save($@"{ScriptName}.png");

            graphics.Dispose();
            img.Dispose();
            A4.Dispose();
            graphics = null;
            img = null;
            A4 = null;

            SaveAsPDF(ScriptName);
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

        private static void DrawRolesOnImage(List<CharacterRole> roles, Graphics graphics, int padding, int iconHeight, int offset, int imageWidth)
        {
            for (int i = 0; i < roles.Count; i++)
            {
                var posX = padding;
                var posY = padding + (i * iconHeight) + (offset * iconHeight);
                var roleIcon = GetImageFromURL(roles[i].RoleIconURL);
                var roleAbility = roles[i].RoleAbilityText;
                var roleName = roles[i].RoleName;

                var measuredString = graphics.MeasureString(roleAbility, new Font("Arial", FontSizeRoles));
                var measuredStringName = graphics.MeasureString(roleAbility, new Font("Arial", FontSizeRoles, FontStyle.Bold));

                //Draws The Role Image/Icon
                graphics.DrawImage(roleIcon, posX, posY, iconHeight, iconHeight);

                //Draws Role Name
                graphics.DrawString(roleName, new Font("Arial", FontSizeRoles, FontStyle.Bold),
                    new SolidBrush(Color.Black),
                    posX + iconHeight,
                    posY + iconHeight / 2 - measuredString.Height / 2);

                //Draws Ability
                graphics.DrawString(roleAbility, new Font("Arial", FontSizeRoles),
                    new SolidBrush(Color.Black),
                    new RectangleF(
                    posX + iconHeight + 250,
                    posY,
                    imageWidth - 2 * padding - (iconHeight + 250),
                    iconHeight));

                //Draws Gray Rectangle
                graphics.DrawRectangle(new Pen(new SolidBrush(Color.Gray), 1), new Rectangle(
                    posX,
                    posY,
                    imageWidth - 2 * padding,
                    iconHeight));
            }
        }

        private static System.Drawing.Image GetImageFromURL(string URL)
        {
            using (WebClient webClient = new WebClient())
            {
                using (Stream stream = webClient.OpenRead(URL))
                {
                    return System.Drawing.Image.FromStream(stream);
                }
            }
        }

        private static void SaveAsPDF(string ScriptName)
        {
            
        }
    }
}