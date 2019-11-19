using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
////using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DirvingTest
{
    public partial class FormBankManager : Form
    {
        private FormModelAdd _formModelAdd = null;
        public FormBankManager()
        {
            InitializeComponent();
        }

        private void FormSkillManager_Load(object sender, EventArgs e)
        {
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleTurquoise;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Rows.Clear();
            UpdateBankList();

            _formModelAdd = new FormModelAdd();
            _formModelAdd.FormBack += SendBack;
        }

        private void UpdateUI()
        {
            labelTittle.Text = "套题管理--对套题信息进行维护，进行套题的增加、删除、修改";
        }
        private void UpdateBankList()
        {
            //List<ModelChapter> lst = null;
            Dictionary<int, ModelChapter> lst = ModelManager.m_DicBankList;
            foreach (var data in lst)
            {
                ModelChapter model = data.Value;
                AddItem(model.Id, model.Tittle, model.IsEnable, model.Classification, model.Count);
            }
        }

        private void AddItem(int id, string tittle, bool status, int type, int count)
        {
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewCheckBoxCell chkBoxCell = new DataGridViewCheckBoxCell();
            chkBoxCell.Value = false;
            row.Cells.Add(chkBoxCell);

            DataGridViewTextBoxCell txtBox1 = new DataGridViewTextBoxCell();
            txtBox1.Value = (dataGridView1.Rows.Count + 1).ToString();
            txtBox1.Tag = id.ToString();
            

            row.Cells.Add(txtBox1);
            txtBox1.ReadOnly = true;


            DataGridViewTextBoxCell txtBox2 = new DataGridViewTextBoxCell();
            txtBox2.Value = tittle;
            txtBox2.ToolTipText = tittle;
            row.Cells.Add(txtBox2);
            txtBox2.ReadOnly = true;           

            DataGridViewTextBoxCell txtBox3 = new DataGridViewTextBoxCell();
            txtBox3.Value = Question._ModelClassificationInfo[type];
            txtBox3.ToolTipText = "套题的所属类型";
            row.Cells.Add((DataGridViewTextBoxCell)txtBox3);
            txtBox3.ReadOnly = true;
            txtBox3.Tag = type;


            DataGridViewTextBoxCell txtBox5 = new DataGridViewTextBoxCell();
            txtBox5.Value = count.ToString();
            txtBox5.ToolTipText = "此套题下面的题目数";
            row.Cells.Add((DataGridViewTextBoxCell)txtBox5);
            txtBox5.ReadOnly = true;


            DataGridViewTextBoxCell txtBox4 = new DataGridViewTextBoxCell();
            txtBox4.Value = status ? "启用" : "停用";
            txtBox4.ToolTipText = "套题是否启用";
            txtBox4.Tag = status;
            row.Cells.Add((DataGridViewTextBoxCell)txtBox4);
            txtBox4.ReadOnly = true;


            DataGridViewButtonCell button = new DataGridViewButtonCell();
            button.Value = "编辑";
            button.ToolTipText = "编辑此套题";
            row.Cells.Add(button);

            button = new DataGridViewButtonCell();
            button.Value = "删除";
            button.ToolTipText = "删除此套题";
            row.Cells.Add(button);


            row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Rows.Add(row);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                ModelChapter model = new ModelChapter();
                model.Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Tag);
                model.Tittle = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                model.Classification = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Tag);
                model.IsEnable = (bool)dataGridView1.Rows[e.RowIndex].Cells[5].Tag;

                doShowModelInfo(model);
            }
            if(e.ColumnIndex == 7)
            {
                ModelChapter model = new ModelChapter();
                model.Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Tag);
                if(DialogResult.Yes == MessageBox.Show("您确认删除此条信息?", "确认窗口", MessageBoxButtons.YesNo))
                {
                    if(true == DeleteModel(model.Id))
                    {
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void labelAdd_MouseMove(object sender, MouseEventArgs e)
        {
            ((Label)sender).ForeColor = Color.Blue;
        }

        private void labelAdd_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Black;
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                ((DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0]).Value = checkBoxSelectAll.Checked;
            }
        }

        private void labelAdd_Click(object sender, EventArgs e)
        {
            ModelChapter model = new ModelChapter();

            model.Id = SystemConfig._maxBankId + 1;
            model.Classification = 1;

            doShowModelInfo(model);
        }

        private void doShowModelInfo(ModelChapter model)
        {
            _formModelAdd.TopLevel = false;
            _formModelAdd.Parent = panelModelInfo;
            panelModelInfo.BringToFront();
            panelModelList.SendToBack();
            _formModelAdd.SetModel(model, 2);
            _formModelAdd.Show();
        }

        public bool SendBack(ModelChapter model, bool Replace)
        {
            if (true == Replace)
            {
                //List<ModelChapter> list = null;
                Dictionary<int, ModelChapter> list = null;
                string path = "";

                list = ModelManager.m_DicBankList;
                path = ModelManager._PathBank;

                bool isReplace = false;
                if (true == ModelManager.AddModelToList(model, list, out isReplace))
                {

                    if (true == ModelManager.SetListToFile(list, path))
                    {
                        this.panelModelList.BringToFront();
                        this.panelModelInfo.SendToBack();
                        if(isReplace != true)
                        {
                            SystemConfig._maxBankId = model.Id;

                            SystemConfig.SaveModelId();
                        }
                        
                        AddItem(model.Id, model.Tittle, model.IsEnable, model.Classification, model.Count);
                        
                        return true;
                    }

                }

                return false;
            }
            else
            {
                this.panelModelList.BringToFront();
                this.panelModelInfo.SendToBack();
                return true;
            }
        }

        private void labelDel_Click(object sender, EventArgs e)
        {
            if (DialogResult.No== MessageBox.Show("您确认删除选中信息?", "确认窗口", MessageBoxButtons.YesNo))
            {
                return;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if(Convert.ToBoolean(((DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0]).EditedFormattedValue) == true)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Tag);
                    if (false == DeleteModel(id))
                    {
                        return;
                    }
                    else
                    {
                        dataGridView1.Rows.RemoveAt(i);
                        i--;
                    }
                }
                
            }
        }

        private bool DeleteModel(int Id)
        {
            try
            {
                Dictionary<int, ModelChapter> list = null;
                string path = "";
                
                list = ModelManager.m_DicBankList;
                path = ModelManager._PathBank;
                
                if (true == ModelManager.DelModelFromList(Id, list))
                {
                    if (false == ModelManager.SetListToFile(list, path))
                    {
                        MessageBox.Show("删除信息失败!id=" +Id , "提示信息", MessageBoxButtons.OK);
                        list = ModelManager.GetListFromFile(path);
                        return false;
                    }
                }

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("删除信息失败!id=" +Id +"  " + ex.Message, "提示信息", MessageBoxButtons.OK);
                return false;
            }
        }
       
    }
}
