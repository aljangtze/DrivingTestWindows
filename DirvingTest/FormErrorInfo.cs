using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DirvingTest
{
    public partial class FormErrorInfo : Form
    {
        public List<Question> m_QuestionList = new List<Question>();
        public delegate bool WantSendBack(List<Question> AnswerList);
        Dictionary<int, AnswerQuestion> m_AnswerList = new Dictionary<int,AnswerQuestion>();
        public WantSendBack SendBack = null;
        /// <summary>
        /// 0 不做任何操作 1重考本技巧 2重做错题
        /// </summary>
        public int ReturnStatus = 0;
        public FormErrorInfo()
        {
            InitializeComponent();
        }

        public void SetAnswers(Dictionary<int, AnswerQuestion> answerList)
        {
            int AllCount = answerList.Count;
            int WrongCount = 0;
            int RightCount = 0;
            int NoAnswerCount = 0;
            m_AnswerList.Clear();
            foreach(var answer in answerList)
            {
                m_AnswerList.Add(answer.Key, answer.Value);
                if (answer.Value.RightStatus == 0)
                    NoAnswerCount++;
                if (answer.Value.RightStatus == 1)
                    RightCount++;
                if (answer.Value.RightStatus == 2)
                    WrongCount++;
            }

            labelTittle.Text = string.Format("总共 {0} 题   答对 {1} 题    答错  {2} 题   未答 {3} 题", AllCount, RightCount, WrongCount, NoAnswerCount);
        }

        public void UpdateDataGridView(int type)
        {
            if(type == 2)
                labelInfo.Text = "回答错误的题目";
            if(type == 1)
                labelInfo.Text = "回答正确的题目";
            if(type == 0)
                labelInfo.Text = "未做的题目";

            dataGridView1.Rows.Clear();
            int Count = 0;
            foreach (var answer in m_AnswerList)
            {
                if (answer.Value.RightStatus != type)
                    continue;

                Count++;
                AddItem(answer.Value);
            }

            labelQuestionCount.Text = Count.ToString();
        }

        void AddItem(AnswerQuestion answer)
        {
            DataGridViewRow row = new DataGridViewRow();

            DataGridViewTextBoxCell txtBox1 = new DataGridViewTextBoxCell();
            txtBox1.Value = answer.seq.ToString();
            txtBox1.ToolTipText = "ID=" + answer.question.Id.ToString();
            row.Cells.Add(txtBox1);
            txtBox1.ReadOnly = true;

            DataGridViewTextBoxCell txtBox2 = new DataGridViewTextBoxCell();
            txtBox2.Value = answer.question.Tittle;
            txtBox2.ToolTipText = answer.question.Tittle;
            row.Cells.Add(txtBox2);
            txtBox2.ReadOnly = true;

            DataGridViewTextBoxCell txtBox4 = new DataGridViewTextBoxCell();
            txtBox4.Value = Question._TypeInfo[answer.question.Type];
            txtBox4.ToolTipText = "题目类型";
            row.Cells.Add((DataGridViewTextBoxCell)txtBox4);
            txtBox4.ReadOnly = true;


            DataGridViewTextBoxCell txtBox5 = new DataGridViewTextBoxCell();
            ChapterInfo model = new ChapterInfo();
            txtBox5.Value = answer.AnswerString;
            txtBox5.ToolTipText = "您的答案";
            row.Cells.Add((DataGridViewTextBoxCell)txtBox5);
            txtBox5.ReadOnly = true;


            DataGridViewTextBoxCell txtBox6 = new DataGridViewTextBoxCell();
            txtBox6.Value = answer.CorrectString;
            txtBox6.ToolTipText = "正确答案";
            row.Cells.Add((DataGridViewTextBoxCell)txtBox6);
            txtBox6.ReadOnly = true;

            DataGridViewTextBoxCell txtBox7 = new DataGridViewTextBoxCell();
            if (0 == answer.RightStatus)
                txtBox7.Value = "未回答";
            if (1 == answer.RightStatus)
                txtBox7.Value = "回答正确";
            if (2 == answer.RightStatus)
                txtBox7.Value = "回答错误";

            txtBox7.ToolTipText = answer.question.SkillNotice;
            row.Cells.Add((DataGridViewTextBoxCell)txtBox7);
            txtBox7.ReadOnly = true;
            
            

            row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Rows.Add(row);
        }
        private void imageButtonWrongQuestions_Click(object sender, EventArgs e)
        {
            UpdateDataGridView(2);
        }

        private void imageButtonRightQuestions_Click(object sender, EventArgs e)
        {
            UpdateDataGridView(1);
        }

        private void imageButtonRedo_Click(object sender, EventArgs e)
        {
            m_QuestionList.Clear();

            foreach(var answer in m_AnswerList)
            {
                m_QuestionList.Add(answer.Value.question);
            }

            if (SendBack != null)
                SendBack(m_QuestionList);

            ReturnStatus = 1;
            this.DialogResult = DialogResult.Yes;
            Close();
        }

        private void imageButtonRedoWrong_Click(object sender, EventArgs e)
        {
            m_QuestionList.Clear();

            foreach (var answer in m_AnswerList)
            {
                if(answer.Value.RightStatus == 2)
                    m_QuestionList.Add(answer.Value.question);
            }

            if(0 == m_QuestionList.Count)
            {
                MessageBox.Show("没有错题需要重做!","提示信息",MessageBoxButtons.OK);
                return;
            }

            if (SendBack != null)
                SendBack(m_QuestionList);

            ReturnStatus = 2;
            this.DialogResult = DialogResult.Yes;
            Close();
        }

        private void imageButtonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            Close();
        }

        private void FormErrorInfo_Shown(object sender, EventArgs e)
        {
            UpdateDataGridView(2);
        }

        private void imageButton1_Click(object sender, EventArgs e)
        {
            UpdateDataGridView(0);
        }
    }
}
