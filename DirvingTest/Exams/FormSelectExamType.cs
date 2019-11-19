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
    public partial class FormSelectExamType : Form
    {
        private int exampType = 0;
        private int driverType = 0;
        public FormSelectExamType()
        {
            InitializeComponent();
        }

        private void imageButtonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (exampType != SystemConfig._examType ||
                driverType != SystemConfig._driverType)
                DialogResult = DialogResult.OK;

            SystemConfig._examType = exampType;
            SystemConfig._driverType = driverType;
            SystemConfig.IniWriteValue("Setting", "CarType", driverType.ToString(), SystemConfig.ConfigPath);
            SystemConfig.IniWriteValue("Setting", "ExamType", exampType.ToString(), SystemConfig.ConfigPath);
            SystemConfig.IniWriteValue("Setting", "DriverType", driverType.ToString(), SystemConfig.ConfigPath);

            Close();
        }

        private void FormSelectExamType_Load(object sender, EventArgs e)
        {

            exampType = SystemConfig._examType;
            driverType = SystemConfig._driverType;

            if (SystemConfig._driverType == 0)
            {
                radioButtonCar.Checked = true;
            }
            else if (SystemConfig._driverType == 1)
            {
                radioButtonBus.Checked = true;
            }
            else if (SystemConfig._driverType == 2)
            {
                radioButtonTruck.Checked = true;
            }
            else if(SystemConfig._driverType == 3)
            {
                radioButtonMoter.Checked = true;
            }


            if (SystemConfig._examType == 0)
            {
                radioButtonSubject1.Checked = true;
            }
            else if(SystemConfig._examType == 1)
            {
                radioButtonSubject4.Checked = true;
            }
            else if(SystemConfig._examType == 2)
            {
                radioButtonRecover.Checked = true;
            }
            else if(SystemConfig._examType ==3)
            {
                radioButtonRepeat.Checked = true;
            }
        }

        private void radioButtonCar_CheckedChanged(object sender, EventArgs e)
        {
            if (true == ((RadioButton)sender).Checked)
                driverType = Convert.ToInt32(((RadioButton)sender).Tag);
            
            //SystemConfig.IniWriteValue("Setting", "CarType", Convert.ToInt32(((RadioButton)sender).Tag).ToString(), SystemConfig.ConfigPath);
        }

        private void radioButtonExams_CheckedChanged(object sender, EventArgs e)
        {
            if (true == ((RadioButton)sender).Checked)
                exampType = Convert.ToInt32(((RadioButton)sender).Tag);
        }
    }
}
