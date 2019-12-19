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
    public partial class FormIntensifySelect : Form, InterfaceForm
    {
        public FormIntensifySelect()
        {
            InitializeComponent();
        }

        public enum SupportChapterType
        {
            /// <summary>
            /// 技巧练习
            /// </summary>
            ChapterSkill = 3,
            /// <summary>
            /// 套题练习
            /// </summary>
            ChapterSuite = 4,
            /// <summary>
            /// 强化练习
            /// </summary>
            ChapterIntensity = 5
        }

        private SupportChapterType g_ChapterType = SupportChapterType.ChapterSkill;
        private SerializableDictionary<int, int> g_Relation_Question_List = new SerializableDictionary<int,int>();

        Dictionary<int, ChapterInfo> chapterList = new Dictionary<int, ChapterInfo>();
        public void SetChapterType(SupportChapterType chapterType)
        {
            g_ChapterType = chapterType;
            switch(g_ChapterType)
            {
                case SupportChapterType.ChapterSkill:
                    lblInfo.Text = "技巧练习--专业的技巧助您快速掌握答题技巧";
                    this.picHeader.Image = global::DirvingTest.Properties.Resources.edit_group;
                    chapterList = ModelManager.m_DicSkillList;
                    g_Relation_Question_List = QuestionManager.m_Relation_Question_Skill;
                    
                    break;
                case SupportChapterType.ChapterIntensity:
                    lblInfo.Text = "强化练习--强化练习容易错误的题目，帮助更好通过考试。";
                    chapterList = ModelManager.m_DicIntensifyList;
                    g_Relation_Question_List = QuestionManager.m_Relation_Question_Intensity;
                    break;
                case SupportChapterType.ChapterSuite:
                    lblInfo.Text = "套题练习--专业的题库分类助您快速掌握相关题型";
                    chapterList = ModelManager.m_DicBankList;
                    g_Relation_Question_List = QuestionManager.m_Relation_Question_Suite;
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

        private int g_ChapterId = 1;
        private int g_FirstChapterId = 1;
        void GenCotrols()
        {
            int i = 0;
            Dictionary<int, string> dicModelId = new Dictionary<int,string>();
            List<string> listTittle = new List<string>();
            List<ChapterInfo> modeList = new List<ChapterInfo>();

            foreach (var modelInfo in this.chapterList)
            {
                listTittle.Add(modelInfo.Value.Name);
                dicModelId.Add(modelInfo.Key, modelInfo.Value.Name);
                modeList.Add(modelInfo.Value);
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
                        if (modelInfo.Classification == 1 || modelInfo.Classification == 2)
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
                radio.Tag = modelInfo.ID;

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

            //List<Question> list = QuestionManager.GenQuestionBySkill(SkillId);
            List<Question> list = QuestionManager.GenQuestionFromRelation(g_ChapterId, g_Relation_Question_List);

            if (g_ChapterId != g_FirstChapterId)
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
            g_ChapterId = Convert.ToInt32(((RadioButton)sender).Tag);
        }

        private void btnRadom_Click(object sender, EventArgs e)
        {
            FormSimulation _simulaForm = FormMain.m_formSimulation;
            
            //List<Question> list = QuestionManager.GenQuestionBySkill(g_ChapterId);
            List<Question> list = QuestionManager.GenQuestionFromRelation(g_ChapterId, g_Relation_Question_List);

            if (g_ChapterId != g_FirstChapterId)
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
