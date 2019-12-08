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
    public partial class FormSubject4 : Form, InterfaceForm
    {
        public FormSubject4()
        {
            InitializeComponent();
            label1.Text = string.Format("{0}年驾驶员理论考试最新学习资料--安全文明驾驶模拟考试（科目四）", SystemConfig.FitYear);
        }

        private void FormSubject4_Load(object sender, EventArgs e)
        {
            FormSimulationWelcom form = new FormSimulationWelcom();
            form.TopLevel = false;
            form.Parent = panelMain;
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        public void ReloadForm()
        {
            panelMain.Controls.Clear();
            FormSubject4_Load(null, null);
        }
    }
}
