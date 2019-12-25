namespace DirvingTest
{
    partial class FormChaperSelect
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
            this.panelDown = new System.Windows.Forms.Panel();
            this.btnRadom = new CotrolLibrary.ImageButton();
            this.labelInfo = new System.Windows.Forms.Label();
            this.btnSequence = new CotrolLibrary.ImageButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonTemplate = new System.Windows.Forms.RadioButton();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.picHeader = new System.Windows.Forms.PictureBox();
            this.btnClear = new CotrolLibrary.ImageButton();
            this.panelDown.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDown
            // 
            this.panelDown.Controls.Add(this.btnRadom);
            this.panelDown.Controls.Add(this.labelInfo);
            this.panelDown.Controls.Add(this.btnSequence);
            this.panelDown.Controls.Add(this.tableLayoutPanel1);
            this.panelDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDown.Location = new System.Drawing.Point(0, 40);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(1070, 585);
            this.panelDown.TabIndex = 0;
            // 
            // btnRadom
            // 
            this.btnRadom.BackgroundImage = global::DirvingTest.Properties.Resources._20150614043555476_easyicon_net_512;
            this.btnRadom.HeadImage = null;
            this.btnRadom.Location = new System.Drawing.Point(552, 533);
            this.btnRadom.MouseClickImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.btnRadom.MouseOverImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.btnRadom.Name = "btnRadom";
            this.btnRadom.Size = new System.Drawing.Size(138, 40);
            this.btnRadom.TabIndex = 30;
            this.btnRadom.Text = "随机练习";
            this.btnRadom.TextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRadom.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.btnRadom_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelInfo.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelInfo.ForeColor = System.Drawing.Color.Brown;
            this.labelInfo.Location = new System.Drawing.Point(141, 128);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(472, 78);
            this.labelInfo.TabIndex = 29;
            this.labelInfo.Text = "当前题库下没有技巧练习！";
            this.labelInfo.Visible = false;
            // 
            // btnSequence
            // 
            this.btnSequence.BackgroundImage = global::DirvingTest.Properties.Resources._20150614043555476_easyicon_net_512;
            this.btnSequence.HeadImage = null;
            this.btnSequence.Location = new System.Drawing.Point(283, 533);
            this.btnSequence.MouseClickImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.btnSequence.MouseOverImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.btnSequence.Name = "btnSequence";
            this.btnSequence.Size = new System.Drawing.Size(138, 40);
            this.btnSequence.TabIndex = 28;
            this.btnSequence.Text = "顺序练习";
            this.btnSequence.TextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSequence.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.btnSequence_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.radioButtonTemplate, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 45);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1046, 470);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // radioButtonTemplate
            // 
            this.radioButtonTemplate.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonTemplate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonTemplate.ForeColor = System.Drawing.Color.Navy;
            this.radioButtonTemplate.Location = new System.Drawing.Point(4, 4);
            this.radioButtonTemplate.Name = "radioButtonTemplate";
            this.radioButtonTemplate.Size = new System.Drawing.Size(167, 39);
            this.radioButtonTemplate.TabIndex = 3;
            this.radioButtonTemplate.TabStop = true;
            this.radioButtonTemplate.Text = "技巧模板技巧模板技巧模板技巧模板技巧模板技巧模板技巧模板";
            this.radioButtonTemplate.UseVisualStyleBackColor = false;
            this.radioButtonTemplate.Visible = false;
            this.radioButtonTemplate.CheckedChanged += new System.EventHandler(this.radioButtonTemplate_CheckedChanged);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Azure;
            this.panelTop.Controls.Add(this.btnClear);
            this.panelTop.Controls.Add(this.panel3);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.lblInfo);
            this.panelTop.Controls.Add(this.picHeader);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1070, 70);
            this.panelTop.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSalmon;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(138, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(61, 19);
            this.panel3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(5, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "操作说明 ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(208, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "请选择对应的练习章节进行学习。";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo.Location = new System.Drawing.Point(138, 14);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(398, 14);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "强化练习--强化练习容易错误的题目，帮助更好通过考试。";
            // 
            // picHeader
            // 
            this.picHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.picHeader.Image = global::DirvingTest.Properties.Resources.notes2;
            this.picHeader.Location = new System.Drawing.Point(46, 8);
            this.picHeader.Name = "picHeader";
            this.picHeader.Size = new System.Drawing.Size(64, 55);
            this.picHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHeader.TabIndex = 0;
            this.picHeader.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = global::DirvingTest.Properties.Resources._20150614043555476_easyicon_net_512;
            this.btnClear.HeadImage = null;
            this.btnClear.Location = new System.Drawing.Point(908, 14);
            this.btnClear.MouseClickImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.btnClear.MouseOverImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(138, 40);
            this.btnClear.TabIndex = 31;
            this.btnClear.Text = "清除错题";
            this.btnClear.TextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.btnClear_Click);
            // 
            // FormChaperSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1070, 625);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormChaperSelect";
            this.Text = "9";
            this.Load += new System.EventHandler(this.FormSkillSelect_Load);
            this.panelDown.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDown;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.PictureBox picHeader;
        private System.Windows.Forms.RadioButton radioButtonTemplate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CotrolLibrary.ImageButton btnSequence;
        private System.Windows.Forms.Label labelInfo;
        private CotrolLibrary.ImageButton btnRadom;
        private CotrolLibrary.ImageButton btnClear;
    }
}