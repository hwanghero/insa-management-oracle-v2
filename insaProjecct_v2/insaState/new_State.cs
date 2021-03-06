﻿using _Database;
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
        /*
         *  년도수로 못불러옴 이건 따로 년도수를 저장을 또 list에 담고
         *  콤보박스로 넣은다음에 (중복체크해서 DB에서)
         *  그걸 누를경우 년도를 불러와서 지금 만든거를 다시 하면은 될듯
         */
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
            foreach(int a in List_Count)
            {
                PieSeries_Add(MM+"월", a);
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
                    cmd.CommandText = @"select BAS_ENTDATE from thrm_bas_hwy";
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        // thrm_bas_hwy 의 bas_enddate를 다 불러옴
                        while (reader.Read())
                        {
                            // MM만 뽑았음
                            String JoinDate = reader["BAS_ENTDATE"].ToString().Substring(4, 2);
                            // 개수를 뽑아야함. MM만 뽑았으니까 그거 count 돌리면될듯?
                            Date_List.Add(JoinDate);
                        }
                    }
                }
            }
        }
    }
}
