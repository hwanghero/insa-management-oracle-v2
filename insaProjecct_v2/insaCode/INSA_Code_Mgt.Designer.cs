namespace insaProjecct_v2
{
    partial class INSACode_Mgt
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
            this.코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.코드값 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.코드이름 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.사용여부 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.생성날짜 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.종료날짜 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.정보상태 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.코드,
            this.코드값,
            this.SEQ,
            this.코드이름,
            this.사용여부,
            this.생성날짜,
            this.종료날짜,
            this.정보상태});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 47);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(901, 506);
            this.dataGridView1.TabIndex = 117;
            // 
            // 코드
            // 
            this.코드.HeaderText = "코드";
            this.코드.Name = "코드";
            // 
            // 코드값
            // 
            this.코드값.HeaderText = "코드값";
            this.코드값.Name = "코드값";
            // 
            // SEQ
            // 
            this.SEQ.HeaderText = "SEQ";
            this.SEQ.Name = "SEQ";
            // 
            // 코드이름
            // 
            this.코드이름.HeaderText = "코드이름";
            this.코드이름.Name = "코드이름";
            // 
            // 사용여부
            // 
            this.사용여부.FalseValue = "N";
            this.사용여부.HeaderText = "사용여부";
            this.사용여부.IndeterminateValue = "N";
            this.사용여부.Name = "사용여부";
            this.사용여부.TrueValue = "Y";
            // 
            // 생성날짜
            // 
            this.생성날짜.HeaderText = "생성날짜";
            this.생성날짜.Name = "생성날짜";
            this.생성날짜.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.생성날짜.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 종료날짜
            // 
            this.종료날짜.HeaderText = "종료날짜";
            this.종료날짜.Name = "종료날짜";
            this.종료날짜.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.종료날짜.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // 정보상태
            // 
            this.정보상태.HeaderText = "정보상태";
            this.정보상태.Name = "정보상태";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 119;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(241, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 120;
            this.button1.Text = "셀 추가";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(75, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(149, 20);
            this.comboBox1.TabIndex = 121;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 122;
            this.label2.Text = "코드 선택";
            // 
            // INSACode_Mgt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 553);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "INSACode_Mgt";
            this.Tag = "단위코드 관리";
            this.Text = "insaCode_Mgt";
            this.Load += new System.EventHandler(this.INSACode_Mgt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn 코드값;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 코드이름;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 사용여부;
        private System.Windows.Forms.DataGridViewTextBoxColumn 생성날짜;
        private System.Windows.Forms.DataGridViewTextBoxColumn 종료날짜;
        private System.Windows.Forms.DataGridViewTextBoxColumn 정보상태;
    }
}