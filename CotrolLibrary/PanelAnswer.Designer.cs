namespace CotrolLibrary
{
    partial class PanelAnswer
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelNum = new System.Windows.Forms.Label();
            this.labelAnswer = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labelNum
            // 
            this.labelNum.AutoSize = true;
            this.labelNum.Location = new System.Drawing.Point(1, 2);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(23, 12);
            this.labelNum.TabIndex = 0;
            this.labelNum.Text = "100";
            this.labelNum.TextChanged += new System.EventHandler(this.labelAnswer_TextChanged);
            this.labelNum.Click += new System.EventHandler(this.OnClick);
            // 
            // labelAnswer
            // 
            this.labelAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAnswer.AutoSize = true;
            this.labelAnswer.Location = new System.Drawing.Point(13, 14);
            this.labelAnswer.Name = "labelAnswer";
            this.labelAnswer.Size = new System.Drawing.Size(11, 12);
            this.labelAnswer.TabIndex = 1;
            this.labelAnswer.Text = "A";
            this.labelAnswer.TextChanged += new System.EventHandler(this.labelAnswer_TextChanged);
            this.labelAnswer.Click += new System.EventHandler(this.OnClick);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(27, 29);
            this.panel1.TabIndex = 2;
            this.panel1.Click += new System.EventHandler(this.OnClick);
            // 
            // PanelAnswer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelAnswer);
            this.Controls.Add(this.labelNum);
            this.Controls.Add(this.panel1);
            this.Name = "PanelAnswer";
            this.Size = new System.Drawing.Size(27, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNum;
        private System.Windows.Forms.Label labelAnswer;
        private System.Windows.Forms.Panel panel1;
    }
}
