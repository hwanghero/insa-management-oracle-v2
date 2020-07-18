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

        // 렉이 너무 먹는다 ㅡㅡ;
        // 최적화가 안됨. 이놈 생성하는순간
        // 다른폼가면 계속 불러오기때문에 터짐
        public void LoadFormList()
        {
            tabControl1.TabPages.Clear();
            _getMenu getMenu = new _getMenu();
            Form_Control control = new Form_Control();
            List<string> Menus = new List<string>();
            getMenu.child_menu(Menus, "인사기록관리");

            // 왜 에러가 나는지
            // -> 리플랙션을 사용해서 모든 폼을 불러오는데
            // 이게 생성자가 또 실행이 되는데
            // 이 select가 또 실행되니까 순환이 돼서 그런거같음
            int count = -1;
            foreach (string Menu in Menus)
            {
                TabPage myTabPage = new TabPage(Menu);

                // Menu 1 - f1,f2,f3..
                // Menu 2 - f1,f2,f3..
                foreach (Form f in erpMain.Send_FormList)
                {
                    if (!f.Name.ToString().Contains("insaSelect"))
                    {
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