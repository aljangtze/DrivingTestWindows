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
    public partial class FormChaperSelect : Form, InterfaceForm
    {
        public FormChaperSelect()
        {
            InitializeComponent();
        }

        public enum SupportChapterType
        {
            /// <summary>
            /// 技巧练习
            /// </summary>
            ChapterSkill = 1,
            /// <summary>
            /// 套题练习
            /// </summary>
            ChapterSuite = 2,
            /// <summary>
            /// 强化练习
            /// </summary>
            ChapterIntensity = 3
        }

        private int g_ChapterType = 1;
        private SerializableDictionary<int, int> g_Relation_Question_List = new SerializableDictionary<int,int>();

        List<ChapterInfo> chapterList = new List<ChapterInfo>();
        public void SetChapterType(int chapterType)
        {
            g_ChapterType = chapterType;
            switch (g_ChapterType)
            {
                case 1:
                    lblInfo.Text = "技巧练习--专业的技巧助您快速掌握答题技巧";
                    this.picHeader.Image = global::DirvingTest.Properties.Resources.edit_group;
                    ChapterManager.GetChapterList((int)chapterType, out chapterList);
                    //chapterList = ModelManager.m_DicSkillList;
                    //g_Relation_Question_List = QuestionManager.m_Relation_Question_Skill;
                    
                    break;

                case 2:
                    lblInfo.Text = "套题练习--专业的题库分类助您快速掌握相关题型";
                    ChapterManager.GetChapterList((int)chapterType, out chapterList);
                    //chapterList = ModelManager.m_DicBankList;
                    //g_Relation_Question_List = QuestionManager.m_Relation_Question_Suite;
                    break;
                case 3:
                    lblInfo.Text = "错题练习--强化练习容易错误的题目，帮助更好通过考试。";
                    ChapterManager.GetChapterList((int)chapterType, out chapterList);
                    //chapterList = ModelManager.m_DicIntensifyList;
                    //g_Relation_Question_List = QuestionManager.m_Relation_Question_Intensity;
                    break;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {

                CreateParams cp = base.CreateParams;

                cp.ExStyle |= 0x02000000;

                return cp;

            }
        }

        private ChapterInfo g_ChapterInfo = new ChapterInfo();
        private int g_FirstChapterId = 0;
        void GenCotrols()
        {
            int i = 0;
            Dictionary<int, string> dicModelId = new Dictionary<int,string>();
            List<string> listTittle = new List<string>();
            List<ChapterInfo> modeList = new List<ChapterInfo>();

            foreach (var modelInfo in this.chapterList)
            {
                listTittle.Add(modelInfo.Name);
                dicModelId.Add(modelInfo.ID, modelInfo.Name);
                modeList.Add(modelInfo);
            }

            modeList.Sort();

            tableLayoutPanel1.Controls.Clear();
            bool isFind = false;
            //foreach(var modelInfo in ModelManager.m_DicSkillList)
            tableLayoutPanel1.SuspendLayout();
            foreach (var modelInfo in modeList)
            {
                //判断是否是科目四
                //其他考试一和恢复考试都是使用的科目一的章节
                if (SystemConfig._examType == 1)
                {
                    //if(modelInfo.Value.Classification != 4)
                    //    continue;
                    if (modelInfo.Classification != 4)
                        continue;
                }
                else
                {
                    //if (modelInfo.Value.Classification == 4)
                    //    continue;
                    if (modelInfo.Classification == 4)
                        continue;

                    //小车
                    if (SystemConfig._driverType == 0)
                    {
                        //if (modelInfo.Value.Classification == 1 || modelInfo.Value.Classification == 2)
                        //    continue;
                        if (modelInfo.Classification == 1 || modelInfo.Classification == 2 || modelInfo.Classification == 5)
                            continue;
                    }
                    //客车
                    else if (SystemConfig._driverType == 1)
                    {
                        //if (modelInfo.Value.Classification == 2)
                        //    continue;
                        if (modelInfo.Classification == 2)
                            continue;
                    }
                    //货车
                    else if (SystemConfig._driverType == 2)
                    {
                        //if (modelInfo.Value.Classification == 1)
                        //    continue;
                        if (modelInfo.Classification == 1)
                            continue;
                    }
                    else
                    {
                        continue;
                    }
                }

                isFind = true;

                RadioButton radio = new RadioButton();
                radio.AutoSize = false;
                radio.Font = radioButtonTemplate.Font;
                radio.Parent= panelDown;
                radio.ForeColor = radioButtonTemplate.ForeColor;
                //radio.Text = modelInfo.Value.Tittle;
                radio.Text = modelInfo.Name;
                radio.Anchor = AnchorStyles.None;
                radio.Dock = DockStyle.Fill;

                tableLayoutPanel1.Controls.Add(radio);
				radio.CheckedChanged += new System.EventHandler(this.radioButtonTemplate_CheckedChanged);
                //radio.Tag = modelInfo.Value.Id;
                radio.Tag = modelInfo;

                if (i == 0)
                {
                    //firstSkillId = modelInfo.Value.Id;
                    g_FirstChapterId = modelInfo.ID;
                    radio.Checked = true;
                }
                i++;
            }
            tableLayoutPanel1.ResumeLayout();

            if (true == isFind)
            {
                labelInfo.Visible = false;
                tableLayoutPanel1.Visible = true;
                btnSequence.Enabled = true;
            }
            else
            {
                labelInfo.Visible = true;
                tableLayoutPanel1.Visible = false;
                btnSequence.Enabled = false;
            }
        }

        private void FormSkillSelect_Load(object sender, EventArgs e)
        {
            GenCotrols();
        }

        private void btnSequence_Click(object sender, EventArgs e)
        {
            FormSimulation _simulaForm = FormMain.m_formSimulation;

            ////List<Question> list = QuestionManager.GenQuestionBySkill(SkillId);
            //List<Question> list = QuestionManager.GenQuestionFromRelation(g_ChapterInfo, g_Relation_Question_List);

            //if (g_ChapterInfo != g_FirstChapterId)
            List<Question> list = new List<Question>();
            if (g_ChapterInfo.ChapterType == 3)
            {
                list = QuestionManager.GetErrorQuestionFromDB(g_ChapterInfo);
            }
            else
            {
                list = QuestionManager.GetQuestionsFromDB(g_ChapterInfo.ID);
            }

            if (g_ChapterInfo.ID != g_FirstChapterId)
            {
                if (!LicenseHelper.IsValid())
                {
                    if (DialogResult.Yes == MessageBox.Show("此章节需要升级为授权用户用方能使用,是否打开授权界面？", "授权提示", MessageBoxButtons.YesNo))
                    {
                        FormLicence form = new FormLicence();
                        form.ShowDialog();
                        if (!LicenseHelper.IsValid())
                            return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
                

            int count = list.Count;
            if(count == 0)
            {
                MessageBox.Show("此章节下面没绑定题目，请重新选择!", "提示信息", MessageBoxButtons.OK);
                return;
            }

            list.Sort();
            _simulaForm.SetQuestions(list, false);

            _simulaForm.SetShowType(1);
            _simulaForm.ResetControlsInfo(Math.Min(count, 100));
            

            _simulaForm.Show();
        }

        private void radioButtonTemplate_CheckedChanged(object sender, EventArgs e)
        {
            g_ChapterInfo = (ChapterInfo)(((RadioButton)sender).Tag);
        }

        private void btnRadom_Click(object sender, EventArgs e)
        {
            FormSimulation _simulaForm = FormMain.m_formSimulation;

            //List<Question> list = QuestionManager.GenQuestionBySkill(g_ChapterId);
            //List<Question> list = QuestionManager.GenQuestionFromRelation(g_ChapterInfo, g_Relation_Question_List);
            List<Question> list = new List<Question>();
            if (g_ChapterInfo.ChapterType == 3)
            {
                list = QuestionManager.GetErrorQuestionFromDB(g_ChapterInfo);
            }
            else
            {
                list = QuestionManager.GetQuestionsFromDB(g_ChapterInfo.ID);
            }

            if (g_ChapterInfo.ID != g_FirstChapterId)
            {
                if (!LicenseHelper.IsValid())
                {
                    if (DialogResult.Yes == MessageBox.Show("此章节需要升级为授权用户用方能使用,是否打开授权界面？", "授权提示", MessageBoxButtons.YesNo))
                    {
                        FormLicence form = new FormLicence();
                        form.ShowDialog();
                        if (!LicenseHelper.IsValid())
                            return;
                    }
                    else
                    {
                        return;
                    }
                }
            }


            int count = list.Count;
            if (count == 0)
            {
                MessageBox.Show("此章节下面没绑定题目，请重新选择!", "提示信息", MessageBoxButtons.OK);
                return;
            }

            _simulaForm.SetQuestions(list);

            _simulaForm.SetShowType(1);
            _simulaForm.ResetControlsInfo(Math.Min(count, 100));


            _simulaForm.Show();
        }

        public void ReloadForm()
        {
            FormSkillSelect_Load(null, null);
        }
    }
}
