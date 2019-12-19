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

        int m_chapterId = 0;
        int m_bankId = 0;
        int m_skillId = 0;
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

                if (!string.IsNullOrEmpty(dataRow["chapter_id"].ToString()))
                    m_chapterId = Convert.ToInt32(dataRow["chapter_id"]);


                if (!string.IsNullOrEmpty(dataRow["skill_id"].ToString()))
                    m_skillId = Convert.ToInt32(dataRow["skill_id"]);


                if (!string.IsNullOrEmpty(dataRow["bank_id"].ToString()))
                    m_bankId = Convert.ToInt32(dataRow["bank_id"]);

                ///更新分类
                int classificationId = Convert.ToInt32(dataRow["classification"]);
                comboBoxClassification.Items.Clear();
                comboBoxClassification.BeginUpdate();
                for (int i = 1; i < Question._ModelClassificationInfo.Length; i++)
                {
                    comboBoxClassification.Items.Add(Question._ModelClassificationInfo[i]);
                }
                comboBoxClassification.EndUpdate();
                comboBoxClassification.SelectedIndex = classificationId - 1;

                //更新分组
                UpdateGroups(m_chapterId, m_skillId, m_bankId);

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
                textBoxTittleImage.Text = question.ImagePath;
                textBoxTittleImage.Text = Directory.GetCurrentDirectory() + "\\Images\\" + Path.GetFileName(question.ImagePath);
                _pathImage = textBoxTittleImage.Text;
            }
            
            if (!string.IsNullOrEmpty(question.FlashPath))
            {
                
                textBoxTittleImage.Text = question.FlashPath;
                textBoxTittleImage.Text = Directory.GetCurrentDirectory() + "\\Flash\\" + Path.GetFileName(question.FlashPath);
                _pathFlash = textBoxTittleImage.Text;
            }

            if(question.Options != null&& question.Options.Count > 0)
            {
                textBoxOptionA.Text = question.Options[0];
                //if(string.IsNullOrEmpty(textBoxOptionA.Text) && question.Type == 1)
                //	textBoxOptionA.Text = "正确";
                //            textBoxOptionB.Text = question.Options[1];
                //if(string.IsNullOrEmpty(textBoxOptionB.Text) && question.Type == 1)
                //	textBoxOptionB.Text = "错误";
                textBoxOptionB.Text = question.Options[1];
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
        }

        private bool BindUIToQuestion(out Question question)
        {
            question = new Question();
            question.Tittle = richTextBoxTittle.Text;
            question.Classification = comboBoxClassification.SelectedIndex + 1;
            question.TittleEmphasize = string.IsNullOrEmpty(textBoxEmphasize.Text)?"" : textBoxEmphasize.Text;
            question.SkillNotice = string.IsNullOrEmpty(richTextBoxSkillNotice.Text) ? "" : richTextBoxSkillNotice.Text;
            question.SkillNotice = question.SkillNotice.Replace("\n", "&");

            if (comboBoxChapter.SelectedItem != null)
            {

                ChapterInfo chapterInfo = (ChapterInfo)comboBoxChapter.SelectedItem;
                question.Module = chapterInfo.ID;
            }
            else
            {
                question.Module = 0;
            }

            if (!string.IsNullOrEmpty(textBoxTittleImage.Text))
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
            else
            {
                question.ImagePath = "";
                question.FlashPath = "";
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

            question.Options = new List<string>();
            question.Options.Clear();
            question.Options.Add(textBoxOptionA.Text);
            question.Options.Add(textBoxOptionB.Text);
            question.Options.Add(textBoxOptionC.Text);
            question.Options.Add(textBoxOptionD.Text);

            question.OptionsEmphasize = new List<string>();
            question.OptionsEmphasize.Clear();
            question.OptionsEmphasize.Add(textBoxEmphasizeA.Text);
            question.OptionsEmphasize.Add(textBoxEmphasizeB.Text);
            question.OptionsEmphasize.Add(textBoxEmphasizeC.Text);
            question.OptionsEmphasize.Add(textBoxEmphasizeD.Text);

            question.CorrectAnswer = new List<int>();
            question.CorrectAnswer.Clear();
            if(checkBoxA.Checked)
				question.CorrectAnswer.Add(1);
			if(checkBoxB.Checked)
				question.CorrectAnswer.Add(2);
			if(checkBoxC.Checked)
				question.CorrectAnswer.Add(3);
			if(checkBoxD.Checked)
				question.CorrectAnswer.Add(4);

            question.Answers = new List<int>();
            question.Answers.Add(checkBoxA.Checked ? 1 : 0);
            question.Answers.Add(checkBoxB.Checked ? 1 : 0);
            question.Answers.Add(checkBoxC.Checked ? 1 : 0);
            question.Answers.Add(checkBoxD.Checked ? 1 : 0);

            return true;
        }

        /// <summary>
        /// 更新选项信息
        /// </summary>
        private void UpdateOptionInfo()
        {
            return;
            if (radioButtonType2.Checked == true)
            {
                textBoxEmphasizeC.Visible = true;
                textBoxEmphasizeD.Visible = true;
                textBoxOptionC.Visible = true;
                textBoxOptionD.Visible = true;

                labelC.Visible = true;
                labelD.Visible = true;
                labelImageC.Visible = true;
                labelImageD.Visible = true;

                textBoxOptionA.Text = m_question.Options[0];
                textBoxOptionB.Text = m_question.Options[1];
                textBoxOptionC.Text = m_question.Options[2];
                textBoxOptionD.Text = m_question.Options[3];

                textBoxEmphasizeA.Text = m_question.OptionsEmphasize[0];
                textBoxEmphasizeB.Text = m_question.OptionsEmphasize[1];
                textBoxEmphasizeC.Text = m_question.OptionsEmphasize[2];
                textBoxEmphasizeD.Text = m_question.OptionsEmphasize[3];

                textBoxOptionA.Enabled = true;
                textBoxOptionB.Enabled = true;
                checkBoxC.Visible = true;
                checkBoxD.Visible = true;
            }
            else
            {
                //textBoxCorrectAnswer.Text = "";
                //textBoxEmphasizeC.Visible = false;
                //textBoxEmphasizeD.Visible = false;
                //textBoxOptionC.Visible = false;
                //textBoxOptionD.Visible = false;
                //buttonBrowseC.Visible = false;
                //buttonBrowseD.Visible = false;
                //labelC.Visible = false;
                //labelD.Visible = false;
                //labelImageC.Visible = false;
                //labelImageD.Visible = false;
                textBoxEmphasizeA.Text = m_question.OptionsEmphasize[0];
                textBoxEmphasizeB.Text = m_question.OptionsEmphasize[1];
                textBoxOptionA.Text = "对";
                textBoxOptionB.Text = "错";
                textBoxOptionA.Enabled = false;
                textBoxOptionB.Enabled = false;
				//checkBoxC.Visible = false;
				//checkBoxD.Visible = false;
            }
        }

        private void radioButtonType2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateOptionInfo();
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

            BindUIToQuestion(out Question question);

            if (true == QuestionManagerSql.UpdateQuestion(question, m_question))
            {
                //MessageBox.Show("保存题目信息成功，题目id:" + m_question.Id.ToString() + ".", "提示信息", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("保存题目信息失败，题目id:" + m_question.Id.ToString() + "请检查题目信息！", "提示信息", MessageBoxButtons.OK);
                return;
            }


            ChapterInfo chapterSkill = (ChapterInfo)comboBoxSkill.SelectedItem;

            bool result = false;
            if (chapterSkill.ID != m_skillId)
            {
                if (chapterSkill.ID == 0)
                {
                    result = QuestionManagerSql.DeleteQuestionGroup(m_question.Id, m_skillId);
                }
                else
                {
                    result = QuestionManagerSql.UpdateQuestionGroup(m_question.Id, chapterSkill.ID, m_skillId, 1);
                }
                if (result)
                {
                    //MessageBox.Show("保存技巧信息成功，题目id:" + m_question.Id.ToString() + ".", "提示信息", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("保存技巧信息失败，题目id:" + m_question.Id.ToString() + "技巧ID：" + m_skillId + "新的技巧ID：" + chapterSkill.ID + "请检查题目信息！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            result = false;
            ChapterInfo chapterBank = (ChapterInfo)cboxBank.SelectedItem;
            if(chapterBank.ID != m_bankId)
            {
                if(chapterBank.ID == 0)
                {
                    result = QuestionManagerSql.DeleteQuestionGroup(m_question.Id, m_bankId);
                }
                else
                {
                    result = QuestionManagerSql.UpdateQuestionGroup(m_question.Id, chapterBank.ID, m_bankId, 2);
                }

                if (result)
                {
                    //MessageBox.Show("保存强化信息成功，题目id:" + m_question.Id.ToString() + ".", "提示信息", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("保存强化信息失败，题目id:" + m_question.Id.ToString() + "强化ID：" + m_skillId + "新的强化ID：" + chapterSkill.ID + "请检查题目信息！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            DialogResult = DialogResult.Yes;
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
