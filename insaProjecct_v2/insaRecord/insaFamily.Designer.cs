namespace insaProjecct_v2
{
    partial class insaFamily
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.관계 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.이름 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.생일 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.동거여부 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.정보상태 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.관계,
            this.이름,
            this.생일,
            this.동거여부,
            this.정보상태});
            this.dataGridView1.Location = new System.Drawing.Point(0, 38);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(901, 515);
            this.dataGridView1.TabIndex = 114;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 115;
            this.button1.Text = "추가";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 116;
            this.button2.Text = "삭제";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // 관계
            // 
            this.관계.HeaderText = "관계";
            this.관계.Items.AddRange(new object[] {
            "아버지",
            "어머니",
            "형",
            "누나",
            "동생"});
            this.관계.Name = "관계";
            this.관계.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.관계.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 이름
            // 
            this.이름.HeaderText = "이름";
            this.이름.Name = "이름";
            // 
            // 생일
            // 
            this.생일.HeaderText = "생일";
            this.생일.Name = "생일";
            // 
            // 동거여부
            // 
            this.동거여부.FalseValue = "N";
            this.동거여부.HeaderText = "동거여부";
            this.동거여부.Name = "동거여부";
            this.동거여부.TrueValue = "Y";
            // 
            // 정보상태
            // 
            this.정보상태.HeaderText = "정보상태";
            this.정보상태.Name = "정보상태";
            // 
            // insaFamily
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 553);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "insaFamily";
            this.Tag = "가족사항";
            this.Text = "가족사항";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewComboBoxColumn 관계;
        private System.Windows.Forms.DataGridViewTextBoxColumn 이름;
        private System.Windows.Forms.DataGridViewTextBoxColumn 생일;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 동거여부;
        private System.Windows.Forms.DataGridViewTextBoxColumn 정보상태;
    }
}