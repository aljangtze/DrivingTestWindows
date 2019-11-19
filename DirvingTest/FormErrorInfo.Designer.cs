namespace DirvingTest
{
    partial class FormErrorInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormErrorInfo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.imageButton1 = new CotrolLibrary.ImageButton();
            this.imageButtonExit = new CotrolLibrary.ImageButton();
            this.imageButtonRedoWrong = new CotrolLibrary.ImageButton();
            this.imageButtonRedo = new CotrolLibrary.ImageButton();
            this.imageButtonRightQuestions = new CotrolLibrary.ImageButton();
            this.imageButtonWrongQuestions = new CotrolLibrary.ImageButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelQuestionCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelDel = new System.Windows.Forms.Label();
            this.labelAdd = new System.Windows.Forms.Label();
            this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.labelTittle = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.imageButton1);
            this.panel1.Controls.Add(this.imageButtonExit);
            this.panel1.Controls.Add(this.imageButtonRedoWrong);
            this.panel1.Controls.Add(this.imageButtonRedo);
            this.panel1.Controls.Add(this.imageButtonRightQuestions);
            this.panel1.Controls.Add(this.imageButtonWrongQuestions);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.labelTittle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 93);
            this.panel1.TabIndex = 3;
            // 
            // imageButton1
            // 
            this.imageButton1.BackgroundImage = global::DirvingTest.Properties.Resources._20150614043555476_easyicon_net_512;
            this.imageButton1.HeadImage = null;
            this.imageButton1.Location = new System.Drawing.Point(265, 32);
            this.imageButton1.MouseClickImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.imageButton1.MouseOverImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.imageButton1.Name = "imageButton1";
            this.imageButton1.Size = new System.Drawing.Size(122, 33);
            this.imageButton1.TabIndex = 34;
            this.imageButton1.Text = "查看未做";
            this.imageButton1.TextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imageButton1.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButton1_Click);
            // 
            // imageButtonExit
            // 
            this.imageButtonExit.BackgroundImage = global::DirvingTest.Properties.Resources._20150614043555476_easyicon_net_512;
            this.imageButtonExit.HeadImage = null;
            this.imageButtonExit.Location = new System.Drawing.Point(649, 32);
            this.imageButtonExit.MouseClickImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.imageButtonExit.MouseOverImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.imageButtonExit.Name = "imageButtonExit";
            this.imageButtonExit.Size = new System.Drawing.Size(122, 33);
            this.imageButtonExit.TabIndex = 33;
            this.imageButtonExit.Text = "退出练习";
            this.imageButtonExit.TextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imageButtonExit.Visible = false;
            this.imageButtonExit.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButtonExit_Click);
            // 
            // imageButtonRedoWrong
            // 
            this.imageButtonRedoWrong.BackgroundImage = global::DirvingTest.Properties.Resources._20150614043555476_easyicon_net_512;
            this.imageButtonRedoWrong.HeadImage = null;
            this.imageButtonRedoWrong.Location = new System.Drawing.Point(393, 32);
            this.imageButtonRedoWrong.MouseClickImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.imageButtonRedoWrong.MouseOverImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.imageButtonRedoWrong.Name = "imageButtonRedoWrong";
            this.imageButtonRedoWrong.Size = new System.Drawing.Size(122, 33);
            this.imageButtonRedoWrong.TabIndex = 32;
            this.imageButtonRedoWrong.Text = "重做错题";
            this.imageButtonRedoWrong.TextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imageButtonRedoWrong.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButtonRedoWrong_Click);
            // 
            // imageButtonRedo
            // 
            this.imageButtonRedo.BackgroundImage = global::DirvingTest.Properties.Resources._20150614043555476_easyicon_net_512;
            this.imageButtonRedo.HeadImage = null;
            this.imageButtonRedo.Location = new System.Drawing.Point(521, 32);
            this.imageButtonRedo.MouseClickImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.imageButtonRedo.MouseOverImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.imageButtonRedo.Name = "imageButtonRedo";
            this.imageButtonRedo.Size = new System.Drawing.Size(122, 33);
            this.imageButtonRedo.TabIndex = 31;
            this.imageButtonRedo.Text = "再做一次";
            this.imageButtonRedo.TextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imageButtonRedo.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButtonRedo_Click);
            // 
            // imageButtonRightQuestions
            // 
            this.imageButtonRightQuestions.BackgroundImage = global::DirvingTest.Properties.Resources._20150614043555476_easyicon_net_512;
            this.imageButtonRightQuestions.HeadImage = null;
            this.imageButtonRightQuestions.Location = new System.Drawing.Point(137, 32);
            this.imageButtonRightQuestions.MouseClickImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.imageButtonRightQuestions.MouseOverImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.imageButtonRightQuestions.Name = "imageButtonRightQuestions";
            this.imageButtonRightQuestions.Size = new System.Drawing.Size(122, 33);
            this.imageButtonRightQuestions.TabIndex = 30;
            this.imageButtonRightQuestions.Text = "查看对题";
            this.imageButtonRightQuestions.TextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imageButtonRightQuestions.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButtonRightQuestions_Click);
            // 
            // imageButtonWrongQuestions
            // 
            this.imageButtonWrongQuestions.BackgroundImage = global::DirvingTest.Properties.Resources._20150614043555476_easyicon_net_512;
            this.imageButtonWrongQuestions.HeadImage = null;
            this.imageButtonWrongQuestions.Location = new System.Drawing.Point(9, 32);
            this.imageButtonWrongQuestions.MouseClickImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.imageButtonWrongQuestions.MouseOverImage = global::DirvingTest.Properties.Resources._20150614043603514_easyicon_net_512;
            this.imageButtonWrongQuestions.Name = "imageButtonWrongQuestions";
            this.imageButtonWrongQuestions.Size = new System.Drawing.Size(122, 33);
            this.imageButtonWrongQuestions.TabIndex = 29;
            this.imageButtonWrongQuestions.Text = "查看错题";
            this.imageButtonWrongQuestions.TextFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imageButtonWrongQuestions.Click += new CotrolLibrary.ImageButton.ClickEventHandler(this.imageButtonWrongQuestions_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.panel4.Controls.Add(this.labelInfo);
            this.panel4.Controls.Add(this.labelQuestionCount);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.labelDel);
            this.panel4.Controls.Add(this.labelAdd);
            this.panel4.Controls.Add(this.checkBoxSelectAll);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 68);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(840, 25);
            this.panel4.TabIndex = 11;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelInfo.Location = new System.Drawing.Point(6, 6);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(63, 14);
            this.labelInfo.TabIndex = 14;
            this.labelInfo.Text = "错误答题";
            // 
            // labelQuestionCount
            // 
            this.labelQuestionCount.AutoSize = true;
            this.labelQuestionCount.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelQuestionCount.ForeColor = System.Drawing.Color.Maroon;
            this.labelQuestionCount.Location = new System.Drawing.Point(781, 6);
            this.labelQuestionCount.Name = "labelQuestionCount";
            this.labelQuestionCount.Size = new System.Drawing.Size(33, 12);
            this.labelQuestionCount.TabIndex = 12;
            this.labelQuestionCount.Text = "2000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(819, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "题";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(761, 8);
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
            this.pictureBox3.Visible = false;
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
            this.pictureBox2.Visible = false;
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
            this.labelDel.Visible = false;
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
            this.labelAdd.Visible = false;
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(9, 4);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(48, 16);
            this.checkBoxSelectAll.TabIndex = 6;
            this.checkBoxSelectAll.Text = "全选";
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            this.checkBoxSelectAll.Visible = false;
            // 
            // labelTittle
            // 
            this.labelTittle.AutoSize = true;
            this.labelTittle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTittle.Location = new System.Drawing.Point(3, 9);
            this.labelTittle.Name = "labelTittle";
            this.labelTittle.Size = new System.Drawing.Size(196, 14);
            this.labelTittle.TabIndex = 2;
            this.labelTittle.Text = "总共100题 答对50题 答错50题";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column8,
            this.Column4,
            this.Column5,
            this.Column7});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 93);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(840, 481);
            this.dataGridView1.TabIndex = 4;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "序号";
            this.Column2.Name = "Column2";
            this.Column2.Width = 60;
            // 
            // Column3
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "题目名称";
            this.Column3.Name = "Column3";
            this.Column3.Width = 400;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "题目类型";
            this.Column8.Name = "Column8";
            this.Column8.Width = 80;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "您的答案";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "正确答案";
            this.Column5.Name = "Column5";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "是否正确";
            this.Column7.Name = "Column7";
            this.Column7.Width = 80;
            // 
            // FormErrorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(840, 574);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormErrorInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "错题回顾";
            this.Shown += new System.EventHandler(this.FormErrorInfo_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelQuestionCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelDel;
        private System.Windows.Forms.Label labelAdd;
        private System.Windows.Forms.CheckBox checkBoxSelectAll;
        private System.Windows.Forms.Label labelTittle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private CotrolLibrary.ImageButton imageButtonWrongQuestions;
        private CotrolLibrary.ImageButton imageButtonRightQuestions;
        private CotrolLibrary.ImageButton imageButtonRedo;
        private CotrolLibrary.ImageButton imageButtonRedoWrong;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private CotrolLibrary.ImageButton imageButtonExit;
        private CotrolLibrary.ImageButton imageButton1;
    }
}