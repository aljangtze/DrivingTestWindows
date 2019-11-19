namespace LicenseTool
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxGuid = new System.Windows.Forms.TextBox();
            this.btnGenLicense = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxValid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLinceseCheck = new System.Windows.Forms.Button();
            this.txtBoxLicense = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxGuid
            // 
            this.textBoxGuid.Location = new System.Drawing.Point(12, 35);
            this.textBoxGuid.Name = "textBoxGuid";
            this.textBoxGuid.Size = new System.Drawing.Size(440, 21);
            this.textBoxGuid.TabIndex = 1;
            // 
            // btnGenLicense
            // 
            this.btnGenLicense.Location = new System.Drawing.Point(12, 75);
            this.btnGenLicense.Name = "btnGenLicense";
            this.btnGenLicense.Size = new System.Drawing.Size(113, 23);
            this.btnGenLicense.TabIndex = 2;
            this.btnGenLicense.Text = "生成授权文件";
            this.btnGenLicense.UseVisualStyleBackColor = true;
            this.btnGenLicense.Click += new System.EventHandler(this.btnGenLicense_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "电脑标识";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(14, 354);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(272, 124);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(363, 354);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(278, 124);
            this.richTextBox3.TabIndex = 6;
            this.richTextBox3.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(335, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxValid
            // 
            this.textBoxValid.Location = new System.Drawing.Point(216, 78);
            this.textBoxValid.MaxLength = 6;
            this.textBoxValid.Name = "textBoxValid";
            this.textBoxValid.Size = new System.Drawing.Size(87, 21);
            this.textBoxValid.TabIndex = 8;
            this.textBoxValid.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "天（输入0表示不做限制)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "有效期";
            // 
            // btnLinceseCheck
            // 
            this.btnLinceseCheck.Location = new System.Drawing.Point(14, 111);
            this.btnLinceseCheck.Name = "btnLinceseCheck";
            this.btnLinceseCheck.Size = new System.Drawing.Size(111, 23);
            this.btnLinceseCheck.TabIndex = 11;
            this.btnLinceseCheck.Text = "验证授权信息";
            this.btnLinceseCheck.UseVisualStyleBackColor = true;
            this.btnLinceseCheck.Click += new System.EventHandler(this.btnLinceseCheck_Click);
            // 
            // txtBoxLicense
            // 
            this.txtBoxLicense.Location = new System.Drawing.Point(15, 134);
            this.txtBoxLicense.Multiline = true;
            this.txtBoxLicense.Name = "txtBoxLicense";
            this.txtBoxLicense.Size = new System.Drawing.Size(440, 150);
            this.txtBoxLicense.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 288);
            this.Controls.Add(this.txtBoxLicense);
            this.Controls.Add(this.btnLinceseCheck);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxValid);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenLicense);
            this.Controls.Add(this.textBoxGuid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "授权工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxGuid;
        private System.Windows.Forms.Button btnGenLicense;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxValid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLinceseCheck;
        private System.Windows.Forms.TextBox txtBoxLicense;
    }
}

