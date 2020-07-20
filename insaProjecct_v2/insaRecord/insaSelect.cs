using _Database;
using Common;
using insaRecord;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace insaProjecct_v2
{
    public partial class insaSelect : Form
    {
        public insaSelect()
        {
            InitializeComponent();
        }
        public void LoadFormList()
        {
            tabControl1.TabPages.Clear();
            _getMenu getMenu = new _getMenu();
            Form_Control control = new Form_Control();
            List<string> Menus = new List<string>();
            getMenu.child_menu(Menus, "인사기록관리");
            int count = -1;
            foreach (string Menu in Menus)
            {
                TabPage myTabPage = new TabPage(Menu);
                foreach (Form f in erpMain.Send_FormList)
                {
                    if (!f.Name.ToString().Contains("insaSelect"))
                    {
                        if (Menu.Equals(f.Tag))
                        {
                            f.TopLevel = false;
                            myTabPage.Controls.Add(f);
                            f.Show();
                            Type type = f.GetType();
                            control.get_control(f, true);
                            control.control_enabled(false, true);
                            if (f == (f as insaBasic))
                            {
                                MethodInfo method = type.GetMethod("Control_Input_Date");
                                method.Invoke(f, null);
                            }
                            else if (f == (f as Iinsa_Interface))
                            {
                                MethodInfo method = type.GetMethod("ShowData");
                                method.Invoke(f, null);
                            }
                        }
                    }
                }
                try
                {
                    count++;
                    if (count == 7)
                    {
                        break;
                    }
                    tabControl1.TabPages.Add(myTabPage);
                }
                catch { }
            }
        }
        private void insaSelect_Load(object sender, EventArgs e)
        {
            if (insaSide.select_empno != null)
            {
                LoadFormList();
            }
        }
    }
}