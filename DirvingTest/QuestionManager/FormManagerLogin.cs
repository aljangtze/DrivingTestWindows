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
    public partial class FormManagerLogin : Form
    {
        public FormManagerLogin()
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
            textBoxPassword.Focus();
            textBoxPassword.Text = "";
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text != SystemConfig._StrPassword)
            {
                MessageBox.Show("对不起，您的认证信息不正确,请重新输入!", "提示信息" , MessageBoxButtons.OK);
                textBoxPassword.Focus();
                return;
            }

            DialogResult = DialogResult.Yes;
            SystemConfig._IsLogin = true;
            Close();
        }
		
		private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Return)
			{
				btnAuth.PerformClick();
			}
		}
    }
}
