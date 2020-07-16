using Oracle.ManagedDataAccess.Client;
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

namespace insaProjecct_v2.insaCode
{
    public partial class GroupCode_Mgt : Form, ICode_Interface
    {
        OracleDBManager _DB = new OracleDBManager();
        
        dataGridView dgv = new dataGridView();

        public GroupCode_Mgt()
        {
            InitializeComponent();
            // 데이터그리드뷰 set
            dgv.SET(dataGridView1);
            // 삭제 고유키 설정 (데이터그리드뷰 컬럼)
            dgv.Delete_Column_set("코드");
            // 이벤트 핸들러
            dgv.DGV_EventHandler();
            dgv.ShowData("tieas_cdg_hwy", "*");
        }

        #region 데이터값 상태 체크 후 입력, 수정, 삭제
        public void gird_data_binding()
        {
            foreach (DataGridViewRow dtRow in dataGridView1.Rows)
            {
                String CDG_GRPCD = dtRow.Cells["코드"].FormattedValue.ToString();
                String CDG_GRPNM = dtRow.Cells["코드이름"].FormattedValue.ToString();
                String CDG_DIGIT = dtRow.Cells["제한숫자"].FormattedValue.ToString();
                String CDG_LENGTH = dtRow.Cells["길이"].FormattedValue.ToString();
                String CDG_USE = dtRow.Cells["사용여부"].FormattedValue.ToString();
                String CDG_KIND = dtRow.Cells["종류"].FormattedValue.ToString();
                String check = dtRow.Cells["정보상태"].FormattedValue.ToString();

                if (check.Equals("Insert"))
                {
                    thrm_add(CDG_GRPCD, CDG_GRPNM, CDG_DIGIT, CDG_LENGTH, dgv.CheckboxToString(CDG_USE), CDG_KIND);
                }
                else if (check.Equals("Update"))
                {
                    thrm_update(CDG_GRPCD, CDG_GRPNM, CDG_DIGIT, CDG_LENGTH, dgv.CheckboxToString(CDG_USE), CDG_KIND);
                }
            }

            if (dgv.getDeleteREL.Count != 0)
            {
                foreach (string getDeleteREL in dgv.getDeleteREL)
                {
                    thrm_delete(getDeleteREL);
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

                    comm.CommandText = @"INSERT INTO tieas_cdg_hwy values(:empno, :resno, :name, :cname, :ename, :datasys1)";
                    comm.Parameters.Add("empno", val[0]);
                    comm.Parameters.Add("resno", val[1]);
                    comm.Parameters.Add("name", val[2]);
                    comm.Parameters.Add("cname", val[3]);
                    comm.Parameters.Add("ename", val[4]);
                    comm.Parameters.Add("datasys1", val[5]);
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
                        comm.CommandText = @"update tieas_cdg_hwy set CDG_GRPNM='" + val[1] + "', CDG_DIGIT='" + val[2] + "', CDG_LENGTH='" + val[3] + "', CDG_USE='" + val[4] + "', CDG_KIND='" + val[5] + "' where CDG_GRPCD='" + val[0] + "'";
                        var a = comm.ExecuteNonQuery();
                        check = 0;
                        Console.WriteLine(comm.CommandText);
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

        public void Apply()
        {
            gird_data_binding();
            dgv.ShowData("tieas_cdg_hwy", "*");
        }

        public void Cancel()
        {
            dgv.ShowData("tieas_cdg_hwy", "*");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #region 추가버튼 누를시
        private void button1_Click(object sender, EventArgs e)
        {
            dgv.ADD("", "", "", "", false, "", "");
        }
        #endregion
    }
}
