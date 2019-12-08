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
    public partial class FormBankSelect : Form, InterfaceForm
    {
        public FormBankSelect()
        {
            InitializeComponent();
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

        private int BankId = 1;
        private int firstBankId = 1;
        void GenCotrols()
        {
            int i = 0;
            Dictionary<int, string> dicModelId = new Dictionary<int,string>();
            List<string> listTittle = new List<string>();
            List<ModelChapter> modeList = new List<ModelChapter>();
            foreach(var modelInfo in ModelManager.m_DicBankList)
            {
                listTittle.Add(modelInfo.Value.Tittle);
                dicModelId.Add(modelInfo.Key, modelInfo.Value.Tittle);
                modeList.Add(modelInfo.Value);
            }

            modeList.Sort();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.SuspendLayout();
            bool isFind = false;
            //foreach(var modelInfo in ModelManager.m_DicSkillList)
            foreach (var modelInfo in modeList)
            {
                //判断是否是科目四
                //科目一和恢复资格考试都选取科目一的题目
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
                radio.Text = modelInfo.Tittle;
                radio.Anchor = AnchorStyles.None;
                radio.Dock = DockStyle.Fill;

                tableLayoutPanel1.Controls.Add(radio);
				radio.CheckedChanged += new System.EventHandler(this.radioButtonTemplate_CheckedChanged);
                //radio.Tag = modelInfo.Value.Id;
                radio.Tag = modelInfo.Id;

                if (i == 0)
                {
                    //firstSkillId = modelInfo.Value.Id;
                    firstBankId = modelInfo.Id;
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
            List<Question> list = QuestionManager.GenQuestionByBankId(BankId);

            //if (BankId != firstBankId)
            if(true)
            {
                if (!LicenseHelper.IsValid())
                {
                    if (DialogResult.Yes == MessageBox.Show("此套题练习功能需要升级为授权用户用方能使用,是否打开授权界面？", "授权提示", MessageBoxButtons.YesNo))
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
                MessageBox.Show("此套题下面没绑定题目，请重新选择!", "提示信息", MessageBoxButtons.OK);
                return;
            }

            list.Sort();
            _simulaForm.SetQuestions(list, false);

            _simulaForm.SetShowType(2);
            _simulaForm.ResetControlsInfo(Math.Min(count, 100));
            

            _simulaForm.Show();
        }

        private void radioButtonTemplate_CheckedChanged(object sender, EventArgs e)
        {
            BankId = Convert.ToInt32(((RadioButton)sender).Tag);
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            FormSimulation _simulaForm = FormMain.m_formSimulation;
            List<Question> list = QuestionManager.GenQuestionByBankId(BankId);

            //if (BankId != firstBankId)
            if (true)
            {
                if (!LicenseHelper.IsValid())
                {
                    if (DialogResult.Yes == MessageBox.Show("此套题练习功能需要升级为授权用户用方能使用,是否打开授权界面？", "授权提示", MessageBoxButtons.YesNo))
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
                MessageBox.Show("此套题下面没绑定题目，请重新选择!", "提示信息", MessageBoxButtons.OK);
                return;
            }

            _simulaForm.SetQuestions(list);

            _simulaForm.SetShowType(2);
            _simulaForm.ResetControlsInfo(Math.Min(count, 100));


            _simulaForm.Show();
        }

        public void ReloadForm()
        {
            FormSkillSelect_Load(null, null);
        }
    }
}
