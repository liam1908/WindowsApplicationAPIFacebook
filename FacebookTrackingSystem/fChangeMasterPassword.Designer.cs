namespace FacebookTrackingSystem
{
    partial class fChangeMasterPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fChangeMasterPassword));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txb_UserReNewPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txb_UserNewPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Change = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txb_UserOldPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txb_UserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btn_Exit);
            this.panel1.Controls.Add(this.btn_Change);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 351);
            this.panel1.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txb_UserReNewPassword);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(15, 186);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(618, 52);
            this.panel5.TabIndex = 5;
            // 
            // txb_UserReNewPassword
            // 
            this.txb_UserReNewPassword.Location = new System.Drawing.Point(197, 10);
            this.txb_UserReNewPassword.Name = "txb_UserReNewPassword";
            this.txb_UserReNewPassword.Size = new System.Drawing.Size(402, 22);
            this.txb_UserReNewPassword.TabIndex = 1;
            this.txb_UserReNewPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Re Mật khẩu mới:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txb_UserNewPassword);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(15, 128);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(618, 52);
            this.panel4.TabIndex = 3;
            // 
            // txb_UserNewPassword
            // 
            this.txb_UserNewPassword.Location = new System.Drawing.Point(197, 10);
            this.txb_UserNewPassword.Name = "txb_UserNewPassword";
            this.txb_UserNewPassword.Size = new System.Drawing.Size(402, 22);
            this.txb_UserNewPassword.TabIndex = 1;
            this.txb_UserNewPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật khẩu mới:";
            // 
            // btn_Exit
            // 
            this.btn_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Exit.Location = new System.Drawing.Point(519, 297);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(114, 38);
            this.btn_Exit.TabIndex = 4;
            this.btn_Exit.Text = "Thoát";
            this.btn_Exit.UseVisualStyleBackColor = true;
            // 
            // btn_Change
            // 
            this.btn_Change.Location = new System.Drawing.Point(315, 297);
            this.btn_Change.Name = "btn_Change";
            this.btn_Change.Size = new System.Drawing.Size(167, 38);
            this.btn_Change.TabIndex = 3;
            this.btn_Change.Text = "Thay đổi mật khẩu";
            this.btn_Change.UseVisualStyleBackColor = true;
            this.btn_Change.Click += new System.EventHandler(this.btn_Change_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txb_UserOldPassword);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(15, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(618, 52);
            this.panel3.TabIndex = 2;
            // 
            // txb_UserOldPassword
            // 
            this.txb_UserOldPassword.Location = new System.Drawing.Point(197, 10);
            this.txb_UserOldPassword.Name = "txb_UserOldPassword";
            this.txb_UserOldPassword.Size = new System.Drawing.Size(402, 22);
            this.txb_UserOldPassword.TabIndex = 1;
            this.txb_UserOldPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu cũ:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txb_UserName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(15, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(618, 52);
            this.panel2.TabIndex = 0;
            // 
            // txb_UserName
            // 
            this.txb_UserName.Location = new System.Drawing.Point(197, 10);
            this.txb_UserName.Name = "txb_UserName";
            this.txb_UserName.Size = new System.Drawing.Size(402, 22);
            this.txb_UserName.TabIndex = 1;
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
            // fChangeMasterPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 375);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fChangeMasterPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Master Password";
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Change;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txb_UserOldPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txb_UserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txb_UserReNewPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txb_UserNewPassword;
        private System.Windows.Forms.Label label3;
    }
}