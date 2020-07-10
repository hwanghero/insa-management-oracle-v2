using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using _Database;

namespace insaProjecct_v2
{
    public partial class erpMain : Form
    {
        // 전체 폼을 불러올시 생성자가 계속 생성되기때문에 어쩔수없이 체크 넣어줌.
        static Boolean Enabled_Check = false;

        // 패널에 띄울 폼, 리플랙션 할 오브젝트
        Form saveform;
        object now_form;

        // CRUD MODE
        static public string mode { get; set; }

        // SIDE FORM
        insaSide side_form = new insaSide();

        // 폼 여러개 추가
        public void add_form(Form form)
        {
            if (saveform != null)
            {
                saveform.Close();
            }
            form.TopLevel = false;
            form.Parent = this.panel1;
            form.Show();
            now_form = form;
            saveform = form;
        }

        public erpMain()
        {
            InitializeComponent();

            if (Enabled_Check != true)
            {
                this.Enabled = false;

                Login login = new Login(this);
                login.Show();

                _getMenu getMenu = new _getMenu();
                getMenu.parent_menu(treeView1);
                getMenu.child_menu(treeView1, "인사기록관리");



                Enabled_Check = true;
            }
        }

        private void statustimer_Tick(object sender, EventArgs e)
        {
            timerLabel.Text = String.Format("{0}시 {1:0#}분 {2}초", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second.ToString().PadLeft(2, '0'));
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            List<Form> ltList = GetAssemblyFormList();
            foreach (Form load in ltList)
            {
                if (e.Node.Text.Equals(load.Tag))
                {
                    add_form(load);
                }
            }
        }

        #region 프로젝트 폼 목록 읽어 오기
        public static Form GetAssemblyForm(string strFormName)
        {
            Form f = null;
            foreach (Type t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes())
            {
                //프로젝트 내 폼 중에서 찾을 이름과 같으면..
                if (t.Name == strFormName)
                {
                    //인스턴스 개체 생성 
                    object o = Activator.CreateInstance(t);
                    //인스턴스 개체 폼 형식으로 캐스팅
                    f = o as Form;
                }
            }
            return f;
        }

        public static List<Form> GetAssemblyFormList()
        {
            List<Form> ltForm = new List<Form>();
            foreach (Type t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes())
            {
                // 인터페이스는 상속받는게 없기때문에 BaseType에서 오류가남.
                if (!t.ToString().Contains("Interface"))
                {
                    if (t.BaseType.FullName.ToString() == "System.Windows.Forms.Form")
                    {
                        object o = Activator.CreateInstance(t);
                        Form f = o as Form;
                        ltForm.Add(f);
                    }
                }
            }
            return ltForm;
        }
        #endregion

        #region CRUD 버튼 클릭시
        private void button1_Click(object sender, EventArgs e)
        {
            mode = "insert";
            CRUD_Enabled(false);
            APPLY_Enabled(true);
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            mode = "update";
            CRUD_Enabled(false);
            APPLY_Enabled(true);
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            mode = "delete";
            CRUD_Enabled(false);
            APPLY_Enabled(true);
        }

        private void apply_btn_Click(object sender, EventArgs e)
        {
            if (now_form != null)
            {
                Type type = now_form.GetType();
                MethodInfo method = type.GetMethod("null");
                if (mode.Equals("insert"))
                {
                    method = type.GetMethod("DB_Insert");
                }
                else if (mode.Equals("update"))
                {
                    method = type.GetMethod("DB_Update");
                }
                else if (mode.Equals("delete"))
                {
                    method = type.GetMethod("DB_Delete");
                }
                method.Invoke(now_form, null);
                APPLY_Enabled(false);
                CRUD_Enabled(true);
            }
        }
        #endregion

        private void erpMain_Load(object sender, EventArgs e)
        {
            side_form.TopLevel = false;
            side_form.Parent = this.panel2;
            side_form.Show();

            APPLY_Enabled(false);
            CRUD_Enabled(true);
        }

        private void CRUD_Enabled(Boolean check)
        {
            insert_btn.Enabled = check;
            update_btn.Enabled = check;
            delete_btn.Enabled = check;
        }

        private void APPLY_Enabled(Boolean check)
        {
            apply_btn.Enabled = check;
            cancel_btn.Enabled = check;
        }
    }
}