﻿using _Database;
using insaRecord;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace insaProjecct_v2
{
    public partial class Office_Cert : Form, Iinsa_Interface
    {
        OracleDBManager _DB = new OracleDBManager();

        public Office_Cert()
        {
            InitializeComponent();
        }

        public void DB_Delete()
        {
        }

        public void DB_Insert()
        {
        }

        public void DB_Update()
        {
        }

        public void ShowData()
        {
            if (_DB.GetConnection() == true)
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = _DB.Connection;
                    cmd.CommandText = @"select BAS_NAME, BAS_RESNO, BAS_ADDR, BAS_HDPNO, BAS_ENTDATE, BAS_DEPT, BAS_POS, cd.cd_grpcd, cd.cd_code, cd.cd_codnm, dept_code, dept_name "+
                    "from thrm_bas_hwy bas, tieas_cd_hwy cd, thrm_dept_hwy dept "+
                    "where cd.cd_grpcd='POS' and cd.cd_code = bas.bas_pos and dept_code = bas_dept and bas.bas_empno='"+insaSide.select_empno+"'";
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            String entdate = reader["BAS_ENTDATE"].ToString().Substring(0, 4)+"년 "+ reader["BAS_ENTDATE"].ToString().Substring(4, 2)+"월 "+ reader["BAS_ENTDATE"].ToString().Substring(6, 2)+"일";
                            name_label.Text = reader["BAS_NAME"].ToString();
                            bth_label.Text = reader["BAS_RESNO"].ToString();
                            address_label.Text = reader["BAS_ADDR"].ToString();
                            phone_label.Text = reader["BAS_HDPNO"].ToString();
                            start_label.Text = entdate;
                            dept_label.Text = reader["DEPT_NAME"].ToString();
                            pos_label.Text = reader["CD_CODNM"].ToString();
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Show();
        }

        private Bitmap imageLoad() // 이미지를 불러오는 부분
        {
            Bitmap bmp = new Bitmap(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            tableLayoutPanel1.DrawToBitmap(bmp, new Rectangle(0, 0, tableLayoutPanel1.Width, tableLayoutPanel1.Height));
            return bmp;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Point drawPoint = new Point(320, 150); // 좌측 상단 시작점. // 2중 using 문 사용.
            using (Font font = new Font("Lucida Console", 30))
            using (SolidBrush drawBrush = new SolidBrush(Color.Black))
            {
                g.DrawString("재직증명서", font, drawBrush, drawPoint);
            }
            e.Graphics.DrawImage(imageLoad(), 0, 300, tableLayoutPanel1.Width - 70, tableLayoutPanel1.Height);
        }

        private void Office_Cert_Load(object sender, EventArgs e)
        {
            nowtime_label.Text = "상기와 같이 재직하고 있음을 증명함.\n\n" + DateTime.Now.ToString("yyyy년 MM월 dd일");
        }
    }
}
