using _Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Oracle.ManagedDataAccess.Client;

namespace insaProjecct_v2
{
    public partial class INSACode_Mgt : Form, ICode_Interface
    {
        _Code _Code = new _Code();
        dataGridView dgv = new dataGridView();
        OracleDBManager _DB = new OracleDBManager();
        String combo_code;
        _Common common = new _Common();

        public INSACode_Mgt()
        {
            InitializeComponent();
            dgv.SET(dataGridView1);
            dgv.DGV_EventHandler();
            dgv.dgv_time_col_add("생성날짜");
            dgv.dgv_time_col_add("종료날짜");
            button1.Visible = false;
            foreach (string item in _Code.GetCodeList()) { comboBox1.Items.Add(item); }
        }

        #region 데이터값 상태 체크 후 입력, 수정, 삭제
        public void gird_data_binding()
        {
            //CD_GRPCD, CD_CODE, CD_SEQ, CD_CODNMS, CD_USE, CD_SDATE, CD_EDATE
            foreach (DataGridViewRow dtRow in dataGridView1.Rows)
            {
                String CDG_GRPCD = dtRow.Cells["코드"].FormattedValue.ToString();
                String CD_CODE = dtRow.Cells["코드값"].FormattedValue.ToString();
                String CD_SEQ = dtRow.Cells["SEQ"].FormattedValue.ToString();
                String CD_CODNMS = dtRow.Cells["코드이름"].FormattedValue.ToString();
                String CDG_USE = dtRow.Cells["사용여부"].FormattedValue.ToString();
                String CD_SDATE = dtRow.Cells["생성날짜"].FormattedValue.ToString();
                String CD_EDATE = dtRow.Cells["종료날짜"].FormattedValue.ToString();
                String check = dtRow.Cells["정보상태"].FormattedValue.ToString();

                if (check.Equals("Insert"))
                {
                    thrm_add(CDG_GRPCD, CD_CODE, CD_SEQ, CD_CODNMS, dgv.CheckboxToString(CDG_USE), CD_SDATE, CD_EDATE);
                }
                else if (check.Equals("Update"))
                {
                    thrm_update(CDG_GRPCD, CD_CODE, CD_SEQ, CD_CODNMS, dgv.CheckboxToString(CDG_USE), common.ParseString(CD_SDATE, "yyyyMMdd"), common.ParseString(CD_EDATE, "yyyyMMdd"));
                }
            }

            if (dgv.getDeleteREL.Count != 0)
            {
                foreach (string getDeleteREL in dgv.getDeleteREL)
                {
                    //thrm_delete(getDeleteREL);
                }
            }
        }
        #endregion

        #region 입력, 수정, 삭제 DB 접속
        // 입력
        public int thrm_add(params object[] val)
        {
            int check = 1;
            try
            {
                if (_DB.GetConnection() == true)
                {
                    OracleCommand comm = new OracleCommand();
                    comm.Connection = _DB.Connection;
                    //CD_GRPCD, CD_CODE, CD_SEQ, CD_CODNMS, CD_USE, CD_SDATE, CD_EDATE
                    comm.CommandText = @"INSERT INTO tieas_cd_hwy values(:empno, :resno, :name, :cname, '', '', '', :ename, :datasys1, :datasys2)";
                    comm.Parameters.Add("empno", val[0]);
                    comm.Parameters.Add("resno", val[1]);
                    comm.Parameters.Add("name", val[2]);
                    comm.Parameters.Add("cname", val[3]);
                    comm.Parameters.Add("ename", val[4]);
                    comm.Parameters.Add("datasys1", Convert.ToDateTime(val[5]).ToString("yyyyMMdd"));
                    comm.Parameters.Add("datasys2", Convert.ToDateTime(val[6]).ToString("yyyyMMdd"));
                    comm.Prepare();
                    var a = comm.ExecuteNonQuery();
                    Console.WriteLine(a + " row insert");
                    comm.Cancel();
                    comm.Dispose();
                    check = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return check;
        }

        public int thrm_update(params object[] val)
        {
            int check = 1;
            try
            {
                if (_DB.GetConnection() == true)
                {
                    using (OracleCommand comm = new OracleCommand())
                    {
                        comm.Connection = _DB.Connection;
                        //CD_GRPCD, CD_CODE, CD_SEQ, CD_CODNMS, CD_USE, CD_SDATE, CD_EDATE
                        comm.CommandText = @"update tieas_cd_hwy set CD_CODE='" + val[1] + "', CD_SEQ='" + val[2] + "', CD_CODNMS='" + val[3] + "', CD_USE='" + val[4] + "', CD_SDATE='" + Convert.ToDateTime(val[5]).ToString("yyyyMMdd") + "', CD_EDATE='" + Convert.ToDateTime(val[6]).ToString("yyyyMMdd") + "' where CD_GRPCD='" + val[0] + "'";
                        Console.WriteLine(comm.CommandText);
                        var a = comm.ExecuteNonQuery();
                        check = 0;
                        Console.WriteLine(a + " row update");
                    }
                }
            }
            catch (Exception a)
            {
                Console.WriteLine(a);
            }
            return check;
        }

        public int thrm_delete(String empno)
        {
            int check = 1;
            try
            {
                if (_DB.GetConnection() == true)
                {
                    using (OracleCommand comm = new OracleCommand())
                    {
                        comm.Connection = _DB.Connection;
                        comm.CommandText = @"delete from tieas_cdg_hwy where CDG_GRPCD='" + empno + "'";
                        var a = comm.ExecuteNonQuery();
                        check = 0;
                        Console.WriteLine(comm.CommandText);
                        Console.WriteLine(a + " row deleted");
                    }
                }
            }
            catch (Exception a)
            {
                Console.WriteLine(a);
            }
            return check;
        }
        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
            String[] split_box = comboBox1.SelectedItem.ToString().Split('-');
            combo_code = split_box[0];
            // 컬럼과 select column이 맞아야함.
            dgv.ShowData("CD_GRPCD, CD_CODE, CD_SEQ, CD_CODNMS, CD_USE, CD_SDATE, CD_EDATE", "tieas_cd_hwy where CD_GRPCD='"+ combo_code + "'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgv.ADD("", "", "", "", false, "", "");
        }

        public void Apply()
        {
            gird_data_binding();
            dgv.ShowData("CD_GRPCD, CD_CODE, CD_SEQ, CD_CODNMS, CD_USE, CD_SDATE, CD_EDATE", "tieas_cd_hwy where CD_GRPCD='" + combo_code + "'");
        }

        public void Cancel()
        {
            dgv.ShowData("CD_GRPCD, CD_CODE, CD_SEQ, CD_CODNMS, CD_USE, CD_SDATE, CD_EDATE", "tieas_cd_hwy where CD_GRPCD='" + combo_code + "'");
        }
    }
}
