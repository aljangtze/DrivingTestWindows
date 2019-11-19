namespace DirvingTest
{
    partial class FormPurchase
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.richTextBoxPuchase = new System.Windows.Forms.RichTextBox();
            this.richTextBoxComulication = new System.Windows.Forms.RichTextBox();
            this.richTextBoxHelper = new System.Windows.Forms.RichTextBox();
            this.imageButton4 = new CotrolLibrary.ImageButton();
            this.imageButtonHelp = new CotrolLibrary.ImageButton();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 48);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(472, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "感谢您支持驾考快易通！我们将竭诚为您提供最优质的驾驶考试服务！";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightCyan;
            this.panel3.Controls.Add(this.imageButtonHelp);
            this.panel3.Controls.Add(this.imageButton4);
            this.panel3.Controls.Add(this.richTextBoxPuchase);
            this.panel3.Controls.Add(this.richTextBoxComulication);
            this.panel3.Controls.Add(this.richTextBoxHelper);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(976, 571);
            this.panel3.TabIndex = 2;
            // 
            // richTextBoxPuchase
            // 
            this.richTextBoxPuchase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxPuchase.BackColor = System.Drawing.Color.Azure;
            this.richTextBoxPuchase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxPuchase.Location = new System.Drawing.Point(145, 4);
            this.richTextBoxPuchase.Name = "richTextBoxPuchase";
            this.richTextBoxPuchase.ReadOnly = true;
            this.richTextBoxPuchase.Size = new System.Drawing.Size(827, 560);
            this.richTextBoxPuchase.TabIndex = 1;
            this.richTextBoxPuchase.Text = "";
            // 
            // richTextBoxComulication
            // 
            this.richTextBoxComulication.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxComulication.BackColor = System.Drawing.Color.Azure;
            this.richTextBoxComulication.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxComulication.Location = new System.Drawing.Point(167, 405);
            this.richTextBoxComulication.Name = "richTextBoxComulication";
            this.richTextBoxComulication.ReadOnly = true;
            this.richTextBoxComulication.Size = new System.Drawing.Size(762, 36);
            this.richTextBoxComulication.TabIndex = 5;
            this.richTextBoxComulication.Text = "";
            this.richTextBoxComulication.Visible = false;
            // 
            // richTextBoxHelper
            // 
            this.richTextBoxHelper.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxHelper.BackColor = System.Drawing.Color.Azure;
            this.richTextBoxHelper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxHelper.Location = new System.Drawing.Point(155, 225);
            this.richTextBoxHelper.Name = "richTextBoxHelper";
            this.richTextBoxHelper.ReadOnly = true;
            this.richTextBoxHelper.Size = new System.Drawing.Size(774, 131);
            this.richTextBoxHelper.TabIndex = 3;
            this.richTextBoxHelper.Text = "";
            this.richTextBoxHelper.Visible = false;
            // 
            // imageButton4
            // 
            this.imageButton4.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.imageButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageButton4.ForeColor = System.Drawing.SystemColors.Control;
            this.imageButton4.HeadImage = global::DirvingTest.Properties.Resources.edit_group;
            this.imageButton4.Location = new System.Drawing.Point(3, 41);
            this.imageButton4.MouseClickImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.imageButton4.MouseOverImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.imageButton4.Name = "imageButton4";
            this.imageButton4.Size = new System.Drawing.Size(139, 31);
            this.imageButton4.TabIndex = 16;
            this.imageButton4.Tag = "4";
            this.imageButton4.Text = "技巧购买";
            this.imageButton4.TextFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imageButton4.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButton4_Click);
            // 
            // imageButtonHelp
            // 
            this.imageButtonHelp.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.imageButtonHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imageButtonHelp.ForeColor = System.Drawing.SystemColors.Control;
            this.imageButtonHelp.HeadImage = global::DirvingTest.Properties.Resources.faq;
            this.imageButtonHelp.Location = new System.Drawing.Point(3, 6);
            this.imageButtonHelp.MouseClickImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.imageButtonHelp.MouseOverImage = global::DirvingTest.Properties.Resources.ButtonImage2;
            this.imageButtonHelp.Name = "imageButtonHelp";
            this.imageButtonHelp.Size = new System.Drawing.Size(139, 31);
            this.imageButtonHelp.TabIndex = 17;
            this.imageButtonHelp.Tag = "8";
            this.imageButtonHelp.Text = "使用帮助";
            this.imageButtonHelp.TextFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imageButtonHelp.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButtonHelp_Click);
            // 
            // FormPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(976, 619);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPurchase";
            this.Text = "FormPurchase";
            this.Load += new System.EventHandler(this.FormPurchase_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox richTextBoxPuchase;
        private System.Windows.Forms.RichTextBox richTextBoxHelper;
        private System.Windows.Forms.RichTextBox richTextBoxComulication;
        private CotrolLibrary.ImageButton imageButton4;
        private CotrolLibrary.ImageButton imageButtonHelp;

    }
}