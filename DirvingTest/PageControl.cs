using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DirvingTest
{
    public partial class PageControl : UserControl
    {
        public PageControl()
        {
            InitializeComponent();
            //10
            //20
            //50
            //100
            cboxNumber.SelectedIndex = 1;
        }

        


        int currentPage = 0;
        public int CurrentPage
        {
            get
            {
                return currentPage;
            }

            set
            {
                if(value>PageNumber)
                {
                    currentPage = PageNumber;
                    ChangePages();
                    return;
                }

                if(value <= 0)
                {
                    if(TotalCount<=0)
                    {
                        currentPage = 0;
                        ChangePages();
                        return;
                    }
                    else
                    {
                        currentPage = 1;
                        ChangePages();
                        return;
                    }
                }

                currentPage = value;
                ChangePages();
            }
        }

        int pageNumber = 1;
        public int PageNumber
        {
            get
            {
                return pageNumber;
            }
        }

        int perPageNumber = 20;
        [Browsable(true)]
        public int PerPageNumber
        {
            get
            {
                return perPageNumber;
            }
            set
            {
                int number = value;
                if (number <= 10)
                {
                    number = 10;
                }
                else if(number > 20 && number <= 50)
                {
                    number = 50;
                }
                else if(number > 10 && number <=20)
                {
                    number = 20;
                }
                else
                {
                    number = 100;
                }

                if (number != perPageNumber)
                {
                    perPageNumber = number;

                    switch(number)
                    {
                        case 10:
                            cboxNumber.SelectedIndex = 0;
                            break;
                        case 20:
                            cboxNumber.SelectedIndex = 1;
                            break;
                        case 50:
                            cboxNumber.SelectedIndex = 2;
                            break;
                        default:
                            cboxNumber.SelectedIndex = 3;
                            break;
                    }

                    Initialize();
                }

                
            }
        }

        int totalCount = 0;
        [Browsable(true)]
        public int TotalCount
        {
            get
            {
                return totalCount;
            }
            set
            {
                if (totalCount != value)
                {
                    totalCount = value;
                }

                Initialize();
            }
        }

        void Initialize()
        {
            pageNumber = (totalCount / perPageNumber) + (totalCount % perPageNumber == 0 ? 0 : 1);

            txtPageNumber.Text = Convert.ToString(pageNumber / 2);

            CurrentPage = 1;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            CurrentPage = 1;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            CurrentPage = PageNumber;
        }

        public delegate void RefreshDatas(int pageNumber, int currentPage);
        public RefreshDatas OnChangeDatas;

        private void cboxNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(perPageNumber != Convert.ToInt32(cboxNumber.Text))
            {
                PerPageNumber = Convert.ToInt32(cboxNumber.Text);
                //Initialize();
                ChangePages();  
            }
        }

        void ChangePages()
        {

            lblInfo.Text = string.Format("共 {0} 条 {1}/{2}页", totalCount, currentPage, PageNumber);
            label4.Text = string.Format("第{0}页", currentPage);
            if (isUpdateInfo == false)
            {
                OnChangeDatas?.Invoke(perPageNumber, currentPage);
            }
        }

        private void btnJump_Click(object sender, EventArgs e)
        {
            try
            {
                int page = Convert.ToInt32(txtPageNumber.Text);
                CurrentPage = page;
            }
            catch
            {

            }
        }

        private void txtPageNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnJump.PerformClick();
            }
        }


        bool isUpdateInfo = false;
        public void BeginUpdate()
        {
            isUpdateInfo = true;

        }

        public void EndUpdate()
        {
            ChangePages();
            isUpdateInfo = false;
        }
    }
}
