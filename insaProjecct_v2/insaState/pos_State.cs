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

namespace insaProjecct_v2.insaState
{
    public partial class pos_State : Form
    {
        OracleDBManager _DB = new OracleDBManager();
        List<PieSeries> Pie_List = new List<PieSeries>();

        public pos_State()
        {
            InitializeComponent();
        }

        private void pos_State_Load(object sender, EventArgs e)
        {
            POS_ADD();
            foreach (PieSeries a in Pie_List)
            {
                pieChart1.Series.Add(a);
            }
        }

        public void PieSeries_Add(String Title, int Value)
        {
            Pie_List.Add(new PieSeries
            {
                Title = Title,
                Values = new ChartValues<decimal> { Value }
            });
        }

        public void POS_ADD()
        {
            if (_DB.GetConnection() == true)
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = _DB.Connection;
                    cmd.CommandText = @"select cd_codnm, cd_code from tieas_cd_hwy where cd_grpcd='POS'";
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            using (OracleCommand cmd2 = new OracleCommand())
                            {
                                cmd2.Connection = _DB.Connection;
                                cmd2.CommandText = @"select count(*) as RESULT from thrm_bas_hwy bas, tieas_cd_hwy cd where bas.bas_pos = cd.cd_code and cd.cd_grpcd='POS' and cd.cd_code='" + reader["CD_CODE"].ToString() + "'";

                                using (OracleDataReader reader2 = cmd2.ExecuteReader())
                                {
                                    while (reader2.Read())
                                    {
                                        PieSeries_Add(reader["CD_CODNM"].ToString(), Convert.ToInt32(reader2["RESULT"]));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
