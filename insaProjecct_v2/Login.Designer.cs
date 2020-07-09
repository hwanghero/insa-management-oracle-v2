namespace insaProjecct_v2
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.idsave_check = new System.Windows.Forms.CheckBox();
            this.pwbox = new System.Windows.Forms.TextBox();
            this.idbox = new System.Windows.Forms.TextBox();
            this.exit = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loginForm_timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "PW";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "ID";
            // 
            // idsave_check
            // 
            this.idsave_check.AutoSize = true;
            this.idsave_check.Location = new System.Drawing.Point(140, 313);
            this.idsave_check.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.idsave_check.Name = "idsave_check";
            this.idsave_check.Size = new System.Drawing.Size(84, 16);
            this.idsave_check.TabIndex = 3;
            this.idsave_check.Text = "아이디저장";
            this.idsave_check.UseVisualStyleBackColor = true;
            this.idsave_check.CheckedChanged += new System.EventHandler(this.idsave_check_CheckedChanged);
            // 
            // pwbox
            // 
            this.pwbox.Location = new System.Drawing.Point(110, 284);
            this.pwbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pwbox.Name = "pwbox";
            this.pwbox.PasswordChar = '*';
            this.pwbox.Size = new System.Drawing.Size(114, 21);
            this.pwbox.TabIndex = 2;
            // 
            // idbox
            // 
            this.idbox.Location = new System.Drawing.Point(110, 255);
            this.idbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.idbox.Name = "idbox";
            this.idbox.Size = new System.Drawing.Size(114, 21);
            this.idbox.TabIndex = 1;
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(160, 348);
            this.exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(64, 29);
            this.exit.TabIndex = 8;
            this.exit.Text = "종료";
            this.exit.UseVisualStyleBackColor = true;
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(83, 348);
            this.connect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(65, 29);
            this.connect.TabIndex = 7;
            this.connect.Text = "접속";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(47, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 225);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // loginForm_timer
            // 
            this.loginForm_timer.Interval = 10;
            this.loginForm_timer.Tick += new System.EventHandler(this.loginForm_timer_Tick);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(315, 394);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idsave_check);
            this.Controls.Add(this.pwbox);
            this.Controls.Add(this.idbox);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox idsave_check;
        private System.Windows.Forms.TextBox pwbox;
        private System.Windows.Forms.TextBox idbox;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer loginForm_timer;
    }
}