namespace insaProjecct_v2
{
    partial class insaCareer
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
            this.근무처명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.최종직급 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.담당업무 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.담당부서 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.소재지 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.근무시작월 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.근무종료월 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.퇴직사유 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.정보상태 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(103, 9);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 29);
            this.button2.TabIndex = 119;
            this.button2.Text = "삭제";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 29);
            this.button1.TabIndex = 118;
            this.button1.Text = "추가";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.근무처명,
            this.최종직급,
            this.담당업무,
            this.담당부서,
            this.소재지,
            this.근무시작월,
            this.근무종료월,
            this.퇴직사유,
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
            // 근무처명
            // 
            this.근무처명.HeaderText = "근무처명";
            this.근무처명.MinimumWidth = 6;
            this.근무처명.Name = "근무처명";
            this.근무처명.Width = 125;
            // 
            // 최종직급
            // 
            this.최종직급.HeaderText = "최종직급";
            this.최종직급.Items.AddRange(new object[] {
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
            this.최종직급.MinimumWidth = 6;
            this.최종직급.Name = "최종직급";
            this.최종직급.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.최종직급.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.최종직급.Width = 125;
            // 
            // 담당업무
            // 
            this.담당업무.HeaderText = "담당업무";
            this.담당업무.MinimumWidth = 6;
            this.담당업무.Name = "담당업무";
            this.담당업무.Width = 125;
            // 
            // 담당부서
            // 
            this.담당부서.HeaderText = "담당부서";
            this.담당부서.MinimumWidth = 6;
            this.담당부서.Name = "담당부서";
            this.담당부서.Width = 125;
            // 
            // 소재지
            // 
            this.소재지.HeaderText = "소재지";
            this.소재지.MinimumWidth = 6;
            this.소재지.Name = "소재지";
            this.소재지.Width = 125;
            // 
            // 근무시작월
            // 
            this.근무시작월.HeaderText = "근무시작월";
            this.근무시작월.MinimumWidth = 6;
            this.근무시작월.Name = "근무시작월";
            this.근무시작월.Width = 125;
            // 
            // 근무종료월
            // 
            this.근무종료월.HeaderText = "근무종료월";
            this.근무종료월.MinimumWidth = 6;
            this.근무종료월.Name = "근무종료월";
            this.근무종료월.Width = 125;
            // 
            // 퇴직사유
            // 
            this.퇴직사유.HeaderText = "퇴직/이직사유";
            this.퇴직사유.MinimumWidth = 6;
            this.퇴직사유.Name = "퇴직사유";
            this.퇴직사유.Width = 300;
            // 
            // 정보상태
            // 
            this.정보상태.HeaderText = "정보상태";
            this.정보상태.MinimumWidth = 6;
            this.정보상태.Name = "정보상태";
            this.정보상태.Width = 125;
            // 
            // insaCareer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1030, 691);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "insaCareer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "경력사항";
            this.Text = "insaCareer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 근무처명;
        private System.Windows.Forms.DataGridViewComboBoxColumn 최종직급;
        private System.Windows.Forms.DataGridViewTextBoxColumn 담당업무;
        private System.Windows.Forms.DataGridViewTextBoxColumn 담당부서;
        private System.Windows.Forms.DataGridViewTextBoxColumn 소재지;
        private System.Windows.Forms.DataGridViewTextBoxColumn 근무시작월;
        private System.Windows.Forms.DataGridViewTextBoxColumn 근무종료월;
        private System.Windows.Forms.DataGridViewTextBoxColumn 퇴직사유;
        private System.Windows.Forms.DataGridViewTextBoxColumn 정보상태;
    }
}