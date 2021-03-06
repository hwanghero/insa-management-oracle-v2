﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        // 현재 폼 저장
        static public object now_form;
        Form saveForm;
        // CRUD MODE
        static public string mode { get; set; }
        // SIDE FORM (싱글톤 패턴)
        insaSide side_form = insaSide.Instance();
        // 폼 컨트롤
        Form_Control control = new Form_Control();
        // 결과값 전달
        static public Boolean getResult { get; set; }
        _Common common = new _Common();

        // 통합에게 폼 보내기 - 통합은 맨 밑에 있어서 모든 폼을 불러오고 break를 함.
        public List<Form> FormList = new List<Form>();
        static public List<Form> Send_FormList = new List<Form>();

        // 폼 여러개 추가
        public void add_form(Form form)
        {
            if (saveForm != null)
            {
                saveForm.Close();
            }

            if (form.IsDisposed == false)
            {
                saveForm = form;
                now_form = form;
                form.TopLevel = false;
                form.Parent = this.panel1;
                form.Show();

                // 그냥 폼 확인해서 다 다르게 CRUD 주자.
                if ((now_form as Form).Name.Contains("insa"))
                {
                    control.get_control(form, false);
                    control.control_enabled(false, false);
                    APPLY_Hide(true);
                    if (now_form != (now_form as insaBasic))
                    {
                        control.get_control(form, true);
                        control.control_enabled(true, true);
                        CRUD_Hide(false);

                    }
                    else
                    {
                        CRUD_ALL_Hide(true);
                    }
                }
                else if ((now_form as Form).Name.Contains("Code"))
                {
                    CRUD_ALL_Hide(false);
                    APPLY_Hide(true);
                    APPLY_Enabled(true);
                }
                else
                {
                    CRUD_ALL_Hide(false);
                    APPLY_Hide(false);
                }
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

                // 메뉴 데이터베이스에서 가져오기
                _getMenu getMenu = new _getMenu();
                // 부모 트리부터 설치
                getMenu.parent_menu(treeView1);
                // 자식 트리 설치
                getMenu.child_menu(treeView1, "인사기초정보");
                getMenu.child_menu(treeView1, "인사기록관리");
                getMenu.child_menu(treeView1, "인사변동관리");
                getMenu.child_menu(treeView1, "제증명서 발급");
                getMenu.child_menu(treeView1, "현황 및 통계");
                Enabled_Check = true;
            }
        }

        private void statustimer_Tick(object sender, EventArgs e)
        {
            timerLabel.Text = String.Format("{0}시 {1:0#}분 {2}초", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second.ToString().PadLeft(2, '0'));
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            GetFormList();
            Form form = new Form();
            Boolean result = false;
            Send_FormList = FormList.ToList();
            foreach (Form get in FormList)
            {
                if (e.Node.Text.Equals(get.Tag))
                {
                    form = get;
                    result = true;
                }
            }
            if (result)
            {
                add_form(form);
                result = false;
            }
        }

        public void GetFormList()
        {
            FormList.Clear();
            foreach (Type t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes())
            {
                if (!t.ToString().Contains("Interface") && !t.ToString().Contains("insaSide"))
                {
                    if (t.BaseType.FullName.ToString() == "System.Windows.Forms.Form")
                    {
                        object o = Activator.CreateInstance(t);
                        Form f = o as Form;
                        FormList.Add(f);
                    }
                }
            }
        }

        #region CRUD 버튼 클릭시
        private void button1_Click(object sender, EventArgs e)
        {
            if (now_form != null)
            {
                mode = "insert";
                CRUD_Enabled(false);
                APPLY_Enabled(true);
                control.control_enabled(true, false);
                if (now_form == (now_form as insaBasic))
                {

                    control.get_control(now_form as Form, false);
                    control.control_reset();

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
                control.control_enabled(true, false);

                // 인사기본사항 업데이트 누를 경우 사원 정보 불러옴
                if (now_form == (now_form as insaBasic))
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
                }
                else
                {
                    mode = "delete";
                    CRUD_Enabled(false);
                    APPLY_Enabled(true);
                    control.control_enabled(true, false);
                }
            }
        }

        private void apply_btn_Click(object sender, EventArgs e)
        {
            if (now_form != null)
            {
                if ((now_form as Form).Name.Contains("insa"))
                {
                    if (insaSide.select_empno == null)
                    {
                        common.MsgboxShow("사원을 선택해주세요.");
                        return;
                    }
                    else
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
                        if (getResult == true)
                        {
                            APPLY_Enabled(false);
                            CRUD_Enabled(true);
                            control.control_enabled(false, false);
                            control.control_reset();
                            side_form.insaSide_Refresh();
                        }
                    }
                }
                if ((now_form as Form).Name.Contains("Code"))
                {
                    Type type = now_form.GetType();
                    MethodInfo method = type.GetMethod("null");
                    method = type.GetMethod("Apply");
                    method.Invoke(now_form, null);
                }
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            if ((now_form as Form).Name.Contains("insa"))
            {
                APPLY_Enabled(false);
                CRUD_Enabled(true);
                control.control_enabled(false, false);
                control.control_reset();
            }

            if ((now_form as Form).Name.Contains("Code"))
            {
                Type type = now_form.GetType();
                MethodInfo method = type.GetMethod("null");
                method = type.GetMethod("ShowData");
                method.Invoke(now_form, null);
            }
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
            GetFormList();
        }
        public void CRUD_Hide(Boolean check)
        {
            update_btn.Visible = check;
            delete_btn.Visible = check;
        }

        // 코드관리
        public void CRUD_ALL_Hide(Boolean check)
        {
            insert_btn.Visible = check;
            update_btn.Visible = check;
            delete_btn.Visible = check;
        }

        public void APPLY_Hide(Boolean check)
        {
            apply_btn.Visible = check;
            cancel_btn.Visible = check;
        }
    }
}