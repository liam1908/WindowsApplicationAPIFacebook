namespace FacebookTrackingSystem
{
    partial class fLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ExitLogin = new System.Windows.Forms.Button();
            this.btn_Login = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txb_UserPasswordLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txb_UserNameLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_ExitLogin);
            this.panel1.Controls.Add(this.btn_Login);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(25, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 194);
            this.panel1.TabIndex = 1;
            // 
            // btn_ExitLogin
            // 
            this.btn_ExitLogin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_ExitLogin.Location = new System.Drawing.Point(519, 138);
            this.btn_ExitLogin.Name = "btn_ExitLogin";
            this.btn_ExitLogin.Size = new System.Drawing.Size(114, 38);
            this.btn_ExitLogin.TabIndex = 4;
            this.btn_ExitLogin.Text = "Thoát";
            this.btn_ExitLogin.UseVisualStyleBackColor = true;
            this.btn_ExitLogin.Click += new System.EventHandler(this.btn_ExitLogin_Click);
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(387, 138);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(114, 38);
            this.btn_Login.TabIndex = 3;
            this.btn_Login.Text = "Đăng nhập";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txb_UserPasswordLogin);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(15, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(618, 52);
            this.panel3.TabIndex = 2;
            // 
            // txb_UserPasswordLogin
            // 
            this.txb_UserPasswordLogin.Location = new System.Drawing.Point(197, 10);
            this.txb_UserPasswordLogin.Name = "txb_UserPasswordLogin";
            this.txb_UserPasswordLogin.Size = new System.Drawing.Size(402, 22);
            this.txb_UserPasswordLogin.TabIndex = 1;
            this.txb_UserPasswordLogin.UseSystemPasswordChar = true;
            this.txb_UserPasswordLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txb_UserPasswordLogin_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txb_UserNameLogin);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(15, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(618, 52);
            this.panel2.TabIndex = 0;
            // 
            // txb_UserNameLogin
            // 
            this.txb_UserNameLogin.Location = new System.Drawing.Point(197, 10);
            this.txb_UserNameLogin.Name = "txb_UserNameLogin";
            this.txb_UserNameLogin.Size = new System.Drawing.Size(402, 22);
            this.txb_UserNameLogin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập:";
            // 
            // fLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 250);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_ExitLogin;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txb_UserPasswordLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txb_UserNameLogin;
        private System.Windows.Forms.Label label1;
    }
}