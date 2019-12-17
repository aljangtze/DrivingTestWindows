using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DirvingTest
{
    public partial class FormUserModify : Form
    {
        public FormUserModify()
        {
            InitializeComponent();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        UserInfo oldUser = new UserInfo();
        public void SetUser(UserInfo user)
        {
            oldUser = user;
        }

        private void FormUserModify_Shown(object sender, EventArgs e)
        {
            txtName.Text = oldUser.UserName;
            txtPassword.Text = oldUser.Password;
            cboxStatus.SelectedIndex = oldUser.Status ? 1 : 0;
            cboxType.SelectedIndex = oldUser.Type;
        }

        

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("用户名不能为空,请重新输入!", "提示信息", MessageBoxButtons.OK);
                txtName.Focus();
                return;
            }
            UserInfo user = new UserInfo();
            user.ID = oldUser.ID;
            user.UserName = txtName.Text;
            user.Password = txtPassword.Text.Trim();
            user.Status = cboxStatus.SelectedIndex == 1;
            user.Type = cboxType.SelectedIndex;

            UserManager userManager = new UserManager();
            if (false == userManager.UpdateUser(user))
            {
                MessageBox.Show("更新用户失败", "提示信息", MessageBoxButtons.OK);
                return;
            }

            DialogResult = DialogResult.Yes;
            Close();
        }
		
		private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Return)
			{
				btnOk.PerformClick();
			}
		}

        
    }
}
