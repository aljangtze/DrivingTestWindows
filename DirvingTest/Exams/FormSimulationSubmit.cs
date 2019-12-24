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
    public partial class FormSimulationSubmit : Form
    {
        public FormSimulationSubmit()
        {
            InitializeComponent();
        }

        public void SetInfo(bool AutoSubmit)
        {
            if (true == AutoSubmit)
            {
                labelInfo1.Text = "注意：按考试规定，您答错的题目已经低于及格线，将被强制交卷！";
                labelInfo1.Top = 24;
                labelInfo2.Visible = false;
                labelInfo1.Height = 87;
                btnSubmit.Focus();
            }
            else
            {
                labelInfo1.Top = 12;
                labelInfo1.Height = 57;
                labelInfo1.Text = "1、点击【确认交卷】将提交考试成绩！";
                labelInfo2.Text = "2、点击【继续考试】将关闭本窗口，继续考试！";
                labelInfo2.Visible = true;
                btnBack.Focus();
            }
        }
    }
	
	
}
