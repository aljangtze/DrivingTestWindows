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
    public partial class FormPurchase : Form, InterfaceForm
    {
        public FormPurchase()
        {
            InitializeComponent();
        }

        private void FormPurchase_Load(object sender, EventArgs e)
        {
            richTextBoxPuchase.LoadFile("tmp/help");
            //richTextBoxHelper.LoadFile("购买说明xx.rtf");
            //richTextBoxComulication.LoadFile("联系我们.rtf");
            richTextBoxPuchase.Focus();
        }

        private void imageButton4_Click(object sender, EventArgs e)
        {
            richTextBoxPuchase.LoadFile("tmp/buy");
        }

        private void imageButtonHelp_Click(object sender, EventArgs e)
        {
            richTextBoxPuchase.LoadFile("tmp/help");
        }

        public void ReloadForm()
        {
            return;
        }
    }
}
