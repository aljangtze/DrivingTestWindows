﻿namespace DirvingTest
{
    partial class FormBankSelect
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
            this.btnRandom = new CotrolLibrary.ImageButton();
            this.labelInfo = new System.Windows.Forms.Label();
            this.btnSequence = new CotrolLibrary.ImageButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonTemplate = new System.Windows.Forms.RadioButton();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelDown.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDown
            // 
            this.panelDown.Controls.Add(this.btnRandom);
            this.panelDown.Controls.Add(this.labelInfo);
            this.panelDown.Controls.Add(this.btnSequence);
            this.panelDown.Controls.Add(this.tableLayoutPanel1);
            this.panelDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDown.Location = new System.Drawing.Point(0, -45);
            this.panelDown.Name = "panelDown";
            this.panelDown.Size = new System.Drawing.Size(1070, 670);
            this.panelDown.TabIndex = 0;
            // 
            // btnRandom
            // 
            this.btnRandom.BackgroundImage = global::DirvingTest.Properties.Resources._20150614043555476_easyicon_net_512;
            this.btnRandom.HeadImage = null;
            this.btnRandom.Location = new System.Drawing.Point(623, 608);
            this.btnRandom.MouseClickImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.btnRandom.MouseOverImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(138, 40);
            this.btnRandom.TabIndex = 30;
            this.btnRandom.Text = "随机练习";
            this.btnRandom.TextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRandom.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.btnRandom_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelInfo.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelInfo.ForeColor = System.Drawing.Color.Brown;
            this.labelInfo.Location = new System.Drawing.Point(151, 262);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(472, 78);
            this.labelInfo.TabIndex = 29;
            this.labelInfo.Text = "当前题库下没有套题练习！";
            this.labelInfo.Visible = false;
            // 
            // btnSequence
            // 
            this.btnSequence.BackgroundImage = global::DirvingTest.Properties.Resources._20150614043555476_easyicon_net_512;
            this.btnSequence.HeadImage = null;
            this.btnSequence.Location = new System.Drawing.Point(289, 608);
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
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8919F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.89189F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.89189F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.89189F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.21622F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.21622F));
            this.tableLayoutPanel1.Controls.Add(this.radioButtonTemplate, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 130);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1040, 460);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // radioButtonTemplate
            // 
            this.radioButtonTemplate.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonTemplate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButtonTemplate.ForeColor = System.Drawing.Color.Navy;
            this.radioButtonTemplate.Location = new System.Drawing.Point(4, 4);
            this.radioButtonTemplate.Name = "radioButtonTemplate";
            this.radioButtonTemplate.Size = new System.Drawing.Size(168, 38);
            this.radioButtonTemplate.TabIndex = 3;
            this.radioButtonTemplate.TabStop = true;
            this.radioButtonTemplate.Text = "套题模板套题模板套题模板套题模板套题模板套题模板";
            this.radioButtonTemplate.UseVisualStyleBackColor = false;
            this.radioButtonTemplate.Visible = false;
            this.radioButtonTemplate.CheckedChanged += new System.EventHandler(this.radioButtonTemplate_CheckedChanged);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Azure;
            this.panelTop.Controls.Add(this.panel3);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.pictureBox1);
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
            this.label2.Text = "请选择对应的套题章节进行学习。";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(138, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "套题练习--专业的题库分类助您快速掌握相关题型";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.pictureBox1.Image = global::DirvingTest.Properties.Resources.notes;
            this.pictureBox1.Location = new System.Drawing.Point(46, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormBankSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1070, 625);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormBankSelect";
            this.Text = "FormSkillSelect";
            this.Load += new System.EventHandler(this.FormSkillSelect_Load);
            this.panelDown.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDown;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton radioButtonTemplate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CotrolLibrary.ImageButton btnSequence;
        private System.Windows.Forms.Label labelInfo;
        private CotrolLibrary.ImageButton btnRandom;
    }
}