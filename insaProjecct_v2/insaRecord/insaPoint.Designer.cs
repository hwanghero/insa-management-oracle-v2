namespace insaProjecct_v2
{
    partial class insaPoint
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.상벌일자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.상벌구분 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.상벌번호 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.상벌종별 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.시행처 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.상벌내용 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.내외구분 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.직급 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.소속 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.정보상태 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(94, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 122;
            this.button2.Text = "삭제";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 121;
            this.button1.Text = "추가";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.상벌일자,
            this.상벌구분,
            this.상벌번호,
            this.상벌종별,
            this.시행처,
            this.상벌내용,
            this.내외구분,
            this.직급,
            this.소속,
            this.정보상태});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 37);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(901, 516);
            this.dataGridView1.TabIndex = 120;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // 상벌일자
            // 
            this.상벌일자.HeaderText = "상벌일자";
            this.상벌일자.Name = "상벌일자";
            // 
            // 상벌구분
            // 
            this.상벌구분.HeaderText = "상벌구분";
            this.상벌구분.Items.AddRange(new object[] {
            "상",
            "벌"});
            this.상벌구분.Name = "상벌구분";
            this.상벌구분.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.상벌구분.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 상벌번호
            // 
            this.상벌번호.HeaderText = "상벌번호";
            this.상벌번호.Name = "상벌번호";
            // 
            // 상벌종별
            // 
            this.상벌종별.HeaderText = "상벌종별";
            this.상벌종별.Name = "상벌종별";
            this.상벌종별.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.상벌종별.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 시행처
            // 
            this.시행처.HeaderText = "시행처";
            this.시행처.Name = "시행처";
            // 
            // 상벌내용
            // 
            this.상벌내용.HeaderText = "상벌내용";
            this.상벌내용.Name = "상벌내용";
            // 
            // 내외구분
            // 
            this.내외구분.HeaderText = "내외구분";
            this.내외구분.Items.AddRange(new object[] {
            "내부",
            "외부"});
            this.내외구분.Name = "내외구분";
            // 
            // 직급
            // 
            this.직급.HeaderText = "직급(당시)";
            this.직급.Items.AddRange(new object[] {
            "회장",
            "부회장",
            "사장",
            "부사장",
            "전무",
            "상무",
            "부장",
            "과장",
            "차장",
            "대리",
            "사원"});
            this.직급.Name = "직급";
            // 
            // 소속
            // 
            this.소속.HeaderText = "소속(당시)";
            this.소속.Items.AddRange(new object[] {
            "총무부",
            "인사부"});
            this.소속.Name = "소속";
            // 
            // 정보상태
            // 
            this.정보상태.HeaderText = "정보상태";
            this.정보상태.Name = "정보상태";
            // 
            // insaPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 553);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "insaPoint";
            this.Tag = "상벌사항";
            this.Text = "insaPoint";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 상벌일자;
        private System.Windows.Forms.DataGridViewComboBoxColumn 상벌구분;
        private System.Windows.Forms.DataGridViewTextBoxColumn 상벌번호;
        private System.Windows.Forms.DataGridViewTextBoxColumn 상벌종별;
        private System.Windows.Forms.DataGridViewTextBoxColumn 시행처;
        private System.Windows.Forms.DataGridViewTextBoxColumn 상벌내용;
        private System.Windows.Forms.DataGridViewComboBoxColumn 내외구분;
        private System.Windows.Forms.DataGridViewComboBoxColumn 직급;
        private System.Windows.Forms.DataGridViewComboBoxColumn 소속;
        private System.Windows.Forms.DataGridViewTextBoxColumn 정보상태;
    }
}