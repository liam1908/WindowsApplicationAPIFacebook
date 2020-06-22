using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookTrackingSystem.Data;


namespace FacebookTrackingSystem
{
    

    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        //fTrackingSystem f = new fTrackingSystem();
        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = txb_UserNameLogin.Text;
            string password = txb_UserPasswordLogin.Text;
            if (Login(username,password))
            {
                //this.Hide();
                //f.ShowDialog();
                //this.Show();
                MasterLogin.LoginFalg = true;
                this.Close();
            }
            else
            {
                MasterLogin.LoginFalg = false;
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }       

        private void btn_ExitLogin_Click(object sender, EventArgs e)
        {
            MasterLogin.LoginFalg = false;
            this.Close();
        }    


        bool Login(string name, string pass)
        {
            if ((name == MasterLogin.user_name) && (pass == MasterLogin.pass_word)) return true;
            else
                return false;
        }

        private void txb_UserPasswordLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_Login_Click(sender, e);
        }
    }
}
