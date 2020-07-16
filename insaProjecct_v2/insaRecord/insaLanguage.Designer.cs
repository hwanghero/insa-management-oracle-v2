namespace insaProjecct_v2
{
    partial class insaLanguage
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.외국어코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.점수 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.취득일 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.발급기관 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.정보상태 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.외국어코드,
            this.점수,
            this.취득일,
            this.발급기관,
            this.정보상태});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 46);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1030, 645);
            this.dataGridView1.TabIndex = 117;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // 외국어코드
            // 
            this.외국어코드.HeaderText = "외국어코드";
            this.외국어코드.MinimumWidth = 6;
            this.외국어코드.Name = "외국어코드";
            this.외국어코드.Width = 125;
            // 
            // 점수
            // 
            this.점수.HeaderText = "점수";
            this.점수.MinimumWidth = 6;
            this.점수.Name = "점수";
            this.점수.Width = 125;
            // 
            // 취득일
            // 
            this.취득일.HeaderText = "취득일";
            this.취득일.MinimumWidth = 6;
            this.취득일.Name = "취득일";
            this.취득일.Width = 125;
            // 
            // 발급기관
            // 
            this.발급기관.HeaderText = "발급기관";
            this.발급기관.Items.AddRange(new object[] {
            "YBM 어학시험",
            "JLPT",
            "HSK 한국사무국 시험센터"});
            this.발급기관.MinimumWidth = 6;
            this.발급기관.Name = "발급기관";
            this.발급기관.Width = 125;
            // 
            // 정보상태
            // 
            this.정보상태.HeaderText = "정보상태";
            this.정보상태.MinimumWidth = 6;
            this.정보상태.Name = "정보상태";
            this.정보상태.Width = 125;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(106, 9);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 29);
            this.button2.TabIndex = 119;
            this.button2.Text = "삭제";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 29);
            this.button1.TabIndex = 118;
            this.button1.Text = "추가";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // insaLanguage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 691);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "insaLanguage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "외국어";
            this.Text = "insaLanguage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 외국어코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn 점수;
        private System.Windows.Forms.DataGridViewTextBoxColumn 취득일;
        private System.Windows.Forms.DataGridViewComboBoxColumn 발급기관;
        private System.Windows.Forms.DataGridViewTextBoxColumn 정보상태;
    }
}