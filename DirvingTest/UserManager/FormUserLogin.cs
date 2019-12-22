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
    public partial class FormUserLogin : Form
    {
        public FormUserLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void FormManagerLogin_Load(object sender, EventArgs e)
        {
            txtName.Text = UserManager.LoginUser.UserName;
            txtPassword.Text = "";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("用户名不能为空,请重新输入!", "提示信息", MessageBoxButtons.OK);
                txtName.Focus();
                return;
            }

            if(false == UserManager.Login(txtName.Text, txtPassword.Text))
            {
                MessageBox.Show("登录失败，请检查输入!", "提示信息", MessageBoxButtons.OK);

            }
            else 
            {
                MessageBox.Show("登录成功!", "提示信息", MessageBoxButtons.OK);

                DialogResult = DialogResult.OK;
                Close();
            }
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
