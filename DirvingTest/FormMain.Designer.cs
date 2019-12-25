namespace DirvingTest
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelMain = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuQuestionManager = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSkillManager = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBankManager = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEasyErrorChapterManager = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuChapterManager = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUserManager = new System.Windows.Forms.ToolStripMenuItem();
            this.Register = new System.Windows.Forms.ToolStripMenuItem();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.btnInitialQuestions = new CotrolLibrary.ImageButton();
            this.pictureBoxMenu = new System.Windows.Forms.PictureBox();
            this.btnPractise = new CotrolLibrary.ImageButton();
            this.btnRecoverExam = new CotrolLibrary.ImageButton();
            this.btnSimulations = new CotrolLibrary.ImageButton();
            this.imageButtonSkill = new CotrolLibrary.ImageButton();
            this.imageButtonMoudle = new CotrolLibrary.ImageButton();
            this.labelExamInfo = new System.Windows.Forms.Label();
            this.imageButtonProblems = new CotrolLibrary.ImageButton();
            this.btnHelp = new CotrolLibrary.ImageButton();
            this.btnSkillTrain = new CotrolLibrary.ImageButton();
            this.btnHome = new CotrolLibrary.ImageButton();
            this.labelChangeExamType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageButtonClose = new CotrolLibrary.ImageButton();
            this.imageButtonMin = new CotrolLibrary.ImageButton();
            this.contextMenuStrip1.SuspendLayout();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Location = new System.Drawing.Point(0, 114);
            this.panelMain.Margin = new System.Windows.Forms.Padding(0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1070, 625);
            this.panelMain.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuQuestionManager,
            this.MenuSkillManager,
            this.MenuBankManager,
            this.MenuEasyErrorChapterManager,
            this.MenuChapterManager,
            this.MenuUserManager,
            this.Register});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 158);
            this.contextMenuStrip1.Text = "注册菜单";
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // MenuQuestionManager
            // 
            this.MenuQuestionManager.Name = "MenuQuestionManager";
            this.MenuQuestionManager.Size = new System.Drawing.Size(136, 22);
            this.MenuQuestionManager.Text = "题库管理";
            this.MenuQuestionManager.Click += new System.EventHandler(this.MenuQuestionManager_Click);
            // 
            // MenuSkillManager
            // 
            this.MenuSkillManager.Name = "MenuSkillManager";
            this.MenuSkillManager.Size = new System.Drawing.Size(136, 22);
            this.MenuSkillManager.Text = "技巧管理";
            this.MenuSkillManager.Click += new System.EventHandler(this.MenuSkillManager_Click);
            // 
            // MenuBankManager
            // 
            this.MenuBankManager.Name = "MenuBankManager";
            this.MenuBankManager.Size = new System.Drawing.Size(136, 22);
            this.MenuBankManager.Text = "套题管理";
            this.MenuBankManager.Click += new System.EventHandler(this.MenuBankManager_Click);
            // 
            // MenuEasyErrorChapterManager
            // 
            this.MenuEasyErrorChapterManager.Name = "MenuEasyErrorChapterManager";
            this.MenuEasyErrorChapterManager.Size = new System.Drawing.Size(136, 22);
            this.MenuEasyErrorChapterManager.Text = "易错题管理";
            this.MenuEasyErrorChapterManager.Click += new System.EventHandler(this.MenuEasyErrorChapterManager_Click);
            // 
            // MenuChapterManager
            // 
            this.MenuChapterManager.Name = "MenuChapterManager";
            this.MenuChapterManager.Size = new System.Drawing.Size(136, 22);
            this.MenuChapterManager.Text = "章节管理";
            this.MenuChapterManager.Click += new System.EventHandler(this.MenuChapterManager_Click);
            // 
            // MenuUserManager
            // 
            this.MenuUserManager.Name = "MenuUserManager";
            this.MenuUserManager.Size = new System.Drawing.Size(136, 22);
            this.MenuUserManager.Text = "用户管理";
            this.MenuUserManager.Click += new System.EventHandler(this.MenuUserManager_Click);
            // 
            // Register
            // 
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(136, 22);
            this.Register.Text = "注册";
            this.Register.Visible = false;
            this.Register.Click += new System.EventHandler(this.Register_Click);
            // 
            // panelTitle
            // 
            this.panelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelTitle.BackgroundImage = global::DirvingTest.Properties.Resources.backgroudTitle;
            this.panelTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTitle.Controls.Add(this.lblUserName);
            this.panelTitle.Controls.Add(this.lblLogin);
            this.panelTitle.Controls.Add(this.btnInitialQuestions);
            this.panelTitle.Controls.Add(this.pictureBoxMenu);
            this.panelTitle.Controls.Add(this.btnPractise);
            this.panelTitle.Controls.Add(this.btnRecoverExam);
            this.panelTitle.Controls.Add(this.btnSimulations);
            this.panelTitle.Controls.Add(this.imageButtonSkill);
            this.panelTitle.Controls.Add(this.imageButtonMoudle);
            this.panelTitle.Controls.Add(this.labelExamInfo);
            this.panelTitle.Controls.Add(this.imageButtonProblems);
            this.panelTitle.Controls.Add(this.btnHelp);
            this.panelTitle.Controls.Add(this.btnSkillTrain);
            this.panelTitle.Controls.Add(this.btnHome);
            this.panelTitle.Controls.Add(this.labelChangeExamType);
            this.panelTitle.Controls.Add(this.label1);
            this.panelTitle.Controls.Add(this.pictureBox1);
            this.panelTitle.Controls.Add(this.imageButtonClose);
            this.panelTitle.Controls.Add(this.imageButtonMin);
            this.panelTitle.Location = new System.Drawing.Point(-7, 0);
            this.panelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1085, 115);
            this.panelTitle.TabIndex = 2;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            this.panelTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseUp);
            // 
            // lblUserName
            // 
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblUserName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUserName.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblUserName.Location = new System.Drawing.Point(506, 49);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(140, 14);
            this.lblUserName.TabIndex = 26;
            this.lblUserName.Text = "登录用户:未登录";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogin.Font = new System.Drawing.Font("宋体", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLogin.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblLogin.Location = new System.Drawing.Point(851, 85);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(89, 19);
            this.lblLogin.TabIndex = 25;
            this.lblLogin.Text = "用户登录";
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLogin.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnInitialQuestions
            // 
            this.btnInitialQuestions.BackColor = System.Drawing.Color.Transparent;
            this.btnInitialQuestions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInitialQuestions.ForeColor = System.Drawing.SystemColors.Control;
            this.btnInitialQuestions.HeadImage = null;
            this.btnInitialQuestions.Location = new System.Drawing.Point(946, 30);
            this.btnInitialQuestions.MouseClickImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.btnInitialQuestions.MouseOverImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.btnInitialQuestions.Name = "btnInitialQuestions";
            this.btnInitialQuestions.Size = new System.Drawing.Size(71, 31);
            this.btnInitialQuestions.TabIndex = 24;
            this.btnInitialQuestions.Tag = "7";
            this.btnInitialQuestions.Text = "题库管理";
            this.btnInitialQuestions.TextFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInitialQuestions.Visible = false;
            this.btnInitialQuestions.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.btnInitialQuestions_Click);
            // 
            // pictureBoxMenu
            // 
            this.pictureBoxMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxMenu.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxMenu.Image = global::DirvingTest.Properties.Resources.menu;
            this.pictureBoxMenu.Location = new System.Drawing.Point(603, 22);
            this.pictureBoxMenu.Name = "pictureBoxMenu";
            this.pictureBoxMenu.Size = new System.Drawing.Size(23, 23);
            this.pictureBoxMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMenu.TabIndex = 18;
            this.pictureBoxMenu.TabStop = false;
            this.pictureBoxMenu.Click += new System.EventHandler(this.pictureBoxMenu_Click);
            this.pictureBoxMenu.MouseLeave += new System.EventHandler(this.pictureBoxMenu_MouseLeave);
            this.pictureBoxMenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMenu_MouseMove);
            // 
            // btnPractise
            // 
            this.btnPractise.BackColor = System.Drawing.Color.Transparent;
            this.btnPractise.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPractise.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPractise.HeadImage = global::DirvingTest.Properties.Resources.notes;
            this.btnPractise.Location = new System.Drawing.Point(429, 75);
            this.btnPractise.MouseClickImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.btnPractise.MouseOverImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.btnPractise.Name = "btnPractise";
            this.btnPractise.Size = new System.Drawing.Size(119, 37);
            this.btnPractise.TabIndex = 23;
            this.btnPractise.Tag = "4";
            this.btnPractise.Text = "强化练习";
            this.btnPractise.TextFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPractise.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButton_Click);
            // 
            // btnRecoverExam
            // 
            this.btnRecoverExam.BackColor = System.Drawing.Color.Transparent;
            this.btnRecoverExam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRecoverExam.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRecoverExam.HeadImage = global::DirvingTest.Properties.Resources.add;
            this.btnRecoverExam.Location = new System.Drawing.Point(568, 75);
            this.btnRecoverExam.MouseClickImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.btnRecoverExam.MouseOverImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.btnRecoverExam.Name = "btnRecoverExam";
            this.btnRecoverExam.Size = new System.Drawing.Size(119, 37);
            this.btnRecoverExam.TabIndex = 22;
            this.btnRecoverExam.Tag = "5";
            this.btnRecoverExam.Text = "错题练习";
            this.btnRecoverExam.TextFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRecoverExam.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButton_Click);
            // 
            // btnSimulations
            // 
            this.btnSimulations.BackColor = System.Drawing.Color.Transparent;
            this.btnSimulations.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSimulations.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSimulations.HeadImage = global::DirvingTest.Properties.Resources.edit;
            this.btnSimulations.Location = new System.Drawing.Point(151, 75);
            this.btnSimulations.MouseClickImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.btnSimulations.MouseOverImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.btnSimulations.Name = "btnSimulations";
            this.btnSimulations.Size = new System.Drawing.Size(119, 37);
            this.btnSimulations.TabIndex = 13;
            this.btnSimulations.Tag = "2";
            this.btnSimulations.Text = "模拟考试";
            this.btnSimulations.TextFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSimulations.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButton_Click);
            // 
            // imageButtonSkill
            // 
            this.imageButtonSkill.BackColor = System.Drawing.Color.Transparent;
            this.imageButtonSkill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageButtonSkill.ForeColor = System.Drawing.SystemColors.Control;
            this.imageButtonSkill.HeadImage = null;
            this.imageButtonSkill.Location = new System.Drawing.Point(720, 32);
            this.imageButtonSkill.MouseClickImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.imageButtonSkill.MouseOverImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.imageButtonSkill.Name = "imageButtonSkill";
            this.imageButtonSkill.Size = new System.Drawing.Size(71, 31);
            this.imageButtonSkill.TabIndex = 21;
            this.imageButtonSkill.Tag = "5";
            this.imageButtonSkill.Text = "技巧管理";
            this.imageButtonSkill.TextFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imageButtonSkill.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButton_Click);
            // 
            // imageButtonMoudle
            // 
            this.imageButtonMoudle.BackColor = System.Drawing.Color.Transparent;
            this.imageButtonMoudle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageButtonMoudle.ForeColor = System.Drawing.SystemColors.Control;
            this.imageButtonMoudle.HeadImage = null;
            this.imageButtonMoudle.Location = new System.Drawing.Point(797, 32);
            this.imageButtonMoudle.MouseClickImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.imageButtonMoudle.MouseOverImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.imageButtonMoudle.Name = "imageButtonMoudle";
            this.imageButtonMoudle.Size = new System.Drawing.Size(71, 31);
            this.imageButtonMoudle.TabIndex = 20;
            this.imageButtonMoudle.Tag = "6";
            this.imageButtonMoudle.Text = "章节管理";
            this.imageButtonMoudle.TextFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imageButtonMoudle.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButton_Click);
            // 
            // labelExamInfo
            // 
            this.labelExamInfo.AutoSize = true;
            this.labelExamInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelExamInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.labelExamInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelExamInfo.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.labelExamInfo.Location = new System.Drawing.Point(304, 32);
            this.labelExamInfo.Name = "labelExamInfo";
            this.labelExamInfo.Size = new System.Drawing.Size(140, 14);
            this.labelExamInfo.TabIndex = 19;
            this.labelExamInfo.Text = "当前题库:小车驾驶证";
            // 
            // imageButtonProblems
            // 
            this.imageButtonProblems.BackColor = System.Drawing.Color.Transparent;
            this.imageButtonProblems.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageButtonProblems.ForeColor = System.Drawing.SystemColors.Control;
            this.imageButtonProblems.HeadImage = null;
            this.imageButtonProblems.Location = new System.Drawing.Point(869, 32);
            this.imageButtonProblems.MouseClickImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.imageButtonProblems.MouseOverImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.imageButtonProblems.Name = "imageButtonProblems";
            this.imageButtonProblems.Size = new System.Drawing.Size(71, 31);
            this.imageButtonProblems.TabIndex = 17;
            this.imageButtonProblems.Tag = "7";
            this.imageButtonProblems.Text = "题库管理";
            this.imageButtonProblems.TextFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imageButtonProblems.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButton_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.Transparent;
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHelp.ForeColor = System.Drawing.SystemColors.Control;
            this.btnHelp.HeadImage = global::DirvingTest.Properties.Resources.faq;
            this.btnHelp.Location = new System.Drawing.Point(707, 75);
            this.btnHelp.MouseClickImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.btnHelp.MouseOverImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(119, 37);
            this.btnHelp.TabIndex = 16;
            this.btnHelp.Tag = "6";
            this.btnHelp.Text = "使用帮助";
            this.btnHelp.TextFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHelp.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButton_Click);
            // 
            // btnSkillTrain
            // 
            this.btnSkillTrain.BackColor = System.Drawing.Color.Transparent;
            this.btnSkillTrain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSkillTrain.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSkillTrain.HeadImage = global::DirvingTest.Properties.Resources.edit_group;
            this.btnSkillTrain.Location = new System.Drawing.Point(290, 75);
            this.btnSkillTrain.MouseClickImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.btnSkillTrain.MouseOverImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.btnSkillTrain.Name = "btnSkillTrain";
            this.btnSkillTrain.Size = new System.Drawing.Size(119, 37);
            this.btnSkillTrain.TabIndex = 15;
            this.btnSkillTrain.Tag = "3";
            this.btnSkillTrain.Text = "技巧学习";
            this.btnSkillTrain.TextFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSkillTrain.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButton_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.ForeColor = System.Drawing.SystemColors.Control;
            this.btnHome.HeadImage = global::DirvingTest.Properties.Resources.home;
            this.btnHome.Location = new System.Drawing.Point(12, 75);
            this.btnHome.MouseClickImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.btnHome.MouseOverImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(119, 37);
            this.btnHome.TabIndex = 6;
            this.btnHome.Tag = "1";
            this.btnHome.Text = "首页";
            this.btnHome.TextFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHome.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButton_Click);
            // 
            // labelChangeExamType
            // 
            this.labelChangeExamType.AutoSize = true;
            this.labelChangeExamType.BackColor = System.Drawing.Color.Transparent;
            this.labelChangeExamType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelChangeExamType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelChangeExamType.ForeColor = System.Drawing.Color.Goldenrod;
            this.labelChangeExamType.Location = new System.Drawing.Point(506, 27);
            this.labelChangeExamType.Name = "labelChangeExamType";
            this.labelChangeExamType.Size = new System.Drawing.Size(91, 14);
            this.labelChangeExamType.TabIndex = 4;
            this.labelChangeExamType.Text = "点击更换题库";
            this.labelChangeExamType.Click += new System.EventHandler(this.labelChangeExamType_Click);
            this.labelChangeExamType.MouseLeave += new System.EventHandler(this.label3_MouseLeave);
            this.labelChangeExamType.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label3_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(107, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "驾考快易通";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::DirvingTest.Properties.Resources.classic_camaro;
            this.pictureBox1.Location = new System.Drawing.Point(16, -8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // imageButtonClose
            // 
            this.imageButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageButtonClose.BackColor = System.Drawing.Color.Transparent;
            this.imageButtonClose.BackgroundImage = global::DirvingTest.Properties.Resources.CloseStandard;
            this.imageButtonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imageButtonClose.HeadImage = null;
            this.imageButtonClose.Location = new System.Drawing.Point(1044, 3);
            this.imageButtonClose.MouseClickImage = global::DirvingTest.Properties.Resources.CloseMove;
            this.imageButtonClose.MouseOverImage = global::DirvingTest.Properties.Resources.CloseMove;
            this.imageButtonClose.Name = "imageButtonClose";
            this.imageButtonClose.Size = new System.Drawing.Size(23, 21);
            this.imageButtonClose.TabIndex = 1;
            this.imageButtonClose.TextFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imageButtonClose.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButtonClose_Click);
            // 
            // imageButtonMin
            // 
            this.imageButtonMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageButtonMin.BackColor = System.Drawing.Color.Transparent;
            this.imageButtonMin.BackgroundImage = global::DirvingTest.Properties.Resources.Min;
            this.imageButtonMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imageButtonMin.HeadImage = null;
            this.imageButtonMin.Location = new System.Drawing.Point(1015, 3);
            this.imageButtonMin.MouseClickImage = global::DirvingTest.Properties.Resources.MinMove;
            this.imageButtonMin.MouseOverImage = global::DirvingTest.Properties.Resources.MinMove;
            this.imageButtonMin.Name = "imageButtonMin";
            this.imageButtonMin.Size = new System.Drawing.Size(23, 21);
            this.imageButtonMin.TabIndex = 0;
            this.imageButtonMin.TextFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imageButtonMin.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButtonMin_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 739);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "驾考快易通";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelTitle;
        private CotrolLibrary.ImageButton imageButtonMin;
        private CotrolLibrary.ImageButton imageButtonClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelChangeExamType;
        private CotrolLibrary.ImageButton btnHome;
        private CotrolLibrary.ImageButton btnSkillTrain;
        private CotrolLibrary.ImageButton btnSimulations;
        private CotrolLibrary.ImageButton btnHelp;
        private CotrolLibrary.ImageButton imageButtonProblems;
        private System.Windows.Forms.PictureBox pictureBoxMenu;
        private System.Windows.Forms.Label labelExamInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Register;
        private CotrolLibrary.ImageButton imageButtonMoudle;
        private System.Windows.Forms.ToolStripMenuItem MenuQuestionManager;
        private System.Windows.Forms.ToolStripMenuItem MenuSkillManager;
        private System.Windows.Forms.ToolStripMenuItem MenuChapterManager;
        private CotrolLibrary.ImageButton imageButtonSkill;
        private CotrolLibrary.ImageButton btnRecoverExam;
        private CotrolLibrary.ImageButton btnPractise;
        private System.Windows.Forms.ToolStripMenuItem MenuBankManager;
        private System.Windows.Forms.ToolStripMenuItem MenuEasyErrorChapterManager;
        private CotrolLibrary.ImageButton btnInitialQuestions;
        private System.Windows.Forms.ToolStripMenuItem MenuUserManager;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblUserName;
    }
}

