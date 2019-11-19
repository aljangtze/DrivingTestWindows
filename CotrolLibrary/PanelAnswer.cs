using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CotrolLibrary
{
    public partial class PanelAnswer : UserControl
    {
        public PanelAnswer()
        {
            InitializeComponent();
        }


        [Category("内容"), Description("标题内容")]
        public string NumText
        {
            get
            {
                return labelNum.Text.ToString();
            }
            set
            {
                labelNum.Text = value;
            }
        }

        [Category("内容"), Description("答案")]
        public string AnswerText
        {
            get
            {
                return labelAnswer.Text.ToString();
            }
            set
            {
                labelAnswer.Text = value;
            }
        }

        private void labelAnswer_TextChanged(object sender, EventArgs e)
        {
            labelAnswer.Left = this.Width;
            labelAnswer.Left = this.Width - labelAnswer.Width - 2;
        }

        public delegate void ClickEventHandler(object sender, EventArgs e);
        public new event ClickEventHandler Click;
        private void OnClick(object sender, EventArgs e)
        {
            ClickEventHandler clickEvent = this.Click;
            if (clickEvent != null)
            {
                clickEvent(this, e);
            }
        }
    }
}
