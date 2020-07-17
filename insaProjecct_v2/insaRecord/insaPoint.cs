using _Database;
using insaRecord;
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
using Common;

namespace insaProjecct_v2
{
    public partial class insaPoint : Form, Iinsa_Interface
    {
        OracleDBManager _DB = new OracleDBManager();
        // 삭제 정보 저장
        List<string> getDeleteREL = new List<string>();
        DateTimePicker dtp;

        _Common common = new _Common();

        public insaPoint()
        {
            InitializeComponent();
        }

        #region 데이터값 그리드뷰에 뿌려주기
        public void ShowData()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                if (dtp != null)
                    dtp.Visible = false;
            }

            if (_DB.GetConnection() == true)
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = _DB.Connection;
                    cmd.CommandText = "select AWARD_DATE, AWARD_TYPE, AWARD_NO, AWARD_KIND, AWARD_ORGAN, AWARD_CONTENT, AWARD_INOUT, AWARD_POS, AWARD_DEPT from thrm_award_hwy where AWARD_EMPNO='" + insaSide.select_empno + "'";
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader["AWARD_DATE"], reader["AWARD_TYPE"], reader["AWARD_NO"], reader["AWARD_KIND"], reader["AWARD_ORGAN"], reader["AWARD_CONTENT"], reader["AWARD_INOUT"], reader["AWARD_POS"], reader["AWARD_DEPT"], "");
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
                String AWARD_DATE = dtRow.Cells["상벌일자"].FormattedValue.ToString();
                String AWARD_TYPE = dtRow.Cells["상벌구분"].FormattedValue.ToString();
                String AWARD_NO = dtRow.Cells["상벌번호"].FormattedValue.ToString();
                String AWARD_KIND = dtRow.Cells["상벌종별"].FormattedValue.ToString();
                String AWARD_ORGAN = dtRow.Cells["시행처"].FormattedValue.ToString();
                String AWARD_CONTENT = dtRow.Cells["상벌내용"].FormattedValue.ToString();
                String AWARD_INOUT = dtRow.Cells["내외구분"].FormattedValue.ToString();
                String AWARD_POS = dtRow.Cells["직급"].FormattedValue.ToString();
                String AWARD_DEPT = dtRow.Cells["소속"].FormattedValue.ToString();
                String check = dtRow.Cells["정보상태"].FormattedValue.ToString();

                if (check.Equals("Insert"))
                {
                    thrm_add(insaSide.select_empno, common.ParseString(AWARD_DATE, "yyyyMMdd"), AWARD_TYPE, AWARD_NO, AWARD_KIND, AWARD_ORGAN, AWARD_CONTENT, AWARD_INOUT, AWARD_POS, AWARD_DEPT);
                }
                else if (check.Equals("Update"))
                {
                    thrm_update(insaSide.select_empno, common.ParseString(AWARD_DATE, "yyyyMMdd"), AWARD_TYPE, AWARD_NO, AWARD_KIND, AWARD_ORGAN, AWARD_CONTENT, AWARD_INOUT, AWARD_POS, AWARD_DEPT);
                }
            }

            if (getDeleteREL.Count != 0)
            {
                foreach (string getDeleteREL in getDeleteREL)
                {
                    thrm_delete(insaSide.select_empno, getDeleteREL);
                }
            }
        }
        #endregion

        #region 입력, 수정, 삭제 DB 접속
        // 입력
        public int thrm_add(String empno, DateTime car_com, String car_region, String car_yyyymm_f, String car_yyyymm_t, String car_pos, String car_dept, String car_job, String car_reason, String award_dept)
        {
            int check = 1;
            try
            {
                if (_DB.GetConnection() == true)
                {
                    OracleCommand comm = new OracleCommand();
                    comm.Connection = _DB.Connection;

                    comm.CommandText = @"INSERT INTO thrm_award_hwy values(:empno, :resno, :name, :cname, :ename, :datasys1, :datasys2, :datasys3, :car_reason, :award_dept)";
                    comm.Parameters.Add("empno", empno);
                    comm.Parameters.Add("resno", car_com.ToString("yyyyMMdd"));
                    comm.Parameters.Add("name", car_region);
                    comm.Parameters.Add("cname", car_yyyymm_f);
                    comm.Parameters.Add("ename", car_yyyymm_t);
                    comm.Parameters.Add("datasys1", car_pos);
                    comm.Parameters.Add("datasys2", car_dept);
                    comm.Parameters.Add("datasys3", car_job);
                    comm.Parameters.Add("car_reason", car_reason);
                    comm.Parameters.Add("award_dept", award_dept);
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

        public int thrm_update(String empno, DateTime car_com, String car_region, String car_yyyymm_f, String car_yyyymm_t, String car_pos, String car_dept, String car_job, String car_reason, String award_dept)
        {
            int check = 1;
            try
            {
                if (_DB.GetConnection() == true)
                {
                    using (OracleCommand comm = new OracleCommand())
                    {
                        comm.Connection = _DB.Connection;
                        comm.CommandText = @"update thrm_award_hwy set AWARD_DATE='" + car_com.ToString("yyyyMMdd") + "', AWARD_TYPE='" + car_region + "', AWARD_NO='" + car_yyyymm_f + "', AWARD_KIND='" + car_yyyymm_t + "', AWARD_ORGAN='" + car_pos + "', AWARD_CONTENT='" + car_dept + "', AWARD_INOUT='" + car_job + "', AWARD_POS='" + car_reason + "', AWARD_DEPT='" + award_dept + "' where AWARD_EMPNO='" + empno + "' and AWARD_NO='" + car_yyyymm_f + "'";
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
                        comm.CommandText = @"delete from thrm_award_hwy where AWARD_EMPNO='" + empno + "' and AWARD_NO='" + CAR_COM + "'";
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

        public void DB_Insert()
        {
            gird_data_binding();
            ShowData();
            erpMain.getResult = true;
        }
        public void DB_Update()
        {

        }
        public void DB_Delete()
        {

        }
        #region 추가버튼 누를시
        private void button1_Click(object sender, EventArgs e)
        {
            int RowIndex = dataGridView1.RowCount;
            dataGridView1.Rows.Add("", "", "", "", "", "", "", "", "");
            dataGridView1.Columns["정보상태"].ReadOnly = false;
            dataGridView1.Rows[RowIndex].Cells[9].Value = "Insert";
            dataGridView1.Rows[RowIndex].DefaultCellStyle.BackColor = Color.Green;
            dataGridView1.Columns["정보상태"].ReadOnly = true;
        }
        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("상벌일자"))
                {
                    dtp = new DateTimePicker();
                    dtp.Format = DateTimePickerFormat.Short;
                    dtp.Visible = true;
                    var rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(rect.Width, rect.Height);
                    dtp.Location = new Point(rect.X, rect.Y);
                    dtp.CloseUp += new EventHandler(dtp_CloseUp);
                    dtp.TextChanged += new EventHandler(dtp_OnTextChange);
                    dataGridView1.Controls.Add(dtp);
                }
            }
        }

        private void dtp_OnTextChange(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dtp.Text.ToString();
        }
        private void dtp_CloseUp(object sender, EventArgs e)
        {
            dtp.Visible = false;
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.Row.Index];
            getDeleteREL.Add(row.Cells[2].Value.ToString());
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (erpMain.now_form != null)
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    int row_index = e.RowIndex;
                    if (!dataGridView1[9, row_index].Value.ToString().Equals("Insert"))
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["정보상태"].Value = "Update";
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Aqua;
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void insaPoint_Load(object sender, EventArgs e)
        {
            if (insaSide.select_empno != null)
                ShowData();
        }
    }
}
