using _Database;
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
    public partial class INSACode_Mgt : Form
    {
        _Code _Code = new _Code();
        dataGridView dgv = new dataGridView();
        public INSACode_Mgt()
        {
            InitializeComponent();
            dgv.SET(dataGridView1);
            button1.Visible = false;
            foreach (string item in _Code.GetCodeList()) { comboBox1.Items.Add(item); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
            //CD_GRPCD, CD_CODE, CD_SEQ, CD_CODNMS, CD_USE, CD_SDATE, CD_EDATE
            dgv.ShowData("*", "tieas_cd_hwy where CD_GRPCD='DUT'");
        }
    }
}
