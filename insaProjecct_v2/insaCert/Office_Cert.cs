using insaRecord;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace insaProjecct_v2
{
    public partial class Office_Cert : Form, Iinsa_Interface
    {
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
            MessageBox.Show("hello");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 프린트 선택
            printDialog1.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // 페이지 설정
            pageSetupDialog1.PageSettings = printDocument1.DefaultPageSettings;
            pageSetupDialog1.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // 프린터 미리보기 / 인쇄
            printPreviewDialog1.ShowDialog();
        }

        private Bitmap imageLoad() // 이미지를 불러오는 부분
        {
            Bitmap bmp = new Bitmap(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
            this.tableLayoutPanel1.DrawToBitmap(bmp, new Rectangle(0, 0, this.tableLayoutPanel1.Width, this.tableLayoutPanel1.Height));
            bmp.Save("panel.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            return bmp;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(imageLoad(), 0, 0, 210, 297);
        }

        
    }
}
