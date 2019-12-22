using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirvingTest
{
    public partial class FormTrainErrorInfo : Form
    {
        string _imagePath = "";
        string _flashPath = "";

        public FormTrainErrorInfo()
        {
            InitializeComponent();
        }

        int ParentWidth = 1000;
        public void SetInfo(Question question, int id, int parentWidth, bool isTrain=false)
        {
            //labelTitle.Text = id + "." + question.Tittle;
            ParentWidth = parentWidth;

            if (question.Type > 1)
            {
                //labelA.Text = "A." + question.Options[0];
                //labelB.Text = "B." + question.Options[1];
                //labelC.Text = "C." + question.Options[2];
                //labelD.Text = "D." + question.Options[3];

                string rightAnswer = "";

                for (int i = 0; i < question.CorrectAnswer.Count; i++)
                {
                    if (1 == question.CorrectAnswer[i])
                        rightAnswer += "A";
                    else if (2 == question.CorrectAnswer[i])
                        rightAnswer += "B";
                    else if (3 == question.CorrectAnswer[i])
                        rightAnswer += "C";
                    else
                        rightAnswer += "D";
                }

                labelRightAnswer.Text = rightAnswer;
            }
            else
            {
                //labelA.Text = "";
                //labelB.Text = "";
                //labelC.Text = "";
                //labelD.Text = "";

                if (1 == question.CorrectAnswer[0])
                {
                    labelRightAnswer.Text = "对";
                }
                else
                {
                    labelRightAnswer.Text = "错";
                }    
            }

            _imagePath = question.ImagePath;
            _flashPath = question.FlashPath;

            if (isTrain)
            {
                labelNormalNotice.Text = question.SkillNotice;
            }
            else
            {
                labelNormalNotice.Text = question.NormalNotice;
                timer1.Start();
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormSimulationErrorInfo_Shown(object sender, EventArgs e)
        {
            Left = ParentWidth * 2 / 3;
            Top = 50;

            if (string.IsNullOrEmpty(_imagePath) && string.IsNullOrEmpty(_flashPath))
            {
                panel1Image.Visible = false;
            }
            else
            {
                panel1Image.Visible = true;
                if (string.IsNullOrEmpty(_imagePath))
                {
                    axShockwaveFlash1.BringToFront();
                    axShockwaveFlash1.Movie = Directory.GetCurrentDirectory() + "\\Flash\\" + Path.GetFileName(_flashPath);
                    
                    axShockwaveFlash1.Rewind();
                    axShockwaveFlash1.Play();
                }
                else
                {
                    pictureBox1.BringToFront();
                    pictureBox1.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\Images\\" + Path.GetFileName(_imagePath));
                }
            }

            //TODO:阅读技巧
            VoiceHelper _voiceHelper = VoiceHelper.getVoiceHelper();
            string info = labelNormalNotice.Text.ToString();
            System.Threading.Thread td = new System.Threading.Thread(() => {
                _voiceHelper = VoiceHelper.getVoiceHelper();
                _voiceHelper.Speeker(info);
            });
            td.IsBackground = true;
            td.Start();

        }

    }
}
