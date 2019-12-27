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
    public partial class FormQuestionManage : Form, InterfaceForm
    {
        FormQuestionDetails m_details = null;
        public FormQuestionManage()
        {
            InitializeComponent();
        }

        private void FormQuestionManage_Load(object sender, EventArgs e)
        {
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleTurquoise;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Rows.Clear();

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView1.RowsDefaultCellStyle.WrapMode = (DataGridViewTriState.True);

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            m_details = new FormQuestionDetails();
             m_details.FormBack += SendBack;
            m_details.TopLevel = false;
            m_details.Parent = this.panelDetails;
        }

        private void FormQuestionManage_Shown(object sender, EventArgs e)
        {
            ChapterInfo modelNull = new ChapterInfo();
            modelNull.ID = 0;
            modelNull.Name = "全部";

            ChapterInfo modelNotSplit = new ChapterInfo();
            modelNotSplit.ID = -1;
            modelNotSplit.Name = "未分类";

            comboBoxChapter.Items.Add(modelNull);
            foreach (var model in ModelManager.m_DicMoudleList)
            {
                comboBoxChapter.Items.Add(model);
            }

            comboBoxSkill.Items.Add(modelNull);
            foreach(var model in ModelManager.m_DicSkillList)
            {
                comboBoxSkill.Items.Add(model.Value);
            }
            comboBoxSkill.Items.Add(modelNotSplit);

            comboBoxBank.Items.Add(modelNull);
            foreach(var model in ModelManager.m_DicBankList)
            {
                comboBoxBank.Items.Add(model.Value);
            }
            comboBoxBank.Items.Add(modelNotSplit);

            comboBoxBank.SelectedIndex = 0;
            comboBoxSkill.SelectedIndex = 0;
            comboBoxChapter.SelectedIndex = 1;
            

            foreach (var classification in Question._ModelClassificationInfo)
            {
                comboBoxClassification.Items.Add(classification);
            }
            comboBoxClassification.SelectedIndex = 0;

            foreach (var typeInfo in Question._TypeInfo)
            {
                comboBoxType.Items.Add(typeInfo);
            }
            comboBoxType.SelectedIndex = 0;

            RefreshQuestions();
        }

        private void AddItem(Question question)
        {
            if(!string.IsNullOrEmpty(textBoxFilterTittle.Text))
            {
                if (question.Tittle.IndexOf(textBoxFilterTittle.Text) == -1)
                    return;
            }

            if(!string.IsNullOrEmpty(textBoxFilterOptions.Text))
            {
                bool isFind = false;
                foreach(var info in question.Options)
                {
                    if (info.IndexOf(textBoxFilterOptions.Text) != -1)
                        isFind = true;
                }

                if (isFind == false)
                    return;
            }

            DataGridViewRow row = new DataGridViewRow();
            DataGridViewCheckBoxCell chkBoxCell = new DataGridViewCheckBoxCell();
            chkBoxCell.Value = false;
            chkBoxCell.Tag = question;
            row.Cells.Add(chkBoxCell);

            DataGridViewTextBoxCell txtBox1 = new DataGridViewTextBoxCell();
            txtBox1.Value = Convert.ToInt32(dataGridView1.Rows.Count + 1);
            //txtBox1.Tag = question.Id.ToString();
            txtBox1.ToolTipText = "ID=" + question.Id.ToString();
            row.Cells.Add(txtBox1);
            txtBox1.ReadOnly = true;

            DataGridViewTextBoxCell txtBox2 = new DataGridViewTextBoxCell();
            txtBox2.Value = question.Tittle;
            txtBox2.ToolTipText = question.Tittle;
            row.Cells.Add(txtBox2);
            txtBox2.ReadOnly = true;

            //这个类别不正确
            DataGridViewTextBoxCell txtBox3 = new DataGridViewTextBoxCell();
            
            if(question.Classification == 0)
                txtBox3.Value = "未分类";
            else
                txtBox3.Value = Question._ModelClassificationInfo[question.Classification];

            txtBox3.ToolTipText = "题目类别";
            

            row.Cells.Add((DataGridViewTextBoxCell)txtBox3);
            txtBox3.ReadOnly = true;
            //txtBox3.Tag = question.Type;


            DataGridViewTextBoxCell txtBox4 = new DataGridViewTextBoxCell();
            txtBox4.Value = Question._TypeInfo[question.Type];
            if (question.Type == 1)
                txtBox4.ToolTipText = "题目类型";
            else
            {
                string questionOptions = "";
                for (int i=1; i<=question.Options.Count; i++)
                {
                    var option = question.Options[i-1];
                    questionOptions += i.ToString() + "." + option + "  ";
                }
                txtBox4.ToolTipText = questionOptions;
            }
            row.Cells.Add((DataGridViewTextBoxCell)txtBox4);
            //txtBox4.Tag = question.Type;
            txtBox4.ReadOnly = true;


            DataGridViewTextBoxCell txtBox5 = new DataGridViewTextBoxCell();
            ChapterInfo model = new ChapterInfo();
            ModelManager.m_DicMoudleList.TryGetValue(question.Module, out model);
            if(model == null)
            {
                txtBox5.Value = "未分类";
                txtBox5.ToolTipText = "未分类";
            }
            else
            {
                txtBox5.Value = model.Name;
                txtBox5.ToolTipText = model.Name;
            }
            row.Cells.Add((DataGridViewTextBoxCell)txtBox5);
            txtBox5.ReadOnly = true;


            DataGridViewTextBoxCell txtBox6 = new DataGridViewTextBoxCell();
           // txtBox6.Tag = question.Skill;
            ChapterInfo modelSkill = null;
            ModelManager.m_DicSkillList.TryGetValue(question.Skill, out modelSkill);
            if (modelSkill == null)
            {
                txtBox6.Value = "未分类";
                txtBox6.ToolTipText = "未分类";
            }
            else
            {
                txtBox6.Value = modelSkill.Name;
                txtBox6.ToolTipText = modelSkill.Name;
            }
            row.Cells.Add((DataGridViewTextBoxCell)txtBox6);
            txtBox6.ReadOnly = true;

            DataGridViewTextBoxCell txtBox7 = new DataGridViewTextBoxCell();
            // txtBox6.Tag = question.Skill;
            ChapterInfo modelBank = null;
            ModelManager.m_DicBankList.TryGetValue(question.BankId, out modelBank);
            if (modelBank == null)
            {
                txtBox7.Value = "未分类";
                txtBox7.ToolTipText = "未分类";
            }
            else
            {
                txtBox7.Value = modelBank.Name;
                txtBox7.ToolTipText = modelBank.Name;
            }
            row.Cells.Add((DataGridViewTextBoxCell)txtBox7);
            txtBox7.ReadOnly = true;

            DataGridViewButtonCell button = new DataGridViewButtonCell();
            button.Value = "编辑";
            row.Cells.Add(button);

            button = new DataGridViewButtonCell();
            button.Value = "删除";
            row.Cells.Add(button);


            row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Rows.Add(row);
        }

        private void RefreshQuestions()
        {
            try
            {
                dataGridView1.Rows.Clear();
                foreach (var question in QuestionManager.m_QuestionsList)
                {
                    if (question == null)
                        continue;

                    if (0 != comboBoxChapter.SelectedIndex)
                    {
                        if (question.Module != comboBoxChapter.SelectedIndex)
                            continue;
                    }

                    ChapterInfo modelSkill = (ChapterInfo)comboBoxSkill.SelectedItem;
                    if(modelSkill.ID == -1)
                    {
                        //未分类
                        if (question.Skill != 0)
                            continue;
                    }
                    else if(modelSkill.ID !=0)
                    {
                        if (question.Skill != modelSkill.ID)
                            continue;
                    }

                    ChapterInfo modelBank = (ChapterInfo)comboBoxBank.SelectedItem;
                    if(modelBank.ID ==-1)
                    {
                        //未分类
                        if (question.BankId != 0)
                            continue;
                    }
                    else if(modelBank.ID !=0)
                    {
                        if (question.BankId != modelBank.ID)
                            continue;
                    }

                    //if (0 != comboBoxSkill.SelectedIndex)
                    //{
                    //    if (question.Skill != comboBoxSkill.SelectedIndex)
                    //        continue;
                    //}

                    if (0 != comboBoxType.SelectedIndex)
                    {
                        if (question.Type != comboBoxType.SelectedIndex)
                            continue;
                    }

                    if (0 != comboBoxClassification.SelectedIndex)
                    {
                        if (question.Classification != comboBoxClassification.SelectedIndex)
                            continue;
                    }

                    AddItem(question);

                }

                labelQuestionCount.Text = dataGridView1.Rows.Count.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("题目未完全加载，请稍候打开！" + ex.Message);
            }
        }

        private void labelAdd_Click(object sender, EventArgs e)
        {
            panelDetails.BringToFront();
            panelManager.SendToBack();

            Question question = new Question();
            question.Id = QuestionManager._maxQuestionNum + 1;
            question.Tittle = "";
            question.Classification = 3;
            question.CorrectAnswer = new List<int>();
            question.CorrectAnswer.Add(1);
            question.Type = 1;
            question.NormalNotice = "";
            question.Options = new List<string>();
            question.Options.Add("正确");
            question.Options.Add("错误");
            question.Options.Add("");
            question.Options.Add("");
            question.OptionsEmphasize = new List<string>();
            question.OptionsEmphasize.Add("");
            question.OptionsEmphasize.Add("");
            question.OptionsEmphasize.Add("");
            question.OptionsEmphasize.Add("");
            question.Skill = 0;
            question.Module = 0;
            question.TittleEmphasize = "";
            question.SkillNotice = "";
            question.FlashPath = "";
            question.ImagePath = "";

            m_details.SetQuestions(question);
            m_details.Show();
        }

        private void labelDel_Click(object sender, EventArgs e)
        {
            if (DialogResult.No== MessageBox.Show("您确认删除选中信息?", "确认窗口", MessageBoxButtons.YesNo))
            {
                return;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(((DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0]).EditedFormattedValue) == true)
                {
                    Question curQuestion = (Question)dataGridView1.Rows[i].Cells[0].Tag;
                    if (false == QuestionManager.DeleteQuestion(curQuestion))
                    {
                        return;
                    }
                    else
                    {
                        dataGridView1.Rows.RemoveAt(i);
                        i--;
                    }
                }

            }
        }

        private void labelAdd_MouseMove(object sender, MouseEventArgs e)
        {
            ((Label)sender).ForeColor = Color.Blue;
        }

        private void labelAdd_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Black;
        }

        private void checkBoxSelectAll_CheckStateChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                ((DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0]).Value = checkBoxSelectAll.Checked;
            }
        }

        private void comboBoxChapter_SelectedValueChanged(object sender, EventArgs e)
        {
            RefreshQuestions();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Question curQuestion = null;

            if (e.RowIndex < 0)
                return;

            //编辑
            if (e.ColumnIndex == 8)
            {
                curQuestion = (Question)dataGridView1.Rows[e.RowIndex].Cells[0].Tag;
                m_details.TopLevel = false;
                m_details.Parent = this.panelDetails;
                panelDetails.BringToFront();
                panelManager.SendToBack();
                m_details.SetQuestions(curQuestion);
                m_details.Show();
            }

            //删除
            if(e.ColumnIndex == 9)
            {
                if (DialogResult.Yes == MessageBox.Show("您确认删除此条信息?", "确认窗口", MessageBoxButtons.YesNo))
                {
                    curQuestion = (Question)dataGridView1.Rows[e.RowIndex].Cells[0].Tag;
                    if (true == QuestionManager.DeleteQuestion(curQuestion))
                    {
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                }
                
            }
        }


        public bool SendBack(Question question, bool Replace)
        {
            if (true == Replace)
            {
                bool isUpdate = false;
                if (false == QuestionManager.SaveQuestion(m_details.m_question, out isUpdate, Directory.GetCurrentDirectory() + "\\" + SystemConfig.PathQuestions +"\\" + m_details.m_question.Id.ToString() + ".txt"))
                    return false;

                if(false == isUpdate)
                {
                    QuestionManager.m_QuestionsList.Add(m_details.m_question);

                    QuestionManager._maxQuestionNum = m_details.m_question.Id;
                    QuestionManager.SaveQuestionMaxNum();
                }

                this.panelManager.BringToFront();
                this.panelDetails.SendToBack();
            }
            else
            {
                this.panelManager.BringToFront();
                this.panelDetails.SendToBack();
                
            }

            textBoxFilterOptions.Text = "";
            textBoxFilterTittle.Text = "";
			RefreshQuestions();
			
			return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshQuestions();
        }

        public void ReloadForm()
        {
            return;
        }
    }
}
