using FacebookTrackingSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacebookTrackingSystem
{
    public partial class fChangeMasterPassword : Form
    {
        public fChangeMasterPassword()
        {
            InitializeComponent();
        }

        private void btn_Change_Click(object sender, EventArgs e)
        {
            /*Kiểm tra điều khiện hợp lệ*/
            bool Confirm_UN_Odd_PW;
            bool Confirm_NewPW;
            if ((txb_UserName.Text == MasterLogin.user_name) && (txb_UserOldPassword.Text == MasterLogin.pass_word))
                Confirm_UN_Odd_PW = true;
            else Confirm_UN_Odd_PW = false;
            if ((txb_UserNewPassword.Text == txb_UserReNewPassword.Text))
                Confirm_NewPW = true;
            else Confirm_NewPW = false;


            if (Confirm_NewPW && Confirm_UN_Odd_PW)
            {
                MasterLogin.pass_word = txb_UserNewPassword.Text;
                MessageBox.Show("Đã đổi Password thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
