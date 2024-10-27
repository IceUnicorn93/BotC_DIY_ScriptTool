namespace BotC_Custom_ScriptTool.Forms
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNewRole = new System.Windows.Forms.Button();
            this.tcMainControl = new System.Windows.Forms.TabControl();
            this.tpCharacters = new System.Windows.Forms.TabPage();
            this.pbRoleIcon = new System.Windows.Forms.PictureBox();
            this.rbDemon = new System.Windows.Forms.RadioButton();
            this.rbOutsider = new System.Windows.Forms.RadioButton();
            this.rbMinion = new System.Windows.Forms.RadioButton();
            this.rbTownsfolk = new System.Windows.Forms.RadioButton();
            this.tbRoleAbility = new System.Windows.Forms.TextBox();
            this.tbRoleIconURL = new System.Windows.Forms.TextBox();
            this.tbRoleName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSafe = new System.Windows.Forms.Button();
            this.lbRoles = new System.Windows.Forms.ListBox();
            this.tpScript = new System.Windows.Forms.TabPage();
            this.lbJinxes = new System.Windows.Forms.ListBox();
            this.btnJinxes = new System.Windows.Forms.Button();
            this.btnLoadScript = new System.Windows.Forms.Button();
            this.btnSaveScript = new System.Windows.Forms.Button();
            this.tbScriptAuthor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbScriptName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblScriptCountDemons = new System.Windows.Forms.Label();
            this.lblScriptCountMinions = new System.Windows.Forms.Label();
            this.lblScriptCountOutsiders = new System.Windows.Forms.Label();
            this.lblScriptCountTownsfolk = new System.Windows.Forms.Label();
            this.rbFilterAll = new System.Windows.Forms.RadioButton();
            this.rbFilterDemons = new System.Windows.Forms.RadioButton();
            this.rbFilterMinions = new System.Windows.Forms.RadioButton();
            this.rbFilterOutsider = new System.Windows.Forms.RadioButton();
            this.rbFilterTownsfolk = new System.Windows.Forms.RadioButton();
            this.clbScriptRoles = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tpPDF = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxPrintCharacterBorder = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rbUse2Columns = new System.Windows.Forms.RadioButton();
            this.rbUse1Column = new System.Windows.Forms.RadioButton();
            this.tbCustomBackgroundPath = new System.Windows.Forms.TextBox();
            this.btnGeneratePDF = new System.Windows.Forms.Button();
            this.btnConfigureNightOrder = new System.Windows.Forms.Button();
            this.tcMainControl.SuspendLayout();
            this.tpCharacters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRoleIcon)).BeginInit();
            this.tpScript.SuspendLayout();
            this.tpPDF.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNewRole
            // 
            this.btnNewRole.Location = new System.Drawing.Point(8, 6);
            this.btnNewRole.Name = "btnNewRole";
            this.btnNewRole.Size = new System.Drawing.Size(93, 23);
            this.btnNewRole.TabIndex = 0;
            this.btnNewRole.Text = "New Role";
            this.btnNewRole.UseVisualStyleBackColor = true;
            this.btnNewRole.Click += new System.EventHandler(this.btnNewRole_Click);
            // 
            // tcMainControl
            // 
            this.tcMainControl.Controls.Add(this.tpCharacters);
            this.tcMainControl.Controls.Add(this.tpScript);
            this.tcMainControl.Controls.Add(this.tpPDF);
            this.tcMainControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMainControl.Location = new System.Drawing.Point(0, 0);
            this.tcMainControl.Name = "tcMainControl";
            this.tcMainControl.SelectedIndex = 0;
            this.tcMainControl.Size = new System.Drawing.Size(689, 399);
            this.tcMainControl.TabIndex = 1;
            this.tcMainControl.SelectedIndexChanged += new System.EventHandler(this.tcMainControl_SelectedIndexChanged);
            // 
            // tpCharacters
            // 
            this.tpCharacters.Controls.Add(this.pbRoleIcon);
            this.tpCharacters.Controls.Add(this.rbDemon);
            this.tpCharacters.Controls.Add(this.rbOutsider);
            this.tpCharacters.Controls.Add(this.rbMinion);
            this.tpCharacters.Controls.Add(this.rbTownsfolk);
            this.tpCharacters.Controls.Add(this.tbRoleAbility);
            this.tpCharacters.Controls.Add(this.tbRoleIconURL);
            this.tpCharacters.Controls.Add(this.tbRoleName);
            this.tpCharacters.Controls.Add(this.label4);
            this.tpCharacters.Controls.Add(this.label3);
            this.tpCharacters.Controls.Add(this.label2);
            this.tpCharacters.Controls.Add(this.label1);
            this.tpCharacters.Controls.Add(this.btnAdd);
            this.tpCharacters.Controls.Add(this.btnLoad);
            this.tpCharacters.Controls.Add(this.btnSafe);
            this.tpCharacters.Controls.Add(this.lbRoles);
            this.tpCharacters.Controls.Add(this.btnNewRole);
            this.tpCharacters.Location = new System.Drawing.Point(4, 22);
            this.tpCharacters.Name = "tpCharacters";
            this.tpCharacters.Padding = new System.Windows.Forms.Padding(3);
            this.tpCharacters.Size = new System.Drawing.Size(681, 373);
            this.tpCharacters.TabIndex = 0;
            this.tpCharacters.Text = "Characters";
            this.tpCharacters.UseVisualStyleBackColor = true;
            // 
            // pbRoleIcon
            // 
            this.pbRoleIcon.Location = new System.Drawing.Point(339, 216);
            this.pbRoleIcon.Name = "pbRoleIcon";
            this.pbRoleIcon.Size = new System.Drawing.Size(149, 149);
            this.pbRoleIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRoleIcon.TabIndex = 16;
            this.pbRoleIcon.TabStop = false;
            // 
            // rbDemon
            // 
            this.rbDemon.AutoSize = true;
            this.rbDemon.Location = new System.Drawing.Point(551, 90);
            this.rbDemon.Name = "rbDemon";
            this.rbDemon.Size = new System.Drawing.Size(59, 17);
            this.rbDemon.TabIndex = 15;
            this.rbDemon.TabStop = true;
            this.rbDemon.Text = "Demon";
            this.rbDemon.UseVisualStyleBackColor = true;
            // 
            // rbOutsider
            // 
            this.rbOutsider.AutoSize = true;
            this.rbOutsider.Location = new System.Drawing.Point(419, 88);
            this.rbOutsider.Name = "rbOutsider";
            this.rbOutsider.Size = new System.Drawing.Size(64, 17);
            this.rbOutsider.TabIndex = 14;
            this.rbOutsider.TabStop = true;
            this.rbOutsider.Text = "Outsider";
            this.rbOutsider.UseVisualStyleBackColor = true;
            // 
            // rbMinion
            // 
            this.rbMinion.AutoSize = true;
            this.rbMinion.Location = new System.Drawing.Point(489, 90);
            this.rbMinion.Name = "rbMinion";
            this.rbMinion.Size = new System.Drawing.Size(56, 17);
            this.rbMinion.TabIndex = 13;
            this.rbMinion.TabStop = true;
            this.rbMinion.Text = "Minion";
            this.rbMinion.UseVisualStyleBackColor = true;
            // 
            // rbTownsfolk
            // 
            this.rbTownsfolk.AutoSize = true;
            this.rbTownsfolk.Location = new System.Drawing.Point(339, 88);
            this.rbTownsfolk.Name = "rbTownsfolk";
            this.rbTownsfolk.Size = new System.Drawing.Size(74, 17);
            this.rbTownsfolk.TabIndex = 12;
            this.rbTownsfolk.TabStop = true;
            this.rbTownsfolk.Text = "Townsfolk";
            this.rbTownsfolk.UseVisualStyleBackColor = true;
            // 
            // tbRoleAbility
            // 
            this.tbRoleAbility.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRoleAbility.Location = new System.Drawing.Point(339, 113);
            this.tbRoleAbility.Multiline = true;
            this.tbRoleAbility.Name = "tbRoleAbility";
            this.tbRoleAbility.Size = new System.Drawing.Size(334, 97);
            this.tbRoleAbility.TabIndex = 11;
            // 
            // tbRoleIconURL
            // 
            this.tbRoleIconURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRoleIconURL.Location = new System.Drawing.Point(339, 61);
            this.tbRoleIconURL.Name = "tbRoleIconURL";
            this.tbRoleIconURL.Size = new System.Drawing.Size(334, 20);
            this.tbRoleIconURL.TabIndex = 10;
            this.tbRoleIconURL.TextChanged += new System.EventHandler(this.tbRoleIconURL_TextChanged);
            // 
            // tbRoleName
            // 
            this.tbRoleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRoleName.Location = new System.Drawing.Point(339, 35);
            this.tbRoleName.Name = "tbRoleName";
            this.tbRoleName.Size = new System.Drawing.Size(334, 20);
            this.tbRoleName.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ability";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Icon URL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(598, 342);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(188, 6);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSafe
            // 
            this.btnSafe.Location = new System.Drawing.Point(107, 6);
            this.btnSafe.Name = "btnSafe";
            this.btnSafe.Size = new System.Drawing.Size(75, 23);
            this.btnSafe.TabIndex = 2;
            this.btnSafe.Text = "Safe";
            this.btnSafe.UseVisualStyleBackColor = true;
            this.btnSafe.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbRoles
            // 
            this.lbRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbRoles.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRoles.FormattingEnabled = true;
            this.lbRoles.Location = new System.Drawing.Point(8, 35);
            this.lbRoles.Name = "lbRoles";
            this.lbRoles.Size = new System.Drawing.Size(255, 329);
            this.lbRoles.TabIndex = 1;
            this.lbRoles.SelectedIndexChanged += new System.EventHandler(this.lbRoles_SelectedIndexChanged);
            // 
            // tpScript
            // 
            this.tpScript.Controls.Add(this.btnConfigureNightOrder);
            this.tpScript.Controls.Add(this.lbJinxes);
            this.tpScript.Controls.Add(this.btnJinxes);
            this.tpScript.Controls.Add(this.btnLoadScript);
            this.tpScript.Controls.Add(this.btnSaveScript);
            this.tpScript.Controls.Add(this.tbScriptAuthor);
            this.tpScript.Controls.Add(this.label7);
            this.tpScript.Controls.Add(this.tbScriptName);
            this.tpScript.Controls.Add(this.label6);
            this.tpScript.Controls.Add(this.lblScriptCountDemons);
            this.tpScript.Controls.Add(this.lblScriptCountMinions);
            this.tpScript.Controls.Add(this.lblScriptCountOutsiders);
            this.tpScript.Controls.Add(this.lblScriptCountTownsfolk);
            this.tpScript.Controls.Add(this.rbFilterAll);
            this.tpScript.Controls.Add(this.rbFilterDemons);
            this.tpScript.Controls.Add(this.rbFilterMinions);
            this.tpScript.Controls.Add(this.rbFilterOutsider);
            this.tpScript.Controls.Add(this.rbFilterTownsfolk);
            this.tpScript.Controls.Add(this.clbScriptRoles);
            this.tpScript.Controls.Add(this.label5);
            this.tpScript.Location = new System.Drawing.Point(4, 22);
            this.tpScript.Name = "tpScript";
            this.tpScript.Padding = new System.Windows.Forms.Padding(3);
            this.tpScript.Size = new System.Drawing.Size(681, 373);
            this.tpScript.TabIndex = 1;
            this.tpScript.Text = "Script";
            this.tpScript.UseVisualStyleBackColor = true;
            // 
            // lbJinxes
            // 
            this.lbJinxes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbJinxes.FormattingEnabled = true;
            this.lbJinxes.Location = new System.Drawing.Point(269, 205);
            this.lbJinxes.Name = "lbJinxes";
            this.lbJinxes.Size = new System.Drawing.Size(239, 160);
            this.lbJinxes.TabIndex = 19;
            this.lbJinxes.DoubleClick += new System.EventHandler(this.lbJinxes_DoubleClick);
            this.lbJinxes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbJinxes_KeyDown);
            // 
            // btnJinxes
            // 
            this.btnJinxes.Location = new System.Drawing.Point(269, 175);
            this.btnJinxes.Name = "btnJinxes";
            this.btnJinxes.Size = new System.Drawing.Size(110, 23);
            this.btnJinxes.TabIndex = 18;
            this.btnJinxes.Text = "Configure new Jinx";
            this.btnJinxes.UseVisualStyleBackColor = true;
            this.btnJinxes.Click += new System.EventHandler(this.btnJinxes_Click);
            // 
            // btnLoadScript
            // 
            this.btnLoadScript.Location = new System.Drawing.Point(598, 89);
            this.btnLoadScript.Name = "btnLoadScript";
            this.btnLoadScript.Size = new System.Drawing.Size(75, 23);
            this.btnLoadScript.TabIndex = 17;
            this.btnLoadScript.Text = "Load";
            this.btnLoadScript.UseVisualStyleBackColor = true;
            this.btnLoadScript.Click += new System.EventHandler(this.btnLoadScript_Click);
            // 
            // btnSaveScript
            // 
            this.btnSaveScript.Location = new System.Drawing.Point(598, 60);
            this.btnSaveScript.Name = "btnSaveScript";
            this.btnSaveScript.Size = new System.Drawing.Size(75, 23);
            this.btnSaveScript.TabIndex = 16;
            this.btnSaveScript.Text = "Save";
            this.btnSaveScript.UseVisualStyleBackColor = true;
            this.btnSaveScript.Click += new System.EventHandler(this.btnSaveScript_Click);
            // 
            // tbScriptAuthor
            // 
            this.tbScriptAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbScriptAuthor.Location = new System.Drawing.Point(310, 34);
            this.tbScriptAuthor.Name = "tbScriptAuthor";
            this.tbScriptAuthor.Size = new System.Drawing.Size(363, 20);
            this.tbScriptAuthor.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(266, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Author";
            // 
            // tbScriptName
            // 
            this.tbScriptName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbScriptName.Location = new System.Drawing.Point(310, 8);
            this.tbScriptName.Name = "tbScriptName";
            this.tbScriptName.Size = new System.Drawing.Size(363, 20);
            this.tbScriptName.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Script";
            // 
            // lblScriptCountDemons
            // 
            this.lblScriptCountDemons.AutoSize = true;
            this.lblScriptCountDemons.Location = new System.Drawing.Point(349, 135);
            this.lblScriptCountDemons.Name = "lblScriptCountDemons";
            this.lblScriptCountDemons.Size = new System.Drawing.Size(35, 13);
            this.lblScriptCountDemons.TabIndex = 10;
            this.lblScriptCountDemons.Text = "label6";
            // 
            // lblScriptCountMinions
            // 
            this.lblScriptCountMinions.AutoSize = true;
            this.lblScriptCountMinions.Location = new System.Drawing.Point(349, 112);
            this.lblScriptCountMinions.Name = "lblScriptCountMinions";
            this.lblScriptCountMinions.Size = new System.Drawing.Size(35, 13);
            this.lblScriptCountMinions.TabIndex = 9;
            this.lblScriptCountMinions.Text = "label6";
            // 
            // lblScriptCountOutsiders
            // 
            this.lblScriptCountOutsiders.AutoSize = true;
            this.lblScriptCountOutsiders.Location = new System.Drawing.Point(349, 89);
            this.lblScriptCountOutsiders.Name = "lblScriptCountOutsiders";
            this.lblScriptCountOutsiders.Size = new System.Drawing.Size(35, 13);
            this.lblScriptCountOutsiders.TabIndex = 8;
            this.lblScriptCountOutsiders.Text = "label6";
            // 
            // lblScriptCountTownsfolk
            // 
            this.lblScriptCountTownsfolk.AutoSize = true;
            this.lblScriptCountTownsfolk.Location = new System.Drawing.Point(349, 64);
            this.lblScriptCountTownsfolk.Name = "lblScriptCountTownsfolk";
            this.lblScriptCountTownsfolk.Size = new System.Drawing.Size(35, 13);
            this.lblScriptCountTownsfolk.TabIndex = 7;
            this.lblScriptCountTownsfolk.Text = "label6";
            // 
            // rbFilterAll
            // 
            this.rbFilterAll.AutoSize = true;
            this.rbFilterAll.Location = new System.Drawing.Point(269, 152);
            this.rbFilterAll.Name = "rbFilterAll";
            this.rbFilterAll.Size = new System.Drawing.Size(36, 17);
            this.rbFilterAll.TabIndex = 6;
            this.rbFilterAll.TabStop = true;
            this.rbFilterAll.Text = "All";
            this.rbFilterAll.UseVisualStyleBackColor = true;
            this.rbFilterAll.CheckedChanged += new System.EventHandler(this.rbFilter_CheckedChanged);
            // 
            // rbFilterDemons
            // 
            this.rbFilterDemons.AutoSize = true;
            this.rbFilterDemons.Location = new System.Drawing.Point(269, 129);
            this.rbFilterDemons.Name = "rbFilterDemons";
            this.rbFilterDemons.Size = new System.Drawing.Size(64, 17);
            this.rbFilterDemons.TabIndex = 5;
            this.rbFilterDemons.TabStop = true;
            this.rbFilterDemons.Text = "Demons";
            this.rbFilterDemons.UseVisualStyleBackColor = true;
            this.rbFilterDemons.CheckedChanged += new System.EventHandler(this.rbFilter_CheckedChanged);
            // 
            // rbFilterMinions
            // 
            this.rbFilterMinions.AutoSize = true;
            this.rbFilterMinions.Location = new System.Drawing.Point(269, 106);
            this.rbFilterMinions.Name = "rbFilterMinions";
            this.rbFilterMinions.Size = new System.Drawing.Size(61, 17);
            this.rbFilterMinions.TabIndex = 4;
            this.rbFilterMinions.TabStop = true;
            this.rbFilterMinions.Text = "Minions";
            this.rbFilterMinions.UseVisualStyleBackColor = true;
            this.rbFilterMinions.CheckedChanged += new System.EventHandler(this.rbFilter_CheckedChanged);
            // 
            // rbFilterOutsider
            // 
            this.rbFilterOutsider.AutoSize = true;
            this.rbFilterOutsider.Location = new System.Drawing.Point(269, 83);
            this.rbFilterOutsider.Name = "rbFilterOutsider";
            this.rbFilterOutsider.Size = new System.Drawing.Size(69, 17);
            this.rbFilterOutsider.TabIndex = 3;
            this.rbFilterOutsider.TabStop = true;
            this.rbFilterOutsider.Text = "Outsiders";
            this.rbFilterOutsider.UseVisualStyleBackColor = true;
            this.rbFilterOutsider.CheckedChanged += new System.EventHandler(this.rbFilter_CheckedChanged);
            // 
            // rbFilterTownsfolk
            // 
            this.rbFilterTownsfolk.AutoSize = true;
            this.rbFilterTownsfolk.Location = new System.Drawing.Point(269, 60);
            this.rbFilterTownsfolk.Name = "rbFilterTownsfolk";
            this.rbFilterTownsfolk.Size = new System.Drawing.Size(74, 17);
            this.rbFilterTownsfolk.TabIndex = 2;
            this.rbFilterTownsfolk.TabStop = true;
            this.rbFilterTownsfolk.Text = "Townsfolk";
            this.rbFilterTownsfolk.UseVisualStyleBackColor = true;
            this.rbFilterTownsfolk.CheckedChanged += new System.EventHandler(this.rbFilter_CheckedChanged);
            // 
            // clbScriptRoles
            // 
            this.clbScriptRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.clbScriptRoles.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbScriptRoles.FormattingEnabled = true;
            this.clbScriptRoles.Location = new System.Drawing.Point(8, 31);
            this.clbScriptRoles.Name = "clbScriptRoles";
            this.clbScriptRoles.Size = new System.Drawing.Size(255, 334);
            this.clbScriptRoles.TabIndex = 1;
            this.clbScriptRoles.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbScriptRoles_ItemCheck);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Select Roles";
            // 
            // tpPDF
            // 
            this.tpPDF.Controls.Add(this.label9);
            this.tpPDF.Controls.Add(this.cbxPrintCharacterBorder);
            this.tpPDF.Controls.Add(this.label8);
            this.tpPDF.Controls.Add(this.rbUse2Columns);
            this.tpPDF.Controls.Add(this.rbUse1Column);
            this.tpPDF.Controls.Add(this.tbCustomBackgroundPath);
            this.tpPDF.Controls.Add(this.btnGeneratePDF);
            this.tpPDF.Location = new System.Drawing.Point(4, 22);
            this.tpPDF.Name = "tpPDF";
            this.tpPDF.Padding = new System.Windows.Forms.Padding(3);
            this.tpPDF.Size = new System.Drawing.Size(681, 373);
            this.tpPDF.TabIndex = 2;
            this.tpPDF.Text = "PDF";
            this.tpPDF.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Print Character Border";
            // 
            // cbxPrintCharacterBorder
            // 
            this.cbxPrintCharacterBorder.AutoSize = true;
            this.cbxPrintCharacterBorder.Location = new System.Drawing.Point(141, 58);
            this.cbxPrintCharacterBorder.Name = "cbxPrintCharacterBorder";
            this.cbxPrintCharacterBorder.Size = new System.Drawing.Size(15, 14);
            this.cbxPrintCharacterBorder.TabIndex = 5;
            this.cbxPrintCharacterBorder.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 26);
            this.label8.TabIndex = 4;
            this.label8.Text = "Custom Background\r\nImage Path";
            // 
            // rbUse2Columns
            // 
            this.rbUse2Columns.AutoSize = true;
            this.rbUse2Columns.Location = new System.Drawing.Point(238, 35);
            this.rbUse2Columns.Name = "rbUse2Columns";
            this.rbUse2Columns.Size = new System.Drawing.Size(96, 17);
            this.rbUse2Columns.TabIndex = 3;
            this.rbUse2Columns.TabStop = true;
            this.rbUse2Columns.Text = "Use 2 Columns";
            this.rbUse2Columns.UseVisualStyleBackColor = true;
            // 
            // rbUse1Column
            // 
            this.rbUse1Column.AutoSize = true;
            this.rbUse1Column.Location = new System.Drawing.Point(141, 35);
            this.rbUse1Column.Name = "rbUse1Column";
            this.rbUse1Column.Size = new System.Drawing.Size(91, 17);
            this.rbUse1Column.TabIndex = 2;
            this.rbUse1Column.TabStop = true;
            this.rbUse1Column.Text = "Use 1 Column";
            this.rbUse1Column.UseVisualStyleBackColor = true;
            // 
            // tbCustomBackgroundPath
            // 
            this.tbCustomBackgroundPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCustomBackgroundPath.Location = new System.Drawing.Point(141, 9);
            this.tbCustomBackgroundPath.Name = "tbCustomBackgroundPath";
            this.tbCustomBackgroundPath.Size = new System.Drawing.Size(532, 20);
            this.tbCustomBackgroundPath.TabIndex = 1;
            // 
            // btnGeneratePDF
            // 
            this.btnGeneratePDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneratePDF.Location = new System.Drawing.Point(598, 326);
            this.btnGeneratePDF.Name = "btnGeneratePDF";
            this.btnGeneratePDF.Size = new System.Drawing.Size(75, 39);
            this.btnGeneratePDF.TabIndex = 0;
            this.btnGeneratePDF.Text = "Generate PDF";
            this.btnGeneratePDF.UseVisualStyleBackColor = true;
            this.btnGeneratePDF.Click += new System.EventHandler(this.btnGeneratePDF_Click);
            // 
            // btnConfigureNightOrder
            // 
            this.btnConfigureNightOrder.Location = new System.Drawing.Point(385, 175);
            this.btnConfigureNightOrder.Name = "btnConfigureNightOrder";
            this.btnConfigureNightOrder.Size = new System.Drawing.Size(123, 23);
            this.btnConfigureNightOrder.TabIndex = 20;
            this.btnConfigureNightOrder.Text = "Configure Night Order";
            this.btnConfigureNightOrder.UseVisualStyleBackColor = true;
            this.btnConfigureNightOrder.Click += new System.EventHandler(this.btnConfigureNightOrder_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 399);
            this.Controls.Add(this.tcMainControl);
            this.Name = "Main";
            this.Text = "Blood on the Clocktower - Custom Script Tool";
            this.tcMainControl.ResumeLayout(false);
            this.tpCharacters.ResumeLayout(false);
            this.tpCharacters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRoleIcon)).EndInit();
            this.tpScript.ResumeLayout(false);
            this.tpScript.PerformLayout();
            this.tpPDF.ResumeLayout(false);
            this.tpPDF.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewRole;
        private System.Windows.Forms.TabControl tcMainControl;
        private System.Windows.Forms.TabPage tpCharacters;
        private System.Windows.Forms.ListBox lbRoles;
        private System.Windows.Forms.TabPage tpScript;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSafe;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RadioButton rbDemon;
        private System.Windows.Forms.RadioButton rbOutsider;
        private System.Windows.Forms.RadioButton rbMinion;
        private System.Windows.Forms.RadioButton rbTownsfolk;
        private System.Windows.Forms.TextBox tbRoleAbility;
        private System.Windows.Forms.TextBox tbRoleIconURL;
        private System.Windows.Forms.TextBox tbRoleName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbRoleIcon;
        private System.Windows.Forms.TabPage tpPDF;
        private System.Windows.Forms.CheckedListBox clbScriptRoles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbFilterDemons;
        private System.Windows.Forms.RadioButton rbFilterMinions;
        private System.Windows.Forms.RadioButton rbFilterOutsider;
        private System.Windows.Forms.RadioButton rbFilterTownsfolk;
        private System.Windows.Forms.RadioButton rbFilterAll;
        private System.Windows.Forms.Label lblScriptCountTownsfolk;
        private System.Windows.Forms.Label lblScriptCountDemons;
        private System.Windows.Forms.Label lblScriptCountMinions;
        private System.Windows.Forms.Label lblScriptCountOutsiders;
        private System.Windows.Forms.TextBox tbScriptAuthor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbScriptName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSaveScript;
        private System.Windows.Forms.Button btnLoadScript;
        private System.Windows.Forms.Button btnJinxes;
        private System.Windows.Forms.ListBox lbJinxes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbUse2Columns;
        private System.Windows.Forms.RadioButton rbUse1Column;
        private System.Windows.Forms.TextBox tbCustomBackgroundPath;
        private System.Windows.Forms.Button btnGeneratePDF;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbxPrintCharacterBorder;
        private System.Windows.Forms.Button btnConfigureNightOrder;
    }
}

