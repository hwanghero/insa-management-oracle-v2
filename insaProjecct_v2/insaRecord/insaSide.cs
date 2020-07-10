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
    public partial class insaSide : Form
    {
        public insaSide()
        {
            InitializeComponent();
        }

        private void searchBox_Click(object sender, MouseEventArgs e)
        {
            searchBox.ResetText();
            searchBox.ForeColor = Color.Black;
        }
    }
}
