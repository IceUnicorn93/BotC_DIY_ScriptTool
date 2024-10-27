using BotC_Custom_ScriptTool.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BotC_Custom_ScriptTool.Forms
{
    public partial class frmNightOrder : Form
    {
        public NightOrder Order = new NightOrder();

        public frmNightOrder(NightOrder no)
        {
            InitializeComponent();

            Order = no;

            foreach (var FirstNight in Order.FirstNight)
            {
                var btn = new Button();
                btn.Text = FirstNight;
                btn.Size = new Size(flowLayoutPanel1.Width - 20, btn.Size.Height);
                btn.Click += (s, ea) =>
                {
                    flowLayoutPanel1.Controls.Remove(btn);
                    Order.FirstNight.Remove(btn.Text);
                };
                flowLayoutPanel1.Controls.Add(btn);
            }

            foreach (var OtherNight in Order.OtherNights)
            {
                var btn = new Button();
                btn.Text = OtherNight;
                btn.Size = new Size(flowLayoutPanel2.Width - 20, btn.Size.Height);
                btn.Click += (s, ea) =>
                {
                    flowLayoutPanel2.Controls.Remove(btn);
                    Order.OtherNights.Remove(btn.Text);
                };
                flowLayoutPanel2.Controls.Add(btn);
            }
        }

        private void btnAddToFirstNight_Click(object sender, EventArgs e)
        {
            if (tbAction.Text == "") return;

            var btn = new Button();
            btn.Text = tbAction.Text;
            btn.Size = new Size(flowLayoutPanel1.Width - 20, btn.Size.Height);
            btn.Click += (s, ea) =>
            {
                flowLayoutPanel1.Controls.Remove(btn);
                Order.FirstNight.Remove(btn.Text);
            };
            flowLayoutPanel1.Controls.Add(btn);
            Order.FirstNight.Add(btn.Text);
        }

        private void btnAddOtherNight_Click(object sender, EventArgs e)
        {
            if (tbAction.Text == "") return;

            var btn = new Button();
            btn.Text = tbAction.Text;
            btn.Size = new Size(flowLayoutPanel2.Width - 20, btn.Size.Height);
            btn.Click += (s, ea) =>
            {
                flowLayoutPanel2.Controls.Remove(btn);
                Order.OtherNights.Remove(btn.Text);
            };
            flowLayoutPanel2.Controls.Add(btn);
            Order.OtherNights.Add(btn.Text);
        }
    }
}
