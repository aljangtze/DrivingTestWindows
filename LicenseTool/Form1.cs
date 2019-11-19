using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace LicenseTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //LicenseHelper.GenKey();
            LicenseHelper.GetPriKey();

            string guid = LicenseHelper.GetCpuId();

            
            string license = DateTime.Now.Date.ToString("yyyy-MM-dd") + LicenseHelper.GenLicense(guid);
            txtBoxLicense.Text = FileHelper.Encrypt(license, guid.Substring(0, 8));

            FileHelper.WriteToTextFile(txtBoxLicense.Text, "license.dat");

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string licenseCode = FileHelper.Decrypt(FileHelper.ReadTextFile("License.dat"), LicenseHelper.GetCpuId().Substring(0, 8));
            richTextBox3.Text = licenseCode;

            LicenseHelper.GetPubKey();
            if(true == LicenseHelper.CheckLicense(licenseCode.Substring(10, licenseCode.Length-10), LicenseHelper.GetCpuId()))
                MessageBox.Show("正确");
            else
                MessageBox.Show("errro");
        }

        private void btnGenLicense_Click(object sender, EventArgs e)
        {
            int days = 0;
            if (string.IsNullOrEmpty(textBoxGuid.Text))
            {
                if (DialogResult.No == MessageBox.Show("请输入电脑标识是否按照有效天数生成授权信息？", "提示信息", MessageBoxButtons.YesNo))
                    return;
            }
            else
            {
                if (textBoxGuid.Text.Length < 8)
                {
                    MessageBox.Show("电脑标识必须是大于等于8位的字符串");
                    textBoxGuid.Focus();
                    return;
                }
            }
            try
            {
                days = Convert.ToInt32(textBoxValid.Text);
            }
            catch
            {
                MessageBox.Show("有效使用天数输入不正确,请重新输入!", "错误信息", MessageBoxButtons.OK);
                textBoxValid.Focus();
                return;
            }

            LicenseHelper.GetPriKey();

            string guid = textBoxGuid.Text;
            if(string.IsNullOrEmpty(guid))
            {
                string license;
                if("0" == textBoxValid.Text)
                    license = "0000-00-00";
                else
                    license = (DateTime.Now.Date.AddDays(days)).ToString("yyyy-MM-dd");

                txtBoxLicense.Text = FileHelper.Encrypt(license);
            }
            else
            {
                string license;
                if ("0" == textBoxValid.Text)
                    license = "0000-00-00";
                else
                    license = (DateTime.Now.Date.AddDays(days)).ToString("yyyy-MM-dd");

                license = license + LicenseHelper.GenLicense(guid);

                txtBoxLicense.Text = FileHelper.Encrypt(license, guid.Substring(0, 8));
            }

            FileHelper.WriteToTextFile(txtBoxLicense.Text, "License.dat");
        }

        private void btnLinceseCheck_Click(object sender, EventArgs e)
        {
            string licenseInfo = txtBoxLicense.Text;

            if(licenseInfo.Length < 30)
            {
                licenseInfo = FileHelper.Decrypt(licenseInfo);
                richTextBox2.Text = licenseInfo;

            }
            else
            {
                licenseInfo = FileHelper.Decrypt(licenseInfo, textBoxGuid.Text.Substring(0, 8));
                richTextBox2.Text = licenseInfo;
            }

            string date = licenseInfo.Substring(0, 10);
            string license = licenseInfo.Substring(10, licenseInfo.Length - 10);

            if (string.IsNullOrEmpty(license))
            {
                if(date == "0000-00-00")
                    MessageBox.Show(string.Format("验证通过， 有效期为:{0}", "永久有效"), "提示信息", MessageBoxButtons.OK);
                else
                    MessageBox.Show(string.Format("验证通过， 有效期为:{0}", date), "提示信息", MessageBoxButtons.OK);
            }
            else
            {
                LicenseHelper.GetPubKey();
                if (true == LicenseHelper.CheckLicense(license, textBoxGuid.Text))
                {
                    MessageBox.Show(string.Format("验证通过， 有效期为:{0}", date), "提示信息", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("验证失败");
                }
            }
        }
    }
}
