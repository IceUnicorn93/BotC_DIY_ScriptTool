using BotC_Custom_ScriptTool.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BotC_Custom_ScriptTool.Forms
{
    public partial class frmNightOrder : Form
    {
        public NightOrder Order = new NightOrder();

        public frmNightOrder(NightOrder no, List<string> roles)
        {
            InitializeComponent();

            Order = no;

            foreach (var FirstNight in Order.FirstNight)
            {
                var btn = new Button();
                btn.Text = $"{FirstNight.Rolename} - {FirstNight.NightInformation}";
                btn.Size = new Size(flowLayoutPanel1.Width - 20, btn.Size.Height);
                btn.Tag = FirstNight;
                btn.Click += (s, ea) =>
                {
                    flowLayoutPanel1.Controls.Remove(btn);
                    Order.FirstNight.Remove(FirstNight);
                };
                flowLayoutPanel1.Controls.Add(btn);
            }

            foreach (var OtherNight in Order.OtherNights)
            {
                var btn = new Button();
                btn.Text = $"{OtherNight.Rolename} - {OtherNight.NightInformation}";
                btn.Size = new Size(flowLayoutPanel2.Width - 20, btn.Size.Height);
                btn.Click += (s, ea) =>
                {
                    flowLayoutPanel2.Controls.Remove(btn);
                    Order.OtherNights.Remove(OtherNight);
                };
                flowLayoutPanel2.Controls.Add(btn);
            }

            cbRoles.Items.Clear();
            cbRoles.Items.Add("General Info");
            foreach (var role in roles)
            {
                cbRoles.Items.Add(role);
            }
        }

        private void btnAddToFirstNight_Click(object sender, EventArgs e)
        {
            if (tbAction.Text == "") return;

            var btn = new Button();
            btn.Text = $"{cbRoles.Text} - {tbAction.Text}";
            btn.Size = new Size(flowLayoutPanel1.Width - 20, btn.Size.Height);
            btn.Click += (s, ea) =>
            {
                flowLayoutPanel1.Controls.Remove(btn);
                NightInfo info = new NightInfo { NightInformation = tbAction.Text, Rolename = cbRoles.Text };
                Order.FirstNight.Remove(info);
            };
            flowLayoutPanel1.Controls.Add(btn);
            Order.FirstNight.Add(new NightInfo { NightInformation = tbAction.Text, Rolename = cbRoles.Text});
        }

        private void btnAddOtherNight_Click(object sender, EventArgs e)
        {
            if (tbAction.Text == "") return;

            var btn = new Button();
            btn.Text = $"{cbRoles.Text} - {tbAction.Text}";
            btn.Size = new Size(flowLayoutPanel2.Width - 20, btn.Size.Height);
            btn.Click += (s, ea) =>
            {
                flowLayoutPanel2.Controls.Remove(btn);
                NightInfo info = new NightInfo { NightInformation = tbAction.Text, Rolename = cbRoles.Text };
                Order.OtherNights.Remove(info);
            };
            flowLayoutPanel2.Controls.Add(btn);
            Order.OtherNights.Add(new NightInfo { NightInformation = tbAction.Text, Rolename = cbRoles.Text });
        }
    }
}
