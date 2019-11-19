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
    public partial class FormRecoverExam : Form, InterfaceForm
    {
        public FormRecoverExam()
        {
            InitializeComponent();
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
            FormSubject4_Load(null, null);
        }
    }
}
