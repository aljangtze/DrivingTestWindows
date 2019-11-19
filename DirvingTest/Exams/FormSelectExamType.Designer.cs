namespace DirvingTest
{
    partial class FormSelectExamType
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imageButtonClose = new CotrolLibrary.ImageButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonCar = new System.Windows.Forms.RadioButton();
            this.radioButtonBus = new System.Windows.Forms.RadioButton();
            this.radioButtonTruck = new System.Windows.Forms.RadioButton();
            this.buttonOk = new System.Windows.Forms.Button();
            this.radioButtonSubject4 = new System.Windows.Forms.RadioButton();
            this.groupCars = new System.Windows.Forms.GroupBox();
            this.radioButtonMoter = new System.Windows.Forms.RadioButton();
            this.groupExams = new System.Windows.Forms.GroupBox();
            this.radioButtonRecover = new System.Windows.Forms.RadioButton();
            this.radioButtonSubject1 = new System.Windows.Forms.RadioButton();
            this.radioButtonRepeat = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupCars.SuspendLayout();
            this.groupExams.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageButtonClose
            // 
            this.imageButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageButtonClose.BackColor = System.Drawing.Color.Transparent;
            this.imageButtonClose.BackgroundImage = global::DirvingTest.Properties.Resources.close;
            this.imageButtonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imageButtonClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imageButtonClose.HeadImage = null;
            this.imageButtonClose.Location = new System.Drawing.Point(424, 3);
            this.imageButtonClose.MouseClickImage = global::DirvingTest.Properties.Resources.CloseMove;
            this.imageButtonClose.MouseOverImage = global::DirvingTest.Properties.Resources.CloseMove;
            this.imageButtonClose.Name = "imageButtonClose";
            this.imageButtonClose.Size = new System.Drawing.Size(23, 23);
            this.imageButtonClose.TabIndex = 2;
            this.imageButtonClose.TextFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imageButtonClose.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButtonClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "选择题库";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.imageButtonClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(456, 40);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Beige;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(456, 52);
            this.panel2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(19, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "请选择您要进行考试的题库!";
            // 
            // radioButtonCar
            // 
            this.radioButtonCar.AutoSize = true;
            this.radioButtonCar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonCar.Location = new System.Drawing.Point(24, 31);
            this.radioButtonCar.Name = "radioButtonCar";
            this.radioButtonCar.Size = new System.Drawing.Size(143, 16);
            this.radioButtonCar.TabIndex = 7;
            this.radioButtonCar.Tag = "0";
            this.radioButtonCar.Text = "小车（C1、C2、C3）";
            this.radioButtonCar.UseVisualStyleBackColor = true;
            this.radioButtonCar.CheckedChanged += new System.EventHandler(this.radioButtonCar_CheckedChanged);
            // 
            // radioButtonBus
            // 
            this.radioButtonBus.AutoSize = true;
            this.radioButtonBus.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonBus.Location = new System.Drawing.Point(24, 62);
            this.radioButtonBus.Name = "radioButtonBus";
            this.radioButtonBus.Size = new System.Drawing.Size(143, 16);
            this.radioButtonBus.TabIndex = 8;
            this.radioButtonBus.Tag = "1";
            this.radioButtonBus.Text = "客车（A1、A3、B1）";
            this.radioButtonBus.UseVisualStyleBackColor = true;
            this.radioButtonBus.CheckedChanged += new System.EventHandler(this.radioButtonCar_CheckedChanged);
            // 
            // radioButtonTruck
            // 
            this.radioButtonTruck.AutoSize = true;
            this.radioButtonTruck.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonTruck.Location = new System.Drawing.Point(24, 93);
            this.radioButtonTruck.Name = "radioButtonTruck";
            this.radioButtonTruck.Size = new System.Drawing.Size(116, 16);
            this.radioButtonTruck.TabIndex = 9;
            this.radioButtonTruck.Tag = "2";
            this.radioButtonTruck.Text = "货车（A2、B2）";
            this.radioButtonTruck.UseVisualStyleBackColor = true;
            this.radioButtonTruck.CheckedChanged += new System.EventHandler(this.radioButtonCar_CheckedChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.BackColor = System.Drawing.Color.Coral;
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonOk.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonOk.Location = new System.Drawing.Point(131, 273);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(191, 34);
            this.buttonOk.TabIndex = 10;
            this.buttonOk.Text = "确定";
            this.buttonOk.UseVisualStyleBackColor = false;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // radioButtonSubject4
            // 
            this.radioButtonSubject4.AutoSize = true;
            this.radioButtonSubject4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonSubject4.Location = new System.Drawing.Point(21, 61);
            this.radioButtonSubject4.Name = "radioButtonSubject4";
            this.radioButtonSubject4.Size = new System.Drawing.Size(147, 16);
            this.radioButtonSubject4.TabIndex = 11;
            this.radioButtonSubject4.Tag = "1";
            this.radioButtonSubject4.Text = "科目四 安全文明驾驶";
            this.radioButtonSubject4.UseVisualStyleBackColor = true;
            this.radioButtonSubject4.CheckedChanged += new System.EventHandler(this.radioButtonExams_CheckedChanged);
            // 
            // groupCars
            // 
            this.groupCars.Controls.Add(this.radioButtonMoter);
            this.groupCars.Controls.Add(this.radioButtonCar);
            this.groupCars.Controls.Add(this.radioButtonBus);
            this.groupCars.Controls.Add(this.radioButtonTruck);
            this.groupCars.Location = new System.Drawing.Point(12, 99);
            this.groupCars.Name = "groupCars";
            this.groupCars.Size = new System.Drawing.Size(200, 161);
            this.groupCars.TabIndex = 12;
            this.groupCars.TabStop = false;
            this.groupCars.Text = "选择车辆";
            // 
            // radioButtonMoter
            // 
            this.radioButtonMoter.AutoSize = true;
            this.radioButtonMoter.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonMoter.Location = new System.Drawing.Point(24, 124);
            this.radioButtonMoter.Name = "radioButtonMoter";
            this.radioButtonMoter.Size = new System.Drawing.Size(135, 16);
            this.radioButtonMoter.TabIndex = 10;
            this.radioButtonMoter.Tag = "3";
            this.radioButtonMoter.Text = "摩托车（D、E、F）";
            this.radioButtonMoter.UseVisualStyleBackColor = true;
            this.radioButtonMoter.CheckedChanged += new System.EventHandler(this.radioButtonCar_CheckedChanged);
            // 
            // groupExams
            // 
            this.groupExams.Controls.Add(this.radioButtonRepeat);
            this.groupExams.Controls.Add(this.radioButtonRecover);
            this.groupExams.Controls.Add(this.radioButtonSubject1);
            this.groupExams.Controls.Add(this.radioButtonSubject4);
            this.groupExams.Location = new System.Drawing.Point(236, 99);
            this.groupExams.Name = "groupExams";
            this.groupExams.Size = new System.Drawing.Size(201, 161);
            this.groupExams.TabIndex = 13;
            this.groupExams.TabStop = false;
            this.groupExams.Text = "考试类型";
            // 
            // radioButtonRecover
            // 
            this.radioButtonRecover.AutoSize = true;
            this.radioButtonRecover.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonRecover.Location = new System.Drawing.Point(21, 94);
            this.radioButtonRecover.Name = "radioButtonRecover";
            this.radioButtonRecover.Size = new System.Drawing.Size(101, 16);
            this.radioButtonRecover.TabIndex = 13;
            this.radioButtonRecover.Tag = "2";
            this.radioButtonRecover.Text = "恢复资格考试";
            this.radioButtonRecover.UseVisualStyleBackColor = true;
            this.radioButtonRecover.CheckedChanged += new System.EventHandler(this.radioButtonExams_CheckedChanged);
            // 
            // radioButtonSubject1
            // 
            this.radioButtonSubject1.AutoSize = true;
            this.radioButtonSubject1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonSubject1.Location = new System.Drawing.Point(21, 28);
            this.radioButtonSubject1.Name = "radioButtonSubject1";
            this.radioButtonSubject1.Size = new System.Drawing.Size(147, 16);
            this.radioButtonSubject1.TabIndex = 12;
            this.radioButtonSubject1.Tag = "0";
            this.radioButtonSubject1.Text = "科目一 基础理论考试";
            this.radioButtonSubject1.UseVisualStyleBackColor = true;
            this.radioButtonSubject1.CheckedChanged += new System.EventHandler(this.radioButtonExams_CheckedChanged);
            // 
            // radioButtonRepeat
            // 
            this.radioButtonRepeat.AutoSize = true;
            this.radioButtonRepeat.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonRepeat.Location = new System.Drawing.Point(21, 127);
            this.radioButtonRepeat.Name = "radioButtonRepeat";
            this.radioButtonRepeat.Size = new System.Drawing.Size(75, 16);
            this.radioButtonRepeat.TabIndex = 14;
            this.radioButtonRepeat.Tag = "3";
            this.radioButtonRepeat.Text = "消分考试";
            this.radioButtonRepeat.UseVisualStyleBackColor = true;
            this.radioButtonRepeat.CheckedChanged += new System.EventHandler(this.radioButtonExams_CheckedChanged);
            // 
            // FormSelectExamType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(456, 327);
            this.Controls.Add(this.groupExams);
            this.Controls.Add(this.groupCars);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSelectExamType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSelectExamType";
            this.Load += new System.EventHandler(this.FormSelectExamType_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupCars.ResumeLayout(false);
            this.groupCars.PerformLayout();
            this.groupExams.ResumeLayout(false);
            this.groupExams.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CotrolLibrary.ImageButton imageButtonClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonCar;
        private System.Windows.Forms.RadioButton radioButtonBus;
        private System.Windows.Forms.RadioButton radioButtonTruck;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.RadioButton radioButtonSubject4;
        private System.Windows.Forms.GroupBox groupCars;
        private System.Windows.Forms.GroupBox groupExams;
        private System.Windows.Forms.RadioButton radioButtonRecover;
        private System.Windows.Forms.RadioButton radioButtonSubject1;
        private System.Windows.Forms.RadioButton radioButtonMoter;
        private System.Windows.Forms.RadioButton radioButtonRepeat;
    }
}