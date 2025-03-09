using BotC_Custom_ScriptTool.Classes;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BotC_Custom_ScriptTool.Forms
{
    public partial class frmAutomaticNightOrderConfig: Form
    {
        public AutomaticNightOrderConfig Config { get; private set; }
        public frmAutomaticNightOrderConfig(AutomaticNightOrderConfig config)
        {
            InitializeComponent();

            Config = new AutomaticNightOrderConfig();

            tbFirstNight.Text = string.Join(Environment.NewLine, config.FirstNight);
            tbOtherNights.Text = string.Join(Environment.NewLine, config.OtherNights);


            Config = config;
        }

        private void tbTextChanged(object sender, EventArgs e)
        {
            Config.FirstNight = tbFirstNight.Lines.ToList();
            Config.OtherNights = tbOtherNights.Lines.ToList();
        }
    }
}
