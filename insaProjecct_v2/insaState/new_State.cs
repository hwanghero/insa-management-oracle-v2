using _Database;
using LiveCharts;
using LiveCharts.Wpf;
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

namespace insaProjecct_v2
{
    public partial class new_State : Form
    {
        OracleDBManager _DB = new OracleDBManager();
        List<PieSeries> Pie_List = new List<PieSeries>();
        public new_State()
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

        private void new_State_Load(object sender, EventArgs e)
        {
            PIE_ADD();
            foreach (PieSeries a in Pie_List)
            {
                pieChart1.Series.Add(a);
            }
        }

        public void PIE_ADD()
        {
            if (_DB.GetConnection() == true)
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = _DB.Connection;
                    cmd.CommandText = @"select BAS_ENTDATE from thrm_bas_hwy";
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        // thrm_bas_hwy 의 bas_enddate를 다 불러옴
                        while (reader.Read())
                        {
                            // MM만 뽑았음
                            String JoinDate = reader["BAS_ENTDATE"].ToString().Substring(4, 6);
                            // 개수를 뽑아야함.
                        }
                    }
                }
            }
        }
    }
}
