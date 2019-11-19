namespace DirvingTest
{
    partial class FormSkillExplain
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
            this.richTextBoxExplain = new System.Windows.Forms.RichTextBox();
            this.panelMid = new System.Windows.Forms.Panel();
            this.panelBottm = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.buttonMax = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonMin = new System.Windows.Forms.Button();
            this.buttonReader = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.imageButtonClose = new CotrolLibrary.ImageButton();
            this.panelMid.SuspendLayout();
            this.panelBottm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxExplain
            // 
            this.richTextBoxExplain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.richTextBoxExplain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxExplain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBoxExplain.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBoxExplain.Location = new System.Drawing.Point(0, 43);
            this.richTextBoxExplain.Name = "richTextBoxExplain";
            this.richTextBoxExplain.Size = new System.Drawing.Size(540, 356);
            this.richTextBoxExplain.TabIndex = 0;
            this.richTextBoxExplain.Text = "";
            // 
            // panelMid
            // 
            this.panelMid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.panelMid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMid.Controls.Add(this.panelTop);
            this.panelMid.Controls.Add(this.richTextBoxExplain);
            this.panelMid.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMid.Location = new System.Drawing.Point(0, 0);
            this.panelMid.Name = "panelMid";
            this.panelMid.Size = new System.Drawing.Size(542, 401);
            this.panelMid.TabIndex = 1;
            // 
            // panelBottm
            // 
            this.panelBottm.Controls.Add(this.trackBar1);
            this.panelBottm.Controls.Add(this.buttonMax);
            this.panelBottm.Controls.Add(this.buttonClose);
            this.panelBottm.Controls.Add(this.buttonMin);
            this.panelBottm.Controls.Add(this.buttonReader);
            this.panelBottm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottm.Location = new System.Drawing.Point(0, 401);
            this.panelBottm.Name = "panelBottm";
            this.panelBottm.Size = new System.Drawing.Size(542, 50);
            this.panelBottm.TabIndex = 2;
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.trackBar1.Location = new System.Drawing.Point(44, 16);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 20);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.Value = 4;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // buttonMax
            // 
            this.buttonMax.Location = new System.Drawing.Point(154, 18);
            this.buttonMax.Name = "buttonMax";
            this.buttonMax.Size = new System.Drawing.Size(17, 18);
            this.buttonMax.TabIndex = 3;
            this.buttonMax.Text = "+";
            this.buttonMax.UseVisualStyleBackColor = true;
            this.buttonMax.Click += new System.EventHandler(this.buttonMax_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(428, 8);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 34);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "关闭";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonMin
            // 
            this.buttonMin.Location = new System.Drawing.Point(21, 16);
            this.buttonMin.Name = "buttonMin";
            this.buttonMin.Size = new System.Drawing.Size(17, 18);
            this.buttonMin.TabIndex = 1;
            this.buttonMin.Text = "-";
            this.buttonMin.UseVisualStyleBackColor = true;
            this.buttonMin.Click += new System.EventHandler(this.buttonMin_Click);
            // 
            // buttonReader
            // 
            this.buttonReader.Location = new System.Drawing.Point(347, 8);
            this.buttonReader.Name = "buttonReader";
            this.buttonReader.Size = new System.Drawing.Size(75, 34);
            this.buttonReader.TabIndex = 0;
            this.buttonReader.Text = "语音阅读";
            this.buttonReader.UseVisualStyleBackColor = true;
            this.buttonReader.Click += new System.EventHandler(this.buttonReader_Click);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Azure;
            this.panelTop.Controls.Add(this.imageButtonClose);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(540, 44);
            this.panelTop.TabIndex = 1;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            this.panelTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "技巧提示";
            // 
            // imageButtonClose
            // 
            this.imageButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageButtonClose.BackColor = System.Drawing.Color.Transparent;
            this.imageButtonClose.BackgroundImage = global::DirvingTest.Properties.Resources.CloseStandard;
            this.imageButtonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imageButtonClose.HeadImage = null;
            this.imageButtonClose.Location = new System.Drawing.Point(508, 4);
            this.imageButtonClose.MouseClickImage = global::DirvingTest.Properties.Resources.CloseMove;
            this.imageButtonClose.MouseOverImage = global::DirvingTest.Properties.Resources.CloseMove;
            this.imageButtonClose.Name = "imageButtonClose";
            this.imageButtonClose.Size = new System.Drawing.Size(23, 21);
            this.imageButtonClose.TabIndex = 4;
            this.imageButtonClose.TextFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imageButtonClose.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButtonClose_Click);
            // 
            // FormSkillExplain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(542, 451);
            this.Controls.Add(this.panelBottm);
            this.Controls.Add(this.panelMid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSkillExplain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSkillExplain";
            this.panelMid.ResumeLayout(false);
            this.panelBottm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxExplain;
        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Panel panelBottm;
        private System.Windows.Forms.Button buttonReader;
        private System.Windows.Forms.Button buttonMin;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonMax;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private CotrolLibrary.ImageButton imageButtonClose;
    }
}