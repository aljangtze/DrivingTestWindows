﻿namespace DirvingTest
{
    partial class FormQuestionManageSql
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboxChaperType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxFilterOptions = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxFilterTittle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelQuestionCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelDel = new System.Windows.Forms.Label();
            this.labelAdd = new System.Windows.Forms.Label();
            this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboxClassification = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxChapter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTittle = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelManager = new System.Windows.Forms.Panel();
            this.pageControl1 = new DirvingTest.PageControl();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelManager.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.cboxChaperType);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.textBoxFilterOptions);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBoxFilterTittle);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.comboBoxType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboxClassification);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.comboBoxChapter);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelTittle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 143);
            this.panel1.TabIndex = 2;
            // 
            // cboxChaperType
            // 
            this.cboxChaperType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxChaperType.FormattingEnabled = true;
            this.cboxChaperType.Location = new System.Drawing.Point(68, 53);
            this.cboxChaperType.Name = "cboxChaperType";
            this.cboxChaperType.Size = new System.Drawing.Size(156, 20);
            this.cboxChaperType.TabIndex = 23;
            this.cboxChaperType.SelectedIndexChanged += new System.EventHandler(this.cboxChaperType_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 22;
            this.label11.Text = "分组类型:";
            // 
            // textBoxFilterOptions
            // 
            this.textBoxFilterOptions.Location = new System.Drawing.Point(478, 85);
            this.textBoxFilterOptions.Name = "textBoxFilterOptions";
            this.textBoxFilterOptions.Size = new System.Drawing.Size(156, 21);
            this.textBoxFilterOptions.TabIndex = 6;
            this.textBoxFilterOptions.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(423, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "选项内容:";
            this.label8.Visible = false;
            // 
            // textBoxFilterTittle
            // 
            this.textBoxFilterTittle.Location = new System.Drawing.Point(68, 85);
            this.textBoxFilterTittle.Name = "textBoxFilterTittle";
            this.textBoxFilterTittle.Size = new System.Drawing.Size(349, 21);
            this.textBoxFilterTittle.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "题目内容:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(690, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "筛选";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.panel4.Controls.Add(this.labelQuestionCount);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.labelDel);
            this.panel4.Controls.Add(this.labelAdd);
            this.panel4.Controls.Add(this.checkBoxSelectAll);
            this.panel4.Location = new System.Drawing.Point(0, 117);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1036, 24);
            this.panel4.TabIndex = 11;
            // 
            // labelQuestionCount
            // 
            this.labelQuestionCount.AutoSize = true;
            this.labelQuestionCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelQuestionCount.ForeColor = System.Drawing.Color.Maroon;
            this.labelQuestionCount.Location = new System.Drawing.Point(971, 6);
            this.labelQuestionCount.Name = "labelQuestionCount";
            this.labelQuestionCount.Size = new System.Drawing.Size(33, 12);
            this.labelQuestionCount.TabIndex = 12;
            this.labelQuestionCount.Text = "2000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1009, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "题";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(951, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "共";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DirvingTest.Properties.Resources.del;
            this.pictureBox3.Location = new System.Drawing.Point(139, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(14, 14);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.labelDel_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DirvingTest.Properties.Resources.add;
            this.pictureBox2.Location = new System.Drawing.Point(70, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(14, 14);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.labelAdd_Click);
            // 
            // labelDel
            // 
            this.labelDel.AutoSize = true;
            this.labelDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelDel.Location = new System.Drawing.Point(159, 7);
            this.labelDel.Name = "labelDel";
            this.labelDel.Size = new System.Drawing.Size(29, 12);
            this.labelDel.TabIndex = 8;
            this.labelDel.Text = "删除";
            this.labelDel.Click += new System.EventHandler(this.labelDel_Click);
            // 
            // labelAdd
            // 
            this.labelAdd.AutoSize = true;
            this.labelAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelAdd.Location = new System.Drawing.Point(87, 6);
            this.labelAdd.Name = "labelAdd";
            this.labelAdd.Size = new System.Drawing.Size(29, 12);
            this.labelAdd.TabIndex = 7;
            this.labelAdd.Text = "新增";
            this.labelAdd.Click += new System.EventHandler(this.labelAdd_Click);
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(9, 4);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(48, 16);
            this.checkBoxSelectAll.TabIndex = 8;
            this.checkBoxSelectAll.Text = "全选";
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            this.checkBoxSelectAll.CheckStateChanged += new System.EventHandler(this.checkBoxSelectAll_CheckStateChanged);
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(904, 54);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(75, 20);
            this.comboBoxType.TabIndex = 4;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxChapter_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(870, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "题型：";
            // 
            // cboxClassification
            // 
            this.cboxClassification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxClassification.FormattingEnabled = true;
            this.cboxClassification.Location = new System.Drawing.Point(746, 54);
            this.cboxClassification.Name = "cboxClassification";
            this.cboxClassification.Size = new System.Drawing.Size(96, 20);
            this.cboxClassification.TabIndex = 3;
            this.cboxClassification.SelectedIndexChanged += new System.EventHandler(this.comboBoxChapter_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(689, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "题目类别：";
            // 
            // comboBoxChapter
            // 
            this.comboBoxChapter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChapter.FormattingEnabled = true;
            this.comboBoxChapter.Location = new System.Drawing.Point(313, 54);
            this.comboBoxChapter.Name = "comboBoxChapter";
            this.comboBoxChapter.Size = new System.Drawing.Size(323, 20);
            this.comboBoxChapter.TabIndex = 1;
            this.comboBoxChapter.SelectedValueChanged += new System.EventHandler(this.comboBoxChapter_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "章节分类:";
            // 
            // labelTittle
            // 
            this.labelTittle.AutoSize = true;
            this.labelTittle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTittle.Location = new System.Drawing.Point(3, 18);
            this.labelTittle.Name = "labelTittle";
            this.labelTittle.Size = new System.Drawing.Size(428, 14);
            this.labelTittle.TabIndex = 2;
            this.labelTittle.Text = "题库管理--对试题信息进行维护，进行技巧的增加、删除、修改";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column11,
            this.Column2,
            this.Column3,
            this.Column7,
            this.Column8,
            this.Column4,
            this.Column5,
            this.Column10,
            this.Column6,
            this.Column9});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 143);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1046, 398);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panelManager
            // 
            this.panelManager.Controls.Add(this.dataGridView1);
            this.panelManager.Controls.Add(this.panel1);
            this.panelManager.Controls.Add(this.pageControl1);
            this.panelManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelManager.Location = new System.Drawing.Point(0, 0);
            this.panelManager.Name = "panelManager";
            this.panelManager.Size = new System.Drawing.Size(1046, 582);
            this.panelManager.TabIndex = 4;
            // 
            // pageControl1
            // 
            this.pageControl1.CurrentPage = 1;
            this.pageControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pageControl1.Location = new System.Drawing.Point(0, 541);
            this.pageControl1.Name = "pageControl1";
            this.pageControl1.PerPageNumber = 20;
            this.pageControl1.Size = new System.Drawing.Size(1046, 41);
            this.pageControl1.TabIndex = 4;
            this.pageControl1.TotalCount = 100;
            // 
            // panelDetails
            // 
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(1046, 582);
            this.panelDetails.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "*";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.Width = 20;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "序号";
            this.Column11.Name = "Column11";
            this.Column11.Width = 60;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ID";
            this.Column2.Name = "Column2";
            this.Column2.Width = 60;
            // 
            // Column3
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column3.HeaderText = "题目名称";
            this.Column3.Name = "Column3";
            this.Column3.Width = 400;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "题目类别";
            this.Column7.Name = "Column7";
            this.Column7.Width = 80;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "题目类型";
            this.Column8.Name = "Column8";
            this.Column8.Width = 80;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "章节分组";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "技巧分组";
            this.Column5.Name = "Column5";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "强化分组";
            this.Column10.Name = "Column10";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "编辑";
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column6.Width = 52;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "删除";
            this.Column9.Name = "Column9";
            this.Column9.Width = 50;
            // 
            // FormQuestionManageSql
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1046, 582);
            this.Controls.Add(this.panelManager);
            this.Controls.Add(this.panelDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQuestionManageSql";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormQuestionManage";
            this.Load += new System.EventHandler(this.FormQuestionManage_Load);
            this.Shown += new System.EventHandler(this.FormQuestionManage_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelManager.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTittle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelManager;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.ComboBox comboBoxChapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxClassification;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelDel;
        private System.Windows.Forms.Label labelAdd;
        private System.Windows.Forms.CheckBox checkBoxSelectAll;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelQuestionCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxFilterOptions;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxFilterTittle;
        private PageControl pageControl1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboxChaperType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewButtonColumn Column6;
        private System.Windows.Forms.DataGridViewButtonColumn Column9;
    }
}