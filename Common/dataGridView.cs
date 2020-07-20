using _Database;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public class dataGridView
    {
        DateTimePicker dtp;
        DataGridView dataGridView1;
        OracleDBManager _DB = new OracleDBManager();
        // 삭제 정보 저장
        public List<string> getDeleteREL = new List<string>();
        public string Delete_static;
        List<string> timepicker_col = new List<string>();

        #region 데이터그리드뷰 적용
        public void SET(object dataGridView)
        {
            dataGridView1 = dataGridView as DataGridView;
        }
        #endregion

        #region 데이터값 그리드뷰에 뿌려주기
        public void ShowData(String DB_Column, String DB_Tablename)
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
                    cmd.CommandText = "select " + DB_Column + " from " + DB_Tablename;
                    Console.WriteLine(cmd.CommandText);
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        //ArrayList rowList = new ArrayList();
                        object[] row;
                        while (reader.Read())
                        {
                            row = new object[reader.FieldCount + 1];
                            reader.GetValues(row);
                            // 안넣으면 get null 에러뜸
                            row[reader.FieldCount] = "";

                            // 체크박스는 여기서 알아서 넣어줘야할듯 강제로
                            dataGridView1.Rows.Add(row);
                        }
                    }
                }
            }
        }
        #endregion

        #region 데이터그리드뷰 추가 버튼 누를시 셀 추가
        public void ADD(params object[] values)
        {
            int RowIndex = dataGridView1.RowCount;
            dataGridView1.Rows.Add(values);
            dataGridView1.Columns["정보상태"].ReadOnly = false;
            dataGridView1.Rows[RowIndex].Cells[dataGridView1.Columns.Count - 1].Value = "Insert";
            dataGridView1.Rows[RowIndex].DefaultCellStyle.BackColor = Color.Green;
            dataGridView1.Columns["정보상태"].ReadOnly = true;
        }
        #endregion

        #region 그리드뷰 불러올때 체크박스로 변환 << 그리드뷰에서 알아서 잡아줌 ^o^ >>
        public Boolean StringToCheckBox(String checkBox)
        {
            if (checkBox.Equals("Y")) return true;
            else return false;
        }
        #endregion

        #region 체크박스 값 받아올때 string으로 받아오니 값만 변환
        public String CheckboxToString(String checkBox)
        {
            if (checkBox.Equals("True")) return "Y";
            else return "N";
        }
        #endregion

        #region 컬럼이름으로 timepicker 켜기
        public void dgv_time_col_add(String col_name)
        {
            timepicker_col.Add(col_name);
        }
        #endregion

        #region dataTimePicker GridView Cell Click
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1)
            {
                // 어케 받아올까요?
                if (timepicker_col.Contains(dataGridView1.Columns[e.ColumnIndex].Name))
                {
                    dtp = new DateTimePicker();
                    dtp.Format = DateTimePickerFormat.Short;
                    dtp.Visible = true;
                    var rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(rect.Width, rect.Height);
                    dtp.Location = new Point(rect.X, rect.Y);
                    dtp.CloseUp += new EventHandler(dtp_CloseUp);
                    dtp.TextChanged += new EventHandler(dtp_OnTextChange);
                    dtp.DragLeave += new EventHandler(dtp_CloseUp);
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

        #region 이벤트 핸들러 
        public void DGV_EventHandler()
        {
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(CellValueChanged);
            dataGridView1.UserDeletingRow += new DataGridViewRowCancelEventHandler(UserDeletingRow);
        }


        private void CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                int row_index = e.RowIndex;
                if (!dataGridView1[dataGridView1.Columns.Count - 1, row_index].Value.ToString().Equals("Insert"))
                {
                    dataGridView1.Rows[row_index].Cells["정보상태"].Value = "Update";
                    dataGridView1.Rows[row_index].DefaultCellStyle.BackColor = Color.Aqua;
                }
            }
        }

        private void UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.Row.Index];
            getDeleteREL.Add(row.Cells[Delete_static].Value.ToString());
        }

        #endregion

        #region 삭제 고유키 컬럼을 설정
        public void Delete_Column_set(string delete_col)
        {
            Delete_static = delete_col;
        }
        #endregion

    }
}
