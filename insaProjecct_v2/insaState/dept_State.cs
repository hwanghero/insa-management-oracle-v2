using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts; //Core of the library
using LiveCharts.Wpf; //The WPF controls
using LiveCharts.WinForms; //the WinForm wrappers
using System.Collections;
using Oracle.ManagedDataAccess.Client;
using _Database;

namespace insaProjecct_v2.insaState
{
    public partial class dept_State : Form
    {
        OracleDBManager _DB = new OracleDBManager();
        List<PieSeries> Pie_List = new List<PieSeries>();

        public dept_State()
        {
            InitializeComponent();
        }

        public void PieSeries_Add(String Title, int Value)
        {
            Pie_List.Add(new PieSeries
            {
                Title = Title,
                Values = new ChartValues<decimal> { Value }
            });
        }

        private void dept_State_Load(object sender, EventArgs e)
        {
            DEPT_ADD("총무부", "001");
            DEPT_ADD("인사부", "002");
            foreach (PieSeries a in Pie_List)
            {
                pieChart1.Series.Add(a);
            }
        }

        public void DEPT_ADD(String Names ,String dept_code)
        {
            if (_DB.GetConnection() == true)
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = _DB.Connection;
                    cmd.CommandText = @"select count(*) from thrm_bas_hwy where bas_dept='"+ dept_code+"'";
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            PieSeries_Add(Names, Convert.ToInt32(reader[0]));
                        }
                    }
                }
            }
        }
    }
}
