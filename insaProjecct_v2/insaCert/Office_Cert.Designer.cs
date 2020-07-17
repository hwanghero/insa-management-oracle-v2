namespace insaProjecct_v2
{
    partial class Office_Cert
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Office_Cert));
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.address_label = new System.Windows.Forms.Label();
            this.bth_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.phone_label = new System.Windows.Forms.Label();
            this.start_label = new System.Windows.Forms.Label();
            this.sts_label = new System.Windows.Forms.Label();
            this.dut_label = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "프린터 선택";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(110, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "페이지 설정";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(205, 15);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "인쇄";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.printDocument1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.address_label, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.bth_label, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.name_label, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.phone_label, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.start_label, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.sts_label, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.dut_label, 3, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 54);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.8055F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.41257F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.59136F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.04819F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.42169F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(901, 499);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label9, 4);
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("굴림", 18F);
            this.label9.Location = new System.Drawing.Point(3, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(895, 224);
            this.label9.TabIndex = 19;
            this.label9.Text = "상기와 같이 재직하고 있음을 증명함.";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // address_label
            // 
            this.address_label.AutoSize = true;
            this.address_label.BackColor = System.Drawing.Color.White;
            this.address_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.address_label, 3);
            this.address_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.address_label.Font = new System.Drawing.Font("굴림", 10F);
            this.address_label.Location = new System.Drawing.Point(225, 43);
            this.address_label.Margin = new System.Windows.Forms.Padding(0);
            this.address_label.Name = "address_label";
            this.address_label.Size = new System.Drawing.Size(676, 42);
            this.address_label.TabIndex = 14;
            this.address_label.Text = " ";
            this.address_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bth_label
            // 
            this.bth_label.AutoSize = true;
            this.bth_label.BackColor = System.Drawing.Color.White;
            this.bth_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bth_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bth_label.Font = new System.Drawing.Font("굴림", 10F);
            this.bth_label.Location = new System.Drawing.Point(675, 0);
            this.bth_label.Margin = new System.Windows.Forms.Padding(0);
            this.bth_label.Name = "bth_label";
            this.bth_label.Size = new System.Drawing.Size(226, 43);
            this.bth_label.TabIndex = 13;
            this.bth_label.Text = " ";
            this.bth_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("굴림", 12F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 43);
            this.label1.TabIndex = 3;
            this.label1.Text = "성명";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("굴림", 12F);
            this.label2.Location = new System.Drawing.Point(0, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 42);
            this.label2.TabIndex = 4;
            this.label2.Text = "주소";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("굴림", 12F);
            this.label3.Location = new System.Drawing.Point(0, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 47);
            this.label3.TabIndex = 5;
            this.label3.Text = "연락처";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("굴림", 12F);
            this.label4.Location = new System.Drawing.Point(450, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 43);
            this.label4.TabIndex = 6;
            this.label4.Text = "생년월일";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("굴림", 12F);
            this.label5.Location = new System.Drawing.Point(450, 85);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 47);
            this.label5.TabIndex = 7;
            this.label5.Text = "담당";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("굴림", 12F);
            this.label6.Location = new System.Drawing.Point(0, 132);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(225, 48);
            this.label6.TabIndex = 8;
            this.label6.Text = "입사일자";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("굴림", 12F);
            this.label8.Location = new System.Drawing.Point(450, 132);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(225, 48);
            this.label8.TabIndex = 10;
            this.label8.Text = "직책";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label7, 4);
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("굴림", 18F);
            this.label7.Location = new System.Drawing.Point(3, 404);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(895, 95);
            this.label7.TabIndex = 11;
            this.label7.Text = "회 사 명 :  IT콘텐츠\r\n\r\n부산경상대학교 총장\r\n";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.BackColor = System.Drawing.Color.White;
            this.name_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.name_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.name_label.Font = new System.Drawing.Font("굴림", 10F);
            this.name_label.Location = new System.Drawing.Point(225, 0);
            this.name_label.Margin = new System.Windows.Forms.Padding(0);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(225, 43);
            this.name_label.TabIndex = 12;
            this.name_label.Text = " ";
            this.name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // phone_label
            // 
            this.phone_label.AutoSize = true;
            this.phone_label.BackColor = System.Drawing.Color.White;
            this.phone_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phone_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.phone_label.Font = new System.Drawing.Font("굴림", 10F);
            this.phone_label.Location = new System.Drawing.Point(225, 85);
            this.phone_label.Margin = new System.Windows.Forms.Padding(0);
            this.phone_label.Name = "phone_label";
            this.phone_label.Size = new System.Drawing.Size(225, 47);
            this.phone_label.TabIndex = 15;
            this.phone_label.Text = " ";
            this.phone_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // start_label
            // 
            this.start_label.AutoSize = true;
            this.start_label.BackColor = System.Drawing.Color.White;
            this.start_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.start_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.start_label.Font = new System.Drawing.Font("굴림", 10F);
            this.start_label.Location = new System.Drawing.Point(225, 132);
            this.start_label.Margin = new System.Windows.Forms.Padding(0);
            this.start_label.Name = "start_label";
            this.start_label.Size = new System.Drawing.Size(225, 48);
            this.start_label.TabIndex = 16;
            this.start_label.Text = " ";
            this.start_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sts_label
            // 
            this.sts_label.AutoSize = true;
            this.sts_label.BackColor = System.Drawing.Color.White;
            this.sts_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sts_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sts_label.Font = new System.Drawing.Font("굴림", 10F);
            this.sts_label.Location = new System.Drawing.Point(675, 85);
            this.sts_label.Margin = new System.Windows.Forms.Padding(0);
            this.sts_label.Name = "sts_label";
            this.sts_label.Size = new System.Drawing.Size(226, 47);
            this.sts_label.TabIndex = 17;
            this.sts_label.Text = " ";
            this.sts_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dut_label
            // 
            this.dut_label.AutoSize = true;
            this.dut_label.BackColor = System.Drawing.Color.White;
            this.dut_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dut_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dut_label.Font = new System.Drawing.Font("굴림", 10F);
            this.dut_label.Location = new System.Drawing.Point(675, 132);
            this.dut_label.Margin = new System.Windows.Forms.Padding(0);
            this.dut_label.Name = "dut_label";
            this.dut_label.Size = new System.Drawing.Size(226, 48);
            this.dut_label.TabIndex = 18;
            this.dut_label.Text = " ";
            this.dut_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Office_Cert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Office_Cert";
            this.Tag = "재직증명서";
            this.Text = "Office_Cert";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label address_label;
        private System.Windows.Forms.Label bth_label;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label phone_label;
        private System.Windows.Forms.Label start_label;
        private System.Windows.Forms.Label sts_label;
        private System.Windows.Forms.Label dut_label;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
    }
}