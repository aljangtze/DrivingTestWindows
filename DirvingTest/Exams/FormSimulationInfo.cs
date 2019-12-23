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
    public partial class FormSimulationInfo : Form
    {
        public int _score = 0;
        public FormSimulationInfo(int Score)
        {
            InitializeComponent();
            _score = Score;
        }

        private void FormSimulationInfo_Shown(object sender, EventArgs e)
        {
            if(_score >= 90)
            {
                labelScore.Text = _score.ToString();
                labelNotice1.Text = "祝贺您，得         分";
                labelNotice2.Text = "祝您早日取得驾照！";
            }
            else
            {
                labelScore.Text = _score.ToString();
                labelNotice1.Text = "很遗憾，得         分";
                labelNotice2.Text = "不及格，祝下次成功考过！";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnRepeat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
