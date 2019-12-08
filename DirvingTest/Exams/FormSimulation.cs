using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
////using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirvingTest
{
    public partial class FormSimulation : Form
    {
        #region user32.dll

        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern Int32 ShowWindow(Int32 hwnd, Int32 nCmdShow);
        public const Int32 SW_SHOW = 5; public const Int32 SW_HIDE = 0;

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        private static extern Int32 SystemParametersInfo(Int32 uAction, Int32 uParam, ref Rectangle lpvParam, Int32 fuWinIni);
        public const Int32 SPIF_UPDATEINIFILE = 0x1;
        public const Int32 SPI_SETWORKAREA = 47;
        public const Int32 SPI_GETWORKAREA = 48;

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern Int32 FindWindow(string lpClassName, string lpWindowName);
 
        #endregion
        FormBigImage formBig = new FormBigImage();
        private bool CanClose = false;
        private bool ShowAutoSubmit = true;
        private readonly Statuses _status = new Statuses();
        private DateTime _EndTime;
        VoiceHelper _voiceHelper = null;
        public FormSimulation()
        {
            InitializeComponent();
        }

        int m_type = 0;
        public void SetShowType(int Type)
        {
            m_type = Type;
            if(Type == 0)
            {
                panelSimulation.Visible = true;
                panelSimulation.BringToFront();
                panelSkill.Visible = false;
                _status.IsSkillTrain = false;
                //labelTitle.Visible = false;
                richTextBoxTitle.Visible = true;
                chkBoxEmphasize.Visible = false;
                chkBoxEmphasize.Checked = false;
                checkBoxAutoChange.Checked = false;
                checkBoxAutoChange.Visible = false;
                checkBoxAutoRead.Checked = false;
                checkBoxAutoRead.Visible = false;
                _status.IsShowCorrectAnswer = false;
                _status.incorectAnswers = 0;
            }
            else if(Type==1)
            {
                panelSimulation.Visible = false;
                panelSkill.BringToFront();
                panelSkill.Visible = true;
                _status.IsSkillTrain = true;
                //labelTitle.Visible = true;
                richTextBoxTitle.Visible = true;
                checkBoxAutoChange.Checked = false;
                checkBoxAutoChange.Visible = true;
                chkBoxEmphasize.Visible = true;
                chkBoxEmphasize.Checked = false;
                checkBoxAutoRead.Checked = false;
                checkBoxAutoRead.Visible = true;
                _status.IsShowCorrectAnswer = true;
                _status.incorectAnswers = 0;
            }
            else
            {
                panelSimulation.Visible = true;
                panelSimulation.BringToFront();
                panelSkill.Visible = false;
                _status.IsSkillTrain = true;
                //labelTitle.Visible = false;
                richTextBoxTitle.Visible = true;
                chkBoxEmphasize.Visible = true;
                chkBoxEmphasize.Checked = false;
                checkBoxAutoChange.Checked = false;
                checkBoxAutoChange.Visible = false;
                checkBoxAutoRead.Checked = false;
                checkBoxAutoRead.Visible = true;
                _status.IsShowCorrectAnswer = false;
                _status.incorectAnswers = 0;
            }
        }
        private void btnAnswer_Click(object sender, EventArgs e)
        {
            if (_status.AllQuestion[_status.CurrentIdx].Type != 3)
            {
                PanelData panelData = (PanelData)_status.AllQeustionPanels[_status.CurrentIdx].Tag;
                labelAnswer.Text = ((Button)sender).Text;
                _status.AllQeustionPanels[_status.CurrentIdx].AnswerText = labelAnswer.Text;

                panelData.answerString = labelAnswer.Text;
                if (_status.AllQuestion[_status.CurrentIdx].CorrectAnswer[0] != Convert.ToInt32(((Control)sender).Tag))
                {
                    panelData.isRight = 2;
                }
                else
                {
                    panelData.isRight = 1;
                }

                if (checkBoxAutoChange.Checked == true)
                {
                    btnNext.PerformClick();
                }
            }
            else
            {
                if(Convert.ToInt32(((Control)sender).Tag) == 1)
                    checkBoxA.Checked = true;
                if(Convert.ToInt32(((Control)sender).Tag) == 2)
                    checkBoxB.Checked = true;
                if(Convert.ToInt32(((Control)sender).Tag) == 3)
                    checkBoxC.Checked = true;
                if(Convert.ToInt32(((Control)sender).Tag) == 4)
                    checkBoxD.Checked = true;
            }
        }

        private void VoiceStop()
        {
            if (_voiceHelper != null)
                _voiceHelper.StopSpeaker();
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            VoiceStop();
            labelAnswer.Text = "";
            ShowPrevious();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            VoiceStop();
            labelAnswer.Text = "";
            ShowNext();
        }

        /// <summary>
        /// 生成答题控件
        /// </summary>
        /// <param name="questionNum"></param>
        public void GenControlsOfQuestions(int questionNum)
        {
            DateTime dateTime1 = System.DateTime.Now;
            if(questionNum <=0 || questionNum > 100)
                return;

            //int panelWith = 0;
            //int panelHeight = 0;

            panelAnswerResult.Controls.Clear();

            for (int i = 0; i < questionNum; i++)
            {
                CotrolLibrary.PanelAnswer panel = new CotrolLibrary.PanelAnswer();
                panel.BorderStyle = panelTemplate.BorderStyle;
                panel.Height = panelAnswer1.Height-2;
                panel.Width = panelAnswer1.Width - 6;
                panel.Font = panelAnswer1.Font;

                PanelData data = new PanelData();
                data.id = i;
                data.isRight = 0;
                data.answerString = "";

                panel.Left = 4 + i % 10 * (panelAnswer1.Width + 2);
                panel.Top = 8 + (i / 10) * (panelAnswer1.Height + 6);

                panel.Tag = data;
                
                panel.NumText = (i+1).ToString();
                panel.AnswerText = "";
                panel.Click += new CotrolLibrary.PanelAnswer.ClickEventHandler(panelTemplate_Click);

                panelAnswerResult.Controls.Add(panel);
                _status.AllQeustionPanels.Add(panel);
            }
        }

        public void ResetControlsInfo(int questionNum)
        {
            _status.CurrentIdx = 0;
            _status.firstLoaded = false;
            _status.Score = 0;
            _status.answeredCount = 0;
            _status.incorectAnswers = 0;
            SetExamInfo(SystemConfig._examType, SystemConfig._driverType);

            ShowAutoSubmit = true;

            labelAnswer.Text = "";
            timer1.Enabled = true;
            timer1.Start();

            if (SystemConfig._examType == 0)
            {
                labelTimer.Text = "45:00";
                _EndTime = System.DateTime.Now.AddMinutes(45);
            }
            else
            {
                labelTimer.Text = "30:00";
                _EndTime = System.DateTime.Now.AddMinutes(45);
            }

            if (_status.AllQeustionPanels.Count < 90)
                Thread.Sleep(100);

            for (int i = 0; i < _status.AllQeustionPanels.Count; i++)
            {
                CotrolLibrary.PanelAnswer panel = _status.AllQeustionPanels[i];
                panel.AnswerText = "";
                panel.NumText = (i+1).ToString();

                PanelData data = (PanelData)panel.Tag;
                data.id = i;
                data.isRight = 0;
                data.answerString = "";
                data.isCheck = false;

                panel.BackColor = Color.White;
                if (i < questionNum)
                    panel.Visible = true;
                else
                    panel.Visible = false;
            }

            ShowId(0);
        }

        private void FormSimulation_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            _voiceHelper = VoiceHelper.getVoiceHelper();

            SetFormFullScreen(true);

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Activate();


            panelMain.Left = (int)Math.Round((this.Width - panelMain.Width) / 2.0);
            panelMain.Top = (int)Math.Round((this.Height - panelMain.Height) / 2.0);            
        }

        private void panelTemplate_Click(object sender, EventArgs e)
        {
            VoiceStop();
            PanelData panelData = (PanelData)((Control)sender).Tag;
            ShowId(panelData.id);
        }

        private void ShowPrevious()
        {
            _status.PrevIdx--;
            if (_status.PrevIdx < 0)
            {
                MessageBox.Show("已经是第一题了");
                return;
            }

            ShowId(_status.PrevIdx);
        }

        void ShowNext()
        {
            if (_status.AllQuestion.Count <= _status.CurrentIdx + 1)
            {
               // MessageBox.Show("已经答完全部题目，正确率：" + labPer.Text);
                MessageBox.Show("已经答完全部题目");
                return;
            }

            ShowId(_status.CurrentIdx + 1);
        }

        private void ShowId(int id)
        {
            //if (id == _status.CurrentIdx && _status.firstLoaded)
            //    return;

            //检查上个答案是否正确
            //if (_status.firstLoaded == false)
            //{
                PanelData panelDataOld = (PanelData)_status.AllQeustionPanels[_status.CurrentIdx].Tag;
                _status.AllQeustionPanels[_status.CurrentIdx].BackColor = panelDataOld.isRight < 2 ? Color.White : Color.Red;

                if (_status.AllQuestion.Count <= 0)
                    return;

                Question questionOld = _status.AllQuestion[_status.CurrentIdx];

                //将上一个题目的状态更新到答题信息
                AnswerQuestion Answer = null;
                _status.AnswerQuestion.TryGetValue(questionOld.Id, out Answer);
                Answer.RightStatus = panelDataOld.isRight;
                Answer.AnswerString = panelDataOld.answerString;

                if (panelDataOld.isCheck == false && panelDataOld.isRight != 0)
                {
                    panelDataOld.isCheck = true;

                    if (panelDataOld.isRight == 2)
                    {
                        //答题完成
                        _status.incorectAnswers++;
                        if (_status.IsSkillTrain == false && true == ShowAutoSubmit)
                        {
                            if ((SystemConfig._examType == 0 && _status.incorectAnswers >= 11) ||
                            (SystemConfig._examType == 1 && _status.incorectAnswers >= 6))
                            {
                                ShowAutoSubmit = false;
                                FormSimulationSubmit submit = new FormSimulationSubmit();
                                submit.SetInfo(true);
                                DialogResult result = submit.ShowDialog();
                                if (DialogResult.Cancel == result)
                                {
                                    return;
                                }
                                else
                                {
                                    FormSimulationInfo simulaInfo = new FormSimulationInfo(_status.Score);
                                    if (DialogResult.OK == simulaInfo.ShowDialog())
                                    {
                                        _status.IsShowCorrectAnswer = true;
                                    }
                                }

                                return;
                            }
                        }
                    
                        if (_status.IsSkillTrain == false)
                        {
                            FormSimulationErrorInfo errorInfo = new FormSimulationErrorInfo();
                            errorInfo.SetInfo(questionOld, _status.CurrentIdx);
                            errorInfo.ShowDialog();
                        }
                    }
                    else
                    {
                        if (SystemConfig._examType == 0)
                        {
                            _status.Score += 1;
                        }
                        else
                        {
                            _status.Score += 2;
                        }
                    }
                }

            Question question = _status.AllQuestion[id];
            PanelData panelDataNew = (PanelData)_status.AllQeustionPanels[id].Tag;
            labelAnswer.Text = panelDataNew.answerString;

            if (id == 0)
            {
                _status.firstLoaded = true;
                _status.AllQeustionPanels[id].BackColor = panelTemplate.BackColor;
            }


            int FontSizeNormal = 18;
            int FontSizeEmphasize = 20;
            int HeightOffset = 5;
            if(Height > 800)
            {
                FontSizeNormal = 20;
                FontSizeEmphasize = 22;
                HeightOffset = 10;
            }

            #region 显示题目信息
            _status.AllQeustionPanels[id].BackColor = panelTemplate.BackColor;
            int top = 0;
            richTextBoxTitle.Font = new Font("宋体", FontSizeNormal);
            if (false == _status.IsSkillTrain)
            {
                //labelTitle.Visible = false;
                richTextBoxTitle.Visible = true;
                richTextBoxTitle.Text = (id + 1) + "." + question.Tittle;
                richTextBoxTitle.Font = new Font("宋体", FontSizeNormal);

                top = richTextBoxTitle.Top + richTextBoxTitle.Height + HeightOffset;
                richTextBoxTitle.BringToFront();
            }
            else
            {
                //题目信息强调
                richTextBoxExplain.Text = question.SkillNotice.Replace("&", "\n");
                richTextBoxExplain.Font = new Font("宋体", FontSizeNormal, FontStyle.Bold);

                richTextBoxTitle.Text = (id + 1) + "." + question.Tittle;
                if (chkBoxEmphasize.Checked)
                {
                    //查找强调并显示
                    //题目信息强调
                    string[] emphasizeList = question.TittleEmphasize.Split(new char[3]{'&',',','，'});
                    for (int i = 0; i < emphasizeList.Length; i++)
                    {
                        richTextBoxTitle.Find(emphasizeList[i]);
                        //richTextBoxTitle.SelectionFont = new Font("宋体", 26.25f, FontStyle.Bold);
                        richTextBoxTitle.SelectionColor = Color.OrangeRed;
                    }
                }
                top = richTextBoxTitle.Top + richTextBoxTitle.Height + HeightOffset;
                //int width = richTextBoxTitle.Width
            }

            //richTextBoxTitle.Width = labelTitle.Width;

            if (question.Type != 1)
            {
                richTextBoxA.Font = new Font("宋体", FontSizeNormal);
                richTextBoxB.Font = new Font("宋体", FontSizeNormal);
                richTextBoxC.Font = new Font("宋体", FontSizeNormal);
                richTextBoxD.Font = new Font("宋体", FontSizeNormal);
                richTextBoxA.Visible = true;
                richTextBoxB.Visible = true;
                richTextBoxC.Visible = true;
                richTextBoxD.Visible = true;

                richTextBoxA.Text = "A. " + question.Options[0];
                richTextBoxB.Text = "B. " + question.Options[1];
                richTextBoxC.Text = "C. " + question.Options[2];
                richTextBoxD.Text = "D. " + question.Options[3];
                //答案信息强调
                //技巧时并且勾选了强调才增加强调
                if (_status.IsSkillTrain && chkBoxEmphasize.Checked)
                {
                    string[] emphasizeList0 = question.OptionsEmphasize[0].Split(new char[3] { '&', ',', '，' });
                    for (int i = 0; i < emphasizeList0.Length; i++)
                    {
                        richTextBoxA.Find(emphasizeList0[i]);
                        //richTextBoxTitle.SelectionFont = new Font("宋体", FontSizeNormal, FontStyle.Bold);
                        richTextBoxA.SelectionColor = Color.OrangeRed;
                    }

                    string[] emphasizeList1 = question.OptionsEmphasize[1].Split(new char[3] { '&', ',', '，' });
                    for (int i = 0; i < emphasizeList1.Length; i++)
                    {
                        richTextBoxB.Find(emphasizeList1[i]);
                        //richTextBoxB.SelectionFont = new Font("宋体", FontSizeNormal, FontStyle.Bold);
                        richTextBoxB.SelectionColor = Color.OrangeRed;
                    }

                    string[] emphasizeList2 = question.OptionsEmphasize[2].Split(new char[3] { '&', ',', '，' });
                    for (int i = 0; i < emphasizeList2.Length; i++)
                    {
                        richTextBoxC.Find(emphasizeList2[i]);
                        //richTextBoxC.SelectionFont = new Font("宋体", FontSizeNormal, FontStyle.Bold);
                        richTextBoxC.SelectionColor = Color.OrangeRed;
                    }
                    string[] emphasizeList3 = question.OptionsEmphasize[3].Split(new char[3] { '&', ',', '，' });
                    for (int i = 0; i < emphasizeList3.Length; i++)
                    {
                        richTextBoxD.Find(emphasizeList3[i]);
                        //richTextBoxD.SelectionFont = new Font("宋体", FontSizeNormal, FontStyle.Bold);
                        richTextBoxD.SelectionColor = Color.OrangeRed;
                    }

                    //richTextBoxA.Find(question.OptionsEmphasize[0]);
                    //richTextBoxA.SelectionFont = new Font("宋体", FontSizeNormal, FontStyle.Bold);
                    //richTextBoxA.SelectionColor = Color.OrangeRed;
                    //richTextBoxB.Find(question.OptionsEmphasize[1]);
                    //richTextBoxB.SelectionFont = new Font("宋体", FontSizeNormal, FontStyle.Bold);
                    //richTextBoxB.SelectionColor = Color.OrangeRed;
                    //richTextBoxC.Find(question.OptionsEmphasize[2]);
                    //richTextBoxC.SelectionFont = new Font("宋体", FontSizeNormal, FontStyle.Bold);
                    //richTextBoxC.SelectionColor = Color.OrangeRed;
                    //richTextBoxD.Find(question.OptionsEmphasize[3]);
                    //richTextBoxD.SelectionFont = new Font("宋体", FontSizeNormal, FontStyle.Bold);
                    //richTextBoxD.SelectionColor = Color.OrangeRed;
                }

                //判断是否多选题
                btnRight.Visible = false;
                btnWrong.Visible = false;
                if (question.Type == 3)
                {
                    checkBoxA.Visible = true;
                    checkBoxB.Visible = true;
                    checkBoxC.Visible = true;
                    checkBoxD.Visible = true;

                    checkBoxA.Enabled = false;
                    checkBoxB.Enabled = false;
                    checkBoxC.Enabled = false;
                    checkBoxD.Enabled = false;
                }
                else
                {
                    checkBoxA.Visible = false;
                    checkBoxB.Visible = false;
                    checkBoxC.Visible = false;
                    checkBoxD.Visible = false;
                }

                richTextBoxA.Top = top;
                richTextBoxB.Top = richTextBoxA.Height + top + HeightOffset;
                richTextBoxC.Top = richTextBoxB.Top + richTextBoxB.Height + HeightOffset;
                richTextBoxD.Top = richTextBoxC.Top + richTextBoxC.Height + HeightOffset;

                checkBoxA.Top = richTextBoxA.Top + 12;
                checkBoxB.Top = richTextBoxB.Top + 12;
                checkBoxC.Top = richTextBoxC.Top + 12;
                checkBoxD.Top = richTextBoxD.Top + 12;

                btnA.Visible = true;
                btnB.Visible = true;
                btnC.Visible = true;
                btnD.Visible = true;

                btnA.Enabled = false;
                btnB.Enabled = false;
                btnC.Enabled = false;
                btnD.Enabled = false;

                //isRight 0 未答 1 正确  2错误
                if (panelDataNew.isRight != 0)
                {
                    if (question.Type == 3)
                    {
                        if (panelDataNew.answerString.IndexOf('A') != -1)
                            checkBoxA.Enabled = true;
                        if (panelDataNew.answerString.IndexOf('B') != -1)
                            checkBoxB.Enabled = true;
                        if (panelDataNew.answerString.IndexOf('C') != -1)
                            checkBoxC.Enabled = true;
                        if (panelDataNew.answerString.IndexOf('D') != -1)
                            checkBoxD.Enabled = true;
                    }
                }
                else
                {
                    if (question.Type == 3)
                    {
                        checkBoxA.Enabled = true;
                        checkBoxB.Enabled = true;
                        checkBoxC.Enabled = true;
                        checkBoxD.Enabled = true;

                        btnA.Enabled = true;
                        btnB.Enabled = true;
                        btnC.Enabled = true;
                        btnD.Enabled = true;
                    }
                    else
                    {
                        btnA.Enabled = true;
                        btnB.Enabled = true;
                        btnC.Enabled = true;
                        btnD.Enabled = true;
                    }
                    checkBoxA.Checked = false;
                    checkBoxB.Checked = false;
                    checkBoxC.Checked = false;
                    checkBoxD.Checked = false;
                }

                labelNotice.Text = "单选题，请在备选答案中选择您认为正确的答案！";
                //if (question.CorrectAnswer.Count > 1)
                if (question.Type == 3)
                {
                    labelNotice.Text = "选择题，请在备选答案中选择您认为不止一个正确的答案！";
                }
            }
            else
            {
                checkBoxA.Visible = false;
                checkBoxB.Visible = false;
                checkBoxC.Visible = false;
                checkBoxD.Visible = false;
                checkBoxA.Checked = false;
                checkBoxB.Checked = false;
                checkBoxC.Checked = false;
                checkBoxD.Checked = false;

                richTextBoxA.Visible = false;
                richTextBoxB.Visible = false;
                richTextBoxC.Visible = false;
                richTextBoxD.Visible = false;

                richTextBoxA.Text = "";
                richTextBoxB.Text = "";
                richTextBoxC.Text = "";
                richTextBoxD.Text = "";
                //UNDO:
                //labelA.Text = "";
                //labelB.Text = "";
                //labelC.Text = "";
                //labelD.Text = "";

                btnRight.Visible = true;
                btnWrong.Visible = true;

                btnA.Visible = false;
                btnB.Visible = false;
                btnC.Visible = false;
                btnD.Visible = false;

                if (panelDataNew.isRight != 0)
                {
                    btnRight.Enabled = false;
                    btnWrong.Enabled = false;
                }
                else
                {
                    btnRight.Enabled = true;
                    btnWrong.Enabled = true;
                }

                labelNotice.Text = "判断题，请判断对错！";
            }

            //判断是否显示正确的答案
            labelAnswerInfo.Visible = false;
            labelCorrectAnswer.Visible = false;
            labelCorrectAnswer.Text = "";
            if (panelDataNew.isRight != 0)
            {
                if (_status.IsShowCorrectAnswer)
                {
                    labelAnswerInfo.Visible = true;
                    labelCorrectAnswer.Visible = true;

                    AnswerQuestion correctAnswer;
                    _status.AnswerQuestion.TryGetValue(question.Id, out correctAnswer);
                    if (correctAnswer != null)
                        labelCorrectAnswer.Text = correctAnswer.CorrectString;
                }
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
                axShockwaveFlash1.Visible = false;

                string imagePath = Directory.GetCurrentDirectory() + "\\Images\\" + Path.GetFileName(question.ImagePath);
                //Image imageInfo = Image.FromFile(question.ImagePath);
                Image imageInfo = Image.FromFile(imagePath);
                if (pictureBox1.Height > imageInfo.Height && pictureBox1.Width >= imageInfo.Height)
                {
                    pictureBox1.Dock = DockStyle.Fill;
                    pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                else
                {
                    pictureBox1.Dock = DockStyle.None;
                    pictureBox1.Height = panelImageInfo.Height;
                    pictureBox1.Width =(int)(1.0*imageInfo.Width / imageInfo.Height * pictureBox1.Height);
                    pictureBox1.Left = (panelImageInfo.Width - pictureBox1.Width)/2;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                pictureBox1.Image = imageInfo;
            }

            if (!string.IsNullOrEmpty(question.FlashPath))
            {
                axShockwaveFlash1.Visible = true;
                pictureBox1.Visible = false;
                axShockwaveFlash1.BringToFront();
                axShockwaveFlash1.Movie = Directory.GetCurrentDirectory() + "\\Flash\\" + Path.GetFileName(question.FlashPath);
                this.axShockwaveFlash1.Rewind();
                this.axShockwaveFlash1.Play();
            }
            #endregion

            //更新状态
            _status.PrevIdx = id;
            _status.CurrentIdx = id;

            //处理上一题、下一题
            btnPrevious.Enabled = (id != 0);
            btnNext.Enabled = (id != _status.AllQuestion.Count - 1);

            if (_status.IsSkillTrain && true == checkBoxAutoRead.Checked)
            {
                _voiceHelper.StopSpeaker();
                _voiceHelper.Speeker(richTextBoxExplain.Text.Replace("&", " "));
            }
        }

        #region 生成题目并打乱答案
        /// <summary>
        /// 生成题目
        /// </summary>
        /// <returns></returns>
        public int GenQuestions()
        {
            if (_status.AllQuestion.Count > 0)
                _status.AllQuestion.Clear();

            //排序
            List<Question>lst = QuestionManager.GenQuestionsByExam(SystemConfig._examType, SystemConfig._driverType);
            int [] count = new int [15] {0,0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            int [] typeCount = new int[3]{0, 0, 0};
            foreach(var question in lst)
            {
                typeCount[question.Type-1] += 1;
                count[question.Module-1] += 1;
            }

            _status.AllQuestion.AddRange(lst);
            GenAnswerList();

            return _status.AllQuestion.Count;
        }

        public void SetQuestions(List<Question> list, bool isFlutte=true)
        {
            if (_status.AllQuestion.Count > 0)
                _status.AllQuestion.Clear();

            //打乱答案顺序
            FlutteOptions(list);
            

            //打乱题目顺序
            if (isFlutte == true)
                this.FlutteQuestions(list);

            ReorderQuestions(list);

            _status.AllQuestion.AddRange(list);

            GenAnswerList();

        }

        public void ReorderQuestions(List<Question>list)
        {
            List<Question> type1List = new List<Question>();
            List<Question> type2List = new List<Question>();
            List<Question> type3List = new List<Question>();
            
            foreach(Question question in list)
            {
                if(question.Type == 1)
                {
                    type1List.Add(question);
                }
                else if(question.Type==2)
                {
                    type2List.Add(question);
                }
                else
                {
                    type3List.Add(question);
                }
            }

            list.Clear();
            list.AddRange(type1List);
            list.AddRange(type2List);
            list.AddRange(type3List);
        }

        public void FlutteQuestions(List<Question> list)
        {
            Random ran = new Random();
            List<int> newList = new List<int>();
            int index = 0;
            Question temp;
            for (int i = 0; i < list.Count; i++)
            {

                index = ran.Next(0, list.Count-1);
                if (index != i)
                {
                    temp = list[i];
                    list[i] = list[index];
                    list[index] = temp;
                }
            }
        }

        public void FlutteOptions(List<Question> list)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());

            foreach(Question question in list)
            {
                if(question.Type ==1)
                    continue;

                HashSet<int> questionOrder = new HashSet<int>();
                for (var i = 0; i < 4; i++)
                {
                    var ret = rnd.Next(1, 5);
                    if (ret == 5)
                        MessageBox.Show("error");

                    while (!questionOrder.Add(ret))
                    {
                        ret = rnd.Next(1, 5);
                    }
                }

                int index = 0;
                List<int> curCorrectAnswer = new List<int>();
                List<string> curOptions = new List<string>();
                List<string>curOptionsEmphasize = new List<string>();
                curCorrectAnswer.AddRange(question.CorrectAnswer);
                curOptions.AddRange(question.Options);
                curOptionsEmphasize.AddRange(question.OptionsEmphasize);

                question.Options.Clear();
                question.OptionsEmphasize.Clear();
                question.CorrectAnswer.Clear();
                foreach (var i in questionOrder)
                {
                    index++;
                    question.Options.Add(curOptions[i-1]);
                    question.OptionsEmphasize.Add(curOptionsEmphasize[i-1]);

                    foreach (int anwserId in curCorrectAnswer)
                    {
                        if (anwserId == i)
                        {
                            question.CorrectAnswer.Add(index);
                        }
                        continue;
                    }
                }
            }
           
        }
        
        /// <summary>
        /// 生成答案
        /// </summary>
        private void GenAnswerList()
        {
            _status.AnswerQuestion.Clear();
            int seq = 0;
            foreach (var question in _status.AllQuestion)
            {
                AnswerQuestion answer = new AnswerQuestion();
                answer.question = question;
                seq++;
                answer.seq = seq;
                answer.RightStatus = 0;
                answer.AnswerString = "";
                answer.CorrectString = "";
                for (int i = 0; i < question.CorrectAnswer.Count; i++)
                {
                    int answerType = question.CorrectAnswer[i];
                    if (question.Type == 1)
                    {
                        if (1 == answerType)
                        {
                            answer.CorrectString = string.IsNullOrEmpty(question.Options[0]) ? "正确" : question.Options[0];
                        }
                        if (2 == answerType)
                        {
                            answer.CorrectString = string.IsNullOrEmpty(question.Options[1]) ? "错误" : question.Options[1];
                        }
                    }
                    else
                    {
                        if (1 == answerType)
                        {
                            answer.CorrectString += "A";
                        }
                        if (2 == answerType)
                        {
                            answer.CorrectString += "B";
                        }
                        if (3 == answerType)
                        {
                            answer.CorrectString += "C";
                        }
                        if (4 == answerType)
                        {
                            answer.CorrectString += "D";
                        }
                    }

                }
                _status.AnswerQuestion.Add(question.Id, answer);
            }
        }

        #endregion 

        private void FormSimulation_Shown(object sender, EventArgs e)
        {
            CanClose = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTimer.Text = (_EndTime - DateTime.Now).Minutes.ToString() + ":" + (_EndTime - DateTime.Now).Seconds.ToString();
            if(_EndTime<=DateTime.Now)
            {
                timer1.Stop();
                if(!_status.IsSkillTrain)
                {
                    FormSimulationInfo simulaInfo = new FormSimulationInfo(_status.Score);
                    if(DialogResult.OK == simulaInfo.ShowDialog())
                    {
                        _status.IsShowCorrectAnswer = true;
                    }
                    else
                    {
                        //SetFormFullScreen(false);
                        //Hide();
                    }
                }
                else
                {
                    FormSkillTrainFinish form = new FormSkillTrainFinish();
                    form.SendBack += FormBack;
                    form.SetAnswers(_status.AnswerQuestion);
                    if(DialogResult.Yes == form.ShowDialog())
                    {

                    }
                    else
                    {
                        //Hide();
                    }
                }
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            //更新当前答题结果
            PanelData panelDataNow= (PanelData)_status.AllQeustionPanels[_status.CurrentIdx].Tag;
            Question questionNow= _status.AllQuestion[_status.CurrentIdx];
            AnswerQuestion Answer = null;
            _status.AnswerQuestion.TryGetValue(questionNow.Id, out Answer);
            Answer.RightStatus = panelDataNow.isRight;
            Answer.AnswerString = panelDataNow.answerString;

            if (panelDataNow.isCheck == false && panelDataNow.isRight != 0)
            {
                panelDataNow.isCheck = true;

                if (panelDataNow.isRight == 2)
                {
                    //答题完成
                    _status.incorectAnswers++;
                    if (_status.IsSkillTrain == false && true == ShowAutoSubmit)
                    {
                        if ((SystemConfig._examType == 0 && _status.incorectAnswers >= 11) ||
                        (SystemConfig._examType == 1 && _status.incorectAnswers >= 6))
                        {
                            ShowAutoSubmit = false;
                            FormSimulationSubmit submit = new FormSimulationSubmit();
                            submit.SetInfo(true);
                            DialogResult result = submit.ShowDialog();
                            if (DialogResult.Cancel == result)
                            {
                                return;
                            }
                            else
                            {
                                FormSimulationInfo simulaInfo = new FormSimulationInfo(_status.Score);
                                if (DialogResult.OK == simulaInfo.ShowDialog())
                                {
                                    _status.IsShowCorrectAnswer = true;
                                }
                            }

                            return;
                        }
                    }
                }
                else
                {
                    if (SystemConfig._examType == 0)
                    {
                        _status.Score += 1;
                    }
                    else
                    {
                        _status.Score += 2;
                    }
                }
            }

            VoiceStop();
            if (btnNext.Enabled == false)
            {
                btnPrevious.PerformClick();
                btnNext.PerformClick();
            }
            if(btnPrevious.Enabled == false)
            {
                btnNext.PerformClick();
                btnPrevious.PerformClick();
            }

            if (!_status.IsSkillTrain)
            {
                FormSimulationSubmit submit = new FormSimulationSubmit();
                submit.SetInfo(false);
                DialogResult result = submit.ShowDialog();
                if (DialogResult.Cancel == result)
                {
                    return;
                }
                else
                {
                   
                    for(int i= 0; i < _status.AllQeustionPanels.Count; i++)
                    {
                        PanelData panelDataOld = (PanelData)_status.AllQeustionPanels[i].Tag;
                        if(panelDataOld.isRight == 0)
                        {
                            _status.AllQeustionPanels[i].BackColor = Color.Red;
                        }
                    }

                    FormSimulationInfo simulaInfo = new FormSimulationInfo(_status.Score);
                    if (DialogResult.OK == simulaInfo.ShowDialog())
                    {
                        _status.IsShowCorrectAnswer = true;
                    }
                    else
                    {
                        //SetFormFullScreen(false);
                        //Hide();
                    }
                }
            }
            else
            {
                FormSkillTrainFinish form = new FormSkillTrainFinish();
                for (int i = 0; i < _status.AllQeustionPanels.Count; i++)
                {
                    PanelData panelDataOld = (PanelData)_status.AllQeustionPanels[i].Tag;
                    if (panelDataOld.isRight == 0)
                    {
                        _status.AllQeustionPanels[i].BackColor = Color.Red;
                    }
                }

                form.SendBack += FormBack;
                form.SetAnswers(_status.AnswerQuestion);
                if(DialogResult.Yes == form.ShowDialog())
                {

                }
                else
                {
                   //Hide();
                }

                //FormErrorInfo form1 = new FormErrorInfo();
                //form1.SendBack += FormBack;
                //form1.SetAnswers(_status.AnswerQuestion);
                //if (DialogResult.Yes == form1.ShowDialog())
                //{
                //    Hide();
                //    this.Show();
                //}
                //else
                //{
                //    Hide();
                //}
                
            }

        }

        public bool FormBack(List<Question> list)
        {
            this.SetShowType(m_type);
            this.SetQuestions(list);
            this.ResetControlsInfo(_status.AllQuestion.Count);
            return true;
        }

        /// <summary>
        /// examType 0 C1 1C4
        /// driverType 0 小车 1货车 2客车
        /// </summary>
        /// <param name="examType"></param>
        /// <param name="dirverType"></param>
        private void SetExamInfo(int examType, int dirverType)
        {
            pictureBox2.Image = Image.FromFile("driver.png");
            labelClassInfo.Text = "第01考台";

            switch (dirverType)
            {
                case 0:
                    labelDriverInfo.Text = "小车类";

                    break;
                case 1:
                    labelDriverInfo.Text = "客车类";
                    break;
                case 2:
                    labelDriverInfo.Text = "货车类";
                    break;
                case 3:
                    labelDriverInfo.Text = "摩托车";
                    break;
                default:
                    labelDriverInfo.Text = "小车类";
                    break;
            }
            if(examType == 0)
            {
                labelExamInfo.Text = "科目一";   
            }
            else if(examType ==1)
            {
                labelExamInfo.Text = "科目四";
            }else if(examType ==2)
            {
                labelExamInfo.Text = "恢复资格考试";
            }
            else if(examType ==3)
            {
                labelExamInfo.Text = "消分考试";
            }
            else
            {
                labelExamInfo.Text = "unknown";
            }
        }

        public Boolean SetFormFullScreen(Boolean fullscreen)//, ref Rectangle rectOld
        {
            Rectangle rectOld = Rectangle.Empty;
            Int32 hwnd = 0;
            hwnd = FindWindow("Shell_TrayWnd", null);//获取任务栏的句柄

            if (hwnd == 0) return false;

            if (fullscreen)//全屏
            {
                //ShowWindow(hwnd, SW_HIDE);//隐藏任务栏

                SystemParametersInfo(SPI_GETWORKAREA, 0, ref rectOld, SPIF_UPDATEINIFILE);//get  屏幕范围
                Rectangle rectFull = Screen.PrimaryScreen.Bounds;//全屏范围
                SystemParametersInfo(SPI_SETWORKAREA, 0, ref rectFull, SPIF_UPDATEINIFILE);//窗体全屏幕显示
            }
            else//还原 
            {
                //ShowWindow(hwnd, SW_SHOW);//显示任务栏

                SystemParametersInfo(SPI_SETWORKAREA, 0, ref rectOld, SPIF_UPDATEINIFILE);//窗体还原
            }
            return true;
        }

        private void imageButtonClose_Click(object sender, EventArgs e)
        {
            VoiceStop();
            if(DialogResult.OK != MessageBox.Show("正在考试，是否立即退出?", "确认信息", MessageBoxButtons.OKCancel))
                return;
            
            SetFormFullScreen(false);
            Hide();
        }

        private void FormSimulation_FormClosed(object sender, FormClosedEventArgs e)
        {
            SetFormFullScreen(false);
        }

        private void pictureBoxVoice_Click(object sender, EventArgs e)
        {
            _voiceHelper = VoiceHelper.getVoiceHelper();
            _voiceHelper.Speeker(richTextBoxExplain.Text.ToString());
            richTextBoxExplain.Focus();
        }

        private void pictureBoxExplain_Click(object sender, EventArgs e)
        {
            _voiceHelper.StopSpeaker();
            FormSkillExplain form = new FormSkillExplain();
            form.TopLevel = false;
            form.Parent = this;
            form.BringToFront();
            form.SetText(richTextBoxExplain.Text.Replace("&", "\n"));
            form.Show();
        }

        private void checkBoxA_CheckedChanged(object sender, EventArgs e)
        {
            PanelData panelData = (PanelData)_status.AllQeustionPanels[_status.CurrentIdx].Tag;
            if (panelData.isCheck == true)
                return;

            char [] ch = new char[1] ;
            ch[0] = (char)(64 + Convert.ToInt32(((CheckBox)sender).Tag));
            string answer = new String(ch);

            string currentAnswerList = _status.AllQeustionPanels[_status.CurrentIdx].AnswerText; 
            //如果是一样的则直接返回
            if(((CheckBox)sender).Checked == true)
            {
                //如果已经选中，则返回，未选中则加入并计算是答案是否正确
                if (currentAnswerList.IndexOf(answer) != -1)
                    return;
                else
                {
                    labelAnswer.Text = currentAnswerList.Insert(0, answer);
                }
            }
            else
            {
                if (currentAnswerList.IndexOf(answer) != -1)
                {
                    labelAnswer.Text = currentAnswerList.Replace(answer, "");
                }
                else
                    return;
            }
            
            //检查结果是否正确
            _status.AllQeustionPanels[_status.CurrentIdx].AnswerText = labelAnswer.Text;
            panelData.answerString = labelAnswer.Text;

            if(_status.AllQuestion[_status.CurrentIdx].CorrectAnswer.Count != panelData.answerString.Length)
            {
                panelData.isRight = 2;
            }
            else
            {
                panelData.isRight = 1;
                for (int i = 0; i < _status.AllQuestion[_status.CurrentIdx].CorrectAnswer.Count; i++)
                {
                    ch[0] = (char)(64+_status.AllQuestion[_status.CurrentIdx].CorrectAnswer[i]);
                    string rightAnswerOne = new String(ch);
                    if(panelData.answerString.IndexOf(rightAnswerOne) == -1)
                    {
                        panelData.isRight = 2;
                        break;
                    }
                }
            }
        }

        private void panelQuestion_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.Y || e.KeyCode == Keys.NumPad4)
            {
                if (btnRight.Visible == true)
                    btnRight.PerformClick();

            }
            if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.N || e.KeyCode == Keys.NumPad6)
            {
                if (btnWrong.Visible == true)
                    btnWrong.PerformClick();
            }

            if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.A || e.KeyCode == Keys.NumPad7)
            {
                if (btnA.Visible == true)
                    btnA.PerformClick();
            }

            if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.B || e.KeyCode == Keys.NumPad8)
            {
                if (btnB.Visible == true)
                    btnB.PerformClick();
            }

            if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.C)
            {
                if (btnC.Visible == true)
                    btnC.PerformClick();
            }

            if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.D || e.KeyCode == Keys.NumPad5)
            {
                if (btnD.Visible == true)
                    btnD.PerformClick();
            }

            if(e.KeyCode == Keys.Enter)
            {
                btnFinish.PerformClick();
            }
            if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
            {
                btnNext.PerformClick();
            }
            if(e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
            {
                btnPrevious.PerformClick();
            }
            if(e.KeyCode == Keys.Delete)
            {
                imageButtonClose.PerformClick();
            }
        }

        private void checkBoxAutoRead_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBoxAutoRead.Checked == true)
            //    _voiceHelper.Speeker(richTextBoxExplain.Text);
            //else

            if(checkBoxAutoRead.Checked == false)
                _voiceHelper.StopSpeaker();
            else
                _voiceHelper.Speeker(richTextBoxExplain.Text);

            btnNext.Focus();
        }

        private void FormSimulation_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F4 && e.Modifiers == Keys.Alt)
            {
                CanClose = true;
            }
        }

        private void FormSimulation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(CanClose == true)
            {
                e.Cancel = true;
                CanClose = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Question question = _status.AllQuestion[_status.CurrentIdx];
            if(!string.IsNullOrEmpty(question.ImagePath))
            {
                formBig.SetInfo(question.ImagePath, question.FlashPath);
                formBig.Show();
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            formBig.Hide();
        }

        private void axShockwaveFlash1_Enter(object sender, EventArgs e)
        {
            Question question = _status.AllQuestion[_status.CurrentIdx];
            if(!string.IsNullOrEmpty(question.FlashPath))
            {
                formBig.SetInfo(question.ImagePath, question.FlashPath);
                formBig.ShowDialog();
            }
        }

        private void axShockwaveFlash1_Leave(object sender, EventArgs e)
        {
            formBig.Hide();
        }

        private void richTextBoxTitle_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            RichTextBox richTextBox = ((RichTextBox)sender);
            richTextBox.Height = e.NewRectangle.Height;
            richTextBox.Width = panelQuestion.Width - richTextBox.Left - 25;
        }

        private void panelAnswerResult_Resize(object sender, EventArgs e)
        {
            try
            {
                //return;
                foreach (Control control in panelAnswerResult.Controls)
                {
                    CotrolLibrary.PanelAnswer panel = control as CotrolLibrary.PanelAnswer;
                    if (panel == null)
                        continue;

                    int panelWidth = (panelAnswerResult.Width - 4) / 9;
                    int panelHeight = (panelAnswerResult.Height - 4) / 9;

                    PanelData data = (PanelData)panel.Tag;
                    if (data == null)
                        continue;
                     
                    int id = data.id;

                    panel.Width = Math.Min(panelWidth, panel.Width);
                    panel.Height = Math.Min(panelHeight, panel.Height);
                    panel.Left = 4 + id % 10 * (panel.Width + 2);
                    panel.Top = 4 + (id / 10) * (panel.Height + 2);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkBoxEmphasize_CheckedChanged(object sender, EventArgs e)
        {
            int FontSizeNormal = 18;
            int FontSizeEmphasize = 20;
            int HeightOffset = 5;
            if (Height > 800)
            {
                FontSizeNormal = 20;
                FontSizeEmphasize = 22;
                HeightOffset = 10;
            }

            ShowId(_status.CurrentIdx);
            return;

            Question question = _status.AllQuestion[_status.CurrentIdx];
            if (chkBoxEmphasize.Checked)
            {
                richTextBoxTitle.Find(question.TittleEmphasize);
                richTextBoxTitle.SelectionFont = new Font("宋体", FontSizeNormal, FontStyle.Bold);
                richTextBoxTitle.SelectionColor = Color.OrangeRed;

                richTextBoxA.Find(question.OptionsEmphasize[0]);
                richTextBoxA.SelectionFont = new Font("宋体", FontSizeNormal, FontStyle.Bold);
                richTextBoxA.SelectionColor = Color.OrangeRed;
                richTextBoxB.Find(question.OptionsEmphasize[1]);
                richTextBoxB.SelectionFont = new Font("宋体", FontSizeNormal, FontStyle.Bold);
                richTextBoxB.SelectionColor = Color.OrangeRed;
                richTextBoxC.Find(question.OptionsEmphasize[2]);
                richTextBoxC.SelectionFont = new Font("宋体", FontSizeNormal, FontStyle.Bold);
                richTextBoxC.SelectionColor = Color.OrangeRed;
                richTextBoxD.Find(question.OptionsEmphasize[3]);
                richTextBoxD.SelectionFont = new Font("宋体", FontSizeNormal, FontStyle.Bold);
                richTextBoxD.SelectionColor = Color.OrangeRed;
            }            
            else
            {
                richTextBoxTitle.Find(question.TittleEmphasize);
                richTextBoxTitle.SelectionFont = new Font("宋体", FontSizeNormal);
                richTextBoxTitle.SelectionColor = Color.Black;

                richTextBoxA.Find(question.OptionsEmphasize[0]);
                richTextBoxA.SelectionFont = new Font("宋体", FontSizeNormal);
                richTextBoxA.SelectionColor = Color.Black;
                richTextBoxB.Find(question.OptionsEmphasize[1]);
                richTextBoxB.SelectionFont = new Font("宋体", FontSizeNormal);
                richTextBoxB.SelectionColor = Color.Black;
                richTextBoxC.Find(question.OptionsEmphasize[2]);
                richTextBoxC.SelectionFont = new Font("宋体", FontSizeNormal);
                richTextBoxC.SelectionColor = Color.Black;
                richTextBoxD.Find(question.OptionsEmphasize[3]);
                richTextBoxD.SelectionFont = new Font("宋体", FontSizeNormal);
                richTextBoxD.SelectionColor = Color.Black;
            }
        }
    }

    class PanelData
    {
        public int id = 0;
        public string answerString = "";
        public int isRight = 0;
        public bool isCheck = false;
    }

    class Statuses
    {
        /// <summary>
        /// 初始化保存要回答的题目列表，回答完毕的题目 会从数组中删除
        /// </summary>
        public List<Question> AllQuestion = new List<Question>();

        public List<CotrolLibrary.PanelAnswer> AllQeustionPanels = new List<CotrolLibrary.PanelAnswer>();
        public int Score = 0;
        public bool firstLoaded = false;

        /// <summary>
        /// 当前回答到AllQuestion里第几个元素
        /// </summary>
        public int CurrentIdx = 0;
        /// <summary>
        /// 问题Id
        /// </summary>
        public Question Ques
        {
            get
            {
                return AllQuestion[CurrentIdx];
            }
        }

        /// <summary>
        /// 用于查看上一题的记录
        /// </summary>
        public int PrevIdx { get; set; }

        /// <summary>
        /// 所有问题总数（比如回答1~100,这个值就是100）
        /// </summary>
        public int QuestionNum
        {
            get
            {
                return AllQuestion.Count;
            }
        }

        public int incorectAnswers = 0;
        public int answeredCount = 0;
        //判断是否技巧训练的界面
        public bool IsSkillTrain = false;
        public bool IsShowCorrectAnswer = false;

        public Dictionary<int, AnswerQuestion> AnswerQuestion = new Dictionary<int, AnswerQuestion>();
    }
}