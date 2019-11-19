using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace CotrolLibrary
{
    [DefaultEvent("Click")]
    public partial class ImageButton : UserControl
    {
        public ImageButton()
        {
            this.InitializeComponent();
        }


        private void OnClick(object sender, EventArgs e)
        {
            ClickEventHandler clickEvent = this.Click;
            if (clickEvent != null)
            {
                clickEvent(this, e);
            }
        }

        #region 属性

        private Image backgroundimage;
        private Image mouseoverimage;
        private Image mouseclickimage;
        private Image headImage;
        private string text;

        [Category("重要属性"), Description("按钮默认显示的背景图片")]
        public Image HeadImage
        {
            get
            {
                return headImage;
            }
            set
            {
                //this.pictureBoxHead.BackgroundImage = null;
                pictureBoxHead.Image = value;
                headImage = value;
                resetUI();
                pictureBoxHead.Refresh();
                //pictureBoxHead.BackgroundImage = null;
                
            }
        }

        [Category("重要属性"), Description("按钮默认显示的背景图片")]
        public override Image BackgroundImage
        {
            get
            {
                return pImage.Image;
            }
            set
            {
                this.pImage.Image = value;
                backgroundimage = value;
                pImage.Refresh();
                //resetUI();
                //pImage.BackgroundImage = value;
            }
        }

        [Category("重要属性"), Description("按钮中字体的大小")]
        //[Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]
        public Font TextFont
        {
            get
            {
                return this.lblTemp.Font;
            }
            set
            {
                this.lblTemp.Font = value;
                //resetUI();
            }
        }

        [Category("数据"), Description("按钮中要显示的文本")]
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(false)]
        public override string Text
        {
            get
            {
                return this.lblTemp.Text;
            }
            set
            {
                this.lblTemp.Text = value;
                text = value;
            }
        }

        [Category("重要属性"), Description("单击按钮时候显示的图片")]
        public Image MouseClickImage
        {
            get
            {
                return this.mouseclickimage;
            }
            set
            {
                this.mouseclickimage = value;
            }
        }

        [Category("重要属性"), Description("鼠标移动到按钮上时显示的图片")]
        public Image MouseOverImage
        {
            get
            {
                return this.mouseoverimage;
            }
            set
            {
                this.mouseoverimage = value;
            }
        }

        #endregion

        #region 事件

        public delegate void ClickEventHandler(object sender, EventArgs e);
        public new event ClickEventHandler Click;

        public void PerformClick()
        {
            this.OnClick(this, new EventArgs());
        }

        private void ImageButton_Load(object sender, EventArgs e)
        {
            this.pImage.Image = this.backgroundimage;
            this.lblTemp.Parent = this.pImage;

            this.pictureBoxHead.Parent = this.pImage;
            this.pictureBoxHead.Image = this.headImage;
            
            this.lblTemp.Text = text;

            resetUI();
        }

        private void ImageButton_Resize(object sender, EventArgs e)
        {
            //resetUI();
            //pictureBoxHead.Refresh();
        }

        #region 鼠标事件

        private void Mouse_Enter(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.Hand;
            this.pImage.Image = this.mouseoverimage;
        }

        private void Mouse_Leave(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.Arrow;
            this.pImage.Image = this.backgroundimage;
        }

        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            //this.Cursor = Cursors.Hand;
            this.pImage.Image = this.mouseclickimage;
        }

        private void Mouse_Hover(object sender, EventArgs e)
        {
            this.pImage.Image = this.mouseoverimage;
        }

        private void Mouse_Up(object sender, MouseEventArgs e)
        {
            this.pImage.Image = this.backgroundimage;
        }

        #endregion

        private void lblTemp_TextChanged(object sender, EventArgs e)
        {
            this.lblTemp.Parent = this.pImage;
            resetUI();
        }

        private void pbImage_BackgroundImageChanged(object sender, EventArgs e)
        {
            this.pImage.Refresh();
        }

        #endregion

        private void pictureBoxHead_BackgroundImageChanged(object sender, EventArgs e)
        {
            if (headImage == null)
                resetUI();

            this.pictureBoxHead.Refresh();
        }

        private void resetUI()
        {
            if (pictureBoxHead.Image == null)
            {
                pictureBoxHead.Visible = false;
                pictureBoxHead.BringToFront();
                this.lblTemp.Left = 0;
                this.lblTemp.Top = 0;
                this.lblTemp.Left = (int)Math.Round((double)((((double)this.pImage.Width) / 2.0) - (((double)this.lblTemp.Width) / 2.0)));
                this.lblTemp.Top = (int)Math.Round((double)((((double)this.pImage.Height) / 2.0) - (((double)this.lblTemp.Height) / 2.0)));
            }
            else
            {
                pictureBoxHead.Visible = true;
                pictureBoxHead.BringToFront();
                pictureBoxHead.Left = 10;
                pictureBoxHead.Top = 0;
                pictureBoxHead.Left = (int)Math.Round((double)((((double)this.pImage.Width) / 2.0) - (((double)this.lblTemp.Width) / 2.0))) - pictureBoxHead.Width / 2 - 5;
                pictureBoxHead.Top = (int)Math.Round((double)((((double)this.pImage.Height) / 2.0) - (((double)this.pictureBoxHead.Height) / 2.0)));

                this.lblTemp.Left = 0;
                this.lblTemp.Top = 0;
                this.lblTemp.Left = pictureBoxHead.Width/2 + 5 + (int)Math.Round((double)((((double)this.pImage.Width) / 2.0) - (((double)this.lblTemp.Width) / 2.0)));
                this.lblTemp.Top = (int)Math.Round((double)((((double)this.pImage.Height) / 2.0) - (((double)this.lblTemp.Height) / 2.0)));
            }
        }
    }
}
