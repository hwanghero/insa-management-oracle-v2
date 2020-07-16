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

            tabControl1.TabPages.Clear();
            _getMenu getMenu = new _getMenu();
            Form_Control control = new Form_Control();
            List<string> Menus = new List<string>();
            getMenu.child_menu(Menus, "인사기록관리");

            //foreach (Form f in erpMain.FormList)
            //{
            //    // 메뉴마다 한번씩 다 불러오는듯
            //    Console.WriteLine("LoadFormList: " + f.Name);
            //}
            erpMain erpMain = new erpMain();
            foreach (string Menu in Menus)
            {
                TabPage myTabPage = new TabPage(Menu);

                // Menu 1 - f1,f2,f3..
                // Menu 2 - f1,f2,f3..
                foreach (Form f in erpMain.FormList)
                {
                    // 메뉴마다 한번씩 다 불러오는듯
                    Console.WriteLine("LoadFormList: " + f.Name);

                    if (Menu.Equals(f.Tag))
                    {
                        // 폼을 2개가 동시에 안켜지니까 그런거같은데?
                        // 왜냐면 같은객체니까.
                        f.TopLevel = false;
                        myTabPage.Controls.Add(f);
                        // 삭제된 개체에 액세스할 수 없습니다.
                        // show를 해야해 근데 없어 그니까 삭제된 객체다.
                        // 가설: 폼을 불러오면 안된다.. 데이터그리드뷰에 뜨게한다.

                        f.Show();
                        MessageBox.Show("머야");

                        //Type type = b.GetType();
                        //control.get_control(b, true);
                        //control.control_enabled(false, true);

                        //if (b == (b as insaBasic))
                        //{
                        //    MethodInfo method = type.GetMethod("Control_Input_Date");
                        //    method.Invoke(b, null);
                        //}
                        //else if (b == (b as Iinsa_Interface))
                        //{
                        //    MethodInfo method = type.GetMethod("ShowData");
                        //    method.Invoke(b, null);
                        //}
                    }
                }
                tabControl1.TabPages.Add(myTabPage);
            }
            // 통합은 지워주자공
            tabControl1.TabPages.Remove(tabControl1.TabPages[7]);

        }

        private void insaSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}