namespace BotC_Custom_ScriptTool.Forms
{
    partial class frmAutomaticNightOrderConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFirstNight = new System.Windows.Forms.TextBox();
            this.tbOtherNights = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Night";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Other Nights";
            // 
            // tbFirstNight
            // 
            this.tbFirstNight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbFirstNight.Location = new System.Drawing.Point(12, 25);
            this.tbFirstNight.Multiline = true;
            this.tbFirstNight.Name = "tbFirstNight";
            this.tbFirstNight.Size = new System.Drawing.Size(385, 413);
            this.tbFirstNight.TabIndex = 2;
            this.tbFirstNight.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // tbOtherNights
            // 
            this.tbOtherNights.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOtherNights.Location = new System.Drawing.Point(403, 25);
            this.tbOtherNights.Multiline = true;
            this.tbOtherNights.Name = "tbOtherNights";
            this.tbOtherNights.Size = new System.Drawing.Size(385, 413);
            this.tbOtherNights.TabIndex = 3;
            this.tbOtherNights.TextChanged += new System.EventHandler(this.tbTextChanged);
            // 
            // frmAutomaticNightOrderConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbOtherNights);
            this.Controls.Add(this.tbFirstNight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmAutomaticNightOrderConfig";
            this.Text = "frmAutomaticNightOrderConfig";
            this.TextChanged += new System.EventHandler(this.tbTextChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFirstNight;
        private System.Windows.Forms.TextBox tbOtherNights;
    }
}