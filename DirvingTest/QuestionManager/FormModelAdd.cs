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
    public partial class FormModelAdd : Form
    {
        public delegate bool WantSendBack(ModelChapter model, bool Replace);

        public WantSendBack FormBack = null;

        private ModelChapter m_model = null;
       
        public FormModelAdd()
        {
            InitializeComponent();
        }

        private void labelBack_MouseMove(object sender, MouseEventArgs e)
        {
            labelBack.ForeColor = Color.Red;
        }

        private void labelBack_Click(object sender, EventArgs e)
        {
            if (FormBack != null)
            {
                m_model.Tittle = richTextBoxTittle.Text;
                
                m_model.Classification = comboBoxType.SelectedIndex;
                FormBack(m_model, false);
            }
        }

        private void labelBack_MouseLeave(object sender, EventArgs e)
        {
            labelBack.ForeColor = Color.Blue;
        }

        private void imageButtonSave_Click(object sender, EventArgs e)
        {
            if (FormBack != null)
            {
                if(string.IsNullOrEmpty(richTextBoxTittle.Text))
                {
                    MessageBox.Show("请输入模块名称！", "提示信息", MessageBoxButtons.OK);
                    richTextBoxTittle.Focus();
                    return;
                }

                if(comboBoxStatus.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择模块启用状态！", "提示信息", MessageBoxButtons.OK);
                    comboBoxStatus.Focus();
                    return;
                }

                if(comboBoxType.SelectedIndex < 0)
                {
                    MessageBox.Show("请选择模块类型！", "提示信息", MessageBoxButtons.OK);
                    comboBoxStatus.Focus();
                    return;
                }

                m_model.Tittle = richTextBoxTittle.Text;
                m_model.IsEnable = comboBoxStatus.SelectedIndex == 0 ? true : false;
                m_model.Classification = comboBoxType.SelectedIndex+1;
                if (false == FormBack(m_model, true))
                {
                    MessageBox.Show("保存信息失败！", "提示信息", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("保存信息成功！", "提示信息", MessageBoxButtons.OK);
                    this.Hide();
                }
            }
        }

        public void SetModel(ModelChapter model, int type)
        {
            m_model = model;
            if(type == 0)
            {
                labelName.Text = "技巧名称：";
                labelType.Text = "技巧类型：";
                labelStatus.Text = "技巧状态：";
            }
            if(type == 1)
            {
                labelName.Text = "章节名称：";
                labelType.Text = "章节类型：";
                labelStatus.Text = "章节状态：";
            }

            if(type == 2)
            {
                labelName.Text = "套题名称：";
                labelType.Text = "套题类型：";
                labelStatus.Text = "套题状态：";
            }

            richTextBoxTittle.Focus();
            comboBoxType.SelectedIndex = m_model.Classification - 1;
            comboBoxStatus.SelectedIndex = m_model.IsEnable ? 0 : 1;
            richTextBoxTittle.Text = m_model.Tittle;
        }

        private void FormModelAdd_Shown(object sender, EventArgs e)
        {

        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_model.IsEnable = comboBoxType.SelectedIndex == 0 ? true : false;
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_model.Classification = comboBoxType.SelectedIndex;
        }

        private void richTextBoxTittle_TextChanged(object sender, EventArgs e)
        {
            m_model.Tittle = richTextBoxTittle.Text;
        }

    }
}
