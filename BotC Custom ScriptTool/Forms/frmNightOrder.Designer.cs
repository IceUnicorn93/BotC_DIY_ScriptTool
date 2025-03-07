namespace BotC_Custom_ScriptTool.Forms
{
    partial class frmNightOrder
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddToFirstNight = new System.Windows.Forms.Button();
            this.btnAddOtherNight = new System.Windows.Forms.Button();
            this.cbFirstNight = new System.Windows.Forms.ComboBox();
            this.cbOtherNights = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 112);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(385, 326);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(403, 112);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(385, 326);
            this.flowLayoutPanel2.TabIndex = 1;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Night";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Other Nights";
            // 
            // btnAddToFirstNight
            // 
            this.btnAddToFirstNight.Location = new System.Drawing.Point(273, 12);
            this.btnAddToFirstNight.Name = "btnAddToFirstNight";
            this.btnAddToFirstNight.Size = new System.Drawing.Size(124, 23);
            this.btnAddToFirstNight.TabIndex = 6;
            this.btnAddToFirstNight.Text = "Add to First Night";
            this.btnAddToFirstNight.UseVisualStyleBackColor = true;
            this.btnAddToFirstNight.Click += new System.EventHandler(this.btnAddToFirstNight_Click);
            // 
            // btnAddOtherNight
            // 
            this.btnAddOtherNight.Location = new System.Drawing.Point(664, 12);
            this.btnAddOtherNight.Name = "btnAddOtherNight";
            this.btnAddOtherNight.Size = new System.Drawing.Size(124, 23);
            this.btnAddOtherNight.TabIndex = 7;
            this.btnAddOtherNight.Text = "Add to Other Nights";
            this.btnAddOtherNight.UseVisualStyleBackColor = true;
            this.btnAddOtherNight.Click += new System.EventHandler(this.btnAddOtherNight_Click);
            // 
            // cbFirstNight
            // 
            this.cbFirstNight.FormattingEnabled = true;
            this.cbFirstNight.Location = new System.Drawing.Point(12, 14);
            this.cbFirstNight.Name = "cbFirstNight";
            this.cbFirstNight.Size = new System.Drawing.Size(151, 21);
            this.cbFirstNight.TabIndex = 8;
            // 
            // cbOtherNights
            // 
            this.cbOtherNights.FormattingEnabled = true;
            this.cbOtherNights.Location = new System.Drawing.Point(403, 14);
            this.cbOtherNights.Name = "cbOtherNights";
            this.cbOtherNights.Size = new System.Drawing.Size(151, 21);
            this.cbOtherNights.TabIndex = 9;
            // 
            // frmNightOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbOtherNights);
            this.Controls.Add(this.cbFirstNight);
            this.Controls.Add(this.btnAddOtherNight);
            this.Controls.Add(this.btnAddToFirstNight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmNightOrder";
            this.Text = "Configure Night Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddToFirstNight;
        private System.Windows.Forms.Button btnAddOtherNight;
        private System.Windows.Forms.ComboBox cbFirstNight;
        private System.Windows.Forms.ComboBox cbOtherNights;
    }
}