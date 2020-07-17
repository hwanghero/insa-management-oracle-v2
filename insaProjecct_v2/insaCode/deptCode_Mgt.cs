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
        public deptCode_Mgt()
        {
            InitializeComponent();
            // 데이터그리드뷰 set
            dgv.SET(dataGridView1);
            // 삭제 고유키 설정 (데이터그리드뷰 컬럼)
            dgv.Delete_Column_set("코드");
            // 이벤트 핸들러
            dgv.DGV_EventHandler();
            dgv.ShowData("DEPT_CODE, DEPT_NAME, DEPT_SEQ, DEPT_SDATE, DEPT_EDATE", "thrm_dept_hwy");
        }

        public void Apply()
        {
        }

        public void Cancel()
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgv.ADD("", "", "", "", "", "");
        }
    }
}
