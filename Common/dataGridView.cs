using System;
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
        #region 데이터그리드뷰 추가 버튼 누를시 셀 추가
        public void ADD(DataGridView dataGridView1, params object[] values)
        {
            int RowIndex = dataGridView1.RowCount;
            dataGridView1.Rows.Add(values);
            dataGridView1.Columns["정보상태"].ReadOnly = false;
            dataGridView1.Rows[RowIndex].Cells[dataGridView1.Columns.Count - 1].Value = "Insert";
            dataGridView1.Rows[RowIndex].DefaultCellStyle.BackColor = Color.Green;
            dataGridView1.Columns["정보상태"].ReadOnly = true;
        }
        #endregion

        #region 체크박스 값 받아올때 string으로 받아오니 값만 변환
        public String CheckboxToString(String checkBox)
        {
            if (checkBox.Equals("True")) return "Y";
            else return "N";
        }
        #endregion
    }
}
