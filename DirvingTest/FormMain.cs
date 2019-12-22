using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
//using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DirvingTest
{
    public partial class FormMain : Form
    {
        public static FormSimulation m_formSimulation = null;

        private CotrolLibrary.ImageButton currentButton = null;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wparam, int lparam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private Form activeFrom = null;
        public FormMain()
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


        private void buttonSimulation_Click(object sender, EventArgs e)
        {
            
            if (activeFrom != null)
            {
                Type classType = activeFrom.GetType();

                if (classType.Name == "FormSimulationWelcom")
                {
                    return;
                }

                activeFrom.Close();
            }

            FormSimulationWelcom simulaForm = new FormSimulationWelcom();

            simulaForm.TopLevel = false;

            simulaForm.BringToFront();
            simulaForm.Dock = DockStyle.Fill;

            simulaForm.Parent = this.panelMain;

            simulaForm.SetParentControl(panelMain);

            activeFrom = simulaForm;
            
            simulaForm.Show();
        }

        private void buttonSkill_Click(object sender, EventArgs e)
        {
            if (activeFrom != null)
            {
                Type classType = activeFrom.GetType();

                if (classType.Name == "FormSkillTrain")
                {
                    return;
                }

                activeFrom.Close();
            }


            FormLicence licence = new FormLicence();
            licence.ShowDialog();

            FormSkillTrain newForm = new FormSkillTrain();

            newForm.TopLevel = false;
            newForm.BringToFront();
            newForm.Dock = DockStyle.Fill;

            panelMain.Controls.Add(newForm);

            activeFrom = newForm;

            newForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            //ConfigFileHelper.ConfigPath = Directory.GetCurrentDirectory() + "\\SystemConfig.ini";
            //string result = ConfigFileHelper.IniReadValue("Subject1", "Moudle1", ConfigFileHelper.ConfigPath);
            //initProblemToMoudle();
            QuestionManager.FileCopy(@"D:\Projects\C#\DirvingTest\DirvingTest\bin\test\1522.swf", @"D:\Projects\C#\DirvingTest\DirvingTest\bin\test\1543.swf");
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //加载题目
            

            //生成答题框
            m_formSimulation = new FormSimulation();
            Thread FormThread = new Thread(() =>
            {
                m_formSimulation.GenControlsOfQuestions(100);
               // MessageBox.Show("生成控件完成");
            });

            FormThread.Start();

            if(0 == SystemConfig.GetUserType())
            {
                imageButtonMoudle.Visible = false;
                imageButtonProblems.Visible = false;
                imageButtonSkill.Visible = false;
            }
            else 
            {
                imageButtonMoudle.Visible = true;
                imageButtonProblems.Visible = true;
                imageButtonSkill.Visible = true;   
            }


            Thread VoiceThread = new Thread(() =>
            {
                VoiceHelper _voiceHelper = VoiceHelper.getVoiceHelper();
                //MessageBox.Show("加载声音组件完成");
            });

            VoiceThread.Start();

            Thread LicenceThread = new Thread(() =>
            {
                LicenseHelper.GetCpuId();
                LicenseHelper.GetLinceseInfo();
                //MessageBox.Show("获取授权信息完成");
            });

            LicenceThread.Start();

            btnHome.PerformClick();
        }

        private void initProblemToMoudle()
        {
            FileStream aFile = new FileStream("ProblemToMoudle.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFile);
            for(int i=1; i<=365; i++)
            {
                sw.WriteLine(i + "==>1");
            }
            for (int i = 2541; i <= 2640; i++)
            {
                sw.WriteLine(i + "==>1");
            }

            for (int i = 366; i <= 677; i++)
            {
                sw.WriteLine(i + "==>2");
            }

            for (int i = 678; i <= 864; i++)
            {
                sw.WriteLine(i + "==>3");
            }

            for (int i = 865; i <= 973; i++)
            {
                sw.WriteLine(i + "==>4");
            }

            for (int i = 9710; i <= 9714; i++)
            {
                sw.WriteLine(i + "==>5");
            }
            for (int i = 1026; i <= 1091; i++)
            {
                sw.WriteLine(i + "==>5");
            }

            for (int i = 974; i <= 1025; i++)
            {
                sw.WriteLine(i + "==>6");
            }

            for (int i = 9699; i <= 9709; i++)
            {
                sw.WriteLine(i + "==>6");
            }

            //sw.Close();


            //aFile = new FileStream("ProblemToMoudleSubject2.txt", FileMode.OpenOrCreate);
           // sw = new StreamWriter(aFile);
            for (int i = 1537; i <= 1573; i++)
            {
                sw.WriteLine(i + "==>7");
            }
            for (int i = 1574; i <= 1765; i++)
            {
                sw.WriteLine(i + "==>8");
            }

            for (int i = 2641; i <= 2716; i++)
            {
                sw.WriteLine(i + "==>8");
            }

            for (int i = 1766; i <= 1980; i++)
            {
                sw.WriteLine(i + "==>9");
            }

            for (int i = 1981; i <= 2042; i++)
            {
                sw.WriteLine(i + "==>10");
            }

            for (int i = 2717; i <= 2727; i++)
            {
                sw.WriteLine(i + "==>10");
            }

            for (int i = 2043; i <= 2207; i++)
            {
                sw.WriteLine(i + "==>11");
            }
            
            for (int i = 2728; i <= 2740; i++)
            {
                sw.WriteLine(i + "==>11");
            }

            for (int i = 2208; i <= 2301; i++)
            {
                sw.WriteLine(i + "==>12");
            }

            for (int i = 2302; i <= 2336; i++)
            {
                sw.WriteLine(i + "==>13");
            }

            sw.Close();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            LoadExamInfo();

            FormUserLogin formUserLogin = new FormUserLogin();
            formUserLogin.ShowDialog();
        }

        private void btnQuestionManage_Click(object sender, EventArgs e)
        {
            if (activeFrom != null)
            {
                Type classType = activeFrom.GetType();

                if (classType.Name == "FormQuestionManager")
                {
                    return;
                }

                activeFrom.Close();
            }

            //FormQuestionManager manager = new FormQuestionManager();
            //manager.TopLevel = false;
            //manager.BringToFront();
            //manager.Parent = panelMain;
            //manager.Dock = DockStyle.Fill;

            //activeFrom = manager;
            //activeFrom.Show();
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)//按下的是鼠标左键            
            {
                ReleaseCapture();
                Capture = false;//释放鼠标使能够手动操作                
                SendMessage(Handle, 0x0112, 0xf010 + 0x0002, 0);//拖动窗体            
            }
        }

        private void panelTitle_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Capture = true;
        }

        private void imageButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            ((Control)sender).ForeColor = Color.IndianRed;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).ForeColor = Color.Goldenrod;
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            if (currentButton == sender)
                return;

            if (currentButton != null)
            {
                currentButton.BackgroundImage = null;
            }

            ((CotrolLibrary.ImageButton)(sender)).BackgroundImage = Properties.Resources.ButtonImage2;
            currentButton = (CotrolLibrary.ImageButton)(sender);

            int tag = Convert.ToInt32(currentButton.Tag);
            Form form = null;
            switch(tag)
            {
                case 1:
                    form = new FormHome();
                    break;
                case 2:
                    //form = new FormSubject1();
                    //if(SystemConfig._examType == 0)
                    //{
                    //使用科目一的窗口管理所有的模拟考试
                    form = new FormSubject1();
                    //}

                    //if(SystemConfig._examType == 1)
                    //    form = new FormSubject4();

                    
                    //if(SystemConfig._examType == 2)
                    //    form = new FormRecoverExam();

                    break;
                //case 3:
                //    form = new FormSubject4();
                //    SystemConfig._examType = 1;
                //    break;
                case 3:
                    //form = new FormSkillSelect();
                    //break;
                case 4:
                    //form = new FormBankSelect();
                    //break;
                case 5:

                    //FormIntensifySelect formChapterSelect = new FormIntensifySelect();
                    //formChapterSelect.SetChapterType((FormIntensifySelect.SupportChapterType)tag);
                    //form = formChapterSelect;

                    FormChaperSelect formChapterSelect = new FormChaperSelect();
                    formChapterSelect.SetChapterType((tag-2));
                    form = formChapterSelect;

                    break;
                case 6:
                    form = new FormPurchase();
                    break;
                //case 5:
                //    form = new FormSkillManager();
                //    ((FormSkillManager)form).SetType(0);
                //    break;
                //case 6:
                //    form = new FormSkillManager();
                //    ((FormSkillManager)form).SetType(1);
                //    break;
                //case 7:
                //    form = new FormQuestionManage();
                //    break;
                
                //case 9:
                //    form = new FormRecoverExam();
                //    SystemConfig._examType = 2;
                //    break;

                default:
                    form = new FormHome();
                    break;
            }

            if(activeFrom != null)
                activeFrom.Close();

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.Parent = this.panelMain;
            form.Show();
            
            activeFrom = form;
        }

        private void pictureBoxMenu_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxMenu.BackColor = Color.FromArgb(7, 81, 130);
        }

        private void pictureBoxMenu_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxMenu.BackColor = Color.Transparent;
        }

        private void labelChangeExamType_Click(object sender, EventArgs e)
        {
            FormSelectExamType select = new FormSelectExamType();
            if(DialogResult.Cancel ==  select.ShowDialog())
                return;

            try
            {
                InterfaceForm form = (InterfaceForm)activeFrom;
                form.ReloadForm();
            }
            catch
            {

            }
            

            LoadExamInfo();
        }

        private void imageButtonMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxMenu_Click(object sender, EventArgs e)
        {
            if (false == SystemConfig._IsLogin)
            {
                FormManagerLogin formLogin = new FormManagerLogin();
                if (DialogResult.Yes != formLogin.ShowDialog())
                    return;
            }

            Point dp = new Point(); //定义一个坐标结构

            int top = pictureBoxMenu.Top + pictureBoxMenu.Height;
            int left = pictureBoxMenu.Left + pictureBoxMenu.Width;
            dp.X = left;
            dp.Y = top;

            Point dpScreen = this.PointToScreen(dp);

            contextMenuStrip1.Show(dpScreen.X-22, dpScreen.Y);
        }

        void LoadExamInfo()
        {
            string infoCar = "";
            switch(SystemConfig._driverType)
            {
                case 0:
                    infoCar = "小车";
                    break;
                case 1:
                    infoCar = "客车";
                    break;
                case 2:
                    infoCar = "货车";
                    break;
                case 3:
                    infoCar = "摩托车";
                    break;
                default:
                    infoCar = "unknown";
                    break;
            }
            string infoExam = "";
            switch(SystemConfig._examType)
            {
                case 0:
                    infoExam = "科目一考试";
                    break;
                case 1:
                    infoExam = "科目四考试";
                    break;
                case 2:
                    infoExam = "恢复资格考试";
                    break;
                case 3:
                    infoExam = "消分考试";
                    break;
                default:
                    infoExam = "unknown";
                    break;
            }

            labelExamInfo.Text = string.Format("当前题库:{0}-{1}", infoCar, infoExam);
            return;
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_formSimulation.Close();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            FormLicence form = new FormLicence();
            form.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void MenuQuestionManager_Click(object sender, EventArgs e)
        {
            if (false == SystemConfig._IsLogin)
            {
                FormManagerLogin formLogin = new FormManagerLogin();
                if (DialogResult.Yes != formLogin.ShowDialog())
                    return;
            }

            Form form = new FormQuestionManage();
            if (activeFrom != null)
                activeFrom.Close();

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.Parent = this.panelMain;
            form.Show();

            activeFrom = form;
        }

        /// <summary>
        /// 技巧管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuSkillManager_Click(object sender, EventArgs e)
        {
            //if (false == SystemConfig._IsLogin)
            //{
            //    FormManagerLogin formLogin = new FormManagerLogin();
            //    if (DialogResult.Yes != formLogin.ShowDialog())
            //        return;
            //}

            Form form = new FormChapterManager();
            ((FormChapterManager)form).SetType(1);

            if (activeFrom != null)
                activeFrom.Close();

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.Parent = this.panelMain;
            form.Show();

            activeFrom = form;

        }

        /// <summary>
        /// 套題管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuBankManager_Click(object sender, EventArgs e)
        {
            //if (false == SystemConfig._IsLogin)
            //{
            //    FormManagerLogin formLogin = new FormManagerLogin();
            //    if (DialogResult.Yes != formLogin.ShowDialog())
            //        return;
            //}

            Form form = new FormChapterManager();
            ((FormChapterManager)form).SetType(2);

            if (activeFrom != null)
                activeFrom.Close();

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.Parent = this.panelMain;
            form.Show();

            activeFrom = form;

            //if (false == SystemConfig._IsLogin)
            //{
            //    FormManagerLogin formLogin = new FormManagerLogin();
            //    if (DialogResult.Yes != formLogin.ShowDialog())
            //        return;
            //}

            //Form form = new FormBankManager();
            //if (activeFrom != null)
            //    activeFrom.Close();

            //form.TopLevel = false;
            //form.Dock = DockStyle.Fill;
            //form.Parent = this.panelMain;
            //form.Show();

            //activeFrom = form;
        }

        /// <summary>
        /// 章節管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuChapterManager_Click(object sender, EventArgs e)
        {
            //if(false == SystemConfig._IsLogin)
            //{
            //    FormManagerLogin formLogin = new FormManagerLogin();
            //    if (DialogResult.Yes != formLogin.ShowDialog())
            //        return;
            //}

            Form form = new FormChapterManager();
            ((FormChapterManager)form).SetType(0);

            if (activeFrom != null)
                activeFrom.Close();

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.Parent = this.panelMain;
            form.Show();

            activeFrom = form;
        }

        private void MenuEasyErrorChapterManager_Click(object sender, System.EventArgs e)
        {
            if (false == SystemConfig._IsLogin)
            {
                FormManagerLogin formLogin = new FormManagerLogin();
                if (DialogResult.Yes != formLogin.ShowDialog())
                    return;
            }

            Form form = new FormSkillManager();
            ((FormSkillManager)form).SetType(3);

            if (activeFrom != null)
                activeFrom.Close();

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.Parent = this.panelMain;
            form.Show();

            activeFrom = form;
            //if (false == SystemConfig._IsLogin)
            //{
            //    FormManagerLogin formLogin = new FormManagerLogin();
            //    if (DialogResult.Yes != formLogin.ShowDialog())
            //        return;
            //}

            //Form form = new FormEasyErrorManager();
            //if (activeFrom != null)
            //    activeFrom.Close();

            //form.TopLevel = false;
            //form.Dock = DockStyle.Fill;
            //form.Parent = this.panelMain;
            //form.Show();

            //activeFrom = form;
        }

        private void btnInitialQuestions_Click(object sender, EventArgs e)
        {
            foreach (var question in QuestionManager.m_QuestionsList)
            {
                AddQuestion(question);
            }

            //DataTable data = SQLiteHelper.SQLiteHelper.GetDataTable("select * from questions where 1=@data", new SQLiteParameter[] { new SQLiteParameter("@data", 1) });
        }

        private void AddQuestion(Question question)
        {
            try
            {
                string sqlString = @"insert into questions(id,url,tittle,image,flash,type,moudle 
                                ,classification,option1,option2,option3,option4 
                                ,answer1,answer2,answer3,answer4,tittleEmphasize,skillEmphasize,notice 
                                ,option1Emphasize,option2Emphasize,option3Emphasize,option4Emphasize,
                                skillId, bankId)
                                VALUES(@id,@url, @tittle, @image, @flash, @type, @moudle 
                                , @classification, @option1, @option2, @option3, @option4
                                , @answer1, @answer2, @answer3, @answer4, @tittleEmphasize, @skillEmphasize, @notice
                                , @option1Emphasize, @option2Emphasize, @option3Emphasize, @option4Emphasize,
                                @skillId, @bankId)";

                //SQLiteParameter[] parameters = new SQLiteParameter[23];
                List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                parameters.Add(new SQLiteParameter("@id", question.Id));
                parameters.Add(new SQLiteParameter("@url", question.Url));
                parameters.Add(new SQLiteParameter("@tittle", question.Tittle));
                if (string.IsNullOrEmpty(question.ImagePath))
                {
                    parameters.Add(new SQLiteParameter("@image", null));
                }
                else
                {
                    FileStream fs = new FileStream("Images\\" + question.ImagePath, FileMode.Open);
                    byte[] buffer = StreamUtil.ReadFully(fs);
                    fs.Close();
                    SQLiteParameter para = new SQLiteParameter("@image", DbType.Binary);
                    para.Value = buffer;
                    parameters.Add(para);
                }

                if (string.IsNullOrEmpty(question.FlashPath))
                {
                    parameters.Add(new SQLiteParameter("@flash", null));
                }
                else
                {
                    FileStream fs = new FileStream("Flash\\" + question.FlashPath, FileMode.Open);
                    byte[] buffer = StreamUtil.ReadFully(fs);
                    fs.Close();
                    SQLiteParameter para = new SQLiteParameter("@flash", DbType.Binary);
                    para.Value = buffer;
                    parameters.Add(para);
                }

                parameters.Add(new SQLiteParameter("@type", question.Type));
                parameters.Add(new SQLiteParameter("@moudle", question.Module));
                parameters.Add(new SQLiteParameter("@classification", question.Classification));

                parameters.Add(new SQLiteParameter("@option1", question.Options[0]));
                parameters.Add(new SQLiteParameter("@option2", question.Options[1]));
                parameters.Add(new SQLiteParameter("@option3", question.Options[2]));
                parameters.Add(new SQLiteParameter("@option4", question.Options[3]));

                parameters.Add(new SQLiteParameter("@answer1", question.CorrectAnswer[0]));
                parameters.Add(new SQLiteParameter("@answer2", question.CorrectAnswer[1]));
                parameters.Add(new SQLiteParameter("@answer3", question.CorrectAnswer[2]));
                parameters.Add(new SQLiteParameter("@answer4", question.CorrectAnswer[3]));

                parameters.Add(new SQLiteParameter("@tittleEmphasize", question.TittleEmphasize));
                parameters.Add(new SQLiteParameter("@skillEmphasize", question.SkillNotice));
                parameters.Add(new SQLiteParameter("@notice", question.NormalNotice));


                parameters.Add(new SQLiteParameter("@option1Emphasize", question.OptionsEmphasize[0]));
                parameters.Add(new SQLiteParameter("@option2Emphasize", question.OptionsEmphasize[1]));
                parameters.Add(new SQLiteParameter("@option3Emphasize", question.OptionsEmphasize[2]));
                parameters.Add(new SQLiteParameter("@option4Emphasize", question.OptionsEmphasize[3]));

                parameters.Add(new SQLiteParameter("@skillId", question.Skill));
                parameters.Add(new SQLiteParameter("@bankId", question.BankId));
                int result = SQLiteHelper.SQLiteHelper.ExecuteNonQuery(sqlString, parameters.ToArray());
                if (result <= 0)
                {
                    Console.WriteLine("Error" + question.Id);
                    //MessageBox.Show(ques)
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void MenuUserManager_Click(object sender, EventArgs e)
        {
            if (false == SystemConfig._IsLogin)
            {
                FormManagerLogin formLogin = new FormManagerLogin();
                if (DialogResult.Yes != formLogin.ShowDialog())
                    return;
            }

            Form form = new FormUserManager();

            if (activeFrom != null)
                activeFrom.Close();

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.Parent = this.panelMain;
            form.Show();

            activeFrom = form;
        }
    }
}
