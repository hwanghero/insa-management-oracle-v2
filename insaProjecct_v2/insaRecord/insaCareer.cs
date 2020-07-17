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
using insaRecord;
using System.Globalization;

namespace insaProjecct_v2
{
    public partial class insaCareer : Form, Iinsa_Interface
    {
        OracleDBManager _DB = new OracleDBManager();
        // 삭제 정보 저장
        List<string> getDeleteREL = new List<string>();
        DateTimePicker dtp;

        public insaCareer()
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
                    cmd.CommandText = "select CAR_COM, CAR_REGION, CAR_YYYYMM_F, CAR_YYYYMM_T, CAR_POS, CAR_DEPT, CAR_JOB, CAR_REASON from thrm_car_hwy where CAR_EMPNO='" + insaSide.select_empno + "'";
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader["CAR_COM"], reader["CAR_POS"], reader["CAR_JOB"], reader["CAR_DEPT"], reader["CAR_REGION"], reader["CAR_YYYYMM_F"], reader["CAR_YYYYMM_T"], reader["CAR_REASON"]);
                        }
                    }
                }
            }
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
        #region 데이터값 상태 체크 후 입력, 수정, 삭제
        public void gird_data_binding()
        {
            foreach (DataGridViewRow dtRow in dataGridView1.Rows)
            {
                String com = dtRow.Cells["근무처명"].FormattedValue.ToString();
                String region = dtRow.Cells["소재지"].FormattedValue.ToString();
                String yyyymm_f = dtRow.Cells["근무시작월"].FormattedValue.ToString();
                String yyyymm_t = dtRow.Cells["근무종료월"].FormattedValue.ToString();
                String pos = dtRow.Cells["최종직급"].FormattedValue.ToString();
                String dept = dtRow.Cells["담당부서"].FormattedValue.ToString();
                String job = dtRow.Cells["담당업무"].FormattedValue.ToString();
                String reason = dtRow.Cells["퇴직사유"].FormattedValue.ToString();
                String check = dtRow.Cells["정보상태"].FormattedValue.ToString();
                if (check.Equals("Insert"))
                {
                    thrm_car_add(insaSide.select_empno, com, region, ParseString(yyyymm_f), ParseString(yyyymm_t), pos, dept, job, reason);
                }
                else if (check.Equals("Update"))
                {
                    thrm_car_update(insaSide.select_empno, com, region, ParseString(yyyymm_f), ParseString(yyyymm_t), pos, dept, job, reason);
                }
            }

            if (getDeleteREL.Count != 0)
            {
                foreach (string getDeleteREL in getDeleteREL)
                {
                    thrm_car_delete(insaSide.select_empno, getDeleteREL);
                }
            }
        }
        #endregion

        public DateTime ParseString(string data_string)
        {
            DateTime result_time;
            if (data_string.Length > 8) result_time = DateTime.ParseExact(data_string, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            else result_time = DateTime.ParseExact(data_string, "yyyyMM", CultureInfo.InvariantCulture);
            return result_time;
        }

        #region 입력, 수정, 삭제 DB 접속
        // 입력
        public int thrm_car_add(String empno, String car_com, String car_region, DateTime car_yyyymm_f, DateTime car_yyyymm_t, String car_pos, String car_dept, String car_job, String car_reason)
        {
            int check = 1;
            try
            {
                if (_DB.GetConnection() == true)
                {
                    OracleCommand comm = new OracleCommand();
                    comm.Connection = _DB.Connection;

                    comm.CommandText = @"INSERT INTO THRM_CAR_HWY values(:empno, :resno, :name, :cname, :ename, :datasys1, :datasys2, :datasys3, :car_reason)";
                    comm.Parameters.Add("empno", empno);
                    comm.Parameters.Add("resno", car_com);
                    comm.Parameters.Add("name", car_region);
                    comm.Parameters.Add("cname", car_yyyymm_f.ToString("yyyyMM"));
                    comm.Parameters.Add("ename", car_yyyymm_t.ToString("yyyyMM"));
                    comm.Parameters.Add("datasys1", car_pos);
                    comm.Parameters.Add("datasys2", car_dept);
                    comm.Parameters.Add("datasys3", car_job);
                    comm.Parameters.Add("car_reason", car_reason);
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

        public int thrm_car_update(String empno, String car_com, String car_region, DateTime car_yyyymm_f, DateTime car_yyyymm_t, String car_pos, String car_dept, String car_job, String car_reason)
        {
            int check = 1;
            try
            {
                if (_DB.GetConnection() == true)
                {
                    using (OracleCommand comm = new OracleCommand())
                    {
                        comm.Connection = _DB.Connection;
                        comm.CommandText = @"update thrm_car_hwy set CAR_COM='" + car_com + "', CAR_REGION='" + car_region + "', CAR_YYYYMM_F='" + car_yyyymm_f.ToString("yyyyMM") + "', CAR_YYYYMM_T='" + car_yyyymm_t.ToString("yyyyMM") + "', CAR_POS='" + car_pos + "', CAR_DEPT='" + car_dept + "', CAR_JOB='" + car_job + "', CAR_REASON='" + car_reason + "' where car_empno='" + empno + "'";
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

        public int thrm_car_delete(String empno, String CAR_COM)
        {
            int check = 1;
            try
            {
                if (_DB.GetConnection() == true)
                {
                    using (OracleCommand comm = new OracleCommand())
                    {
                        comm.Connection = _DB.Connection;
                        comm.CommandText = @"delete from thrm_car_hwy where car_empno='" + empno + "' and CAR_COM='" + CAR_COM + "'";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("근무시작월") || dataGridView1.Columns[e.ColumnIndex].Name.Equals("근무종료월"))
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

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (erpMain.now_form != null)
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    int row_index = e.RowIndex;
                    if (!dataGridView1[8, row_index].Value.ToString().Equals("Insert"))
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["정보상태"].Value = "Update";
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Aqua;
                    }
                }
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.Row.Index];
            getDeleteREL.Add(row.Cells[0].Value.ToString());
        }

        #region 추가버튼 누를시
        private void button1_Click(object sender, EventArgs e)
        {
            int RowIndex = dataGridView1.RowCount;
            dataGridView1.Rows.Add("", "", "", "", "", "", "", "");
            dataGridView1.Columns["정보상태"].ReadOnly = false;
            dataGridView1.Rows[RowIndex].Cells[8].Value = "Insert";
            dataGridView1.Rows[RowIndex].DefaultCellStyle.BackColor = Color.Green;
            dataGridView1.Columns["정보상태"].ReadOnly = true;
        }
        #endregion

        private void insaCareer_Load(object sender, EventArgs e)
        {
            if (insaSide.select_empno != null)
                ShowData();
        }
    }
}
