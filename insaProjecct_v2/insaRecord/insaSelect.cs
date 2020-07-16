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
            if (insaSide.select_empno != null)
            {
                LoadFormList();
            }
        }

        // 렉이 너무 먹는다 ㅡㅡ;
        public void LoadFormList()
        {
            if (tabControl1.TabCount > 0)
            {
                tabControl1.TabPages.Clear();
            }
            _getMenu getMenu = new _getMenu();
            Form_Control control = new Form_Control();
            List<string> Menus = new List<string>();
            getMenu.child_menu(Menus, "인사기록관리");
            foreach (string a in Menus)
            {
                // 폼을 가져와야한다
                // 그리고 띄워주면될듯?
                TabPage myTabPage = new TabPage(a);
                foreach (Form b in erpMain.FormList)
                {
                    if (a.Equals(b.Tag))
                    {
                        b.TopLevel = false;
                        myTabPage.Controls.Add(b);
                        b.Show();
                        Type type = b.GetType();
                        // 폼 컨트롤
                        control.get_control(b, true);
                        control.control_enabled(false, true);

                        if (b == (b as insaBasic))
                        {
                            MethodInfo method = type.GetMethod("Control_Input_Date");
                            method.Invoke(b, null);
                        }
                        else if (b == (b as Iinsa_Interface))
                        {
                            MethodInfo method = type.GetMethod("ShowData");
                            method.Invoke(b, null);
                        }
                    }
                }
                tabControl1.TabPages.Add(myTabPage);
            }
            // 통합은 지워주자공
            tabControl1.TabPages.Remove(tabControl1.TabPages[7]);
        }
    }
}
