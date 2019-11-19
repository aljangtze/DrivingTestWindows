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
    public partial class FormSkillExplain : Form
    {
        VoiceHelper voice = VoiceHelper.getVoiceHelper();
        public FormSkillExplain()
        {
            InitializeComponent();
        }

        private void buttonReader_Click(object sender, EventArgs e)
        {
            voice.Speeker(richTextBoxExplain.Text);
            
        }

        public void SetText(string Text)
        {
            richTextBoxExplain.Text = Text;
            trackBar1_Scroll(trackBar1, null);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            voice.StopSpeaker();            
            Close();
        }

        private void buttonMax_Click(object sender, EventArgs e)
        {
            trackBar1.Value = Math.Max(20, trackBar1.Value + 1);
            trackBar1_Scroll(trackBar1, null);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            richTextBoxExplain.Font = new Font("宋体", trackBar1.Value + 20, FontStyle.Bold);
        }

        private void buttonMin_Click(object sender, EventArgs e)
        {
            trackBar1.Value = Math.Max(0, trackBar1.Value - 1);
            trackBar1_Scroll(trackBar1, null);
        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//按下的是鼠标左键            
            {
                FormMain.ReleaseCapture();
                Capture = false;//释放鼠标使能够手动操作                
                FormMain.SendMessage(Handle, 0x0112, 0xf010 + 0x0002, 0);//拖动窗体            
            }
        }

        private void panelTop_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Capture = true;
        }

        private void imageButtonClose_Click(object sender, EventArgs e)
        {
            voice.StopSpeaker();
            Close();
        }
    }
}
