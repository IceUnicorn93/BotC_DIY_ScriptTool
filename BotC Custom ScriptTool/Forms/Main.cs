﻿using BotC_Custom_ScriptTool.Classes;
using BotC_Custom_ScriptTool.FileAccess;
using BotC_Custom_ScriptTool.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BotC_Custom_ScriptTool.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            SetEnableState(false);

            if (File.Exists($@"{Application.StartupPath}\jinxes.json") == false) return;

            jinxes = FileAccessor.ReadJinxes($@"{Application.StartupPath}\jinxes.json");
            lbJinxes.Items.Clear();
            lbJinxes.Items.AddRange(jinxes.ToArray());

            if (File.Exists($@"{Application.StartupPath}\AutomaticNightOrderConfig.json") == false) return;
            nightOrderConfig = FileAccessor.ReadAutomaticNightOrderConfig($@"{Application.StartupPath}\AutomaticNightOrderConfig.json");
        }

        //--------------------- Private Fields

        //Tab 1 (Characters)
        private CharacterRole currentSelectedRole;
        private bool isNewRole = false;
        private List<CharacterRole> roles = new List<CharacterRole>();

        //Tab 2 (Script)
        private List<CharacterRole> selectedScriptRoles = new List<CharacterRole>();
        private List<Jinx> jinxes = new List<Jinx>();
        private NightOrder nightOrder = new NightOrder();
        private AutomaticNightOrderConfig nightOrderConfig = new AutomaticNightOrderConfig();

        //Tab 3 (PDF)
        private int page = 0;

        //Tab 1 (Character)

        /// <summary>
        /// Enables the Character Editing fields
        /// </summary>
        /// <param name="state"></param>
        private void SetEnableState(bool state)
        {
            tbRoleName.Enabled = state;
            tbRoleEnglishName.Enabled = state;
            tbRoleIconURL.Enabled = state;
            tbRoleAbility.Enabled = state;
            btnAdd.Enabled = state;
            tbFirstNight.Enabled = state;
            tbOtherNights.Enabled = state;

            rbTownsfolk.Enabled = state;
            rbOutsider.Enabled = state;
            rbMinion.Enabled = state;
            rbDemon.Enabled = state;
            rbTraveler.Enabled = state;
            rbFabled.Enabled = state;
            rbSystem.Enabled = state;
        }
        
        /// <summary>
        /// Clears Input Fields for Character Fields
        /// </summary>
        private void ClearInputFileds()
        {
            tbRoleName.Text = "";
            tbRoleEnglishName.Text = "";
            tbRoleIconURL.Text = "";
            tbRoleAbility.Text = "";
            tbFirstNight.Text = "";
            tbOtherNights.Text = "";

            rbTownsfolk.Checked = false;
            rbOutsider.Checked = false;
            rbMinion.Checked = false;
            rbDemon.Checked = false;
            rbTraveler.Checked = false;
            rbFabled.Checked = false;
            rbSystem.Checked = false;
        }

        /// <summary>
        /// Fills the Input Fields for Character Creation/Editing
        /// </summary>
        /// <param name="role"></param>
        private void PopulateInputFields(CharacterRole role)
        {
            if (role == null)
            {
                ClearInputFileds();
                return;
            }

            tbRoleName.Text = role.RoleName;
            tbRoleEnglishName.Text = role.EnglishOriginalRoleName;
            tbRoleIconURL.Text = role.RoleIconURL;
            tbRoleAbility.Text = role.RoleAbilityText;
            tbFirstNight.Text = role.FirstNight;
            tbOtherNights.Text = role.OtherNights;

            rbTownsfolk.Checked = role.RoleType == Enums.ERoleType.Townsfolk;
            rbOutsider.Checked = role.RoleType == Enums.ERoleType.Outsider;
            rbMinion.Checked = role.RoleType == Enums.ERoleType.Minion;
            rbDemon.Checked = role.RoleType == Enums.ERoleType.Demon;
            rbTraveler.Checked = role.RoleType == Enums.ERoleType.Traveler;
            rbFabled.Checked = role.RoleType == Enums.ERoleType.Fabled;
            rbSystem.Checked = role.RoleType == Enums.ERoleType.System;
        }

        // Tab 2 (Script)

        /// <summary>
        /// Updates the Label for Script Prepreation
        /// </summary>
        private void UpdateScriptCountLabel()
        {
            lblSelectedData.Text = $"{selectedScriptRoles.Count(n => n.RoleType == Enums.ERoleType.Townsfolk)} / " +
                $"{selectedScriptRoles.Count(n => n.RoleType == Enums.ERoleType.Outsider)} / " +
                $"{selectedScriptRoles.Count(n => n.RoleType == Enums.ERoleType.Minion)}  / " +
                $"{selectedScriptRoles.Count(n => n.RoleType == Enums.ERoleType.Demon)}{Environment.NewLine}" +
                $"Travelers: {selectedScriptRoles.Count(n => n.RoleType == Enums.ERoleType.Traveler)}{Environment.NewLine}" +
                $"Fabled: {selectedScriptRoles.Count(n => n.RoleType == Enums.ERoleType.Fabled)}";

        }

        /// <summary>
        /// Shows a Popup with the selected Jinx
        /// </summary>
        /// <param name="jinx"></param>
        private void ShowJinxForm(Jinx jinx)
        {
            var frm = new Form();
            frm.Size = new Size(457, 135);

            var ucjinx = new ucJinx(jinx, selectedScriptRoles.Select(n => n.RoleName).ToList());
            frm.Controls.Add(ucjinx);
            frm.ShowDialog();
        }

        // Tab 3 (PDF)

        //--------------------- Tab Page 1 (Character)

        /// <summary>
        /// Downloads the Image for the Character Role
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbRoleIconURL_TextChanged(object sender, EventArgs e)
        {
            //Incase of a bad URL, put it in a Try-Catch
            try 
            {
                if(File.Exists($@"{Application.StartupPath}\Images\{tbRoleName.Text}.png"))
                    pbRoleIcon.Load($@"{Application.StartupPath}\Images\{tbRoleName.Text}.png");
                else if(tbRoleIconURL.Text != "")
                        pbRoleIcon.Load(tbRoleIconURL.Text);
            }
            catch{}
        }

        /// <summary>
        /// Creates a new Characer Role and enables the Input Fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewRole_Click(object sender, EventArgs e)
        {
            currentSelectedRole = new CharacterRole();
            ClearInputFileds();
            rbTownsfolk.Checked = true;
            isNewRole = true;
            SetEnableState(true);
        }

        /// <summary>
        /// Adds the new Character Role to the List and clears the Input fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            currentSelectedRole.RoleName = tbRoleName.Text;
            currentSelectedRole.EnglishOriginalRoleName = tbRoleEnglishName.Text;
            currentSelectedRole.RoleIconURL = tbRoleIconURL.Text;
            currentSelectedRole.RoleAbilityText = tbRoleAbility.Text;
            currentSelectedRole.FirstNight = tbFirstNight.Text;
            currentSelectedRole.OtherNights = tbOtherNights.Text;
            currentSelectedRole.RoleType =
                rbTownsfolk.Checked ? Enums.ERoleType.Townsfolk :
                rbOutsider.Checked ? Enums.ERoleType.Outsider :
                rbMinion.Checked ? Enums.ERoleType.Minion :
                rbDemon.Checked ? Enums.ERoleType.Demon :
                rbTraveler.Checked ? Enums.ERoleType.Traveler :
                rbFabled.Checked ? Enums.ERoleType.Fabled :
                rbSystem.Checked ? Enums.ERoleType.System : Enums.ERoleType.Townsfolk;

            if (isNewRole)
                roles.Add(currentSelectedRole);
            lbRoles.Items.Clear();
            lbRoles.Items.AddRange(roles.OrderBy(n => n.ToString()).ToArray());
            lbRoles.SelectedItem = currentSelectedRole;

            ClearInputFileds();
            SetEnableState(false);
        }

        /// <summary>
        /// Popuplates the Input Fields with the selected Character Role
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbRoles.SelectedItem == null) return;

            currentSelectedRole = (CharacterRole)lbRoles.SelectedItem;
            isNewRole = false;
            PopulateInputFields(currentSelectedRole);
            SetEnableState(true);
        }

        /// <summary>
        /// Saves the current List of Characters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            FileAccessor.WriteRoles(roles,
                $@"{Application.StartupPath}\CharacterRoles.json");
        }

        /// <summary>
        /// Loads a List of Characters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if(File.Exists($@"{Application.StartupPath}\CharacterRoles.json") == false) return;

            roles = FileAccessor.ReadRoles(
                $@"{Application.StartupPath}\CharacterRoles.json");

            lbRoles.Items.Clear();
            lbRoles.Items.AddRange(roles.OrderBy(n => n.ToString()).ToArray());

            roles.ForEach(role =>
            {
                try
                {
                    if (role.EnglishOriginalRoleName == "")
                        role.EnglishOriginalRoleName = role.RoleIconURL.Split('/').Last().Split('.').First().Replace("Icon_", ""); 
                }
                catch { }
            });
        }

        /// <summary>
        /// Downloads all Images for the Characters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownloadImages_Click(object sender, EventArgs e)
        {
            if(Directory.Exists($@"{Application.StartupPath}\Images") == false)
                Directory.CreateDirectory($@"{Application.StartupPath}\Images");

            roles.ForEach(role =>
            {
                try
                {
                    if (File.Exists($@"{Application.StartupPath}\Images\{role.RoleName}.png") == false)
                    {
                        pbRoleIcon.Load(role.RoleIconURL);
                        pbRoleIcon.Image.Save($@"{Application.StartupPath}\Images\{role.RoleName}.png"); 
                    }
                }
                catch { }
            });
        }

        //--------------------- Tab Page 2 (Script)

        /// <summary>
        /// Populates the CheckedListBox if any Characters are created
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tcMainControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcMainControl.SelectedIndex == 1 && clbScriptRoles.Items.Count == 0)
            {
                rbFilterAll.Checked = false;
                rbFilterAll.Checked = true;
                UpdateScriptCountLabel();
            }
        }

        /// <summary>
        /// Changes the List in the CheckedListBox based of the Filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbFilter_CheckedChanged(object sender, EventArgs e)
        {
            clbScriptRoles.Items.Clear();

            if (rbFilterAll.Checked)
                clbScriptRoles.Items.AddRange(roles.Where(n => n.RoleType != Enums.ERoleType.System).OrderBy(n => n.ToString()).ToArray());
            else
            {
                var filterValue = -1;
                if (rbFilterTownsfolk.Checked) filterValue = 0;
                if (rbFilterOutsider.Checked) filterValue = 1;
                if (rbFilterMinions.Checked) filterValue = 2;
                if (rbFilterDemons.Checked) filterValue = 3;
                if (rbFilterTraveler.Checked) filterValue = 4;
                if (rbFilterFabled.Checked) filterValue = 5;

                clbScriptRoles.Items.AddRange(roles
                    .Where(n => (int)n.RoleType == filterValue)
                    .OrderBy(n => n.ToString())
                    .ToArray());
            }

            var listOfItemsToChange = new List<int>();
            selectedScriptRoles.ForEach(role =>
            {
                var index = clbScriptRoles.Items.IndexOf(role);
                if (index == -1) return;
                listOfItemsToChange.Add(index);
            });

            listOfItemsToChange.ForEach(n => clbScriptRoles.SetItemChecked(n, true));
            listOfItemsToChange.Clear();
            listOfItemsToChange = null;
        }

        /// <summary>
        /// Updates internal List of selected Roles for the Script (Also handles Limits)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clbScriptRoles_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var checkedListBox = sender as CheckedListBox;
            if (checkedListBox.SelectedItem == "") return;

            var index = e.Index;
            var newState = e.NewValue;

            var role = clbScriptRoles.Items[index] as CharacterRole;

            if (newState == CheckState.Checked && selectedScriptRoles.Contains(role) == false)
                selectedScriptRoles.Add(role);
            else if (newState == CheckState.Unchecked)
                selectedScriptRoles.Remove(role);


            //Remove this Block if limit is unwanted!
            //if (selectedScriptRoles.Count(n => n.RoleType == Enums.ERoleType.Townsfolk) > 14)
            //{
            //    selectedScriptRoles.Remove(role);
            //    e.NewValue = CheckState.Unchecked;
            //}
            //else if (selectedScriptRoles.Count(n => n.RoleType == Enums.ERoleType.Outsider) > 4)
            //{
            //    selectedScriptRoles.Remove(role);
            //    e.NewValue = CheckState.Unchecked;
            //}
            //else if (selectedScriptRoles.Count(n => n.RoleType == Enums.ERoleType.Minion) > 4)
            //{
            //    selectedScriptRoles.Remove(role);
            //    e.NewValue = CheckState.Unchecked;
            //}
            //else if (selectedScriptRoles.Count(n => n.RoleType == Enums.ERoleType.Demon) > 4)
            //{
            //    selectedScriptRoles.Remove(role);
            //    e.NewValue = CheckState.Unchecked;
            //}

            UpdateScriptCountLabel();
        }

        /// <summary>
        /// Saves the Script (based on the Input Field)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveScript_Click(object sender, EventArgs e)
        {
            if(Directory.Exists($@"{Application.StartupPath}\Scripts") == false)
                Directory.CreateDirectory($@"{Application.StartupPath}\Scripts");

            FileAccessor.WriteScript(new Script
            {
                Roles = selectedScriptRoles.Select(n => n.RoleName).ToList(),
                NightOrder = nightOrder,
                ScriptAuthor = tbScriptAuthor.Text,
                ScriptName = tbScriptName.Text
            }, $@"{Application.StartupPath}\Scripts\{tbScriptName.Text}.json");
        }

        /// <summary>
        /// Lets the User load a Script
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadScript_Click(object sender, EventArgs e)
        {
            using(var ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = $@"{Application.StartupPath}\Scripts";
                ofd.Filter = "Script Files|*.json";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var script = FileAccessor.ReadScript(ofd.FileName);
                    
                    tbScriptName.Text = script.ScriptName;
                    tbScriptAuthor.Text = script.ScriptAuthor;

                    nightOrder = script.NightOrder;

                    selectedScriptRoles.Clear();
                    selectedScriptRoles = roles.Where(n =>
                    {
                        return script.Roles.Contains(n.RoleName);
                    }).ToList();
                    foreach ( var role in selectedScriptRoles ) {
                        clbScriptRoles.SetItemChecked(clbScriptRoles.Items.IndexOf(role), true);
                    }

                    UpdateScriptCountLabel();
                }
            }
        }

        /// <summary>
        /// Creates a new Jinx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJinxes_Click(object sender, EventArgs e)
        {
            var newJinx = new Jinx();

            ShowJinxForm(newJinx);

            lbJinxes.Items.Add(newJinx);
            jinxes.Add(newJinx);

            FileAccessor.WriteJinxes(jinxes, $@"{Application.StartupPath}\jinxes.json");
        }

        /// <summary>
        /// Opens an existing Jinx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbJinxes_DoubleClick(object sender, EventArgs e)
        {
            var selectedJinx = lbJinxes.SelectedItem as Jinx;

            ShowJinxForm(selectedJinx);

            lbJinxes.Items.Remove(selectedJinx);
            lbJinxes.Items.Add(selectedJinx);

            FileAccessor.WriteJinxes(jinxes, $@"{Application.StartupPath}\jinxes.json");
        }

        /// <summary>
        /// Delets a Jinx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbJinxes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var selectedJinx = lbJinxes.SelectedItem as Jinx;
                lbJinxes.Items.Remove(selectedJinx);
                jinxes.Remove(selectedJinx);
            }

            FileAccessor.WriteJinxes(jinxes, $@"{Application.StartupPath}\jinxes.json");
        }

        /// <summary>
        /// Opens the Window to configure the Night Order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfigureNightOrder_Click(object sender, EventArgs e)
        {
            var firstNightRoles = selectedScriptRoles.Where(n => !string.IsNullOrEmpty(n.FirstNight)).ToList();
            firstNightRoles.AddRange(roles.Where(n => n.RoleType == Enums.ERoleType.System && !string.IsNullOrEmpty(n.FirstNight)));
            var otherNightsRoles = selectedScriptRoles.Where(n => !string.IsNullOrEmpty(n.OtherNights)).ToList();
            otherNightsRoles.AddRange(roles.Where(n => n.RoleType == Enums.ERoleType.System && !string.IsNullOrEmpty(n.OtherNights)));

            frmNightOrder frmNightOrder = new frmNightOrder(nightOrder, firstNightRoles, otherNightsRoles);
            frmNightOrder.ShowDialog();

            nightOrder = frmNightOrder.Order;
        }

        /// <summary>
        /// Opens the Window to configure the Automatic Night Order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfigureAutomaticNightOrder_Click(object sender, EventArgs e)
        {
            var frm = new frmAutomaticNightOrderConfig(nightOrderConfig);
            frm.ShowDialog();
            nightOrderConfig = frm.Config;
            FileAccessor.WriteAutomaticNightOrderConfig(nightOrderConfig, $@"{Application.StartupPath}\AutomaticNightOrderConfig.json");
        }

        /// <summary>
        /// Uses the Automatic Night Order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUseAutomaticNightOrder_Click(object sender, EventArgs e)
        {
            var firstNightRoles = selectedScriptRoles.Where(n => !string.IsNullOrEmpty(n.FirstNight)).ToList();
            firstNightRoles.AddRange(roles.Where(n => n.RoleType == Enums.ERoleType.System && !string.IsNullOrEmpty(n.FirstNight)));
            var otherNightsRoles = selectedScriptRoles.Where(n => !string.IsNullOrEmpty(n.OtherNights)).ToList();
            otherNightsRoles.AddRange(roles.Where(n => n.RoleType == Enums.ERoleType.System && !string.IsNullOrEmpty(n.OtherNights)));


            nightOrder = new NightOrder();
            nightOrder.FirstNight = firstNightRoles
                .OrderBy(r => nightOrderConfig.FirstNight.IndexOf(r.EnglishOriginalRoleName))
                .Select(n => new NightInfo { Rolename = n.RoleName, NightInformation = n.FirstNight })
                .ToList();
            nightOrder.OtherNights = otherNightsRoles
                .OrderBy(r => nightOrderConfig.OtherNights.IndexOf(r.EnglishOriginalRoleName))
                .Select(n => new NightInfo { Rolename = n.RoleName, NightInformation = n.OtherNights })
                .ToList();
        }

        //--------------------- Tab Page 3 (PDF)

        private void btnGeneratePDF_Click(object sender, EventArgs e)
        {
            var script = new Script
            {
                Roles = selectedScriptRoles.Select(n => n.RoleName).ToList(),
                NightOrder = nightOrder,
                ScriptAuthor = tbScriptAuthor.Text,
                ScriptName = tbScriptName.Text
            };

            pbPreview.Image.Dispose();
            pbPreview.Image = null;

            PDF_ImageCreator.PrintToPDF = true;
            PDF_ImageCreator.FontSizeRoles = (int)nudPdfCharacterNameSize.Value;
            PDF_ImageCreator.FontSizeRoleAbility = (int)nudPdfCharacterAbilitySize.Value;
            PDF_ImageCreator.CreateScript(script, roles, jinxes, tbScriptName.Text, tbScriptAuthor.Text, tbCustomBackgroundPath.Text, rbUse2Columns.Checked, cbxPrintCharacterBorder.Checked);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var script = new Script
            {
                Roles = selectedScriptRoles.Select(n => n.RoleName).ToList(),
                NightOrder = nightOrder,
                ScriptAuthor = tbScriptAuthor.Text,
                ScriptName = tbScriptName.Text
            };

            if (pbPreview.Image != null)
            {
                pbPreview.Image.Dispose();
                pbPreview.Image = null; 
            }

            PDF_ImageCreator.PrintToPDF = false;
            PDF_ImageCreator.FontSizeRoles = (int)nudPdfCharacterNameSize.Value;
            PDF_ImageCreator.FontSizeRoleAbility = (int)nudPdfCharacterAbilitySize.Value;
            PDF_ImageCreator.CreateScript(script, roles, jinxes, tbScriptName.Text, tbScriptAuthor.Text, tbCustomBackgroundPath.Text, rbUse2Columns.Checked, cbxPrintCharacterBorder.Checked);
        }

        private void btnGeneratePreview_Click(object sender, EventArgs e)
        {
            var script = new Script
            {
                Roles = selectedScriptRoles.Select(n => n.RoleName).ToList(),
                NightOrder = nightOrder,
                ScriptAuthor = tbScriptAuthor.Text,
                ScriptName = tbScriptName.Text
            };

            PDF_ImageCreator.FontSizeRoles = (int)nudPdfCharacterNameSize.Value;
            PDF_ImageCreator.FontSizeRoleAbility = (int)nudPdfCharacterAbilitySize.Value;
            PDF_ImageCreator.CreatePreview(script, roles, jinxes, tbScriptName.Text, tbScriptAuthor.Text, tbCustomBackgroundPath.Text, rbUse2Columns.Checked, cbxPrintCharacterBorder.Checked);

            lblPreViewPage.Text = $"1 / {PDF_ImageCreator.PagesToPrint.Count}";
            if(PDF_ImageCreator.PagesToPrint.Count > 0)
                pbPreview.Image = PDF_ImageCreator.PagesToPrint[0];
        }

        private void btnPreviousImage_Click(object sender, EventArgs e)
        {
            if(page == 0) return;
            page--;
            pbPreview.Image = PDF_ImageCreator.PagesToPrint[page];
            lblPreViewPage.Text = $"{page + 1} / {PDF_ImageCreator.PagesToPrint.Count}";
        }

        private void btnNextImage_Click(object sender, EventArgs e)
        {
            if(page == PDF_ImageCreator.PagesToPrint.Count - 1) return;
            page++;
            pbPreview.Image = PDF_ImageCreator.PagesToPrint[page];
            lblPreViewPage.Text = $"{page + 1} / {PDF_ImageCreator.PagesToPrint.Count}";
        }

        private void btnChooseBackground_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbCustomBackgroundPath.Text = ofd.FileName;
            }
        }

        //--------------------- Temporary Stuff

        private void ClipboardImport_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clipboard must follow this format: Type\\tName\\tAbility\\r\\n", "Format needs to be correct", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;   

            var clipboardText = Clipboard.GetText();
            var rows = clipboardText.Split(new[] {'\r', '\n'}).ToList().Where(n => n != "").ToList();

            foreach (var row in rows)
            {
                var cloums = row.Split('\t').ToList();
                var characterType = cloums[0];
                var characterName = cloums[1];
                var characterAbility = cloums[2];

                CharacterRole role;
                bool isNewRole = false;
                if (roles.Any(n => n.RoleName == characterName))
                {
                    role = roles.First(n => n.RoleName == characterName);
                }
                else
                {
                    isNewRole = true;
                    role = new CharacterRole();
                }

                role.RoleName = characterName;
                role.RoleAbilityText = characterAbility;
                role.RoleIconURL = "";
                role.RoleType = characterType == "Townsfolk" ? Enums.ERoleType.Townsfolk :
                    characterType == "Outsider" ? Enums.ERoleType.Outsider :
                    characterType == "Minion" ? Enums.ERoleType.Minion :
                    characterType == "Demon" ? Enums.ERoleType.Demon :
                    characterType == "Traveler" ? Enums.ERoleType.Traveler :
                    characterType == "Fabled" ? Enums.ERoleType.Fabled : Enums.ERoleType.Townsfolk;

                if (isNewRole)
                {
                        role.RoleIconURL = Prompt.ShowDialog(characterName, "Icon URL");
                        roles.Add(role); 
                }
            }

            lbRoles.Items.Clear();
            lbRoles.Items.AddRange(roles.OrderBy(n => n.ToString()).ToArray());
        }

        //Checkt alle Rollen an
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbScriptRoles.Items.Count; i++)
            {
                clbScriptRoles.SetItemChecked(i, true);
            }
        }

        //Temporärer Button um Jinxes zu importieren
        private void button2_Click(object sender, EventArgs e)
        {
            //string FullCleanUp(string Name)
            //{
            //    Name = CleanUpName(Name, " ");
            //    Name = CleanUpName(Name, "'");
            //    Name = CleanUpName(Name, "-");
            //    return Name;
            //}

            //string CleanUpName(string Name, string remove)
            //{
            //    return Name.Replace(remove, "");
            //}

            //var clipboardString = Clipboard.GetText();
            //var lines = clipboardString.Split('\r', '\n').Where(n => n != "").ToList();
            //foreach (var line in lines)
            //{
            //    var rolesAndJinx = line.Split(':');
            //    var roles = rolesAndJinx[0].Trim().Split('/');
            //    var jinx = rolesAndJinx[1].Trim();
            //    var roleA = roles[0].Trim();
            //    var roleB = roles[1].Trim();

            //    var newJinx = new Jinx();
            //    newJinx.JinxText = jinx;
            //    newJinx.RoleA = this.roles.Single(n => n.EnglishOriginalRoleName.ToLower() == FullCleanUp(roleA.ToLower())).RoleName;
            //    newJinx.RoleB = this.roles.Single(n => n.EnglishOriginalRoleName.ToLower() == FullCleanUp(roleB.ToLower())).RoleName;
            //    jinxes.Add(newJinx);
            //    lbJinxes.Items.Add(newJinx);
            //}

            //FileAccessor.WriteJinxes(jinxes, $@"{Application.StartupPath}\jinxes.json");
        }
    }

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
