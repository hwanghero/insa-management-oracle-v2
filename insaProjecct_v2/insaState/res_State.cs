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
    public partial class res_State : Form
    {
        OracleDBManager _DB = new OracleDBManager();
        List<PieSeries> Pie_List = new List<PieSeries>();
        List<string> Date_List = new List<String>();
        int[] List_Count = new int[12];
        string[] Date_MM =
        {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"
        };

        public res_State()
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

        private void res_State_Load(object sender, EventArgs e)
        {
            // 데이터 가져와..
            PIE_ADD();

            // 개수 가져와..
            Date_List.ForEach(delegate (String s)
            {
                foreach (string a in Date_MM)
                {
                    if (s.Contains(a))
                    {
                        Console.WriteLine(s);
                        List_Count[Convert.ToInt32(a) - 1]++;
                    }
                }
            });

            int MM = 1;
            foreach (int a in List_Count)
            {
                PieSeries_Add(MM + "월", a);
                MM++;
            }

            // 파이에 추가해..
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
                    cmd.CommandText = @"select BAS_RESDATE from thrm_bas_hwy";
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        // thrm_bas_hwy 의 bas_enddate를 다 불러옴
                        while (reader.Read())
                        {
                            // MM만 뽑았음
                            String JoinDate = reader["BAS_RESDATE"].ToString().Substring(4, 2);
                            // 개수를 뽑아야함. MM만 뽑았으니까 그거 count 돌리면될듯?
                            Date_List.Add(JoinDate);
                        }
                    }
                }
            }
        }
    }
}
