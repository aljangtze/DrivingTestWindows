using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DirvingTest
{
    public partial class FormQuestionDetailsSql : Form
    {
        private FormBigImage formBig = new FormBigImage();
        private string _pathImage = "";
        private string _pathFlash = "";
        public delegate bool WantSendBack(Question model, bool Replace);

        public Question m_question = null;
        List<int> m_CorrectAnswer = new List<int>();
        public FormQuestionDetailsSql()
        {
            InitializeComponent();
        }
        
        public void SetDataInfo(DataRow dataRow)
        {
            textBoxEmphasizeA.Text = "";
            textBoxEmphasizeB.Text = "";
            textBoxEmphasizeC.Text = "";
            textBoxEmphasizeD.Text = "";

            textBoxOptionA.Text = "";
            textBoxOptionB.Text = "";
            textBoxOptionC.Text = "";
            textBoxOptionD.Text = "";

            _pathImage = "";
            _pathFlash = "";

            try
            {
                int chapterId = 0;
                if (!string.IsNullOrEmpty(dataRow["chapter_id"].ToString()))
                    chapterId = Convert.ToInt32(dataRow["chapter_id"]);

                int skillId = 0;
                if (!string.IsNullOrEmpty(dataRow["skill_id"].ToString()))
                    skillId = Convert.ToInt32(dataRow["skill_id"]);

                int bankId = 0;
                if (!string.IsNullOrEmpty(dataRow["bank_id"].ToString()))
                    bankId = Convert.ToInt32(dataRow["bank_id"]);

                int classificationId = Convert.ToInt32(dataRow["classification"]);

                comboBoxClassification.Items.Clear();
                comboBoxClassification.BeginUpdate();
                for (int i = 1; i < Question._ModelClassificationInfo.Length; i++)
                {
                    comboBoxClassification.Items.Add(Question._ModelClassificationInfo[i]);
                }
                comboBoxClassification.EndUpdate();
                comboBoxClassification.SelectedIndex = classificationId - 1;

                UpdateUI(chapterId, skillId, bankId, classificationId);

                int id = Convert.ToInt32(dataRow["id"]);
                BindUIByQuesiton(id);

                UpdateOptionInfo();
                richTextBoxTittle.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载题目信息失败", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 更新分类
        /// </summary>
        private void UpdateUI( int chapterId, int skillId, int bankId, int classificationId)
        {

            UpdateGroups(chapterId, skillId, bankId);

            richTextBoxTittle.Focus();
        }

        /// <summary>
        /// 更新技巧和章节信息
        /// </summary>
        private void UpdateGroups(int ChapterId, int SkillId,  int bankId)
        {

            comboBoxChapter.Items.Clear();
            comboBoxChapter.BeginUpdate();
            int index = 0;
            ChapterInfo chapterNull = new ChapterInfo();
            chapterNull.ID = 0;
            chapterNull.Name = "未分类";

            comboBoxChapter.Items.Add(chapterNull);

            ChapterManager.GetChapterList(0, out List<ChapterInfo> chapterInfos);
            int i = 0;
            foreach (var chapterInfo in chapterInfos)
            {
                i++;
                comboBoxChapter.Items.Add(chapterInfo);
                if (chapterInfo.ID == ChapterId)
                    index = i;
            }

            comboBoxChapter.SelectedIndex = index;
            comboBoxChapter.EndUpdate();

            comboBoxSkill.Items.Clear();

            comboBoxSkill.BeginUpdate();
            index = 0;
            ChapterInfo skillNull = new ChapterInfo();
            skillNull.ID = 0;
            skillNull.Name = "未分类";
            comboBoxSkill.Items.Add(skillNull);

            ChapterManager.GetChapterList(1, out List<ChapterInfo> chapterSkills);
            i = 0;
            foreach (var chapterInfo in chapterSkills)
            {
                i++;
                comboBoxSkill.Items.Add(chapterInfo);
                if (chapterInfo.ID == SkillId)
                    index = i;
            }
            comboBoxSkill.SelectedIndex = index;
            comboBoxSkill.EndUpdate();

            cboxBank.Items.Clear();
            cboxBank.BeginUpdate();
            index = 0;
            ChapterInfo bankNull = new ChapterInfo();
            bankNull.ID = 0;
            bankNull.Name = "未分类";
            cboxBank.Items.Add(bankNull);

            ChapterManager.GetChapterList(2, out List<ChapterInfo> chapterBanks);
            i = 0;
            foreach (var chapterInfo in chapterBanks)
            {
                i++;
                cboxBank.Items.Add(chapterInfo);
                if (chapterInfo.ID == bankId)
                    index = i;
            }
            cboxBank.SelectedIndex = index;
            cboxBank.EndUpdate();
        }

        /// <summary>
        /// 绑定question到界面
        /// </summary>
        /// <param name="question"></param>
        private void BindUIByQuesiton(int question_id)
        {
            if (false == QuestionManager.GetQuestionFromDB(question_id, out m_question))
                return;

            Question question = m_question;
            richTextBoxTittle.Text =question.Tittle;
            lblIdInfo.Text = question.Id.ToString();
            richTextBoxSkillNotice.Text = question.SkillNotice.Replace("&", "\n");
            if (question.Type == 1)
                radioButtonType1.Checked = true;
            else
                radioButtonType2.Checked = true;

            comboBoxClassification.SelectedIndex = question.Classification - 1;

            textBoxEmphasize.Text = question.TittleEmphasize;
            textBoxTittleImage.Text = "";
            if (!string.IsNullOrEmpty(question.ImagePath))
            {
                textBoxTittleImage.Text = Directory.GetCurrentDirectory() + "\\Images\\" + Path.GetFileName(question.ImagePath);
                _pathImage = textBoxTittleImage.Text;
            }
            if (!string.IsNullOrEmpty(question.FlashPath))
            {
                textBoxTittleImage.Text = Directory.GetCurrentDirectory() + "\\Flash\\" + Path.GetFileName(question.FlashPath);
                _pathFlash = textBoxTittleImage.Text;
            }

            if(question.Options != null&& question.Options.Count > 0)
            {
                textBoxOptionA.Text = question.Options[0];
				if(string.IsNullOrEmpty(textBoxOptionA.Text) && question.Type == 1)
					textBoxOptionA.Text = "正确";
                textBoxOptionB.Text = question.Options[1];
				if(string.IsNullOrEmpty(textBoxOptionB.Text) && question.Type == 1)
					textBoxOptionB.Text = "错误";
                textBoxOptionC.Text = question.Options[2];
                textBoxOptionD.Text = question.Options[3];
                
            }
            if(question.OptionsEmphasize != null && question.OptionsEmphasize.Count > 0)
            {
                for (int i = 0; i < question.OptionsEmphasize.Count; i++)
                {
                    textBoxEmphasizeA.Text = question.OptionsEmphasize[0];
                    textBoxEmphasizeB.Text = question.OptionsEmphasize[1];
                    textBoxEmphasizeC.Text = question.OptionsEmphasize[2];
                    textBoxEmphasizeD.Text = question.OptionsEmphasize[3];
                }
            }

            //string rightAnswer = "";
            foreach(var correct in question.CorrectAnswer)
            {
				if(correct == 1)
					checkBoxA.Checked = true;
				if(correct == 2)
					checkBoxB.Checked = true;
				if(correct == 3)
					checkBoxC.Checked = true;
				if(correct == 4)
					checkBoxD.Checked = true;
            }

            //textBoxCorrectAnswer.Text = rightAnswer;
        }

        private void BindUIToQuestion()
        {
            Question question = m_question;
            question.Tittle = richTextBoxTittle.Text;
            question.Classification = comboBoxClassification.SelectedIndex + 1;
            ChapterInfo modelSkill = ((KeyValuePair<int,ChapterInfo>)comboBoxSkill.SelectedItem).Value;
            if (null == modelSkill)
                question.Skill = 0;
            else
                question.Skill = modelSkill.ID;


            ChapterInfo modelBank = ((KeyValuePair<int, ChapterInfo>)cboxBank.SelectedItem).Value;
            if (null == modelBank)
                question.BankId = 0;
            else
                question.BankId = modelBank.ID;

            ChapterInfo modelChapter = ((KeyValuePair<int, ChapterInfo>)comboBoxChapter.SelectedItem).Value;
            question.Module = modelChapter.ID;
            question.TittleEmphasize = string.IsNullOrEmpty(textBoxEmphasize.Text)?"" : textBoxEmphasize.Text;
            question.SkillNotice = string.IsNullOrEmpty(richTextBoxSkillNotice.Text) ? "" : richTextBoxSkillNotice.Text;
            question.SkillNotice = question.SkillNotice.Replace("\n", "&");
            if(!string.IsNullOrEmpty(textBoxTittleImage.Text))
            {
                string extension = Path.GetExtension(_pathImage);
                if(!string.IsNullOrEmpty(_pathImage))
                {
                    question.ImagePath = question.Id.ToString() + Path.GetExtension(_pathImage);
                }
                if(!string.IsNullOrEmpty(_pathFlash))
                {
                    question.FlashPath = question.Id.ToString() + Path.GetExtension(_pathFlash);
                }
            }


            if (radioButtonType1.Checked == true)
                question.Type = 1;
            else
                question.Type = 2;
			
			int answerCount = 0;
			if(checkBoxA.Checked == true)
				answerCount++;
			if(checkBoxB.Checked == true)
				answerCount++;
			if(checkBoxC.Checked == true)
				answerCount++;
			if(checkBoxD.Checked == true)
				answerCount++;

            if (answerCount > 1)
                question.Type = 3;

            question.Options.Clear();
            question.Options.Add(textBoxOptionA.Text);
            question.Options.Add(textBoxOptionB.Text);
            question.Options.Add(textBoxOptionC.Text);
            question.Options.Add(textBoxOptionD.Text);

            question.OptionsEmphasize.Clear();
            question.OptionsEmphasize.Add(textBoxEmphasizeA.Text);
            question.OptionsEmphasize.Add(textBoxEmphasizeB.Text);
            question.OptionsEmphasize.Add(textBoxEmphasizeC.Text);
            question.OptionsEmphasize.Add(textBoxEmphasizeD.Text);

            question.CorrectAnswer.Clear();
            if(checkBoxA.Checked)
				question.CorrectAnswer.Add(1);
			if(checkBoxB.Checked)
				question.CorrectAnswer.Add(2);
			if(checkBoxC.Checked)
				question.CorrectAnswer.Add(3);
			if(checkBoxD.Checked)
				question.CorrectAnswer.Add(4);
        }

        /// <summary>
        /// 更新选项信息
        /// </summary>
        private void UpdateOptionInfo()
        {
			checkBoxA.Checked = false;
			checkBoxB.Checked = false;
			checkBoxC.Checked = false;
			checkBoxD.Checked = false;
            if (radioButtonType2.Checked == true)
            {
                //textBoxCorrectAnswer.Text = "";
                textBoxEmphasizeC.Visible = true;
                textBoxEmphasizeD.Visible = true;
                textBoxOptionC.Visible = true;
                textBoxOptionD.Visible = true;
                //buttonBrowseC.Visible = true;
                //buttonBrowseD.Visible = true;

                labelC.Visible = true;
                labelD.Visible = true;
                labelImageC.Visible = true;
                labelImageD.Visible = true;

                textBoxOptionA.Text = m_question.Options[0];
                textBoxOptionB.Text = m_question.Options[1];
                textBoxOptionA.Enabled = true;
                textBoxOptionB.Enabled = true;
				checkBoxC.Visible = true;
				checkBoxD.Visible = true;
            }
            else
            {
                //textBoxCorrectAnswer.Text = "";
                textBoxEmphasizeC.Visible = false;
                textBoxEmphasizeD.Visible = false;
                textBoxOptionC.Visible = false;
                textBoxOptionD.Visible = false;
                buttonBrowseC.Visible = false;
                buttonBrowseD.Visible = false;
                labelC.Visible = false;
                labelD.Visible = false;
                labelImageC.Visible = false;
                labelImageD.Visible = false;
                textBoxOptionA.Text = "正确";
                textBoxOptionB.Text = "错误";
                textBoxOptionA.Enabled = false;
                textBoxOptionB.Enabled = false;
				checkBoxC.Visible = false;
				checkBoxD.Visible = false;
            }
        }

        private void radioButtonType2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateOptionInfo();
        }

        private void textBoxCorrectAnswer_TextChanged(object sender, EventArgs e)
        {
            // m_CorrectAnswer.Clear();
            // string answerString = textBoxCorrectAnswer.Text;
            // string strAnswerResult = "";
            // if (answerString.IndexOf("1") != -1 || answerString.IndexOf("A") != -1 || answerString.IndexOf("a") != -1)
            // {
                // strAnswerResult = strAnswerResult + "A";
                // m_CorrectAnswer.Add(1);
            // }
            // if (answerString.IndexOf("2") != -1 || answerString.IndexOf("B") != -1 || answerString.IndexOf("b") != -1)
            // {
                // strAnswerResult = strAnswerResult + "B";
                // m_CorrectAnswer.Add(2);
            // }

            // if (radioButtonType2.Checked && (answerString.IndexOf("3") != -1 || answerString.IndexOf("C") != -1 || answerString.IndexOf("c") != -1))
            // {
                // strAnswerResult = strAnswerResult + "C";
                // m_CorrectAnswer.Add(3);
            // }

            // if (radioButtonType2.Checked && (answerString.IndexOf("4") != -1 || answerString.IndexOf("D") != -1 || answerString.IndexOf("d") != -1))
            // {
                // strAnswerResult = strAnswerResult + "D";
                // m_CorrectAnswer.Add(4);
            // }

            // labelCorrectAnswer.Text = strAnswerResult;

            // if(labelCorrectAnswer.Text.Length > 1)
            // {
                // m_question.Type = 3;
            // }
        }

        private bool CheckQuestionInfo()
        {
            if(string.IsNullOrEmpty(richTextBoxTittle.Text))
            {
                MessageBox.Show("请输入题目名称！", "提示信息", MessageBoxButtons.OK);
                richTextBoxTittle.Focus();
                return false;
            }

            if(string.IsNullOrEmpty(textBoxOptionA.Text))
            {
                MessageBox.Show("请输入选项A信息！", "提示信息", MessageBoxButtons.OK);
                textBoxOptionA.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(textBoxOptionB.Text))
            {
                MessageBox.Show("请输入选项B信息！", "提示信息", MessageBoxButtons.OK);
                textBoxOptionB.Focus();
                return false;
            }

            if (radioButtonType2.Checked == true && string.IsNullOrEmpty(textBoxOptionC.Text))
            {
                MessageBox.Show("请输入选项C信息！", "提示信息", MessageBoxButtons.OK);
                textBoxOptionC.Focus();
                return false;
            }

            if (radioButtonType2.Checked == true && string.IsNullOrEmpty(textBoxOptionD.Text))
            {
                MessageBox.Show("请输入选项D信息！", "提示信息", MessageBoxButtons.OK);
                textBoxOptionD.Focus();
                return false;
            }
			
			if(checkBoxA.Checked == false
				&& checkBoxB.Checked == false
				&& checkBoxC.Checked == false
				&& checkBoxD.Checked == false)
			{
				MessageBox.Show("请选择正确答案信息！", "提示信息", MessageBoxButtons.OK);
				checkBoxA.Focus();
				return false;
			}
			else if(radioButtonType1.Checked == true)
			{
                if (checkBoxA.Checked == true && checkBoxB.Checked == true)
                {
                    MessageBox.Show("判断题只能有一个正确答案！", "提示信息", MessageBoxButtons.OK);
                    checkBoxA.Focus();
                    return false;
                }
			}

            return true;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (false == CheckQuestionInfo())
                return;

            if (DialogResult.No == MessageBox.Show("确认要保存此题目信息吗？", "确认信息", MessageBoxButtons.YesNo))
                return;

            //BindUIToQuestion();
            //if (true == FormBack(m_question, true))
            //{
            //    if(!string.IsNullOrEmpty(_pathImage))
            //    {
            //        string path = Directory.GetCurrentDirectory() + "\\Images\\" + m_question.Id.ToString() + Path.GetExtension(_pathImage);
            //        if(path != _pathImage)
            //            QuestionManager.FileCopy(_pathImage, path);
            //    }
                
            //    if(!string.IsNullOrEmpty(_pathFlash))
            //    {
            //        string path = Directory.GetCurrentDirectory() + "\\Flash\\" + m_question.Id.ToString() + Path.GetExtension(_pathFlash);
            //        if (path != _pathFlash)
            //            QuestionManager.FileCopy(_pathImage, path);
            //    }

            //    MessageBox.Show("保存题目信息成功，题目id:" + m_question.Id.ToString() + ".", "提示信息", MessageBoxButtons.OK);
            //}
            //else
            //    MessageBox.Show("保存题目信息失败，题目id:" + m_question.Id.ToString() + "请检查题目信息！", "提示信息", MessageBoxButtons.OK);

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonBrowserImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();

            openDialog.Filter = "图片文件(*.jpg,*.gif,*.bmp)|*.jpg;*.gif;*.bmp;*.png;|视频文件(*.swf)|*.swf";
            if(DialogResult.Cancel == openDialog.ShowDialog())
                return;

            if(Path.GetFileName(openDialog.FileName).IndexOf(".swf") != -1)
            {
                _pathFlash = openDialog.FileName;
            }
            else
            {
                _pathImage = openDialog.FileName;
            }

            textBoxTittleImage.Text = openDialog.FileName;
        }

        private void btnPreshow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_pathFlash) && string.IsNullOrEmpty(_pathImage))
                return;

            formBig.SetPathInfo(_pathImage, _pathFlash);
            formBig.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxTittleImage.Text = "";
        }

    }
}
