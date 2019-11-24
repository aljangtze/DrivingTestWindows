using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
////using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DirvingTest
{
    public partial class FormSkillManager : Form, InterfaceForm
    {
        private int _Type = 0;
        private FormModelAdd _formModelAdd = null;
        public FormSkillManager()
        {
            InitializeComponent();
        }

        public void SetType(int type)
        {
            _Type = type;
        }

        private void FormSkillManager_Load(object sender, EventArgs e)
        {
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleTurquoise;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Rows.Clear();
            UpdateSkillList();

            _formModelAdd = new FormModelAdd();
            _formModelAdd.FormBack += SendBack;
        }

        private void UpdateUI()
        {
            if (_Type != 0)
            {
                labelTittle.Text = "技巧管理--对技巧信息进行维护，进行技巧的增加、删除、修改";
            }
            else
            {
                labelInfo.Text = "对技巧信息进行维护，进行技巧的增加、删除、修改。";
            }
        }
        private void UpdateSkillList()
        {
            //List<ModelChapter> lst = null;
            Dictionary<int, ModelChapter> lst = null;
            if (_Type != 0)
            {
                lst = ModelManager.m_DicMoudleList;
            }
            else
            {
                lst = ModelManager.m_DicSkillList;
            }
            foreach (var data in lst)
            {
                ModelChapter model = data.Value;
                AddItem(model.Id, model.Tittle, model.IsEnable, model.Classification, model.Count);
#if _SaveToSqliteGroups
                if (_Type != 0)
                    AddChaperOrSkill(model, 0);
                else
                    AddChaperOrSkill(model, 1);
#endif
            }
        }

        private void AddChaperOrSkill(ModelChapter model,int type)
        {
            try
            {
                string sqlString = @"insert into groups (id, name, type, status, count, classification)
                                values
                                (@id, @name, @type, 1, @count, @classification)";

                //SQLiteParameter[] parameters = new SQLiteParameter[23];
                List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                parameters.Add(new SQLiteParameter("@id", model.Id));
                parameters.Add(new SQLiteParameter("@name", model.Tittle));
                parameters.Add(new SQLiteParameter("@type", type));
                parameters.Add(new SQLiteParameter("@count", model.Count));
                parameters.Add(new SQLiteParameter("@classification",model.Classification));
                
                int result = SQLiteHelper.SQLiteHelper.ExecuteNonQuery(sqlString, parameters.ToArray());
                if (result <= 0)
                {
                    Console.WriteLine("Error" + model.Id);
                    //MessageBox.Show(ques)
                }
            }
            catch (Exception ex)
            {

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
            txtBox3.ToolTipText = "技巧的所属类型";
            row.Cells.Add((DataGridViewTextBoxCell)txtBox3);
            txtBox3.ReadOnly = true;
            txtBox3.Tag = type;


            DataGridViewTextBoxCell txtBox5 = new DataGridViewTextBoxCell();
            txtBox5.Value = count.ToString();
            txtBox5.ToolTipText = "此技巧下面的题目数";
            row.Cells.Add((DataGridViewTextBoxCell)txtBox5);
            txtBox5.ReadOnly = true;


            DataGridViewTextBoxCell txtBox4 = new DataGridViewTextBoxCell();
            txtBox4.Value = status ? "启用" : "停用";
            txtBox4.ToolTipText = "技巧是否启用";
            txtBox4.Tag = status;
            row.Cells.Add((DataGridViewTextBoxCell)txtBox4);
            txtBox4.ReadOnly = true;


            DataGridViewButtonCell button = new DataGridViewButtonCell();
            button.Value = "编辑";
            button.ToolTipText = "编辑此技巧";
            row.Cells.Add(button);

            button = new DataGridViewButtonCell();
            button.Value = "删除";
            button.ToolTipText = "删除此技巧";
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
            if (_Type == 0)
                model.Id = SystemConfig._maxSkillId + 1;
            else
                model.Id = SystemConfig._maxModuleId + 1;

            model.Classification = 1;

            doShowModelInfo(model);
        }

        private void doShowModelInfo(ModelChapter model)
        {
            _formModelAdd.TopLevel = false;
            _formModelAdd.Parent = panelModelInfo;
            panelModelInfo.BringToFront();
            panelModelList.SendToBack();
            _formModelAdd.SetModel(model, _Type);
            _formModelAdd.Show();
        }

        public bool SendBack(ModelChapter model, bool Replace)
        {
            if (true == Replace)
            {
                //List<ModelChapter> list = null;
                Dictionary<int, ModelChapter> list = null;
                string path = "";
                if (_Type == 0)
                {
                    list = ModelManager.m_DicSkillList;
                    path = ModelManager._PathSkill;
                }
                else
                {
                    list = ModelManager.m_DicMoudleList;
                    path = ModelManager._PathModule;
                }

                bool isReplace = false;
                if (true == ModelManager.AddModelToList(model, list, out isReplace))
                {

                    if (true == ModelManager.SetListToFile(list, path))
                    {
                        this.panelModelList.BringToFront();
                        this.panelModelInfo.SendToBack();
                        if(isReplace != true)
                        {
                            if (_Type == 0)
                            {
                                SystemConfig._maxSkillId = model.Id;
                            }
                            else
                            {
                                SystemConfig._maxModuleId = model.Id;
                            }

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
                if (_Type == 0)
                {
                    list = ModelManager.m_DicSkillList;
                    path = ModelManager._PathSkill;
                }
                else
                {
                    list = ModelManager.m_DicMoudleList;
                    path = ModelManager._PathModule;
                }
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


        public void ReloadForm()
        {
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuestionManager.m_Relation_Question_Intensity.WriteFile("List_Intensity.xml");
            QuestionManager.m_Relation_Question_Skill.WriteFile("List_Skill.xml");
            QuestionManager.m_Relation_Question_Suite.WriteFile("List_Suite.xml");
        }
    }
}
