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

namespace insaProjecct_v2.insaRecord
{
    public partial class insaFamily : Form,  Iinsa_Interface
    {
        public insaFamily()
        {
            InitializeComponent();
        }

        public void DB_Insert()
        {
            MessageBox.Show("family Insert");
        }

        public void DB_Update()
        {
            MessageBox.Show("family update");
        }

        public void DB_Delete()
        {
            MessageBox.Show("family delete");
        }
    }
}
