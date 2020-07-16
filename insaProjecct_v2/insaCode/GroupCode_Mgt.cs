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
        // 삭제 정보 저장
        List<string> getDeleteREL = new List<string>();
        dataGridView dgv = new dataGridView();
        public GroupCode_Mgt()
        {
            InitializeComponent();
            ShowData();
        }

        #region 데이터값 그리드뷰에 뿌려주기
        public void ShowData()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
            }

            if (_DB.GetConnection() == true)
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = _DB.Connection;
                    cmd.CommandText = "select * from tieas_cdg_hwy";
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        Boolean check;
                        while (reader.Read())
                        {
                            if (reader["CDG_USE"].Equals("Y")) check = true;
                            else check = false;

                            dataGridView1.Rows.Add(reader["CDG_GRPCD"], reader["CDG_GRPNM"], reader["CDG_DIGIT"], reader["CDG_LENGTH"], check, reader["CDG_KIND"], "");
                        }
                    }
                }
            }
        }
        #endregion

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
                    thrm_add(CDG_GRPCD, CDG_GRPNM, CDG_DIGIT, CDG_LENGTH, CDG_USE, CDG_KIND);
                }
                else if (check.Equals("Update"))
                {
                    //thrm_update(insaSide.select_empno, EDU_LOE, common.ParseString(EDU_ENTDATE, "yyyyMMdd"), common.ParseString(EDU_GRADATE, "yyyyMMdd"), EDU_SCHNM, EDU_DEPT, EDU_DEGREE, EDU_GRADE, EDU_GRA, EDU_LAST);
                }
            }

            if (getDeleteREL.Count != 0)
            {
                foreach (string getDeleteREL in getDeleteREL)
                {
                    //thrm_delete(insaSide.select_empno, getDeleteREL);
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

        public int thrm_update(String empno, String car_com, DateTime car_region, DateTime car_yyyymm_f, String car_yyyymm_t, String car_pos, String car_dept, String car_job, String car_reason, String award_dept)
        {
            int check = 1;
            try
            {
                if (_DB.GetConnection() == true)
                {
                    using (OracleCommand comm = new OracleCommand())
                    {
                        comm.Connection = _DB.Connection;
                        comm.CommandText = @"update thrm_edu_hwy set EDU_LOE='" + car_com + "', EDU_ENTDATE='" + car_region.ToString("yyyyMMdd") + "', EDU_GRADATE='" + car_yyyymm_f.ToString("yyyyMMdd") + "', EDU_SCHNM='" + car_yyyymm_t + "', EDU_DEPT='" + car_pos + "', EDU_DEGREE='" + car_dept + "', EDU_GRADE='" + car_job + "', EDU_GRA='" + car_reason + "', EDU_LAST='" + award_dept + "' where EDU_EMPNO='" + empno + "' and EDU_SCHNM='" + car_yyyymm_t + "'";
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

        public int thrm_delete(String empno, String CAR_COM)
        {
            int check = 1;
            try
            {
                if (_DB.GetConnection() == true)
                {
                    using (OracleCommand comm = new OracleCommand())
                    {
                        comm.Connection = _DB.Connection;
                        comm.CommandText = @"delete from thrm_edu_hwy where EDU_EMPNO='" + empno + "' and EDU_SCHNM='" + CAR_COM + "'";
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
            ShowData();
        }

        public void Cancel()
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #region 추가버튼 누를시
        private void button1_Click(object sender, EventArgs e)
        {
            dgv.ADD(dataGridView1, "", "", "", "", false, "", "");
        }
        #endregion
    }
}
