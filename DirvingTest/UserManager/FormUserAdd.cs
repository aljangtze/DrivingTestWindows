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
    public partial class FormUserAdd : Form
    {
        public FormUserAdd()
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
            cboxStatus.SelectedIndex = 1;
            cboxType.SelectedIndex = 0;
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
            user.UserName = txtName.Text;
            user.Password = txtPassword.Text.Trim();
            user.Status = cboxStatus.SelectedIndex == 1;
            user.Type = cboxType.SelectedIndex;

            UserManager userManager = new UserManager();
            if (false == userManager.AddUser(user))
            {
                MessageBox.Show("添加用户失败", "提示信息", MessageBoxButtons.OK);
                return;
            }


            DialogResult = DialogResult.OK;
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
