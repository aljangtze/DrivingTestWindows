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
    public partial class FormSubject1 : Form,InterfaceForm
    {
        public FormSubject1()
        {
            InitializeComponent();
        }

        private void FormSubject1_Load(object sender, EventArgs e)
        {
            if(SystemConfig._examType==0)
                label1.Text = string.Format("{0}年驾驶员理论考试最新学习资料--{1}", SystemConfig.FitYear, "基础知识理论考试（科目一)");
            else if(SystemConfig._examType ==1)
                label1.Text = string.Format("{0}年驾驶员理论考试最新学习资料--{1}", SystemConfig.FitYear, "安全文明驾驶模拟考试（科目四)");
            else if(SystemConfig._examType == 2)
                label1.Text = string.Format("{0}年驾驶员理论考试最新学习资料--{1}", SystemConfig.FitYear, "驾驶员驾驶资格恢复考试");
            else if (SystemConfig._examType == 3)
                label1.Text = string.Format("{0}年驾驶员理论考试最新学习资料--{1}", SystemConfig.FitYear, "驾驶员消分考试");

            FormSimulationWelcom form = new FormSimulationWelcom();
            form.TopLevel = false;
            form.Parent = panelMain;
            form.Dock = DockStyle.Fill;
            form.Show();
        }


        public void ReloadForm()
        {
            panelMain.Controls.Clear();
            FormSubject1_Load(null, null);
        }
    }
}
