using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
////using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DirvingTest
{
    public partial class FormHome : Form, InterfaceForm
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            richTextBoxHome.LoadFile("tmp/home");
            richTextBoxIntroduce.LoadFile("tmp/about");
            lblQQ.Text  =  SystemConfig.QQ;
            lblWechat.Text = SystemConfig.WeChart;
            lblPhone.Text = SystemConfig.PhoneNumber;
            label1.Text = string.Format("软件提供{0}年驾驶员理论考试的最新题库，助您快速通过理论考试", SystemConfig.FitYear);
        }
		
		private void label_MouseMove(object sender, MouseEventArgs e)
		{
			((Control)sender).ForeColor = Color.Red;
		}
		
		private void label_MouseLeave(object sender, EventArgs e)
		{
			((Control)sender).ForeColor = Color.IndianRed;
		}
		
		private void richTextBox6_MouseClick(object sender, MouseEventArgs e)
		{
			FormLicence form = new FormLicence();
			form.ShowDialog();
		}

        private void btnVip_Click(object sender, EventArgs e)
        {
            FormLicence form = new FormLicence();
            form.ShowDialog();
        }


        public void ReloadForm()
        {
            return;
        }
    }
}
