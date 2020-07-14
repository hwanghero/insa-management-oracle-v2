using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace insaProjecct_v2.insaRecord
{
    public partial class insaBasic_Address : Form
    {
        insaBasic erpMain;
        public insaBasic_Address()
        {
            InitializeComponent();
        }

        public insaBasic_Address(insaBasic setForm)
        {
            InitializeComponent();
            erpMain = setForm;
        }

        public static string Find(string s, int p, int l, List<string> v, out int n)
        {
            n = 0;

            try
            {
                HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(
                    "http://openapi.epost.go.kr/postal/retrieveNewAdressAreaCdSearchAllService/retrieveNewAdressAreaCdSearchAllService/getNewAddressListAreaCdSearchAll"
                    + "?ServiceKey=blhB6TxTm5tJXZS42FMbAIJIL%2BeE1YGrassPaIlyFoOs3eAnuo2FxrsszouUj0acoFswQIEuiF%2FF8zjjFt656g%3D%3D" // 서비스키
                    + "&countPerPage=" + l // 페이지당 출력될 개수를 지정(최대 50)
                    + "&currentPage=" + p // 출력될 페이지 번호
                    + "&srchwrd=" + HttpUtility.UrlPathEncode(s) // 검색어
                    );

                rq.Headers = new WebHeaderCollection();
                rq.Headers.Add("Accept-language", "ko");

                bool bOk = false; // <successYN>Y</successYN> 획득 여부
                s = null; // 에러 메시지

                HttpWebResponse rp = (HttpWebResponse)rq.GetResponse();
                XmlTextReader r = new XmlTextReader(rp.GetResponseStream());

                while (r.Read())
                {
                    if (r.NodeType == XmlNodeType.Element)
                    {
                        if (bOk)
                        {
                            if (r.Name == "zipNo" || // 우편번호
                                r.Name == "lnmAdres" || // 도로명 주소
                                r.Name == "rnAdres") // 지번 주소
                            {
                                v.Add(r.ReadString());
                            }
                            else if (r.Name == "totalCount") // 전체 검색수
                            {
                                int.TryParse(r.ReadString(), out n);
                            }
                        }
                        else
                        {
                            if (r.Name == "successYN")
                            {
                                if (r.ReadString() == "Y") bOk = true; // 검색 성공
                            }
                            else if (r.Name == "errMsg") // 에러 메시지
                            {
                                s = r.ReadString();

                                break;
                            }
                        }
                    }
                }

                r.Close();
                rp.Close();

                if (s == null)
                { // OK!
                    if (v.Count < 3)
                        s = "검색결과가 없습니다.";
                }
            }
            catch (Exception e)
            {
                s = e.Message;
            }

            return s;
        }

        void Check()
        {
            if (home_number.Text == "")
            {
                MessageBox.Show("주소를 입력하세요");
            }

            List<string> tm = new List<string>();
            int tma;
            DataTable table = new DataTable();

            table.Columns.Add("우편번호", typeof(string));
            table.Columns.Add("도로명주소", typeof(string));
            table.Columns.Add("지번주소", typeof(string));


            Find(home_number.Text, 1, 50, tm, out tma);

            int i = 0;
            while (i * 3 < 50)
            {
                i++;
                try
                {
                    table.Rows.Add(tm[i * 3 + 0], tm[i * 3 + 1], tm[i * 3 + 2]);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            dataGridView1.DataSource = table;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (home_number.Text == "")
            {
                MessageBox.Show("주소를 입력하세요");
            }

            List<string> tm = new List<string>();
            int tma;
            DataTable table = new DataTable();

            table.Columns.Add("우편번호", typeof(string));
            table.Columns.Add("도로명주소", typeof(string));
            table.Columns.Add("지번주소", typeof(string));


            Find(home_number.Text, 1, 50, tm, out tma);

            int i = 0;
            while (i * 3 < 50)
            {
                i++;
                try
                {
                    table.Rows.Add(tm[i * 3 + 0], tm[i * 3 + 1], tm[i * 3 + 2]);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            dataGridView1.DataSource = table;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            erpMain.address_box.Text = dataGridView1.Rows[e.RowIndex].Cells["도로명주소"].Value.ToString();
            erpMain.zip_box.Text = dataGridView1.Rows[e.RowIndex].Cells["우편번호"].Value.ToString();
            this.Close();
        }
    }
}
