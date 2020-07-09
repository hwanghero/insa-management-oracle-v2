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

        private void insaBasic_Load(object sender, EventArgs e)
        {
            // 한번만 저장시켜야합니다..;;
            CODE_INPUT("POS");
            CODE_INPUT("STS");
            CODE_INPUT("DUT");
            CODE_INPUT("MIL");
            CODE_INPUT("BNK");
        }

        #region 코드 변환 작업

        // :: 데이터베이스에 있는 코드를 콤보박스에 넣는 함수
        // string GRPCD : 코드 그룹 이름
        private void CODE_INPUT(string GRPCD)
        {
            List<string> result_list = new List<string>();
            OracleDBManager _db = new OracleDBManager();
            if (_db.GetConnection() == true)
            {
                Console.WriteLine("db connection");
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = _db.Connection;
                    cmd.CommandText = "select * from tieas_cd_hwy where CD_GRPCD='" + GRPCD + "'";
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result_list.Add(reader["CD_CODNMS"].ToString());
                        }
                    }
                }
            }

            Form_Control frm_ctrl = new Form_Control();
            frm_ctrl.get_Combobox(this);
            foreach (Control thisCtrl in frm_ctrl.get_control_list)
            {
                if (thisCtrl.Tag != null)
                {
                    if (thisCtrl.Tag.Equals(GRPCD))
                    {
                        foreach (string result in result_list)
                        {
                            (thisCtrl as ComboBox).Items.Add(result);
                        }
                    }
                }
            }
        }
        #endregion
    }
}
