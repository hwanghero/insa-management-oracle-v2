namespace insaProjecct_v2.insaState
{
    partial class pos_State
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
            this.label1 = new System.Windows.Forms.Label();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 18F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(901, 66);
            this.label1.TabIndex = 3;
            this.label1.Text = "직위별 인원통계";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pieChart1
            // 
            this.pieChart1.BackColor = System.Drawing.Color.White;
            this.pieChart1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pieChart1.Location = new System.Drawing.Point(0, 66);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(901, 487);
            this.pieChart1.TabIndex = 2;
            this.pieChart1.Text = "pieChart1";
            // 
            // pos_State
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 553);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pieChart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "pos_State";
            this.Tag = "직급별 인원현황";
            this.Text = "pos_State";
            this.Load += new System.EventHandler(this.pos_State_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private LiveCharts.WinForms.PieChart pieChart1;
    }
}