using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace CotrolLibrary
{
    partial class ImageButton
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
            this.lblTemp = new System.Windows.Forms.Label();
            this.pImage = new System.Windows.Forms.PictureBox();
            this.pictureBoxHead = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHead)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTemp
            // 
            this.lblTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTemp.AutoSize = true;
            this.lblTemp.BackColor = System.Drawing.Color.Transparent;
            this.lblTemp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTemp.Location = new System.Drawing.Point(44, 15);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(71, 12);
            this.lblTemp.TabIndex = 1;
            this.lblTemp.Text = "imageButton";
            this.lblTemp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTemp.TextChanged += new System.EventHandler(this.lblTemp_TextChanged);
            this.lblTemp.Click += new System.EventHandler(this.OnClick);
            this.lblTemp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mouse_Down);
            this.lblTemp.MouseEnter += new System.EventHandler(this.Mouse_Enter);
            this.lblTemp.MouseLeave += new System.EventHandler(this.Mouse_Leave);
            this.lblTemp.MouseHover += new System.EventHandler(this.Mouse_Hover);
            this.lblTemp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Mouse_Up);
            // 
            // pImage
            // 
            this.pImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pImage.Location = new System.Drawing.Point(0, 0);
            this.pImage.Name = "pImage";
            this.pImage.Size = new System.Drawing.Size(128, 40);
            this.pImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pImage.TabIndex = 0;
            this.pImage.TabStop = false;
            this.pImage.BackgroundImageChanged += new System.EventHandler(this.pbImage_BackgroundImageChanged);
            this.pImage.Click += new System.EventHandler(this.OnClick);
            this.pImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Mouse_Down);
            this.pImage.MouseEnter += new System.EventHandler(this.Mouse_Enter);
            this.pImage.MouseLeave += new System.EventHandler(this.Mouse_Leave);
            this.pImage.MouseHover += new System.EventHandler(this.Mouse_Hover);
            this.pImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Mouse_Up);
            // 
            // pictureBoxHead
            // 
            this.pictureBoxHead.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxHead.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxHead.Location = new System.Drawing.Point(10, 7);
            this.pictureBoxHead.Name = "pictureBoxHead";
            this.pictureBoxHead.Size = new System.Drawing.Size(28, 28);
            this.pictureBoxHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxHead.TabIndex = 2;
            this.pictureBoxHead.TabStop = false;
            this.pictureBoxHead.Visible = false;
            this.pictureBoxHead.BackgroundImageChanged += new System.EventHandler(this.pictureBoxHead_BackgroundImageChanged);
            // 
            // ImageButton
            // 
            this.Controls.Add(this.lblTemp);
            this.Controls.Add(this.pictureBoxHead);
            this.Controls.Add(this.pImage);
            this.Name = "ImageButton";
            this.Size = new System.Drawing.Size(128, 40);
            this.Load += new System.EventHandler(this.ImageButton_Load);
            this.MouseEnter += new System.EventHandler(this.Mouse_Enter);
            this.MouseLeave += new System.EventHandler(this.Mouse_Leave);
            this.Resize += new System.EventHandler(this.ImageButton_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHead)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label lblTemp;
        private PictureBox pImage;

        #endregion
        private PictureBox pictureBoxHead;

    }
}
