namespace DirvingTest
{
    partial class FormUserManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelTittle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelDel = new System.Windows.Forms.Label();
            this.labelAdd = new System.Windows.Forms.Label();
            this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.panelModelList = new System.Windows.Forms.Panel();
            this.panelModelInfo = new System.Windows.Forms.Panel();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnDel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelModelList.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.labelInfo);
            this.panel1.Controls.Add(this.labelTittle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(865, 83);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(593, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSalmon;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(140, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(60, 19);
            this.panel2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "操作说明";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelInfo.Location = new System.Drawing.Point(210, 53);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(293, 12);
            this.labelInfo.TabIndex = 3;
            this.labelInfo.Text = "对技巧信息进行维护，进行技巧的增加、删除、修改。";
            // 
            // labelTittle
            // 
            this.labelTittle.AutoSize = true;
            this.labelTittle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTittle.Location = new System.Drawing.Point(135, 24);
            this.labelTittle.Name = "labelTittle";
            this.labelTittle.Size = new System.Drawing.Size(428, 14);
            this.labelTittle.TabIndex = 2;
            this.labelTittle.Text = "技巧管理--对技巧信息进行维护，进行技巧的增加、删除、修改";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DirvingTest.Properties.Resources._267;
            this.pictureBox1.Location = new System.Drawing.Point(46, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 83);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(865, 446);
            this.panel3.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
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
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.ColumnStatus,
            this.Column6,
            this.ColumnDel});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 30);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(865, 416);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.labelDel);
            this.panel4.Controls.Add(this.labelAdd);
            this.panel4.Controls.Add(this.checkBoxSelectAll);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(865, 30);
            this.panel4.TabIndex = 6;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DirvingTest.Properties.Resources.del;
            this.pictureBox3.Location = new System.Drawing.Point(139, 10);
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
            this.pictureBox2.Location = new System.Drawing.Point(70, 9);
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
            this.labelDel.Location = new System.Drawing.Point(159, 11);
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
            this.labelAdd.Location = new System.Drawing.Point(87, 10);
            this.labelAdd.Name = "labelAdd";
            this.labelAdd.Size = new System.Drawing.Size(29, 12);
            this.labelAdd.TabIndex = 7;
            this.labelAdd.Text = "新增";
            this.labelAdd.Click += new System.EventHandler(this.labelAdd_Click);
            this.labelAdd.MouseLeave += new System.EventHandler(this.labelAdd_MouseLeave);
            this.labelAdd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelAdd_MouseMove);
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.Location = new System.Drawing.Point(9, 8);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(48, 16);
            this.checkBoxSelectAll.TabIndex = 6;
            this.checkBoxSelectAll.Text = "全选";
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            this.checkBoxSelectAll.CheckStateChanged += new System.EventHandler(this.checkBoxSelectAll_CheckedChanged);
            // 
            // panelModelList
            // 
            this.panelModelList.Controls.Add(this.panel3);
            this.panelModelList.Controls.Add(this.panel1);
            this.panelModelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelModelList.Location = new System.Drawing.Point(0, 0);
            this.panelModelList.Name = "panelModelList";
            this.panelModelList.Size = new System.Drawing.Size(865, 529);
            this.panelModelList.TabIndex = 6;
            // 
            // panelModelInfo
            // 
            this.panelModelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelModelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelModelInfo.Name = "panelModelInfo";
            this.panelModelInfo.Size = new System.Drawing.Size(865, 529);
            this.panelModelInfo.TabIndex = 6;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "*";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column5.Width = 30;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Name";
            this.Column2.HeaderText = "用户名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 400;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "用户密码";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.AutoComplete = false;
            dataGridViewCellStyle2.NullValue = "null";
            this.ColumnStatus.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnStatus.HeaderText = "状态";
            this.ColumnStatus.Items.AddRange(new object[] {
            "启用",
            "停用"});
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.ReadOnly = true;
            this.ColumnStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnStatus.Width = 70;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "编辑";
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column6.Width = 70;
            // 
            // ColumnDel
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "删除";
            this.ColumnDel.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnDel.HeaderText = "删除";
            this.ColumnDel.Name = "ColumnDel";
            this.ColumnDel.ReadOnly = true;
            this.ColumnDel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnDel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnDel.Text = "删除";
            this.ColumnDel.UseColumnTextForButtonValue = true;
            this.ColumnDel.Width = 70;
            // 
            // FormUserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(865, 529);
            this.Controls.Add(this.panelModelList);
            this.Controls.Add(this.panelModelInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormUserManager";
            this.Text = "FormSkillManager";
            this.Load += new System.EventHandler(this.FormSkillManager_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelModelList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelTittle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelModelList;
        private System.Windows.Forms.Panel panelModelInfo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelDel;
        private System.Windows.Forms.Label labelAdd;
        private System.Windows.Forms.CheckBox checkBoxSelectAll;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColumnStatus;
        private System.Windows.Forms.DataGridViewButtonColumn Column6;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnDel;
    }
}