namespace DirvingTest
{
    partial class FormSkillTrainFinish
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelAllCount = new System.Windows.Forms.Label();
            this.labelNoanswerCount = new System.Windows.Forms.Label();
            this.labelIncorrectCount = new System.Windows.Forms.Label();
            this.labelCorrectCout = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelNotice1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRepeat = new System.Windows.Forms.Button();
            this.btnRepatError = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MediumPurple;
            this.panel4.Controls.Add(this.btnRepatError);
            this.panel4.Controls.Add(this.btnRepeat);
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Controls.Add(this.btnOk);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 327);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(491, 64);
            this.panel4.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(262, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(148, 49);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.buttonRetun_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(62, 6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(148, 49);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "再做一次";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel3.Controls.Add(this.labelAllCount);
            this.panel3.Controls.Add(this.labelNoanswerCount);
            this.panel3.Controls.Add(this.labelIncorrectCount);
            this.panel3.Controls.Add(this.labelCorrectCout);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.labelNotice1);
            this.panel3.Location = new System.Drawing.Point(0, 114);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(488, 207);
            this.panel3.TabIndex = 10;
            // 
            // labelAllCount
            // 
            this.labelAllCount.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelAllCount.ForeColor = System.Drawing.Color.Maroon;
            this.labelAllCount.Location = new System.Drawing.Point(204, 8);
            this.labelAllCount.Name = "labelAllCount";
            this.labelAllCount.Size = new System.Drawing.Size(69, 42);
            this.labelAllCount.TabIndex = 12;
            this.labelAllCount.Text = "0";
            this.labelAllCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNoanswerCount
            // 
            this.labelNoanswerCount.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNoanswerCount.ForeColor = System.Drawing.Color.Maroon;
            this.labelNoanswerCount.Location = new System.Drawing.Point(204, 128);
            this.labelNoanswerCount.Name = "labelNoanswerCount";
            this.labelNoanswerCount.Size = new System.Drawing.Size(69, 42);
            this.labelNoanswerCount.TabIndex = 9;
            this.labelNoanswerCount.Text = "0";
            this.labelNoanswerCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelIncorrectCount
            // 
            this.labelIncorrectCount.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelIncorrectCount.ForeColor = System.Drawing.Color.Maroon;
            this.labelIncorrectCount.Location = new System.Drawing.Point(204, 87);
            this.labelIncorrectCount.Name = "labelIncorrectCount";
            this.labelIncorrectCount.Size = new System.Drawing.Size(69, 42);
            this.labelIncorrectCount.TabIndex = 6;
            this.labelIncorrectCount.Text = "0";
            this.labelIncorrectCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCorrectCout
            // 
            this.labelCorrectCout.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCorrectCout.ForeColor = System.Drawing.Color.Maroon;
            this.labelCorrectCout.Location = new System.Drawing.Point(204, 46);
            this.labelCorrectCout.Name = "labelCorrectCout";
            this.labelCorrectCout.Size = new System.Drawing.Size(69, 42);
            this.labelCorrectCout.TabIndex = 3;
            this.labelCorrectCout.Text = "0";
            this.labelCorrectCout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(281, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 24);
            this.label9.TabIndex = 13;
            this.label9.Text = "题";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(45, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(285, 26);
            this.label11.TabIndex = 11;
            this.label11.Text = "当前技巧总共：";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(281, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "题";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(83, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 26);
            this.label8.TabIndex = 8;
            this.label8.Text = "未作回答：";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(281, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "题";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(83, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 26);
            this.label5.TabIndex = 5;
            this.label5.Text = "回答错误：";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(281, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "题";
            // 
            // labelNotice1
            // 
            this.labelNotice1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNotice1.Location = new System.Drawing.Point(83, 57);
            this.labelNotice1.Name = "labelNotice1";
            this.labelNotice1.Size = new System.Drawing.Size(115, 26);
            this.labelNotice1.TabIndex = 1;
            this.labelNotice1.Text = "回答正确：";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel2.Controls.Add(this.labelName);
            this.panel2.Location = new System.Drawing.Point(0, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(488, 44);
            this.panel2.TabIndex = 9;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelName.Location = new System.Drawing.Point(3, 15);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(157, 21);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "技巧训练结果：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 63);
            this.panel1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(71, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(273, 35);
            this.label4.TabIndex = 0;
            this.label4.Text = "信  息  提  示";
            // 
            // btnRepeat
            // 
            this.btnRepeat.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRepeat.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRepeat.Location = new System.Drawing.Point(62, 6);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(148, 49);
            this.btnRepeat.TabIndex = 2;
            this.btnRepeat.Text = "再做一次";
            this.btnRepeat.UseVisualStyleBackColor = true;
            this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
            // 
            // btnRepatError
            // 
            this.btnRepatError.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRepatError.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRepatError.Location = new System.Drawing.Point(262, 6);
            this.btnRepatError.Name = "btnRepatError";
            this.btnRepatError.Size = new System.Drawing.Size(148, 49);
            this.btnRepatError.TabIndex = 3;
            this.btnRepatError.Text = "重做错题";
            this.btnRepatError.UseVisualStyleBackColor = true;
            this.btnRepatError.Click += new System.EventHandler(this.btnRepatError_Click);
            // 
            // FormSkillTrainFinish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 391);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSkillTrainFinish";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSkillTrainFinish";
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelCorrectCout;
        private System.Windows.Forms.Label labelNotice1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelNoanswerCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelIncorrectCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelAllCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnRepeat;
        private System.Windows.Forms.Button btnRepatError;
    }
}