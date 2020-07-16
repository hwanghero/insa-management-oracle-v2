namespace insaProjecct_v2.insaCode
{
    partial class GroupCode_Mgt
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
            this.코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.코드이름 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.제한숫자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.길이 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.사용여부 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.종류 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.정보상태 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.코드,
            this.코드이름,
            this.제한숫자,
            this.길이,
            this.사용여부,
            this.종류,
            this.정보상태});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 45);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(901, 508);
            this.dataGridView1.TabIndex = 118;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 119;
            this.button1.Text = "추가";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // 코드
            // 
            this.코드.HeaderText = "코드";
            this.코드.Name = "코드";
            // 
            // 코드이름
            // 
            this.코드이름.HeaderText = "코드이름";
            this.코드이름.Name = "코드이름";
            // 
            // 제한숫자
            // 
            this.제한숫자.HeaderText = "제한숫자";
            this.제한숫자.Name = "제한숫자";
            // 
            // 길이
            // 
            this.길이.HeaderText = "길이";
            this.길이.Name = "길이";
            // 
            // 사용여부
            // 
            this.사용여부.FalseValue = "N";
            this.사용여부.HeaderText = "사용여부";
            this.사용여부.IndeterminateValue = "N";
            this.사용여부.Name = "사용여부";
            this.사용여부.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.사용여부.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.사용여부.TrueValue = "Y";
            // 
            // 종류
            // 
            this.종류.HeaderText = "종류";
            this.종류.Items.AddRange(new object[] {
            "일반행정",
            "학사행정"});
            this.종류.Name = "종류";
            // 
            // 정보상태
            // 
            this.정보상태.HeaderText = "정보상태";
            this.정보상태.Name = "정보상태";
            // 
            // GroupCode_Mgt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 553);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GroupCode_Mgt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "그룹코드 관리";
            this.Text = "GroupCode_Mgt";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn 코드이름;
        private System.Windows.Forms.DataGridViewTextBoxColumn 제한숫자;
        private System.Windows.Forms.DataGridViewTextBoxColumn 길이;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 사용여부;
        private System.Windows.Forms.DataGridViewComboBoxColumn 종류;
        private System.Windows.Forms.DataGridViewTextBoxColumn 정보상태;
    }
}