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
    public partial class FormSimulationWelcom : Form
    {
        private Panel m_parentControl = null;
        FormSimulation _simulaForm = null;
        public FormSimulationWelcom()
        {
            InitializeComponent();
        }

        public void SetParentControl(Panel parent)
        {
            m_parentControl = parent;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _simulaForm = FormMain.m_formSimulation;

            //QuestionManager.GenClassificationProblems();

            int questionCount = _simulaForm.GenQuestions();

            _simulaForm.ResetControlsInfo(questionCount);
            _simulaForm.SetShowType(0);
            _simulaForm.Show();
        }

        private void FormSimulationWelcom_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_simulaForm != null)
                _simulaForm.Hide();
        }

        private void FormSimulationWelcom_Load(object sender, EventArgs e)
        {
            string examInfo = "";
            switch (SystemConfig._examType)
            {
                case 0:
                    examInfo = "科目一(基础知识理论考试)";
                    break;
                case 1:
                    examInfo = "科目四(安全文明驾驶)";
                    break;
                case 2:
                    examInfo = "恢复驾驶资格考试";
                    break;
                case 3:
                    examInfo = "消分考试";
                    break;
                default:
                    examInfo = "unknown";
                    break;
            }

            labelExamInfo.Text = examInfo;

            string carInfo = "";
            switch (SystemConfig._driverType)
            {
                case 0:
                    carInfo = "小车类";
                    break;
                case 1:
                    carInfo = "客车类";
                    break;
                case 2:
                    carInfo = "货车类";
                    break;
                case 3:
                    carInfo = "摩托车";
                    break;
                default:
                    carInfo = "unknown";
                    break;
            }
            labelCarInfo.Text = carInfo;
        }

        private void FormSimulationWelcom_Shown(object sender, EventArgs e)
        {
            //科目一100题，其他都50题
            if (SystemConfig._examType == 0 || SystemConfig._examType == 3)
            {
                if(SystemConfig._driverType == 3)
                    labelRuleInfo.Text = "50题,30分钟";
                else
                    labelRuleInfo.Text = "100题,45分钟";
            }
            else
                labelRuleInfo.Text = "50题,30分钟";
        }
    }
}
