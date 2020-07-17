namespace insaProjecct_v2
{
    partial class insaSchool
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
            this.학력구분 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.입학일자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.졸업일자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.학교명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.학과 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.학위 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.성적 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.졸업구분 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.최종여부 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.정보상태 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 125;
            this.button2.Text = "삭제";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 124;
            this.button1.Text = "추가";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.학력구분,
            this.입학일자,
            this.졸업일자,
            this.학교명,
            this.학과,
            this.학위,
            this.성적,
            this.졸업구분,
            this.최종여부,
            this.정보상태});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 37);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(901, 516);
            this.dataGridView1.TabIndex = 123;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // 학력구분
            // 
            this.학력구분.HeaderText = "학력구분";
            this.학력구분.Items.AddRange(new object[] {
            "4년제",
            "3년제",
            "2년제",
            "고졸"});
            this.학력구분.Name = "학력구분";
            // 
            // 입학일자
            // 
            this.입학일자.HeaderText = "입학일자";
            this.입학일자.Name = "입학일자";
            // 
            // 졸업일자
            // 
            this.졸업일자.HeaderText = "졸업일자";
            this.졸업일자.Name = "졸업일자";
            // 
            // 학교명
            // 
            this.학교명.HeaderText = "학교명";
            this.학교명.Name = "학교명";
            // 
            // 학과
            // 
            this.학과.HeaderText = "학과(전공)";
            this.학과.Name = "학과";
            // 
            // 학위
            // 
            this.학위.HeaderText = "학위";
            this.학위.Items.AddRange(new object[] {
            "박사",
            "석사",
            "학사"});
            this.학위.Name = "학위";
            // 
            // 성적
            // 
            this.성적.HeaderText = "성적";
            this.성적.Name = "성적";
            // 
            // 졸업구분
            // 
            this.졸업구분.HeaderText = "졸업구분";
            this.졸업구분.Items.AddRange(new object[] {
            "졸업",
            "미졸업"});
            this.졸업구분.Name = "졸업구분";
            // 
            // 최종여부
            // 
            this.최종여부.HeaderText = "최종여부";
            this.최종여부.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.최종여부.Name = "최종여부";
            // 
            // 정보상태
            // 
            this.정보상태.HeaderText = "정보상태";
            this.정보상태.Name = "정보상태";
            // 
            // insaSchool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 553);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "insaSchool";
            this.Tag = "학력사항";
            this.Text = "insaSchool";
            this.Load += new System.EventHandler(this.insaSchool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewComboBoxColumn 학력구분;
        private System.Windows.Forms.DataGridViewTextBoxColumn 입학일자;
        private System.Windows.Forms.DataGridViewTextBoxColumn 졸업일자;
        private System.Windows.Forms.DataGridViewTextBoxColumn 학교명;
        private System.Windows.Forms.DataGridViewTextBoxColumn 학과;
        private System.Windows.Forms.DataGridViewComboBoxColumn 학위;
        private System.Windows.Forms.DataGridViewTextBoxColumn 성적;
        private System.Windows.Forms.DataGridViewComboBoxColumn 졸업구분;
        private System.Windows.Forms.DataGridViewComboBoxColumn 최종여부;
        private System.Windows.Forms.DataGridViewTextBoxColumn 정보상태;
    }
}