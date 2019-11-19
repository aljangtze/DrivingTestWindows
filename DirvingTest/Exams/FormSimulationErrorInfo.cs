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
    public partial class FormSimulationErrorInfo : Form
    {
        string _imagePath = "";
        string _flashPath = "";

        public FormSimulationErrorInfo()
        {
            InitializeComponent();
        }

        public void SetInfo(Question question, int id)
        {
            labelTitle.Text = id + "." + question.Tittle;

            if (question.Type > 1)
            {
                labelA.Text = "A." + question.Options[0];
                labelB.Text = "B." + question.Options[1];
                labelC.Text = "C." + question.Options[2];
                labelD.Text = "D." + question.Options[3];

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
                labelA.Text = "";
                labelB.Text = "";
                labelC.Text = "";
                labelD.Text = "";

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
            labelNormalNotice.Text = question.NormalNotice;
            
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
        }

    }
}
