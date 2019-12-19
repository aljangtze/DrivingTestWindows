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
    public partial class FormChapterModify : Form
    {
        private ChapterInfo m_chapter = null;

        public FormChapterModify()
        {
            InitializeComponent();
            chapterManager = new ChapterManager();
            m_chapter = new ChapterInfo();

            chapterManager.GetChapterTypeList(out List<ChapterType> chapterTypeList);

            cboxChapterType.Items.Clear();
            foreach (ChapterType chapterTypeInfo in chapterTypeList)
            {
                cboxChapterType.Items.Add(chapterTypeInfo);
            }

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

        public bool SetChapter(ChapterInfo chapter)
        {
            if (null != chapter)
                m_chapter = chapter;

            lblInfo.Text = "修改分组:" + chapter.Name;
            richTextBoxTittle.Text = chapter.Name;
            cboxType.SelectedIndex = chapter.Classification-1;
            cboxChapterType.SelectedIndex = chapter.ChapterType;
            cboxStatus.SelectedIndex = chapter.IsEnable ? 1 : 0;
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
            m_chapter.IsEnable = cboxStatus.SelectedIndex == 0 ? true : false;
            m_chapter.Classification = cboxType.SelectedIndex + 1;
            m_chapter.ChapterType = cboxChapterType.SelectedIndex;
            if (false == chapterManager.UpdateChapter(m_chapter))
            {
                MessageBox.Show("更新信息失败！", "提示信息", MessageBoxButtons.OK);
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
            m_chapter.IsEnable = cboxType.SelectedIndex == 0 ? true : false;
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_chapter.Classification = cboxType.SelectedIndex;
        }

        private void richTextBoxTittle_TextChanged(object sender, EventArgs e)
        {
            m_chapter.Name = richTextBoxTittle.Text;
        }

    }
}
