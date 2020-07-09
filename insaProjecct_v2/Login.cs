
using System;
using System.Windows.Forms;
using _Database;
using Common;

namespace insaProjecct_v2
{
    public partial class Login : Form
    {
        Registry reg = new Registry();
        erpMain erpMain;

        public Login()
        {
            InitializeComponent();
        }

        public Login(erpMain erpMain)
        {
            InitializeComponent();
            loginForm_timer.Enabled = true;
            this.erpMain = erpMain;

            if (reg.Get_Save_Registry().Equals("True"))
            {
                idsave_check.Checked = true;
                idbox.Text = reg.Get_ID_Registry();
            }
        }

        private void connect_Click(object sender, EventArgs e)
        {
            _Login db = new _Login();

            if(db.Login(idbox.Text, pwbox.Text) == true)
            {
                if(idsave_check.Checked == true)
                {
                    reg.Set_ID_Registry(idbox.Text);
                    reg.Set_Savecheck_Registry(true);
                }
                this.erpMain.Enabled = true;
                this.erpMain.statusTimer.Enabled = true;
                this.erpMain.status.Items[1].Text = "현재 로그인 아이디: "+idbox.Text;
                this.Close();
                this.Dispose();
            }
            else
            {
                _Common common = new _Common();
                common.MsgboxShow("아이디/비밀번호가 맞지 않습니다.");
            }
        }

        private void idsave_check_CheckedChanged(object sender, EventArgs e)
        {
            if(idsave_check.Checked == false)
            {
                reg.Set_ID_Registry("");
                reg.Set_Savecheck_Registry(false);
            }
        }

        private void loginForm_timer_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.01;
            if (this.Opacity == 1.0)
                loginForm_timer.Enabled = false;
        }
    }
}
