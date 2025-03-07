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

        public frmNightOrder(NightOrder no, List<CharacterRole> rolesFirstNight, List<CharacterRole> rolesOtherNights)
        {
            InitializeComponent();

            Order = no;

            foreach (var FirstNight in Order.FirstNight)
            {
                var btn = new Button();
                var role = (CharacterRole)cbFirstNight.SelectedItem;

                btn.Text = $"{cbFirstNight.Text}";
                btn.Size = new Size(flowLayoutPanel1.Width - 20, btn.Size.Height);
                btn.Click += (s, ea) =>
                {
                    var senderButton = (Button)s;
                    var senderRole = (CharacterRole)senderButton.Tag;
                    flowLayoutPanel1.Controls.Remove(senderButton);
                    NightInfo info = new NightInfo { NightInformation = senderRole.FirstNight, Rolename = senderRole.RoleName };
                    Order.FirstNight.Remove(info);
                };
                btn.Tag = role;
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

            cbFirstNight.Items.Clear();
            cbOtherNights.Items.Clear();
            foreach (var role in rolesFirstNight)
                cbFirstNight.Items.Add(role);
            foreach (var role in rolesOtherNights)
                cbOtherNights.Items.Add(role);
        }

        private void btnAddToFirstNight_Click(object sender, EventArgs e)
        {
            if (cbFirstNight.Text == "") return;

            var btn = new Button();
            var role = (CharacterRole)cbFirstNight.SelectedItem;

            btn.Text = role.RoleName;
            btn.Size = new Size(flowLayoutPanel1.Width - 20, btn.Size.Height);
            btn.Click += (s, ea) =>
            {
                var senderButton = (Button)s;
                var senderRole = (CharacterRole)senderButton.Tag;
                flowLayoutPanel1.Controls.Remove(senderButton);
                NightInfo info = new NightInfo { NightInformation = senderRole.FirstNight, Rolename = senderRole.RoleName };
                Order.FirstNight.Remove(info);
            };
            btn.Tag = role;
            flowLayoutPanel1.Controls.Add(btn);
            Order.FirstNight.Add(new NightInfo { NightInformation = role.FirstNight, Rolename = role.RoleName});
        }

        private void btnAddOtherNight_Click(object sender, EventArgs e)
        {
            if (cbOtherNights.Text == "") return;

            var btn = new Button();
            var role = (CharacterRole)cbOtherNights.SelectedItem;

            btn.Text = role.RoleName;
            btn.Size = new Size(flowLayoutPanel2.Width - 20, btn.Size.Height);
            btn.Click += (s, ea) =>
            {
                var senderButton = (Button)s;
                var senderRole = (CharacterRole)senderButton.Tag;
                flowLayoutPanel2.Controls.Remove(senderButton);
                NightInfo info = new NightInfo { NightInformation = senderRole.FirstNight, Rolename = senderRole.RoleName };
                Order.OtherNights.Remove(info);
            };
            btn.Tag = role;
            flowLayoutPanel2.Controls.Add(btn);
            Order.OtherNights.Add(new NightInfo { NightInformation = role.FirstNight, Rolename = role.RoleName });
        }
    }
}
