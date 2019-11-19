using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
////using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirvingTest
{
    public partial class FormLicence : Form
    {
        public FormLicence()
        {
            InitializeComponent();
        }

        private void FormLicence_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LicenseHelper.ComputerGUID))
            {
                LicenseHelper.GetCpuId();
            }

            //richTextBoxLicense.Text = FileHelper.ReadTextFile("license.dat");
            textBoxCupId.Text = LicenseHelper.ComputerGUID;
            txtBoxLicence.Text = FileHelper.ReadTextFile("license.dat");

            if(LicenseHelper.IsValid() == true)
            {
                labelInfo.ForeColor = Color.Green;
                labelInfo.Text = "授权信息正常";
            }
            else
            {
                labelInfo.ForeColor = Color.DarkRed;
                labelInfo.Text = "授权信息验证失败";
            }
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            string errorInfo = "";
            if (true == LicenseHelper.Register(txtBoxLicence.Text, out errorInfo))
            {
                MessageBox.Show(errorInfo, "提示信息", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(errorInfo, "提示信息", MessageBoxButtons.OK);
            }

            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
