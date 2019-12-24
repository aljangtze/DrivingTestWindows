namespace DirvingTest
{
    partial class FormTrainErrorInfo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrainErrorInfo));
            this.panel1Image = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.axShockwaveFlash1 = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelRightAnswer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNormalNotice = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1Image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1Image
            // 
            this.panel1Image.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1Image.Controls.Add(this.pictureBox1);
            this.panel1Image.Controls.Add(this.axShockwaveFlash1);
            this.panel1Image.Location = new System.Drawing.Point(620, 1);
            this.panel1Image.Name = "panel1Image";
            this.panel1Image.Size = new System.Drawing.Size(585, 364);
            this.panel1Image.TabIndex = 50;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(583, 362);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // axShockwaveFlash1
            // 
            this.axShockwaveFlash1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axShockwaveFlash1.Enabled = true;
            this.axShockwaveFlash1.Location = new System.Drawing.Point(0, 0);
            this.axShockwaveFlash1.Name = "axShockwaveFlash1";
            this.axShockwaveFlash1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlash1.OcxState")));
            this.axShockwaveFlash1.Size = new System.Drawing.Size(583, 362);
            this.axShockwaveFlash1.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(398, 322);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(149, 42);
            this.btnOk.TabIndex = 51;
            this.btnOk.Text = "继续答题";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.labelRightAnswer);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.labelNormalNotice);
            this.panel2.Location = new System.Drawing.Point(2, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(612, 363);
            this.panel2.TabIndex = 52;
            this.panel2.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // labelRightAnswer
            // 
            this.labelRightAnswer.BackColor = System.Drawing.Color.SeaGreen;
            this.labelRightAnswer.Font = new System.Drawing.Font("华文中宋", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelRightAnswer.ForeColor = System.Drawing.Color.Maroon;
            this.labelRightAnswer.Location = new System.Drawing.Point(228, 248);
            this.labelRightAnswer.Name = "labelRightAnswer";
            this.labelRightAnswer.Size = new System.Drawing.Size(155, 37);
            this.labelRightAnswer.TabIndex = 38;
            this.labelRightAnswer.Text = "A";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SeaGreen;
            this.label1.Font = new System.Drawing.Font("华文中宋", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(36, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 45);
            this.label1.TabIndex = 37;
            this.label1.Text = "正确答案：";
            this.label1.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // labelNormalNotice
            // 
            this.labelNormalNotice.BackColor = System.Drawing.Color.SeaGreen;
            this.labelNormalNotice.Font = new System.Drawing.Font("华文中宋", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNormalNotice.ForeColor = System.Drawing.Color.Maroon;
            this.labelNormalNotice.Location = new System.Drawing.Point(18, 23);
            this.labelNormalNotice.Name = "labelNormalNotice";
            this.labelNormalNotice.Size = new System.Drawing.Size(566, 184);
            this.labelNormalNotice.TabIndex = 36;
            this.labelNormalNotice.Text = "1.看到这种手势信号时怎样行驶？1.看到这种手势信号时怎样行驶？1.看到这种手势信号时怎样行驶？";
            this.labelNormalNotice.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormTrainErrorInfo
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(1217, 386);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.panel1Image);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(800, 0);
            this.Name = "FormTrainErrorInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormSimulationErrorInfo";
            this.Load += new System.EventHandler(this.FormTrainErrorInfo_Load);
            this.Shown += new System.EventHandler(this.FormSimulationErrorInfo_Shown);
            this.Click += new System.EventHandler(this.btnOk_Click);
            this.panel1Image.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1Image;
        private AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelNormalNotice;
        private System.Windows.Forms.Label labelRightAnswer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}