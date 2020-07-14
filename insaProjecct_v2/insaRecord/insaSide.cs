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

namespace insaProjecct_v2
{
    public partial class insaSide : Form
    {
        private static insaSide _instance;
        public static String select_empno { get; set; }

        protected insaSide()
        {
            InitializeComponent();
            insaSide_Refresh();
        }

        public void insaSide_Refresh()
        {
            _Side DB_SIDE = new _Side();
            dataGridView1.DataSource = DB_SIDE.sideUserload();
            dataGridView1.Columns[0].HeaderText = "사원번호";
            dataGridView1.Columns[1].HeaderText = "이름";
        }

        public static insaSide Instance()
        {
            if (_instance == null)
            {
                _instance = new insaSide();
            }
            return _instance;
        }

        private void searchBox_Click(object sender, MouseEventArgs e)
        {
            searchBox.ResetText();
            searchBox.ForeColor = Color.Black;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            select_empno = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            label1.Text = "선택한 사원: "+ dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
