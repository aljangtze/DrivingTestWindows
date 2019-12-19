using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
////using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DirvingTest
{
    public partial class FormChapterAdd : Form
    {
        private ChapterInfo m_chapter = null;

        public FormChapterAdd()
        {
            InitializeComponent();
            chapterManager = new ChapterManager();
            m_chapter = new ChapterInfo();

        }

        ChapterManager chapterManager;
        private void labelBack_MouseMove(object sender, MouseEventArgs e)
        {
            labelBack.ForeColor = Color.Red;
        }

        private void labelBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void labelBack_MouseLeave(object sender, EventArgs e)
        {
            labelBack.ForeColor = Color.Blue;
        }

        int _Type = 0;

        public bool SetType(int chapterType)
        {
            if(false == chapterManager.GetChapterTypeList(out List<ChapterType> chapterTypeList))
            {
                return false;
            }

            bool isExists = false;
            string name = "";
            foreach(ChapterType chapterTypeInfo in chapterTypeList)
            {
                if (chapterTypeInfo.ID == chapterType)
                {
                    isExists = true;
                    name = chapterTypeInfo.Name;
                    break;
                }
            }
            if(isExists == false)
            {
                return false;
            }
            _Type = chapterType;
            lblInfo.Text = "添加" + name +"分组";
            return true;
        }
        private void imageButtonSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(richTextBoxTittle.Text))
            {
                MessageBox.Show("分组名称不能为空！", "提示信息", MessageBoxButtons.OK);
                richTextBoxTittle.Focus();
                return;
            }

            m_chapter.Name = richTextBoxTittle.Text;
            m_chapter.IsEnable = comboBoxStatus.SelectedIndex == 0 ? true : false;
            m_chapter.Classification = comboBoxType.SelectedIndex + 1;
            m_chapter.ChapterType = _Type;
            if (false == chapterManager.AddChapter(m_chapter))
            {
                MessageBox.Show("保存信息失败！", "提示信息", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("保存信息成功！", "提示信息", MessageBoxButtons.OK);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_chapter.IsEnable = comboBoxType.SelectedIndex == 0 ? true : false;
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_chapter.Classification = comboBoxType.SelectedIndex;
        }

        private void richTextBoxTittle_TextChanged(object sender, EventArgs e)
        {
            m_chapter.Name = richTextBoxTittle.Text;
        }

    }
}
