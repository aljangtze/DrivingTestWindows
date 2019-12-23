namespace DirvingTest
{
    partial class FormSimulationInfo
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
            this.btnRepeat = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelNotice2 = new System.Windows.Forms.Label();
            this.labelNotice1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MediumPurple;
            this.panel4.Controls.Add(this.btnRepeat);
            this.panel4.Controls.Add(this.btnOk);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 282);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(435, 64);
            this.panel4.TabIndex = 7;
            // 
            // btnRepeat
            // 
            this.btnRepeat.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRepeat.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRepeat.Location = new System.Drawing.Point(45, 5);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(148, 49);
            this.btnRepeat.TabIndex = 1;
            this.btnRepeat.Text = "再考一次";
            this.btnRepeat.UseVisualStyleBackColor = true;
            this.btnRepeat.Click += new System.EventHandler(this.btnRepeat_Click);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(231, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(148, 49);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "关闭";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel3.Controls.Add(this.labelScore);
            this.panel3.Controls.Add(this.labelNotice2);
            this.panel3.Controls.Add(this.labelNotice1);
            this.panel3.Location = new System.Drawing.Point(0, 114);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(435, 164);
            this.panel3.TabIndex = 6;
            // 
            // labelScore
            // 
            this.labelScore.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelScore.ForeColor = System.Drawing.Color.Maroon;
            this.labelScore.Location = new System.Drawing.Point(146, 6);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(79, 42);
            this.labelScore.TabIndex = 3;
            this.labelScore.Text = "0";
            this.labelScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNotice2
            // 
            this.labelNotice2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNotice2.Location = new System.Drawing.Point(28, 74);
            this.labelNotice2.Name = "labelNotice2";
            this.labelNotice2.Size = new System.Drawing.Size(292, 50);
            this.labelNotice2.TabIndex = 2;
            this.labelNotice2.Text = "不及格，祝下次成功考过！";
            // 
            // labelNotice1
            // 
            this.labelNotice1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNotice1.Location = new System.Drawing.Point(28, 16);
            this.labelNotice1.Name = "labelNotice1";
            this.labelNotice1.Size = new System.Drawing.Size(316, 41);
            this.labelNotice1.TabIndex = 1;
            this.labelNotice1.Text = "很遗憾，得    0    分";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel2.Controls.Add(this.labelName);
            this.panel2.Location = new System.Drawing.Point(0, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(435, 44);
            this.panel2.TabIndex = 5;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelName.Location = new System.Drawing.Point(3, 15);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(159, 21);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "xxx女士/先生：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 63);
            this.panel1.TabIndex = 4;
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
            // FormSimulationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(435, 346);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSimulationInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormSimulationInfo";
            this.Shown += new System.EventHandler(this.FormSimulationInfo_Shown);
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
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelNotice2;
        private System.Windows.Forms.Label labelNotice1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Button btnRepeat;

    }
}