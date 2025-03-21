﻿using BotC_Custom_ScriptTool.Enums;
using System;
using System.Collections.Generic;
using System.Data;
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

        public static bool PrintToPDF = false;

        public static List<Image> PagesToPrint = new List<Image>();


        //Image Variables!
        static private float mmpi = 25.4f; //milli meter per inch (DO NOT TOUCH)
        static private int dpi = 150; //dots per inch (Touch only if needed)

        static private int ImageWidth = (int)(210 / mmpi * dpi);
        static private int ImageHeight = (int)(297 / mmpi * dpi);

        static private int padding = 50;
        static private int pageIndex = 0;


        public static void CreatePreview(Script script, List<CharacterRole> allRoles, List<Jinx> allJinxes, string ScriptName, string Author, string PathToCustomImage, bool UseTwoColumns, bool printCharacterBorders)
        {
            foreach (var img in PagesToPrint)
            {
                img.Dispose();
            }
            PagesToPrint.Clear();
            pageIndex = 0;


            if (script.Roles.Count == 0) return;
            if(allJinxes.Count == 0) return;

            var jinxesWhereRole_A_IsMet = allJinxes.Where(jinx => script.Roles.Contains(jinx.RoleA)).ToList();
            var jinxesWhereRole_B_IsAlsoMet = jinxesWhereRole_A_IsMet.Where(jinx => script.Roles.Contains(jinx.RoleB)).ToList();

            if (script.Roles.Count > 0) // Normal Character Sheet / Script
                CreateCharacterSheet(script, allRoles, ScriptName, Author, PathToCustomImage, UseTwoColumns, printCharacterBorders);
            if (script.Roles.Count > 0) // Travelers
                CreateTravelers(script, allRoles, ScriptName, Author, PathToCustomImage, UseTwoColumns, printCharacterBorders);
            if (script.Roles.Count > 0) // Fabled
                CreateFabled(script, allRoles, ScriptName, Author, PathToCustomImage, UseTwoColumns, printCharacterBorders);
            if (script.NightOrder.FirstNight.Count > 0) // NIght Order, first Night
                CreateNightOrder(script, allRoles, true);
            if (script.NightOrder.OtherNights.Count > 0) // Night Order, other Nights
                CreateNightOrder(script, allRoles, false);
            if (jinxesWhereRole_B_IsAlsoMet.Count > 0) // Jinxes
                CreateJinxes(script, jinxesWhereRole_B_IsAlsoMet, allRoles);
        }

        public static void CreateScript(Script script, List<CharacterRole> allRoles, List<Jinx> allJinxes, string ScriptName, string Author, string PathToCustomImage, bool UseTwoColumns, bool printCharacterBorders)
        {
            foreach (var img in PagesToPrint)
            {
                img.Dispose();
            }
            PagesToPrint.Clear();
            pageIndex = 0;

            if (script.Roles.Count == 0 || allRoles.Count == 0)
            {
                MessageBox.Show("No Roles selected! Unable to create something");
                return;
            }

            var jinxesWhereRole_A_IsMet = allJinxes.Where(jinx => script.Roles.Contains(jinx.RoleA)).ToList();
            var jinxesWhereRole_B_IsAlsoMet = jinxesWhereRole_A_IsMet.Where(jinx => script.Roles.Contains(jinx.RoleB)).ToList();

            if (script.Roles.Count > 0)
                CreateCharacterSheet(script, allRoles, ScriptName, Author, PathToCustomImage, UseTwoColumns, printCharacterBorders);
            if(script.NightOrder.FirstNight.Count > 0)
                CreateNightOrder(script, allRoles, true);
            if(script.NightOrder.OtherNights.Count > 0)
                CreateNightOrder(script, allRoles, false);
            if (jinxesWhereRole_B_IsAlsoMet.Count > 0)
                CreateJinxes(script, jinxesWhereRole_B_IsAlsoMet, allRoles);

            //Save as PDF File and clean up!
            SaveAsPDF(Path.Combine(Application.StartupPath, "Scripts", $"{ScriptName}.pdf"));

            foreach (var img in PagesToPrint)
            {
                img.Dispose();
            }
            PagesToPrint.Clear();
        }

        private static Image CreateA4Image()
        {
            Bitmap A4 = new Bitmap(ImageWidth, ImageHeight);
            A4.SetResolution(dpi, dpi);

            return A4;
        }

        private static void CreateCharacterSheet(Script script, List<CharacterRole> allRoles,
            string ScriptName, string Author, string PathToCustomImage,
            bool UseTwoColumns, bool printCharacterBorders)
        {
            var maxPerPage = 26;
            var maxRolesOnOneSheet = UseTwoColumns ? maxPerPage / 2 : maxPerPage;
            var roles = allRoles.Where(n => script.Roles.Contains(n.RoleName) && n.RoleType != ERoleType.System && n.RoleType != ERoleType.Traveler && n.RoleType != ERoleType.Fabled).ToList();

            roles = roles.OrderBy(r => script.Roles.IndexOf(r.RoleName)).ToList();

            var roleCount = UseTwoColumns == false ? roles.Count :
                RoundToNextEvenNumber(roles.Count(n => n.RoleType == ERoleType.Townsfolk)) +
                RoundToNextEvenNumber(roles.Count(n => n.RoleType == ERoleType.Outsider)) +
                RoundToNextEvenNumber(roles.Count(n => n.RoleType == ERoleType.Minion)) +
                RoundToNextEvenNumber(roles.Count(n => n.RoleType == ERoleType.Demon));

            var IconHeight = (ImageHeight - (2 * padding)) / maxRolesOnOneSheet;//(UseTwoColumns ? roleCount / 2 : roleCount)

            for (int charactersDrawn = 0; charactersDrawn < roles.Count; charactersDrawn += maxPerPage)
            {
                var charactersToDraw = roles.Skip(charactersDrawn).Take(maxPerPage).ToList();
                var A4 = CreateA4Image();
                var graphics = Graphics.FromImage(A4);
                if (PathToCustomImage == "")
                    graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, ImageWidth, ImageHeight));
                else
                    graphics.DrawImage(Image.FromFile(PathToCustomImage), new Rectangle(0, 0, ImageWidth, ImageHeight));

                //ScriptName and Author
                DrawScriptNameAndAuthor(graphics, ScriptName, "", Author, padding);

                int count = 0;

                var townsfolk = charactersToDraw.Where(n => n.RoleType == ERoleType.Townsfolk).ToList();
                if(townsfolk.Count > 0)
                {
                    DrawRolesOnImage(townsfolk, graphics, padding, IconHeight, count, ImageWidth, UseTwoColumns, printCharacterBorders, 5);
                    DrawLineOnImage(graphics, ImageWidth, padding, IconHeight, UseTwoColumns ? (int)Math.Round((decimal)count / 2) : count, ERoleType.Townsfolk, 0);
                    count = UseTwoColumns ? RoundToNextEvenNumber(townsfolk.Count) : townsfolk.Count;
                }

                
                var outsider = charactersToDraw.Where(n => n.RoleType == ERoleType.Outsider).ToList();
                if(outsider.Count > 0)
                {
                    DrawRolesOnImage(outsider, graphics, padding, IconHeight, count, ImageWidth, UseTwoColumns, printCharacterBorders, 20);
                    DrawLineOnImage(graphics, ImageWidth, padding, IconHeight, UseTwoColumns ? (int)Math.Round((decimal)count / 2) : count, ERoleType.Outsider, 15);

                    count = UseTwoColumns ?
                        RoundToNextEvenNumber(townsfolk.Count) + RoundToNextEvenNumber(outsider.Count) :
                        townsfolk.Count + outsider.Count;
                }

                var minions = charactersToDraw.Where(n => n.RoleType == ERoleType.Minion).ToList();
                if(minions.Count > 0)
                {
                    DrawRolesOnImage(minions, graphics, padding, IconHeight, count, ImageWidth, UseTwoColumns, printCharacterBorders, 35);
                    DrawLineOnImage(graphics, ImageWidth, padding, IconHeight, UseTwoColumns ? (int)Math.Round((decimal)count / 2) : count, ERoleType.Minion, 30);

                    count = UseTwoColumns ?
                        RoundToNextEvenNumber(townsfolk.Count) + RoundToNextEvenNumber(outsider.Count) + RoundToNextEvenNumber(minions.Count) :
                        townsfolk.Count + outsider.Count + minions.Count;
                }

                var demons = charactersToDraw.Where(n => n.RoleType == ERoleType.Demon).ToList();
                if(demons.Count > 0)
                {
                    DrawRolesOnImage(demons, graphics, padding, IconHeight, count, ImageWidth, UseTwoColumns, printCharacterBorders, 50);
                    DrawLineOnImage(graphics, ImageWidth, padding, IconHeight, UseTwoColumns ? (int)Math.Round((decimal)count / 2) : count, ERoleType.Demon, 45);
                }

                //Draw Not First Night Information
                DrawNotFirstNightOnImage(graphics);

                PagesToPrint.Add(A4);
            }
        }

        private static void CreateNightOrder(Script script, List<CharacterRole> allRoles, bool firstNight)
        {
            int maxPerPage = 18;
            List<NightInfo> info = firstNight ? script.NightOrder.FirstNight : script.NightOrder.OtherNights;
            var MaxIconHeight = (ImageHeight - (2 * padding)) / maxPerPage;

            for (int infosToDraw = 0; infosToDraw < info.Count; infosToDraw += maxPerPage)
            {
                var A4 = CreateA4Image();
                var graphics = Graphics.FromImage(A4);
                graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, ImageWidth, ImageHeight));
                DrawScriptNameAndAuthor(graphics, script.ScriptName, firstNight ? "First Night" : "Other Nights", script.ScriptAuthor, padding);

                var MaxGraphicLength = (int)info.Max(n => graphics.MeasureString(n.Rolename, new Font("Arial", FontSizeHeader)).Width) + padding;

                var partialInfos = info.Skip(infosToDraw).Take(maxPerPage).ToList();

                for (int i = 0; i < partialInfos.Count; i++)
                {
                    NightInfo fi = partialInfos[i];
                    var roleWithInfo = allRoles.FirstOrDefault(n => n.RoleName == fi.Rolename);
                    Image roleIcon;

                    roleIcon = File.Exists($@"{Application.StartupPath}\Images\{roleWithInfo.RoleName}.png") ?
                            Image.FromFile($@"{Application.StartupPath}\Images\{roleWithInfo.RoleName}.png") :
                            GetImageFromURL(roleWithInfo.RoleIconURL);

                    DrawRoleAndRoleInfoForNightOrder(graphics, fi, roleIcon, padding, new Point(0, i * MaxIconHeight), MaxIconHeight, MaxGraphicLength);
                }

                PagesToPrint.Add(A4);
            }
        }

        private static void CreateTravelers(Script script, List<CharacterRole> allRoles,
            string ScriptName, string Author, string PathToCustomImage,
            bool UseTwoColumns, bool printCharacterBorders)
        {
            //If we want to use two columns
            UseTwoColumns = false;

            var maxPerPage = 26;
            var maxRolesOnOneSheet = UseTwoColumns ? maxPerPage / 2 : maxPerPage;
            var roles = allRoles.Where(n => script.Roles.Contains(n.RoleName) && n.RoleType == ERoleType.Traveler).ToList();

            roles = roles.OrderBy(r => script.Roles.IndexOf(r.RoleName)).ToList();

            var roleCount = UseTwoColumns == false ? roles.Count :
                RoundToNextEvenNumber(roles.Count(n => n.RoleType == ERoleType.Traveler));

            var IconHeight = (ImageHeight - (2 * padding)) / maxRolesOnOneSheet;

            for (int charactersDrawn = 0; charactersDrawn < roles.Count; charactersDrawn += maxPerPage)
            {
                var charactersToDraw = roles.Skip(charactersDrawn).Take(maxPerPage).ToList();
                var A4 = CreateA4Image();
                var graphics = Graphics.FromImage(A4);
                if (PathToCustomImage == "")
                    graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, ImageWidth, ImageHeight));
                else
                    graphics.DrawImage(Image.FromFile(PathToCustomImage), new Rectangle(0, 0, ImageWidth, ImageHeight));

                //ScriptName and Author
                DrawScriptNameAndAuthor(graphics, ScriptName, "", Author, padding);

                int count = 0;

                var travelers = charactersToDraw.Where(n => n.RoleType == ERoleType.Traveler).ToList();
                if (travelers.Count > 0)
                {
                    DrawRolesOnImage(travelers, graphics, padding, IconHeight, count, ImageWidth, UseTwoColumns, printCharacterBorders, 5);
                    DrawLineOnImage(graphics, ImageWidth, padding, IconHeight, UseTwoColumns ? (int)Math.Round((decimal)count / 2) : count, ERoleType.Traveler, 0);
                    count = UseTwoColumns ? RoundToNextEvenNumber(travelers.Count) : travelers.Count;
                }

                //Draw Not First Night Information
                DrawNotFirstNightOnImage(graphics);

                PagesToPrint.Add(A4);
            }
        }

        private static void CreateFabled(Script script, List<CharacterRole> allRoles,
            string ScriptName, string Author, string PathToCustomImage,
            bool UseTwoColumns, bool printCharacterBorders)
        {
            //If we want to use two columns
            UseTwoColumns = false;

            var maxPerPage = 26;
            var maxRolesOnOneSheet = UseTwoColumns ? maxPerPage / 2 : maxPerPage;
            var roles = allRoles.Where(n => script.Roles.Contains(n.RoleName) && n.RoleType == ERoleType.Fabled).ToList();

            roles = roles.OrderBy(r => script.Roles.IndexOf(r.RoleName)).ToList();

            var roleCount = UseTwoColumns == false ? roles.Count :
                RoundToNextEvenNumber(roles.Count(n => n.RoleType == ERoleType.Fabled));

            var IconHeight = (ImageHeight - (2 * padding)) / maxRolesOnOneSheet;

            for (int charactersDrawn = 0; charactersDrawn < roles.Count; charactersDrawn += maxPerPage)
            {
                var charactersToDraw = roles.Skip(charactersDrawn).Take(maxPerPage).ToList();
                var A4 = CreateA4Image();
                var graphics = Graphics.FromImage(A4);
                if (PathToCustomImage == "")
                    graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, ImageWidth, ImageHeight));
                else
                    graphics.DrawImage(Image.FromFile(PathToCustomImage), new Rectangle(0, 0, ImageWidth, ImageHeight));

                //ScriptName and Author
                DrawScriptNameAndAuthor(graphics, ScriptName, "", Author, padding);

                int count = 0;

                var fabled = charactersToDraw.Where(n => n.RoleType == ERoleType.Fabled).ToList();
                if (fabled.Count > 0)
                {
                    DrawRolesOnImage(fabled, graphics, padding, IconHeight, count, ImageWidth, UseTwoColumns, printCharacterBorders, 5);
                    DrawLineOnImage(graphics, ImageWidth, padding, IconHeight, UseTwoColumns ? (int)Math.Round((decimal)count / 2) : count, ERoleType.Fabled, 0);
                    count = UseTwoColumns ? RoundToNextEvenNumber(fabled.Count) : fabled.Count;
                }

                //Draw Not First Night Information
                DrawNotFirstNightOnImage(graphics);

                PagesToPrint.Add(A4);
            }
        }

        private static void CreateJinxes(Script script, List<Jinx> allJinxes, List<CharacterRole> allRoles)
        {
            int maxPerPage = 18;
            var MaxIconHeight = (ImageHeight - (2 * padding)) / maxPerPage;

            for (int jinxesToDraw = 0; jinxesToDraw < allJinxes.Count; jinxesToDraw += maxPerPage)
            {
                var A4 = CreateA4Image();
                var graphics = Graphics.FromImage(A4);
                graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, ImageWidth, ImageHeight));
                DrawScriptNameAndAuthor(graphics, script.ScriptName, "Jinxes", script.ScriptAuthor, padding);

                var MaxGraphicLength = (int)allJinxes.Max(n => graphics.MeasureString(n.JinxText, new Font("Arial", FontSizeHeader)).Width) + padding;

                var partialJinxes = allJinxes.Skip(jinxesToDraw).Take(maxPerPage).ToList();

                for (int i = 0; i < partialJinxes.Count; i++)
                {
                    Jinx jinx = partialJinxes[i];
                    var roleA = allRoles.Single(n => n.RoleName == jinx.RoleA);
                    var roleB = allRoles.Single(n => n.RoleName == jinx.RoleB);
                    Image roleIconA;
                    Image roleIconB;

                    roleIconA = File.Exists($@"{Application.StartupPath}\Images\{roleA.RoleName}.png") ?
                            Image.FromFile($@"{Application.StartupPath}\Images\{roleA.RoleName}.png") :
                            GetImageFromURL(roleA.RoleIconURL);

                    roleIconB = File.Exists($@"{Application.StartupPath}\Images\{roleB.RoleName}.png") ?
                            Image.FromFile($@"{Application.StartupPath}\Images\{roleB.RoleName}.png") :
                            GetImageFromURL(roleB.RoleIconURL);

                    DrawJinx(graphics, jinx, roleIconA, roleIconB, padding, new Point(0, i * MaxIconHeight), MaxIconHeight, MaxGraphicLength);
                }

                PagesToPrint.Add(A4);
            }
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

        private static void DrawLineOnImage(Graphics graphics, int imageWidth, int padding, int iconHeight, int offset, ERoleType roleType, int nicePadding = 0)
        {
            graphics.DrawLine(new Pen(new SolidBrush(Color.Black), 2),
                new Point(padding, padding + (offset * iconHeight) + nicePadding),
                new Point(imageWidth - padding, padding + (offset * iconHeight) + nicePadding));

            var mesarued = graphics.MeasureString($"{roleType}", new Font("Arial", FontSizeRoleType));
            graphics.DrawString($"{roleType}",
                new Font("Arial", FontSizeRoleType),
                new SolidBrush(Color.FromArgb(255, 92, 31, 35)),
                new Point(
                    imageWidth - padding - (int)mesarued.Width,
                    padding + (offset * iconHeight) - (int)mesarued.Height + nicePadding));
        }

        private static void DrawRolesOnImage(List<CharacterRole> roles, Graphics graphics, int padding, int iconHeight, int offset, int imageWidth, bool useTwoColumns, bool printCharacterBorders, int nicePadding = 0)
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
                posY += nicePadding;
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

        private static void DrawJinx(Graphics graphics, Jinx jinx, Image roleIconA, Image roleIconB, int padding, Point position, int IconHeight, int MaxLength)
        {
            var calculatedX = position.X + padding;
            var calculatedY = position.Y + padding;

            graphics.DrawImage(roleIconA, calculatedX, calculatedY, IconHeight, IconHeight);
            calculatedX += IconHeight;
            graphics.DrawImage(roleIconB, calculatedX, calculatedY, IconHeight, IconHeight);
            calculatedX += IconHeight;

            graphics.DrawString(jinx.JinxText, new Font("Arial", FontSizeRoleAbility), new SolidBrush(Color.Black), new RectangleF(calculatedX, calculatedY, ImageWidth - padding - calculatedX, IconHeight));
        }

        private static Image GetImageFromURL(string URL)
        {
            if (!string.IsNullOrWhiteSpace(URL))
            {
                using (WebClient webClient = new WebClient())
                {
                    using (Stream stream = webClient.OpenRead(URL))
                    {
                        return Image.FromStream(stream);
                    }
                }
            }
            else
                return new Bitmap(10, 10);
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
            if (pageIndex < PagesToPrint.Count)
            {
                var img = PagesToPrint[pageIndex];
                ev.Graphics.DrawImage(img, new Rectangle(0, 0, (int)ev.Graphics.VisibleClipBounds.Width, (int)ev.Graphics.VisibleClipBounds.Height));
                img.Dispose();
                img = null;

                pageIndex++;

                if (pageIndex == PagesToPrint.Count)
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