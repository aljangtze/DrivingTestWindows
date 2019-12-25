using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            
            string userName = "";
            string userPassword = "";

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            folderPath = Path.Combine(folderPath, "DrivingTest");
            string filePath = Path.Combine(folderPath, "user.ini");
            if (File.Exists(filePath))
            {
                userName = ConfigFileHelper.IniReadValue("UserInfo", "UserName", filePath);
                userPassword = ConfigFileHelper.IniReadValue("UserInfo", "UserPassword", filePath);
            }
            
            txtName.Text = userName;
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
                SystemConfig._IsLogin = UserManager.LoginUser.Type == 1;

                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                folderPath = Path.Combine(folderPath, "DrivingTest");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
                string filePath = Path.Combine(folderPath, "user.ini");
                ConfigFileHelper.IniWriteValue("UserInfo", "UserName", UserManager.LoginUser.UserName, filePath);
                ConfigFileHelper.IniWriteValue("UserInfo", "UserPassword", UserManager.LoginUser.Password, filePath);
                
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
