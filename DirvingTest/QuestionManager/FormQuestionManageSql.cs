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
    public partial class FormQuestionManageSql : Form, InterfaceForm
    {
        FormQuestionDetails m_details = null;
        public FormQuestionManageSql()
        {
            InitializeComponent();
            pageControl1.OnChangeDatas += RefreshDatas;
        }

        ChapterManager chapterManager;
        private void FormQuestionManage_Load(object sender, EventArgs e)
        {
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleTurquoise;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Rows.Clear();

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridView1.RowsDefaultCellStyle.WrapMode = (DataGridViewTriState.True);

            

            foreach (var classification in Question._ModelClassificationInfo)
            {
                cboxClassification.Items.Add(classification);
            }
            cboxClassification.SelectedIndex = 0;

            foreach (var typeInfo in Question._TypeInfo)
            {
                comboBoxType.Items.Add(typeInfo);
            }
            comboBoxType.SelectedIndex = 0;

            chapterManager = new ChapterManager();
            chapterManager.GetChapterTypeList(out List<ChapterType> chapterTypeList, true);
            cboxChaperType.Items.Clear();

            foreach (ChapterType chapterType in chapterTypeList)
            {
                cboxChaperType.Items.Add(chapterType);
            }

            cboxChaperType.SelectedIndex = 0;

            isLoadSuccess = true;
        }

        bool isLoadSuccess = false;
        private void FormQuestionManage_Shown(object sender, EventArgs e)
        {
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


        private void AddItem(DataRow data)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.Tag = data;

            DataGridViewCheckBoxCell chkBoxCell = new DataGridViewCheckBoxCell();
            chkBoxCell.Value = false;
            chkBoxCell.Tag = data["id"];
            row.Cells.Add(chkBoxCell);

            DataGridViewTextBoxCell txtNumber = new DataGridViewTextBoxCell();
            txtNumber.Value = Convert.ToInt32(dataGridView1.Rows.Count + 1);
            row.Cells.Add(txtNumber);

            DataGridViewTextBoxCell txtBox1 = new DataGridViewTextBoxCell();
            txtBox1.Value = Convert.ToInt32(data["id"]);
            //txtBox1.Tag = question.Id.ToString();
            txtBox1.ToolTipText = "ID=" + data["id"].ToString();
            txtBox1.Tag = data["id"];
            row.Cells.Add(txtBox1);
            txtBox1.ReadOnly = true;

            DataGridViewTextBoxCell txtBox2 = new DataGridViewTextBoxCell();
            txtBox2.Value = data["tittle"]; 
            txtBox2.ToolTipText = data["tittle"].ToString();
            row.Cells.Add(txtBox2);
            txtBox2.ReadOnly = true;

            //这个类别不正确
            DataGridViewTextBoxCell txtBox3 = new DataGridViewTextBoxCell();

            int classfication = Convert.ToInt32(data["classification"]);
            if (classfication == 0)
                txtBox3.Value = "未分类";
            else
                txtBox3.Value = Question._ModelClassificationInfo[classfication];

            txtBox3.ToolTipText = "题目类别";


            row.Cells.Add((DataGridViewTextBoxCell)txtBox3);
            txtBox3.ReadOnly = true;


            int type= Convert.ToInt32(data["type"]);


            DataGridViewTextBoxCell txtBox4 = new DataGridViewTextBoxCell();
            txtBox4.Value = Question._TypeInfo[type];
            if (type == 1)
                txtBox4.ToolTipText = "题目类型";
            else
            {
                txtBox4.ToolTipText = "题目类型"; 
            }
            row.Cells.Add((DataGridViewTextBoxCell)txtBox4);
            txtBox4.Tag = type;
            txtBox4.ReadOnly = true;


            DataGridViewTextBoxCell txtBox5 = new DataGridViewTextBoxCell();
            if(string.IsNullOrEmpty(data["chapter_name"].ToString()))
            {
                txtBox5.Value = "未分类";
                txtBox5.ToolTipText = "未分类";
            }
            else
            {
                txtBox5.Value = data["chapter_name"].ToString();
                txtBox5.ToolTipText = data["chapter_name"].ToString();
            }
            row.Cells.Add((DataGridViewTextBoxCell)txtBox5);
            txtBox5.ReadOnly = true;


            DataGridViewTextBoxCell txtBox6 = new DataGridViewTextBoxCell();
            if (string.IsNullOrEmpty(data["skill_name"].ToString()))
            {
                txtBox6.Value = "未分类";
                txtBox6.ToolTipText = "未分类";
            }
            else
            {
                txtBox6.Value = data["skill_name"];
                txtBox6.ToolTipText = data["skill_name"].ToString();
            }
            row.Cells.Add((DataGridViewTextBoxCell)txtBox6);
            txtBox6.ReadOnly = true;

            DataGridViewTextBoxCell txtBox7 = new DataGridViewTextBoxCell();
            // txtBox6.Tag = question.Skill;
            if (string.IsNullOrEmpty(data["bank_name"].ToString()))
            {
                txtBox7.Value = "未分类";
                txtBox7.ToolTipText = "未分类";
            }
            else
            {
                txtBox7.Value = data["bank_name"];
                txtBox7.ToolTipText = data["bank_name"].ToString();
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

        //TODO;更新题目列表
        private void RefreshQuestions()
        {
            if (false == isLoadSuccess)
                return;


            ChapterInfo chapterInfo = (ChapterInfo)comboBoxChapter.SelectedItem;
            ChapterType chapterType = (ChapterType)cboxChaperType.SelectedItem;
            //ChpaterQuestionManager.GetChapterQuestionsCount(chapterType.ID, chapterInfo.ID, cboxClassification.SelectedIndex, comboBoxType.SelectedIndex);

            int dataCount = ChpaterQuestionManager.GetChapterQuestionsCount(chapterType.ID, chapterInfo.ID, cboxClassification.SelectedIndex, comboBoxType.SelectedIndex, "%" + textBoxFilterTittle.Text + "%");
            labelQuestionCount.Text = dataCount.ToString();
            pageControl1.BeginUpdate();
            pageControl1.TotalCount = dataCount;

            RefreshDatas(pageControl1.PerPageNumber, pageControl1.CurrentPage);

            pageControl1.EndUpdate();            
            //labelQuestionCount.Text = data.Rows.Count.ToString();
        }

        public void RefreshDatas(int pageNumber, int currentPage)
        {
            ChapterInfo chapterInfo = (ChapterInfo)comboBoxChapter.SelectedItem;
            ChapterType chapterType = (ChapterType)cboxChaperType.SelectedItem;

            DataTable data = ChpaterQuestionManager.GetChapterQuestions(chapterType.ID, chapterInfo.ID, cboxClassification.SelectedIndex, comboBoxType.SelectedIndex, "%" + textBoxFilterTittle.Text + "%", pageNumber, currentPage);

            dataGridView1.Rows.Clear();
            if (null == data)
            {
                MessageBox.Show("获取题目数据失败");
                return;
            }

            Console.WriteLine(data.Rows.Count);
            foreach (DataRow row in data.Rows)
            {
                AddItem(row);
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
            if (e.RowIndex < 0)
                return;

            //编辑
            if (e.ColumnIndex == 9)
            {
                FormQuestionDetailsSql formQuestionDetailsSql = new FormQuestionDetailsSql();
                formQuestionDetailsSql.SetDataInfo((DataRow)(dataGridView1.Rows[e.RowIndex].Tag));
                if(DialogResult.Yes == formQuestionDetailsSql.ShowDialog())
                {
                    int pageNumber = pageControl1.CurrentPage;
                    RefreshQuestions();
                    pageControl1.CurrentPage = pageNumber;
                }
            }

            //删除
            if(e.ColumnIndex == 10)
            {
                if (DialogResult.Yes == MessageBox.Show("您确认删除此条信息?", "确认窗口", MessageBoxButtons.YesNo))
                {
                    int pageNumber = pageControl1.CurrentPage;
                    RefreshQuestions();
                    pageControl1.CurrentPage = pageNumber;
                    
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

        private void button2_Click(object sender, EventArgs e)
        {
            pageControl1.TotalCount = 200;
        }

        private void cboxChaperType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxChaperType.SelectedIndex < 0)
                return;

            isLoadSuccess = false;
            ChapterType chapterType = (ChapterType)cboxChaperType.SelectedItem;
            ChapterManager.GetChapterList(chapterType.ID, out List<ChapterInfo> chapterInfoList);

            comboBoxChapter.Items.Clear();
            ChapterInfo modelNull = new ChapterInfo();
            modelNull.ID = 0;
            modelNull.Name = "全部";
            comboBoxChapter.Items.Add(modelNull);

            ChapterInfo modelNotSplit = new ChapterInfo();
            modelNotSplit.ID = -1;
            modelNotSplit.Name = "未分类";
            comboBoxChapter.Items.Add(modelNotSplit);

            foreach (ChapterInfo chapterInfo in chapterInfoList)
            {
                comboBoxChapter.Items.Add(chapterInfo);
            }

            comboBoxChapter.SelectedIndex = 0;

            cboxClassification.SelectedIndex = 0;

            comboBoxType.SelectedIndex = 0;

            textBoxFilterTittle.Text = "";

            isLoadSuccess = true;

            RefreshQuestions();
            //textBoxFilterOptions.Text = "";
        }
    }
}
