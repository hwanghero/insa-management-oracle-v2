using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using _Database;
using Common;

namespace insaProjecct_v2
{
    public partial class erpMain : Form
    {
        // 전체 폼을 불러올시 생성자가 계속 생성되기때문에 어쩔수없이 체크 넣어줌.
        static Boolean Enabled_Check = false;

        // 패널에 띄울 폼, 리플랙션 할 오브젝트
        Form saveform;
        static public object now_form;

        // CRUD MODE
        static public string mode { get; set; }
        // SIDE FORM (싱글톤 패턴)
        insaSide side_form = insaSide.Instance();
        // 폼 컨트롤
        Form_Control control = new Form_Control();
        // 결과값 전달
        static public Boolean getResult { get; set; }
        _Common common = new _Common();


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
            control.get_control(form, false);
            control.control_enabled(false);

            // 현재 폼이 인사기본사항 아니면 수정/삭제 숨겨줌
            // 다른 폼 생겨서 수정/삭제 필요하면 적절하게 다시 제작
            if (now_form != (now_form as insaBasic))
            {
                CRUD_Hide(false);
            }
            else
            {
                CRUD_Hide(true);
            }
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
                // 상속받는게 없기때문에 BaseType에서 오류가남.
                // insaside = 싱글톤 에러
                // interface = 생성자 에러
                if (!t.ToString().Contains("Interface") && !t.ToString().Contains("insaSide"))
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
            if (now_form != null)
            {
                mode = "insert";
                CRUD_Enabled(false);
                APPLY_Enabled(true);
                control.control_enabled(true);
                if (now_form == (now_form as insaBasic))
                {
                    if (insaSide.select_empno == null)
                    {
                        common.MsgboxShow("사원을 선택해주세요.");
                    }
                }
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (now_form != null)
            {
                mode = "update";
                CRUD_Enabled(false);
                APPLY_Enabled(true);
                control.control_enabled(true);

                // 인사기본사항 업데이트 누를 경우 사원 정보 불러옴
                if(now_form == (now_form as insaBasic))
                {
                    if (insaSide.select_empno == null)
                    {
                        common.MsgboxShow("사원을 선택해주세요.");
                    }
                }
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (now_form != null)
            {
                // 가족사항은 그리드뷰라 삭제를 따로 해야함.
                if (now_form == (now_form as insaFamily))
                {
                    if (insaSide.select_empno == null)
                    {
                        common.MsgboxShow("사원을 선택해주세요.");
                    }
                    else
                    {
                        common.MsgboxShow("사원을 여러개 및 한개 선택 후\nDelete키를 사용하시면 됩니다.");
                    }
                }
                else
                {
                    mode = "delete";
                    CRUD_Enabled(false);
                    APPLY_Enabled(true);
                    control.control_enabled(true);
                }
            }
        }

        private void apply_btn_Click(object sender, EventArgs e)
        {
            if (now_form != null)
            {
                if (insaSide.select_empno == null)
                {
                    common.MsgboxShow("사원을 선택해주세요.");
                    return;
                }

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
                if (getResult == true)
                {
                    APPLY_Enabled(false);
                    CRUD_Enabled(true);
                    control.control_enabled(false);
                    control.control_reset();
                    side_form.insaSide_Refresh();
                }
            }
        }
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            APPLY_Enabled(false);
            CRUD_Enabled(true);
            control.control_enabled(false);
            control.control_reset();
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
        #endregion

        private void erpMain_Load(object sender, EventArgs e)
        {
            side_form.TopLevel = false;
            side_form.Parent = this.panel2;
            side_form.Show();

            APPLY_Enabled(false);
            CRUD_Enabled(true);
        }

        public void CRUD_Hide(Boolean check)
        {
            update_btn.Visible = check;
        }
    }
}