using BotC_Custom_ScriptTool.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

            for (int i = 0; i < Order.FirstNight.Count; i++)
            {
                NightInfo FirstNight = Order.FirstNight[i];
                var btn = new Button();
                var role = rolesFirstNight.SingleOrDefault(rfn => FirstNight.Rolename == rfn.RoleName);

                if (role == null)
                {
                    Order.FirstNight.RemoveAt(i);
                    continue;
                }

                btn.Text = $"{role.RoleName}";
                btn.Size = new Size(flowLayoutPanel1.Width - 20, btn.Size.Height);
                btn.Name = $"FN_{i}";
                btn.Click += (s, ea) =>
                {
                    var senderButton = (Button)s;
                    var pos = flowLayoutPanel1.Controls.IndexOf(senderButton);
                    flowLayoutPanel1.Controls.Remove(senderButton);
                    Order.FirstNight.RemoveAt(pos);
                };
                btn.Tag = role;
                flowLayoutPanel1.Controls.Add(btn);
            }

            for (int i = 0; i < Order.OtherNights.Count; i++)
            {
                NightInfo OtherNight = Order.OtherNights[i];
                var btn = new Button();
                var role = rolesOtherNights.SingleOrDefault(rfn => OtherNight.Rolename == rfn.RoleName);

                if (role == null)
                {
                    Order.OtherNights.RemoveAt(i);
                    continue;
                }

                btn.Text = $"{role.RoleName}";
                btn.Size = new Size(flowLayoutPanel1.Width - 20, btn.Size.Height);
                btn.Name = $"ON_{i}";
                btn.Click += (s, ea) =>
                {
                    var senderButton = (Button)s;
                    var pos = flowLayoutPanel2.Controls.IndexOf(senderButton);
                    flowLayoutPanel2.Controls.Remove(senderButton);
                    Order.OtherNights.RemoveAt(pos);
                };
                btn.Tag = role;
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
                NightInfo info = new NightInfo { NightInformation = senderRole.OtherNights, Rolename = senderRole.RoleName };
                Order.OtherNights.Remove(info);
            };
            btn.Tag = role;
            flowLayoutPanel2.Controls.Add(btn);
            Order.OtherNights.Add(new NightInfo { NightInformation = role.OtherNights, Rolename = role.RoleName });
        }
    }
}
