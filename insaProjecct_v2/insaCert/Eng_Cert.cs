using _Database;
using insaRecord;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace insaProjecct_v2
{
    public partial class Eng_Cert : Form, Iinsa_Interface
    {
        // ID: gRjJL6fiOepvBWzPyYho
        // Secret: 94sEmdE0hL
        OracleDBManager _DB = new OracleDBManager();
        public Eng_Cert()
        {
            InitializeComponent();
        }

        private string Papago(string kor)
        {
            // 요청 URL
            string sUrl = "https://openapi.naver.com/v1/papago/n2mt";

            // 파라미터에 값넣기 (파파고 NMT API 가이드에서 -d 부분이 파라미터이다)
            string sParam = string.Format("source={0}&target={1}&text={2}", "ko", "en", kor);

            // 파라미터를 Character Set에 맞게 변경
            byte[] bytearry = Encoding.UTF8.GetBytes(sParam);

            // 서버에 요청
            WebRequest webRequest = WebRequest.Create(sUrl);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";

            // 헤더 추가하기 (파파고 NMT API 가이드에서 -h 부분이 헤더이다)
            webRequest.Headers.Add("X-Naver-Client-Id", "gRjJL6fiOepvBWzPyYho");
            webRequest.Headers.Add("X-Naver-Client-Secret", "94sEmdE0hL");

            // 요청 데이터 길이
            webRequest.ContentLength = bytearry.Length;

            Stream stream = webRequest.GetRequestStream();
            stream.Write(bytearry, 0, bytearry.Length);
            stream.Close();

            // 응답 데이터 가져오기(출력포맷)
            WebResponse webResponse = webRequest.GetResponse();
            stream = webResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);
            string sReturn = streamReader.ReadToEnd();

            streamReader.Close();
            stream.Close();
            webResponse.Close();

            JObject jObject = JObject.Parse(sReturn);

            // JSON 출력포맷에서 필요한 부분(번역된 문장)만 가져오기
            return jObject["message"]["result"]["translatedText"].ToString();
        }

        private void Eng_Cert_Load(object sender, EventArgs e)
        {
            nowtime_label.Text = "Prove as above that he is in office.\n\n" + DateTime.Now.ToString("MM/dd/yyyy");
        }

        public void DB_Insert()
        {
        }

        public void DB_Update()
        {
        }

        public void DB_Delete()
        {
        }

        public void ShowData()
        {
            if (_DB.GetConnection() == true)
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = _DB.Connection;
                    cmd.CommandText = @"select BAS_NAME, BAS_RESNO, BAS_ADDR, BAS_HDPNO, BAS_ENTDATE, BAS_DEPT, BAS_POS, cd.cd_grpcd, cd.cd_code, cd.cd_codnm, dept_code, dept_name " +
                    "from thrm_bas_hwy bas, tieas_cd_hwy cd, thrm_dept_hwy dept " +
                    "where cd.cd_grpcd='POS' and cd.cd_code = bas.bas_pos and dept_code = bas_dept and bas.bas_empno='" + insaSide.select_empno + "'";
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            String entdate = reader["BAS_ENTDATE"].ToString().Substring(6, 2) + "/" + reader["BAS_ENTDATE"].ToString().Substring(4, 2) + "/" + reader["BAS_ENTDATE"].ToString().Substring(0, 4);
                            name_label.Text = Papago(reader["BAS_NAME"].ToString());
                            bth_label.Text = reader["BAS_RESNO"].ToString();
                            address_label.Text = Papago(reader["BAS_ADDR"].ToString());
                            phone_label.Text = reader["BAS_HDPNO"].ToString();
                            start_label.Text = entdate;
                            dept_label.Text = Papago(reader["DEPT_NAME"].ToString());
                            pos_label.Text = Papago(reader["CD_CODNM"].ToString());
                        }
                    }
                }
            }
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
            Point drawPoint = new Point(160, 150); // 좌측 상단 시작점. // 2중 using 문 사용.
            using (Font font = new Font("Lucida Console", 30))
            using (SolidBrush drawBrush = new SolidBrush(Color.Black))
            {
                g.DrawString("Proof of employment", font, drawBrush, drawPoint);
            }
            e.Graphics.DrawImage(imageLoad(), 0, 300, tableLayoutPanel1.Width - 70, tableLayoutPanel1.Height);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Show();
        }
    }
}
