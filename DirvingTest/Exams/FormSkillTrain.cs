using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
////using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DirvingTest
{
    public partial class FormSkillTrain : Form
    {
        bool isAddControls = false;
        int _curId = 0;
        int _PrevIdx = 1;
        Question _curQuestion = null;
        
        List<Question> m_QuestionList = new List<Question>();
        List<Question> m_ErrorQuestionList = new List<Question>();
        Dictionary<int, bool> errorDictionary = new Dictionary<int, bool>();
        VoiceHelper _voiceHelper;
        public FormSkillTrain()
        {
            InitializeComponent();
            _voiceHelper = VoiceHelper.getVoiceHelper();
        }

        private void btnReadSkill_Click(object sender, EventArgs e)
        {
            _voiceHelper.Speeker(richTextBoxExplain.Text);
            panelControl.Focus();
        }

        private void FormSkillTrain_Shown(object sender, EventArgs e)
        {
            LoadUI();

            UpdateQuestion(comboxMoudle.SelectedIndex, comboxSkill.SelectedIndex);
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            labelAnswer.Text = ((Button)sender).Text;

            string rightAnswer = "";
            if(_curQuestion.Type == 1)
                rightAnswer = (1==_curQuestion.CorrectAnswer[0])?"对":"错";
            else
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append((char)(64+_curQuestion.CorrectAnswer[0]));

                rightAnswer = strBuilder.ToString();
            }

            labelRightAnswer.Text = "答案是:   " + rightAnswer;

            labelNormalExplain.Visible = true;
            if (Convert.ToInt32(((Button)sender).Tag) != _curQuestion.CorrectAnswer[0])
            {
                try
                {
                    errorDictionary.Add(_curQuestion.Id, true);
                }
                catch
                {
                }

                labelRightAnswer.ForeColor = Color.Maroon;
            }
            else
            {
                labelRightAnswer.ForeColor = Color.Green;
                if (checkBox1.Checked)
                    btnNext.PerformClick();
            }

        }

        private void ShowId(int id)
        {
            LoadNullQuestionUI();

            if(m_QuestionList.Count == 0)
            {
                MessageBox.Show("题库为空！");
                return;
            }
            labelNormalExplain.Visible = false;
            labelRightAnswer.Text = "";
            Question question = m_QuestionList[id];
            richTextBoxExplain.Text = question.SkillNotice;
            richTextBoxExplain.Font = new Font("宋体", 14);
            labelNormalExplain.Text = question.NormalNotice;

            richTextBoxTitle.Text = (id + 1) + "." + question.Tittle;
            
            richTextBoxTitle.Find(question.TittleEmphasize);
            richTextBoxTitle.SelectionFont = new Font("宋体", 18);
            richTextBoxTitle.SelectionColor = Color.DarkRed;

            richTextBoxTitle.Height = 30 * (question.Tittle.Length / (richTextBoxTitle.Width / 22)+ 1);
            if (question.Type == 0)
            {
                labelA.Text = "A. " + question.Options[0];
                labelB.Text = "B. " + question.Options[1];
                labelC.Text = "C. " + question.Options[2];
                labelD.Text = "D. " + question.Options[3];

                labelA.Top = richTextBoxTitle.Top + richTextBoxTitle.Height + 10;
                labelB.Top = labelA.Top + 34;
                labelC.Top = labelB.Top + 34;
                labelD.Top = labelC.Top + 34;

                btnRight.Visible = false;
                btnWrong.Visible = false;

                btnA.Visible = true;
                btnB.Visible = true;
                btnC.Visible = true;
                btnD.Visible = true;
            }
            else
            {
                labelA.Text = "";
                labelB.Text = "";
                labelC.Text = "";
                labelD.Text = "";

                btnRight.Visible = true;
                btnWrong.Visible = true;

                btnA.Visible = false;
                btnB.Visible = false;
                btnC.Visible = false;
                btnD.Visible = false;
            }

            if (string.IsNullOrEmpty(question.ImagePath) || string.IsNullOrEmpty(question.FlashPath))
            {
                pictureBox1.Visible = false;
                axShockwaveFlash1.Visible = false;
            }

            if (!string.IsNullOrEmpty(question.ImagePath))
            {
                pictureBox1.BringToFront();
                pictureBox1.Visible = true;
                if (null != pictureBox1.Image)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }

                pictureBox1.Image = Image.FromFile(Directory.GetCurrentDirectory() + "\\" + question.ImagePath);
            }
            else
            {
                if (null != pictureBox1.Image)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;

                }
                pictureBox1.SendToBack();
            }

            if (!string.IsNullOrEmpty(question.FlashPath))
            {
                axShockwaveFlash1.Visible = true;
                axShockwaveFlash1.BringToFront();
                if (string.IsNullOrEmpty(axShockwaveFlash1.Movie))
                {
                    axShockwaveFlash1.Stop();
                    axShockwaveFlash1.Movie = null;
                }

                axShockwaveFlash1.Movie = Directory.GetCurrentDirectory() + "\\" + question.FlashPath;
                this.axShockwaveFlash1.Rewind();
                this.axShockwaveFlash1.Play();
            }
            else
            {
                if(string.IsNullOrEmpty(axShockwaveFlash1.Movie))
                {
                    axShockwaveFlash1.Stop();
                    axShockwaveFlash1.Movie = null;
                    
                }
                axShockwaveFlash1.SendToBack();
            }

            labelAnswer.Text = "";

            _curQuestion = question;

            _PrevIdx = id;
            _curId = id;

            textBoxPage.Text = (_curId+1).ToString();

            btnPrevious.Enabled = (id != 0);
            btnNext.Enabled = (id != m_QuestionList.Count - 1);

        }

        private void UpdateQuestion(int moudleId, int skillId)
        {
            errorDictionary.Clear();
            m_QuestionList.Clear();

            if (moudleId == 0 && skillId == 0)
            {
                m_QuestionList.AddRange(QuestionManager.m_QuestionsList);
            }
            else
            {
                foreach (var question in QuestionManager.m_QuestionsList)
                {
                    if (question.Module == 0)
                        continue;

                    if ((moudleId == 0 || question.Module == moudleId)
                        && (question.Skill == skillId || skillId == 0))
                    {
                        m_QuestionList.Add(question);
                    }
                }
            }

            errorDictionary.Clear();
            _curId = 0;
            _PrevIdx = 0;

            ShowId(_curId);

            labelQuestionCount.Text = "共 " + m_QuestionList.Count + " 题";
        }

        private void LoadUI()
        {
            isAddControls = false;
            comboxMoudle.Items.Clear();
            comboxMoudle.Items.Add("全部");
            foreach (var item in SystemConfig.Subject1MoudleInfo)
            {
                comboxMoudle.Items.Add(item);
            }

            foreach(var item in SystemConfig.Subject2MoudleInfo)
            {
                comboxMoudle.Items.Add(item);
            }
            comboxMoudle.SelectedIndex = 0;

            comboxSkill.Items.Clear();
            comboxSkill.Items.Add("全部");
            foreach(var item in SystemConfig.SkillMoudleInfo)
            {
                comboxSkill.Items.Add(item);
            }
            comboxSkill.SelectedIndex = 0;

            isAddControls = true;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            _voiceHelper.StopSpeaker();
            ShowPrevious();
        }

        private void ShowPrevious()
        {
            if (_PrevIdx <= 0)
            {
                MessageBox.Show("已经是第一题了");
                return;
            }

            _PrevIdx--;
            ShowId(_PrevIdx);
        }

        void ShowNext()
        {
            if (m_QuestionList.Count <= _curId + 1)
            {
                MessageBox.Show("已经答完全部题目");
                return;
            }

            ShowId(_curId + 1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _voiceHelper.StopSpeaker();
            labelAnswer.Text = "";
            ShowNext();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            _voiceHelper.StopSpeaker();

            try
            {
                int value = Convert.ToInt32(textBoxPage.Text);

                if (value == _curId)
                    return;

                if (value <= 0)
                {
                    textBoxPage.Text = _curId.ToString();
                    return;
                }
                if (value > m_QuestionList.Count)
                {
                    textBoxPage.Text = m_QuestionList.Count.ToString();
                    return;
                }

                ShowId(value - 1);
            }
            catch
            {

            }
           
        }

        private void comboxSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadNullQuestionUI();
            if (isAddControls == false || DialogResult.Cancel == MessageBox.Show("更改模块将重新加载题库，是否重新加载？", "提示信息！", MessageBoxButtons.OKCancel))
                return;

            UpdateQuestion(comboxMoudle.SelectedIndex, comboxSkill.SelectedIndex);
        }

        private void comboxMoudle_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadNullQuestionUI();
            if (isAddControls == false || DialogResult.Cancel == MessageBox.Show("更改模块将重新加载题库，是否重新加载？", "提示信息！", MessageBoxButtons.OKCancel))
                return;

            UpdateQuestion(comboxMoudle.SelectedIndex, comboxSkill.SelectedIndex);
        }

        private void textBoxPage_Leave(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(textBoxPage.Text);

                if (value == _curId)
                    return;

                if(value <=0 )
                {
                    textBoxPage.Text = _curId.ToString();
                    return;
                }
                if (value > m_QuestionList.Count)
                {
                    textBoxPage.Text = m_QuestionList.Count.ToString();
                    return;
                }
            }
            catch
            {

            }
        }

        private void textBoxPage_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnGo.PerformClick();
            }
        }

        private void GetErrrList()
        {
            foreach(var question in m_QuestionList)
            {                
                bool isError = false;
                errorDictionary.TryGetValue(question.Id, out isError);
                if(isError)
                {
                    m_ErrorQuestionList.Add(question);
                }
            }

            _curId = 0;
            _PrevIdx = 1;
            m_QuestionList.Clear();
            m_QuestionList = m_ErrorQuestionList;
            ShowId(_curId);

            labelQuestionCount.Text = "共 " + m_QuestionList.Count + " 题";
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (errorDictionary.Count == 0)
            {
                MessageBox.Show("你真厉害，没有做错!", "提示信息!", MessageBoxButtons.OK);
                return;
            }

            if (DialogResult.Cancel == MessageBox.Show("重做错题将丢失当前进度，是否重做？", "提示信息！", MessageBoxButtons.OKCancel))
                return;

            GetErrrList();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            richTextBoxExplain.Font = new Font("宋体", trackBar1.Value + 10);
        }

        private void LoadNullQuestionUI()
        {
            richTextBoxTitle.Text = "题目";
            labelNormalExplain.Text = "一般解释";
            labelA.Text = "A";
            labelB.Text = "B";
            labelC.Text = "C";
            labelD.Text = "D";
            richTextBoxExplain.Text = "技巧解析";
            labelRightAnswer.Text = "正确答案";
        }
    }
}
