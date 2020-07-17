using _Database;
using Common;
using insaRecord;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace insaProjecct_v2
{
    public partial class insaFamily : Form, Iinsa_Interface
    {
        _Common common = new _Common();
        // DB
        OracleDBManager _DB = new OracleDBManager();
        // 삭제 정보 저장
        List<string> getDeleteREL = new List<string>();
        DateTimePicker dtp;

        public insaFamily()
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
                Boolean itg_result;
                string rel = "";
                if (_DB.GetConnection() == true)
                {
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = _DB.Connection;
                        cmd.CommandText = "select FAM_REL, FAM_NAME, FAM_BTH, FAM_ITG from thrm_fam_hwy where fam_empno='" + insaSide.select_empno + "'";
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["FAM_ITG"].Equals("Y"))
                                    itg_result = true;
                                else
                                    itg_result = false;

                                // 시간이없덩,, 임시로
                                switch (reader["FAM_REL"])
                                {
                                    case "01":
                                        rel = "아버지";
                                        break;
                                    case "02":
                                        rel = "어머니";
                                        break;
                                    case "03":
                                        rel = "형";
                                        break;
                                    case "04":
                                        rel = "누나";
                                        break;
                                    case "05":
                                        rel = "동생";
                                        break;
                                }

                                dataGridView1.Rows.Add(rel, reader["FAM_NAME"], reader["FAM_BTH"], itg_result, "");
                            }
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
                String rel = dtRow.Cells["관계"].FormattedValue.ToString();
                String name = dtRow.Cells["이름"].FormattedValue.ToString();
                String bth = dtRow.Cells["생일"].FormattedValue.ToString();
                String itg = dtRow.Cells["동거여부"].FormattedValue.ToString();
                String check = dtRow.Cells["정보상태"].FormattedValue.ToString();
                // 시간이없덩,, 임시로
                switch (rel)
                {
                    case "아버지":
                        rel = "01";
                        break;
                    case "어머니":
                        rel = "02";
                        break;
                    case "형":
                        rel = "03";
                        break;
                    case "누나":
                        rel = "04";
                        break;
                    case "동생":
                        rel = "05";
                        break;
                }

                DateTime bth_time;
                if (bth.Length > 8) bth_time = DateTime.ParseExact(bth, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                else bth_time = DateTime.ParseExact(bth, "yyyyMMdd", CultureInfo.InvariantCulture);

                if (itg.Equals("True"))
                    itg = "Y";
                else
                    itg = "N";

                if (check.Equals("Insert"))
                {
                    thrm_fam_add(insaSide.select_empno, rel, name, bth_time, itg, "20200624", "1", "2");
                }
                else if (check.Equals("Update"))
                {
                    thrm_fam_update(insaSide.select_empno, rel, name, bth_time, itg);
                }
            }

            if (getDeleteREL.Count != 0)
            {
                foreach (string getDeleteREL in getDeleteREL)
                {
                    thrm_fam_delete(insaSide.select_empno, getDeleteREL);
                }
            }
        }
        #endregion

        #region 입력, 수정, 삭제 DB 접속
        // 입력
        public int thrm_fam_add(String fam_empno, String fam_rel, String fam_name, DateTime fam_bth, String fam_ltg, String datasys1, String datasys2, String datasys3)
        {
            int check = 1;
            try
            {
                if (_DB.GetConnection() == true)
                {
                    OracleCommand comm = new OracleCommand();
                    comm.Connection = _DB.Connection;

                    comm.CommandText = @"INSERT INTO THRM_FAM_HWY values(:empno, :resno, :name, :cname, :ename, :datasys1, :datasys2, :datasys3)";
                    comm.Parameters.Add("empno", fam_empno);
                    comm.Parameters.Add("resno", fam_rel);
                    comm.Parameters.Add("name", fam_name);
                    comm.Parameters.Add("cname", fam_bth.ToString("yyyyMMdd"));
                    comm.Parameters.Add("ename", fam_ltg);
                    comm.Parameters.Add("datasys1", datasys1);
                    comm.Parameters.Add("datasys2", datasys2);
                    comm.Parameters.Add("datasys3", datasys3);
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

        public int thrm_fam_update(String empno, String fam_rel, String fam_name, DateTime fam_bth, string fam_itg)
        {
            int check = 1;
            try
            {
                if (_DB.GetConnection() == true)
                {
                    using (OracleCommand comm = new OracleCommand())
                    {
                        comm.Connection = _DB.Connection;
                        comm.CommandText = @"update thrm_fam_hwy set fam_rel='" + fam_rel + "', fam_name='" + fam_name + "', fam_bth='" + fam_bth.ToString("yyyyMMdd") + "', fam_itg='" + fam_itg + "' where fam_empno='" + empno + "' and fam_rel='" + fam_rel + "'";
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

        public int thrm_fam_delete(String empno, String fam_rel)
        {
            int check = 1;
            try
            {
                if (_DB.GetConnection() == true)
                {
                    using (OracleCommand comm = new OracleCommand())
                    {
                        comm.Connection = _DB.Connection;
                        comm.CommandText = @"delete from thrm_fam_hwy where fam_empno='" + empno + "' and fam_rel='" + fam_rel + "'";
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

        #region 리플랙션 DB_INSERT
        public void DB_Insert()
        {
            gird_data_binding();
            ShowData();
            erpMain.getResult = true;
        }
        #endregion

        #region 수정,삭제 사용을 안함.
        // -o-;
        public void DB_Update() { }
        public void DB_Delete()
        {

        }
        #endregion
        #region 입력, 수정, 삭제 그리드뷰 이벤트
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
        #endregion
        #region 가족사항 추가버튼 누를시
        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewComboBoxCell Rel_Combobox = new DataGridViewComboBoxCell();
            DataGridViewCheckBoxCell Itg_Combobox = new DataGridViewCheckBoxCell();
            Rel_Combobox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;

            // 관계
            Rel_Combobox.Items.Add("아버지");
            Rel_Combobox.Items.Add("어머니");
            Rel_Combobox.Items.Add("형");
            Rel_Combobox.Items.Add("누나");
            Rel_Combobox.Items.Add("동생");

            int RowIndex = dataGridView1.RowCount;

            dataGridView1.Rows.Add(null, "", null, null, "");

            dataGridView1.Rows[RowIndex].Cells[0] = Rel_Combobox;
            dataGridView1.Rows[RowIndex].Cells[3] = Itg_Combobox;

            dataGridView1.Columns["정보상태"].ReadOnly = false;
            dataGridView1.Rows[RowIndex].Cells[4].Value = "Insert";
            dataGridView1.Rows[RowIndex].DefaultCellStyle.BackColor = Color.Green;
            dataGridView1.Columns["정보상태"].ReadOnly = true;
        }
        #endregion
        #region timepicker gridview connection
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("생일"))
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
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            common.MsgboxShow("사원을 여러개 및 한개 선택 후\nDelete키를 사용하시면 됩니다.");
        }

        private void insaFamily_Load(object sender, EventArgs e)
        {
            if (insaSide.select_empno != null)
                ShowData();
        }
    }
}