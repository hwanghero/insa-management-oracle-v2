using insaRecord;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _Database;
using Common;
using Oracle.ManagedDataAccess.Client;

namespace insaProjecct_v2
{
    public partial class insaBasic : Form, Iinsa_Interface
    {
        // 콤보박스 저장용
        static List<Control> CODE_STORE = new List<Control>();

        public insaBasic()
        {
            InitializeComponent();
        }

        public void DB_Insert()
        {
            MessageBox.Show("basic insert");
        }

        public void DB_Update()
        {
            MessageBox.Show("basic update");
        }

        public void DB_Delete()
        {
            MessageBox.Show("basic delete");
        }

        #region 폼 로드시에 콤보박스 값 넣기 (DB 한번 사용)
        private void insaBasic_Load(object sender, EventArgs e)
        {
            // 한번만 체크
            if (CODE_STORE.Count == 0)
            {
                CODE_INPUT("POS");
                CODE_INPUT("STS");
                CODE_INPUT("DUT");
                CODE_INPUT("MIL");
                CODE_INPUT("BNK");
                CODE_INPUT("DEPT");
            }

            // 리스트에 있는거 가져오기
            Form_Control frm_ctrl = new Form_Control();
            frm_ctrl.get_Combobox(this);
            foreach (Control a in CODE_STORE)
            {
                foreach (Control thisCtrl in frm_ctrl.get_control_list)
                {
                    if (thisCtrl.Tag != null)
                    {
                        if (thisCtrl.Tag.Equals(a.Tag))
                        {
                            foreach (string b in (a as ComboBox).Items)
                            {
                                (thisCtrl as ComboBox).Items.Add(b);
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region 콤보박스에 데이터베이스 넣기

        // :: 데이터베이스에 있는 코드를 콤보박스에 넣는 함수
        // string GRPCD : 코드 그룹 이름
        private ComboBox CODE_INPUT(string GRPCD)
        {
            ComboBox combo = new ComboBox();
            OracleDBManager _db = new OracleDBManager();
            if (_db.GetConnection() == true)
            {
                Console.WriteLine("db connection");

                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = _db.Connection;

                    // DEPT는 따로 else에서 처리
                    if (!GRPCD.Equals("DEPT"))
                    {
                        cmd.CommandText = "select * from tieas_cd_hwy where CD_GRPCD='" + GRPCD + "'";
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                combo.Items.Add(reader["CD_CODNMS"].ToString());
                            }
                        }
                    }
                    else
                    {
                        cmd.CommandText = "select * from thrm_dept_hwy";
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                combo.Items.Add(reader["dept_name"].ToString());
                            }
                        }
                    }
                }
            }
            combo.Tag = GRPCD;
            CODE_STORE.Add(combo);
            return combo;
        }
        #endregion
    }
}
