using insaRecord;
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
    public partial class insaBasic : Form, Iinsa_Interface
    {
        public insaBasic()
        {
            InitializeComponent();
        }

        public void DB_Insert()
        {
            MessageBox.Show("basic insert");
        }

        public void DB_Update()
        {
            MessageBox.Show("basic update");
        }

        public void DB_Delete()
        {
            MessageBox.Show("basic delete");
        }
    }
}
