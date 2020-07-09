namespace insaProjecct_v2
{
    partial class erpMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(erpMain));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.status = new System.Windows.Forms.StatusStrip();
            this.timerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.id_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.insert_btn = new System.Windows.Forms.Button();
            this.update_btn = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.statusTimer = new System.Windows.Forms.Timer(this.components);
            this.apply_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.status.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.Location = new System.Drawing.Point(0, 64);
            this.treeView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(203, 553);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // status
            // 
            this.status.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timerLabel,
            this.id_Label});
            this.status.Location = new System.Drawing.Point(0, 615);
            this.status.Name = "status";
            this.status.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.status.Size = new System.Drawing.Size(1311, 22);
            this.status.TabIndex = 1;
            this.status.Text = "statusStrip1";
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = false;
            this.timerLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.timerLabel.Enabled = false;
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(1298, 17);
            this.timerLabel.Spring = true;
            // 
            // id_Label
            // 
            this.id_Label.Name = "id_Label";
            this.id_Label.Size = new System.Drawing.Size(0, 17);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(203, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(901, 553);
            this.panel1.TabIndex = 2;
            // 
            // insert_btn
            // 
            this.insert_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("insert_btn.BackgroundImage")));
            this.insert_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.insert_btn.Location = new System.Drawing.Point(220, 16);
            this.insert_btn.Name = "insert_btn";
            this.insert_btn.Size = new System.Drawing.Size(37, 34);
            this.insert_btn.TabIndex = 3;
            this.insert_btn.UseVisualStyleBackColor = true;
            this.insert_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // update_btn
            // 
            this.update_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("update_btn.BackgroundImage")));
            this.update_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.update_btn.Location = new System.Drawing.Point(264, 16);
            this.update_btn.Name = "update_btn";
            this.update_btn.Size = new System.Drawing.Size(34, 34);
            this.update_btn.TabIndex = 4;
            this.update_btn.UseVisualStyleBackColor = true;
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delete_btn.BackgroundImage")));
            this.delete_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.delete_btn.Location = new System.Drawing.Point(304, 16);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(35, 34);
            this.delete_btn.TabIndex = 4;
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // statusTimer
            // 
            this.statusTimer.Interval = 1000;
            this.statusTimer.Tick += new System.EventHandler(this.statustimer_Tick);
            // 
            // apply_btn
            // 
            this.apply_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("apply_btn.BackgroundImage")));
            this.apply_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.apply_btn.Location = new System.Drawing.Point(365, 16);
            this.apply_btn.Name = "apply_btn";
            this.apply_btn.Size = new System.Drawing.Size(35, 34);
            this.apply_btn.TabIndex = 4;
            this.apply_btn.UseVisualStyleBackColor = true;
            this.apply_btn.Click += new System.EventHandler(this.apply_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cancel_btn.BackgroundImage")));
            this.cancel_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cancel_btn.Location = new System.Drawing.Point(406, 16);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(35, 34);
            this.cancel_btn.TabIndex = 4;
            this.cancel_btn.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(1104, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(206, 553);
            this.panel2.TabIndex = 5;
            // 
            // erpMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1311, 637);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.apply_btn);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.update_btn);
            this.Controls.Add(this.insert_btn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.treeView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "erpMain";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP";
            this.Load += new System.EventHandler(this.erpMain_Load);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button insert_btn;
        private System.Windows.Forms.Button update_btn;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.ToolStripStatusLabel timerLabel;
        public System.Windows.Forms.Timer statusTimer;
        private System.Windows.Forms.ToolStripStatusLabel id_Label;
        public System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.Button apply_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Panel panel2;
    }
}

