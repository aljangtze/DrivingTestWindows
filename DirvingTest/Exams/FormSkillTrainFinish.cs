using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
////using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DirvingTest
{
    public partial class FormSkillTrainFinish : Form
    {
        public List<Question> m_QuestionList = new List<Question>();
        public delegate bool WantSendBack(List<Question> AnswerList);
        Dictionary<int, AnswerQuestion> m_AnswerList = new Dictionary<int, AnswerQuestion>();
        public WantSendBack SendBack = null;
        
        public FormSkillTrainFinish()
        {
            InitializeComponent();
        }

        bool IsDoError = false;
        public void SetAnswers(Dictionary<int, AnswerQuestion> answerList, bool isDoError=false)
        {
            IsDoError = isDoError;
            int AllCount = answerList.Count;
            int WrongCount = 0;
            int RightCount = 0;
            int NoAnswerCount = 0;
            m_AnswerList.Clear();
            foreach (var answer in answerList)
            {
                m_AnswerList.Add(answer.Key, answer.Value);
                if (answer.Value.RightStatus == 0)
                    NoAnswerCount++;
                if (answer.Value.RightStatus == 1)
                    RightCount++;
                if (answer.Value.RightStatus == 2)
                    WrongCount++;
            }

            labelAllCount.Text = AllCount.ToString();
            labelCorrectCout.Text = RightCount.ToString();
            labelIncorrectCount.Text = WrongCount.ToString();
            labelNoanswerCount.Text = NoAnswerCount.ToString();
            buttonRetun.Text = "关闭";
            if (false == IsDoError)
                btnOk.Text = "重做错题";
            else
                btnOk.Text = "再做一次";

            //if(WrongCount== 0)
            //{
            //    buttonRetun.Text = "关闭";
            //}
            //else
            //{      
            //    buttonRetun.Text = "重做错题";
            //}

            //TODO:如果是做错题的，就再做一次和不做了
            //if(IsDoError)
            //{
            //    buttonRetun.Text = "不做了";
            //}
            //else
            //{
            //    btnOk.Text = "关闭";
            //}

        }

        /// <summary>
        /// 处理关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRetun_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
            return;

            if (true == IsDoError)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            m_QuestionList.Clear();

            foreach (var answer in m_AnswerList)
            {
                if (answer.Value.RightStatus == 2 || answer.Value.RightStatus==0)
                    m_QuestionList.Add(answer.Value.question);
            }

            if (0 == m_QuestionList.Count)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            if (SendBack != null)
                SendBack(m_QuestionList);

            DialogResult = DialogResult.Yes;
            Close();
        }

        /// <summary>
        /// 处理再做一次，重做错题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {

            //m_QuestionList.Clear();

            //foreach (var answer in m_AnswerList)
            //{
            //    if (answer.Value.RightStatus == 2 || answer.Value.RightStatus == 0)
            //        m_QuestionList.Add(answer.Value.question);
            //}

            //if (0 == m_QuestionList.Count)
            //{
            //    DialogResult = DialogResult.Cancel;
            //    Close();
            //    return;
            //}

            //if (SendBack != null)
            //    SendBack(m_QuestionList);

            //DialogResult = DialogResult.Yes;
            //Close();


            m_QuestionList.Clear();

            foreach (var answer in m_AnswerList)
            {
                if (IsDoError)
                {
                    m_QuestionList.Add(answer.Value.question);
                }
                else
                {
                    if (answer.Value.RightStatus == 2 || answer.Value.RightStatus == 0)
                        m_QuestionList.Add(answer.Value.question);
                }
            }

            if (SendBack != null)
                SendBack(m_QuestionList);

            this.DialogResult = DialogResult.Yes;
            Close();
        }
    }
}
