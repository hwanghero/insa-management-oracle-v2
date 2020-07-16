using _Database;
using Common;
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

namespace insaProjecct_v2
{
    public partial class insaCert : Form, Iinsa_Interface
    {
        _Common common = new _Common();
        // DB
        OracleDBManager _DB = new OracleDBManager();
        // 삭제 정보 저장
        List<string> getDeleteREL = new List<string>();
        DateTimePicker dtp;
        public insaCert()
        {
            InitializeComponent();
            if (insaSide.select_empno != null)
                ShowData();
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
                    cmd.CommandText = "select LIC_CODE, LIC_GRADE, LIC_ACQDATE, LIC_ORGAN from thrm_lic_hwy where LIC_EMPNO='" + insaSide.select_empno + "'";
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader["LIC_CODE"], reader["LIC_GRADE"], reader["LIC_ACQDATE"], reader["LIC_ORGAN"], "");
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
                String LIC_CODE = dtRow.Cells["자격면허코드"].FormattedValue.ToString();
                String LIC_GRADE = dtRow.Cells["급수"].FormattedValue.ToString();
                String LIC_ACQDATE = dtRow.Cells["취득일"].FormattedValue.ToString();
                String LIC_ORGAN = dtRow.Cells["발급기관"].FormattedValue.ToString();
                String check = dtRow.Cells["정보상태"].FormattedValue.ToString();

                if (check.Equals("Insert"))
                {
                    thrm_add(insaSide.select_empno, LIC_CODE, LIC_GRADE, common.ParseString(LIC_ACQDATE, "yyyyMMdd"), LIC_ORGAN);
                }
                else if (check.Equals("Update"))
                {
                    thrm_update(insaSide.select_empno, LIC_CODE, LIC_GRADE, common.ParseString(LIC_ACQDATE, "yyyyMMdd"), LIC_ORGAN);
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
        public int thrm_add(String empno, String car_com, String car_region, DateTime car_yyyymm_f, String car_yyyymm_t)
        {
            int check = 1;
            try
            {
                if (_DB.GetConnection() == true)
                {
                    OracleCommand comm = new OracleCommand();
                    comm.Connection = _DB.Connection;

                    comm.CommandText = @"INSERT INTO thrm_lic_hwy values(:empno, :resno, :name, :cname, :ename)";
                    comm.Parameters.Add("empno", empno);
                    comm.Parameters.Add("resno", car_com);
                    comm.Parameters.Add("name", car_region);
                    comm.Parameters.Add("cname", car_yyyymm_f.ToString("yyyyMMdd"));
                    comm.Parameters.Add("ename", car_yyyymm_t);
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

        public int thrm_update(String empno, String car_com, String car_region, DateTime car_yyyymm_f, String car_yyyymm_t)
        {
            int check = 1;
            try
            {
                if (_DB.GetConnection() == true)
                {
                    using (OracleCommand comm = new OracleCommand())
                    {
                        comm.Connection = _DB.Connection;
                        comm.CommandText = @"update thrm_lic_hwy set LIC_CODE='" + car_com + "', LIC_GRADE='" + car_region + "', LIC_ACQDATE='" + car_yyyymm_f.ToString("yyyyMMdd") + "', LIC_ORGAN='" + car_yyyymm_t + "' where LIC_EMPNO='" + empno + "' and LIC_CODE='" + car_com + "'";
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
                        comm.CommandText = @"delete from thrm_lic_hwy where LIC_CODE='" + empno + "' and LIC_CODE='" + CAR_COM + "'";
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
            dataGridView1.Rows.Add("", "", "", "", "");
            dataGridView1.Columns["정보상태"].ReadOnly = false;
            dataGridView1.Rows[RowIndex].Cells[4].Value = "Insert";
            dataGridView1.Rows[RowIndex].DefaultCellStyle.BackColor = Color.Green;
            dataGridView1.Columns["정보상태"].ReadOnly = true;
        }
        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("취득일"))
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
                    if (!dataGridView1[4, row_index].Value.ToString().Equals("Insert"))
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
    }
}
