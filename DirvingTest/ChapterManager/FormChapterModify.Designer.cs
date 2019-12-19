namespace DirvingTest
{
    partial class FormChapterModify
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelBack = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageButtonBack = new CotrolLibrary.ImageButton();
            this.imageButtonSave = new CotrolLibrary.ImageButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cboxStatus = new System.Windows.Forms.ComboBox();
            this.labelType = new System.Windows.Forms.Label();
            this.cboxType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.richTextBoxTittle = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxChapterType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelBack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(869, 41);
            this.panel1.TabIndex = 2;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo.Location = new System.Drawing.Point(86, 15);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(80, 16);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "添加技巧 ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(63, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "->";
            // 
            // labelBack
            // 
            this.labelBack.AutoSize = true;
            this.labelBack.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelBack.ForeColor = System.Drawing.Color.Blue;
            this.labelBack.Location = new System.Drawing.Point(28, 15);
            this.labelBack.Name = "labelBack";
            this.labelBack.Size = new System.Drawing.Size(40, 16);
            this.labelBack.TabIndex = 0;
            this.labelBack.Text = "返回";
            this.labelBack.Click += new System.EventHandler(this.labelBack_Click);
            this.labelBack.MouseLeave += new System.EventHandler(this.labelBack_MouseLeave);
            this.labelBack.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelBack_MouseMove);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.panel2.Controls.Add(this.imageButtonBack);
            this.panel2.Controls.Add(this.imageButtonSave);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(869, 548);
            this.panel2.TabIndex = 3;
            // 
            // imageButtonBack
            // 
            this.imageButtonBack.BackgroundImage = global::DirvingTest.Properties.Resources._20150614043555476_easyicon_net_512;
            this.imageButtonBack.HeadImage = null;
            this.imageButtonBack.Location = new System.Drawing.Point(517, 398);
            this.imageButtonBack.MouseClickImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.imageButtonBack.MouseOverImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.imageButtonBack.Name = "imageButtonBack";
            this.imageButtonBack.Size = new System.Drawing.Size(138, 40);
            this.imageButtonBack.TabIndex = 30;
            this.imageButtonBack.Text = "取消";
            this.imageButtonBack.TextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imageButtonBack.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.labelBack_Click);
            // 
            // imageButtonSave
            // 
            this.imageButtonSave.BackgroundImage = global::DirvingTest.Properties.Resources._20150614043555476_easyicon_net_512;
            this.imageButtonSave.HeadImage = null;
            this.imageButtonSave.Location = new System.Drawing.Point(218, 398);
            this.imageButtonSave.MouseClickImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.imageButtonSave.MouseOverImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.imageButtonSave.Name = "imageButtonSave";
            this.imageButtonSave.Size = new System.Drawing.Size(138, 40);
            this.imageButtonSave.TabIndex = 29;
            this.imageButtonSave.Text = "保存";
            this.imageButtonSave.TextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imageButtonSave.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButtonSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(28, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(296, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "请输入相应的信息，点击保存按钮保存。";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 426F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboxChapterType, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboxStatus, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelType, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboxType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelStatus, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBoxTittle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(105, 65);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(722, 283);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // cboxStatus
            // 
            this.cboxStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxStatus.FormattingEnabled = true;
            this.cboxStatus.Items.AddRange(new object[] {
            "启用",
            "禁用"});
            this.cboxStatus.Location = new System.Drawing.Point(105, 186);
            this.cboxStatus.Name = "cboxStatus";
            this.cboxStatus.Size = new System.Drawing.Size(194, 20);
            this.cboxStatus.TabIndex = 9;
            this.cboxStatus.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatus_SelectedIndexChanged);
            // 
            // labelType
            // 
            this.labelType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelType.AutoSize = true;
            this.labelType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.labelType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelType.Location = new System.Drawing.Point(11, 132);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(80, 16);
            this.labelType.TabIndex = 4;
            this.labelType.Text = "分组类型:";
            // 
            // cboxType
            // 
            this.cboxType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxType.FormattingEnabled = true;
            this.cboxType.Items.AddRange(new object[] {
            "A类",
            "B类",
            "C类",
            "安全文明驾驶"});
            this.cboxType.Location = new System.Drawing.Point(105, 130);
            this.cboxType.Name = "cboxType";
            this.cboxType.Size = new System.Drawing.Size(194, 20);
            this.cboxType.TabIndex = 7;
            this.cboxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(306, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(352, 16);
            this.label8.TabIndex = 32;
            this.label8.Text = "*启用则对应题目都有效　禁用则对应题目都无效";
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelStatus.AutoSize = true;
            this.labelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.labelStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStatus.Location = new System.Drawing.Point(11, 188);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(80, 16);
            this.labelStatus.TabIndex = 8;
            this.labelStatus.Text = "分组状态:";
            // 
            // labelName
            // 
            this.labelName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.labelName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelName.Location = new System.Drawing.Point(11, 48);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(80, 16);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "分组名称:";
            // 
            // richTextBoxTittle
            // 
            this.richTextBoxTittle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.richTextBoxTittle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.richTextBoxTittle, 2);
            this.richTextBoxTittle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxTittle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBoxTittle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.richTextBoxTittle.Location = new System.Drawing.Point(105, 4);
            this.richTextBoxTittle.Name = "richTextBoxTittle";
            this.richTextBoxTittle.Size = new System.Drawing.Size(621, 105);
            this.richTextBoxTittle.TabIndex = 5;
            this.richTextBoxTittle.Text = "";
            this.richTextBoxTittle.TextChanged += new System.EventHandler(this.richTextBoxTittle_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(306, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(304, 16);
            this.label7.TabIndex = 31;
            this.label7.Text = "*A类客车\\B类货车\\C类小车\\安全文明驾驶";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(306, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(352, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "*启用则对应题目都有效　禁用则对应题目都无效";
            // 
            // cboxChapterType
            // 
            this.cboxChapterType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboxChapterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxChapterType.FormattingEnabled = true;
            this.cboxChapterType.Items.AddRange(new object[] {
            "启用",
            "禁用"});
            this.cboxChapterType.Location = new System.Drawing.Point(105, 243);
            this.cboxChapterType.Name = "cboxChapterType";
            this.cboxChapterType.Size = new System.Drawing.Size(194, 20);
            this.cboxChapterType.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(11, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 35;
            this.label4.Text = "分组状态:";
            // 
            // FormChapterModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(869, 590);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormChapterModify";
            this.Text = "FormModelAdd";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBoxTittle;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.ComboBox cboxStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox cboxType;
        private CotrolLibrary.ImageButton imageButtonSave;
        private CotrolLibrary.ImageButton imageButtonBack;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboxChapterType;
        private System.Windows.Forms.Label label2;
    }
}