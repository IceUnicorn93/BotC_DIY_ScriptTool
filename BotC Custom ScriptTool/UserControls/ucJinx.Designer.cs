namespace BotC_Custom_ScriptTool.UserControls
{
    partial class ucJinx
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbxRoleA = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxRoleB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbJinxAbility = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Role A";
            // 
            // cbxRoleA
            // 
            this.cbxRoleA.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRoleA.FormattingEnabled = true;
            this.cbxRoleA.Location = new System.Drawing.Point(3, 24);
            this.cbxRoleA.Name = "cbxRoleA";
            this.cbxRoleA.Size = new System.Drawing.Size(190, 21);
            this.cbxRoleA.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Role B";
            // 
            // cbxRoleB
            // 
            this.cbxRoleB.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRoleB.FormattingEnabled = true;
            this.cbxRoleB.Location = new System.Drawing.Point(3, 72);
            this.cbxRoleB.Name = "cbxRoleB";
            this.cbxRoleB.Size = new System.Drawing.Size(190, 21);
            this.cbxRoleB.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Jinx";
            // 
            // tbJinxAbility
            // 
            this.tbJinxAbility.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbJinxAbility.Location = new System.Drawing.Point(199, 24);
            this.tbJinxAbility.Multiline = true;
            this.tbJinxAbility.Name = "tbJinxAbility";
            this.tbJinxAbility.Size = new System.Drawing.Size(239, 69);
            this.tbJinxAbility.TabIndex = 12;
            // 
            // ucJinx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbJinxAbility);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxRoleB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxRoleA);
            this.Controls.Add(this.label1);
            this.Name = "ucJinx";
            this.Size = new System.Drawing.Size(441, 96);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxRoleA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxRoleB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbJinxAbility;
    }
}
