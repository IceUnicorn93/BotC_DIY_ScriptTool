using BotC_Custom_ScriptTool.Classes;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BotC_Custom_ScriptTool.UserControls
{
    public partial class ucJinx : UserControl
    {
        Jinx jinx;

        public ucJinx(Jinx bindingJinx, List<string> roles)
        {
            InitializeComponent();

            jinx = bindingJinx;

            cbxRoleA.Items.AddRange(roles.ToArray());
            cbxRoleB.Items.AddRange(roles.ToArray());

            tbJinxAbility.Text = jinx.JinxText;
            cbxRoleA.SelectedItem = jinx.RoleA;
            cbxRoleB.SelectedItem = jinx.RoleB;

            cbxRoleA.SelectedIndexChanged += (s, e) =>
            {
                jinx.RoleA = cbxRoleA.SelectedItem.ToString();
            };
            cbxRoleB.SelectedIndexChanged += (s, e) =>
            {
                jinx.RoleB = cbxRoleB.SelectedItem.ToString();
            };
            tbJinxAbility.TextChanged += (s, e) =>
            {
                jinx.JinxText = tbJinxAbility.Text;
            };
        }
    }
}
