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
    public partial class deptCode_Mgt : Form, ICode_Interface
    {
        OracleDBManager _DB = new OracleDBManager();
        dataGridView dgv = new dataGridView();
        _Common common = new _Common();

        /**
         *  데이터베이스는 변수로 생성해서 넣는게 더 나을듯.
         *  -> 현재 오류: 데이터타입으로 안넣었다고 에러뜨는거 : 아무값 안넣어도 이렇게 뜨니까
         *      - 이유는 데이터타입으로 받으니까 이런거같은데 이것만 중간에서 수정해주면 해결할듯
         **/

        public deptCode_Mgt()
        {
            InitializeComponent();

        }


        #region 데이터값 상태 체크 후 입력, 수정, 삭제
        public void gird_data_binding()
        {
            foreach (DataGridViewRow dtRow in dataGridView1.Rows)
            {
                String DEPT_CODE = dtRow.Cells["코드"].FormattedValue.ToString();
                String DEPT_NAME = dtRow.Cells["이름"].FormattedValue.ToString();
                String DEPT_SEQ = dtRow.Cells["SEQ"].FormattedValue.ToString();
                String DEPT_SDATE = dtRow.Cells["생성날짜"].FormattedValue.ToString();
                String DEPT_EDATE = dtRow.Cells["종료날짜"].FormattedValue.ToString();
                String check = dtRow.Cells["정보상태"].FormattedValue.ToString();

                if (check.Equals("Insert"))
                {
                    // 데이터타입..여기도 뜸 수정해야함
                    thrm_add(DEPT_CODE, DEPT_NAME, DEPT_SEQ, DEPT_SDATE, DEPT_EDATE);
                }
                else if (check.Equals("Update"))
                {
                    thrm_update(DEPT_CODE, DEPT_NAME, DEPT_SEQ, common.ParseString(DEPT_SDATE, "yyyyMMdd"), common.ParseString(DEPT_EDATE, "yyyyMMdd"));
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

                    comm.CommandText = @"INSERT INTO thrm_dept_hwy values(:empno, :resno, '', :name, '', '', :cname, :ename, '', '', '')";
                    comm.Parameters.Add("empno", val[0]);
                    comm.Parameters.Add("resno", val[1]);
                    comm.Parameters.Add("name", val[2]);
                    comm.Parameters.Add("cname", Convert.ToDateTime(val[3]).ToString("yyyyMMdd"));
                    comm.Parameters.Add("ename", Convert.ToDateTime(val[4]).ToString("yyyyMMdd"));
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
                        //String DEPT_CODE = dtRow.Cells["코드"].FormattedValue.ToString();
                        //String DEPT_NAME = dtRow.Cells["이름"].FormattedValue.ToString();
                        //String DEPT_SEQ = dtRow.Cells["SEQ"].FormattedValue.ToString();
                        //String DEPT_SDATE = dtRow.Cells["생성날짜"].FormattedValue.ToString();
                        //String DEPT_EDATE = dtRow.Cells["종료날짜"].FormattedValue.ToString();
                        comm.Connection = _DB.Connection;
                        comm.CommandText = @"update thrm_dept_hwy set DEPT_NAME='" + val[1] + "', DEPT_SEQ='" + val[2] + "', DEPT_SDATE='" + Convert.ToDateTime(val[3]).ToString("yyyyMMdd") + "', DEPT_EDATE='" + Convert.ToDateTime(val[4]).ToString("yyyyMMdd") + "' where DEPT_CODE='" + val[0] + "'";
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
                        comm.CommandText = @"delete from thrm_dept_hwy where DEPT_CODE='" + empno + "'";
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
            dgv.ShowData("DEPT_CODE, DEPT_NAME, DEPT_SEQ, DEPT_SDATE, DEPT_EDATE", "thrm_dept_hwy");
        }

        public void Cancel()
        {
            dgv.ShowData("DEPT_CODE, DEPT_NAME, DEPT_SEQ, DEPT_SDATE, DEPT_EDATE", "thrm_dept_hwy"); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgv.ADD("", "", "", "", "", "");
        }

        private void deptCode_Mgt_Load(object sender, EventArgs e)
        {
            // 데이터그리드뷰 set
            dgv.SET(dataGridView1);
            // 삭제 고유키 설정 (데이터그리드뷰 컬럼)
            // 이벤트 핸들러
            dgv.DGV_EventHandler();
            dgv.dgv_time_col_add("생성날짜");
            dgv.dgv_time_col_add("종료날짜");
            dgv.ShowData("DEPT_CODE, DEPT_NAME, DEPT_SEQ, DEPT_SDATE, DEPT_EDATE", "thrm_dept_hwy");
            dgv.Delete_Column_set("코드");
        }
    }
}
