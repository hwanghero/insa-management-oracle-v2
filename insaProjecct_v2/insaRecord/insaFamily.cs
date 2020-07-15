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
        // 여기에 CRUD 정보 저장
        DataTable dataTable = new DataTable();
        // 삭제 정보 저장
        List<string> getDeleteREL = new List<string>();

        public insaFamily()
        {
            InitializeComponent();
            if(insaSide.select_empno != null)
            {
                ShowFamily_Data();
            }
        }

        #region 데이터값 그리드뷰에 뿌려주기
        public void ShowFamily_Data()
        {
            dataTable = get_Family("select FAM_REL, FAM_NAME, FAM_BTH, FAM_ITG from thrm_fam_hwy where fam_empno='" + insaSide.select_empno + "'");
            dataTable.Columns.Add("CHECK", typeof(string));
            //if(dataTable.Rows.Count == 0)
            //{
            //    MessageBox.Show("null");
            //}
            dataTable.Columns[0].ColumnName = "관계";
            dataTable.Columns[1].ColumnName = "이름";
            dataTable.Columns[2].ColumnName = "생일";
            dataTable.Columns[3].ColumnName = "동거여부";
            dataTable.Columns[4].ColumnName = "정보상태";
            dataGridView1.DataSource = dataTable.DefaultView;
            dataGridView1.Columns[4].ReadOnly = true;
        }

        // 가족사항 정보를 가져온다.
        public DataTable get_Family(String sql)
        {
            if (_DB.GetConnection() == true)
            {
                OracleDataAdapter adapter = new OracleDataAdapter(sql, _DB.Connection);
                DataTable table = new DataTable { Locale = CultureInfo.InvariantCulture };
                adapter.Fill(table);
                return table;
            }
            return null;
        }
        #endregion

        #region 데이터값 상태 체크 후 입력, 수정, 삭제
        public void gird_data_binding()
        {
            foreach (DataGridViewRow dtRow in dataGridView1.Rows)
            {
                String rel = dtRow.Cells["FAM_REL"].FormattedValue.ToString();
                String name = dtRow.Cells["FAM_NAME"].FormattedValue.ToString();
                String bth = dtRow.Cells["FAM_BTH"].FormattedValue.ToString();
                String itg = dtRow.Cells["FAM_ITG"].FormattedValue.ToString();
                String check = dtRow.Cells["CHECK"].FormattedValue.ToString();

                Console.WriteLine(rel +":"+name+":"+ bth+":"+ itg+":"+ check);
                if (check.Equals("Insert"))
                {
                    thrm_fam_add(insaSide.select_empno, rel, name, bth, itg, "20200624", "1", "2");
                    Console.WriteLine("insert");
                }

                if (check.Equals("Update"))
                {
                    thrm_fam_update(insaSide.select_empno, rel, name, bth, itg);
                    MessageBox.Show("update");
                }
            }
            if (getDeleteREL.Count != 0)
            {
                foreach (string getDeleteREL in getDeleteREL)
                {
                    Console.WriteLine(getDeleteREL);
                    //thrm_fam_delete(insaSide.select_empno, getDeleteREL);
                }
                Console.WriteLine("result count: " + getDeleteREL.Count);
            }
        }

        #region 입력, 수정, 삭제 DB 접속
        // 입력
        public int thrm_fam_add(String fam_empno, String fam_rel, String fam_name, String fam_bth, String fam_ltg, String datasys1, String datasys2, String datasys3)
        {
            int check = 1;
            try
            {
                if (_DB.GetConnection() == true)
                {
                    Console.WriteLine("db insert");
                    OracleCommand comm = new OracleCommand();
                    comm.Connection = _DB.Connection;
                    comm.CommandText = @"INSERT INTO THRM_FAM_HWY values(:empno, :resno, :name, :cname, :ename, :datasys1, :datasys2, :datasys3)";
                    comm.Parameters.Add("empno", fam_empno);
                    comm.Parameters.Add("resno", fam_rel);
                    comm.Parameters.Add("name", fam_name);
                    comm.Parameters.Add("cname", fam_bth);
                    comm.Parameters.Add("ename", fam_ltg);
                    comm.Parameters.Add("datasys1", datasys1);
                    comm.Parameters.Add("datasys2", datasys2);
                    comm.Parameters.Add("datasys3", datasys3);
                    comm.Prepare();
                    comm.ExecuteNonQuery();
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
        #endregion

        // 수정
        public int thrm_fam_update(String empno, String fam_rel, String fam_name, String fam_bth, String fam_itg)
        {
            int check = 1;
            try
            {
                if (_DB.GetConnection() == true)
                {
                    using (OracleCommand comm = new OracleCommand())
                    {
                        comm.Connection = _DB.Connection;
                        comm.CommandText = @"update thrm_fam_hwy set fam_rel='" + fam_rel + "', fam_name='" + fam_name + "', fam_bth='" + fam_bth + "', fam_itg='" + fam_itg + "' where fam_empno='" + empno + "' and fam_rel='"+fam_rel+"'";
                        var a = comm.ExecuteNonQuery();
                        check = 0;
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
                        comm.CommandText = @"delete from thrm_fam_hwy where fam_empno='" + empno + "' and fam_rel='" + fam_rel+"'";
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

        // 입력 이벤트
        public void DB_Insert()
        {
            gird_data_binding();
        }

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
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            dataGridView1.Columns["정보상태"].ReadOnly = false;
            if (!row.Cells["정보상태"].Value.Equals("Insert"))
            {
                row.Cells["정보상태"].Value = "Update";
                row.DefaultCellStyle.BackColor = Color.Aqua;
                dataGridView1.Columns["정보상태"].ReadOnly = true;
            }
        }
        // 추가되면 insert 해준다 ( index를 -1을 해주는 이유는 생성 후의 셀에 값을 넣더라고 )
        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.Row.Index - 1];
            dataGridView1.Columns["정보상태"].ReadOnly = false;
            row.Cells["정보상태"].Value = "Insert";
            row.DefaultCellStyle.BackColor = Color.Green;
            dataGridView1.Columns["정보상태"].ReadOnly = true;
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.Row.Index];
            MessageBox.Show(row.Cells[0].Value.ToString());
            getDeleteREL.Add(row.Cells[0].Value.ToString());
        }
        #endregion
    }
}
