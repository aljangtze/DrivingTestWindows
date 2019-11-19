namespace DirvingTest
{
    partial class FormLicence
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCupId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAuth = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelInfo = new System.Windows.Forms.Label();
            this.txtBoxLicence = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "主机标识：";
            // 
            // textBoxCupId
            // 
            this.textBoxCupId.BackColor = System.Drawing.Color.Azure;
            this.textBoxCupId.Location = new System.Drawing.Point(72, 74);
            this.textBoxCupId.Name = "textBoxCupId";
            this.textBoxCupId.ReadOnly = true;
            this.textBoxCupId.Size = new System.Drawing.Size(256, 21);
            this.textBoxCupId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "授权信息";
            // 
            // btnAuth
            // 
            this.btnAuth.Location = new System.Drawing.Point(162, 272);
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.Size = new System.Drawing.Size(75, 25);
            this.btnAuth.TabIndex = 4;
            this.btnAuth.Text = "注册";
            this.btnAuth.UseVisualStyleBackColor = true;
            this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.Azure;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox2.Location = new System.Drawing.Point(12, 17);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(332, 51);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "由于技巧训练模块需要授权才能使用，请向软件提供方提供主机标识获取授权信息进行注册！";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(269, 272);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtBoxLicence);
            this.panel1.Controls.Add(this.labelInfo);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.richTextBox2);
            this.panel1.Controls.Add(this.btnAuth);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxCupId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 313);
            this.panel1.TabIndex = 7;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(16, 278);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(41, 12);
            this.labelInfo.TabIndex = 7;
            this.labelInfo.Text = "label3";
            // 
            // txtBoxLicence
            // 
            this.txtBoxLicence.BackColor = System.Drawing.Color.Azure;
            this.txtBoxLicence.Location = new System.Drawing.Point(18, 135);
            this.txtBoxLicence.Multiline = true;
            this.txtBoxLicence.Name = "txtBoxLicence";
            this.txtBoxLicence.Size = new System.Drawing.Size(310, 121);
            this.txtBoxLicence.TabIndex = 8;
            // 
            // FormLicence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(378, 318);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLicence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLicence";
            this.Load += new System.EventHandler(this.FormLicence_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCupId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAuth;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.TextBox txtBoxLicence;
    }
}