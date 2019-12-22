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
    public partial class FormChapterManager : Form, InterfaceForm
    {
        private int _Type = 0;
        private FormModelAdd _formModelAdd = null;
        public FormChapterManager()
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

            cboxSkill.Items.Clear();

            bool result = chapterManager.GetChapterTypeList(out List<ChapterType> chapterTypeList);
            if (true == result)
            {
                foreach (ChapterType chapterType in chapterTypeList)
                {
                    cboxSkill.Items.Add(chapterType);
                }
            }

            cboxSkill.SelectedIndex = _Type;

            //RefreshGroups();
        }

        private void AddItem(ChapterInfo chapter, string classficationName)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.Tag = chapter;

            DataGridViewCheckBoxCell chkBoxCell = new DataGridViewCheckBoxCell();
            chkBoxCell.Value = false;
            row.Cells.Add(chkBoxCell);

            DataGridViewTextBoxCell txtBox1 = new DataGridViewTextBoxCell();
            //txtBox1.Value = (dataGridView1.Rows.Count + 1).ToString();
            txtBox1.Value = chapter.ID.ToString();
            txtBox1.Tag = chapter.ID.ToString();

            row.Cells.Add(txtBox1);
            txtBox1.ReadOnly = true;


            DataGridViewTextBoxCell txtBox2 = new DataGridViewTextBoxCell();
            txtBox2.Value = chapter.Name;
            txtBox2.ToolTipText = chapter.Name;
            row.Cells.Add(txtBox2);
            txtBox2.ReadOnly = true;

            DataGridViewTextBoxCell txtBox3 = new DataGridViewTextBoxCell();
            txtBox3.Value = Question._ModelClassificationInfo[chapter.Classification];
            txtBox3.ToolTipText = "分组所属类型";
            row.Cells.Add((DataGridViewTextBoxCell)txtBox3);
            txtBox3.ReadOnly = true;
            txtBox3.Tag = classficationName;


            DataGridViewTextBoxCell txtBox5 = new DataGridViewTextBoxCell();
            txtBox5.Value = chapter.Count.ToString();
            txtBox5.ToolTipText = "此分组下面的题目数";
            row.Cells.Add((DataGridViewTextBoxCell)txtBox5);
            txtBox5.ReadOnly = true;
            txtBox5.Tag = chapter.Count;

            DataGridViewTextBoxCell txtBox4 = new DataGridViewTextBoxCell();
            txtBox4.Value = chapter.IsEnable ? "启用" : "停用";
            txtBox4.ToolTipText = "是否启用";
            txtBox4.Tag = chapter.IsEnable;
            row.Cells.Add((DataGridViewTextBoxCell)txtBox4);
            txtBox4.ReadOnly = true;


            DataGridViewButtonCell button = new DataGridViewButtonCell();
            button.Value = "编辑";
            button.ToolTipText = "编辑此分组";
            row.Cells.Add(button);

            button = new DataGridViewButtonCell();
            button.Value = "删除";
            button.ToolTipText = "删除此分组";
            row.Cells.Add(button);


            row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Rows.Add(row);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                ChapterInfo chapter = (ChapterInfo)dataGridView1.Rows[e.RowIndex].Tag;
                FormChapterModify formChapterModify = new FormChapterModify();
                formChapterModify.SetChapter(chapter);
                if(DialogResult.OK == formChapterModify.ShowDialog())
                {
                    RefreshGroups();
                }
            }
            if (e.ColumnIndex == 7)
            {
                ChapterInfo chapter = (ChapterInfo)dataGridView1.Rows[e.RowIndex].Tag;
                
                if (DialogResult.Yes == MessageBox.Show("您确认删除此条信息?", "确认窗口", MessageBoxButtons.YesNo))
                {
                    if(true == chapterManager.DeleteChapter(chapter))
                    {
                        RefreshGroups();
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
            ChapterInfo model = new ChapterInfo();
            FormChapterAdd formChapterAdd = new FormChapterAdd();
            formChapterAdd.SetType(_Type);
            if (DialogResult.OK == formChapterAdd.ShowDialog())
            {
                RefreshGroups();
            }
        }

        private void doShowModelInfo(ChapterInfo model)
        {
            _formModelAdd.TopLevel = false;
            _formModelAdd.Parent = panelModelInfo;
            panelModelInfo.BringToFront();
            panelModelList.SendToBack();
            _formModelAdd.SetModel(model, _Type);
            _formModelAdd.Show();
        }


        ChapterManager chapterManager = new ChapterManager();
        void RefreshGroups()
        {
            dataGridView1.Rows.Clear();
            chapterManager.GetChapterList(_Type, out DataTable data);
            if (null == data)
                return;

            foreach (DataRow row in data.Rows)
            {
                ChapterInfo modelChapter = new ChapterInfo();
                modelChapter.ID = Convert.ToInt32(row["id"].ToString());
                modelChapter.Classification = Convert.ToInt32(row["classification_id"].ToString());
                modelChapter.IsEnable = row["status"].ToString() == "1";
                modelChapter.Name = row["name"].ToString();
                modelChapter.Count = Convert.ToInt32(row["count"].ToString());
                modelChapter.ChapterType = Convert.ToInt32(row["type"].ToString());
                modelChapter.ChapterSqlString = row["sql"].ToString();
                modelChapter.SqlParamter = row["sql_parameter"].ToString();
                string classficationName = row["classification_name"].ToString();

                AddItem(modelChapter, classficationName);
            }

        }

        private void labelDel_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("您确认删除选中信息?", "确认窗口", MessageBoxButtons.YesNo))
            {
                return;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(((DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0]).EditedFormattedValue) == true)
                {
                    int id = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Tag);
                    //TODO;删除章节
                    //if (false == DeleteModel(id))
                    if (false == DeleteModeFromDb(id))
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
                Dictionary<int, ChapterInfo> lst = null;
                string path = "";
                switch (_Type)
                {
                    case 0:
                        lst = ModelManager.m_DicMoudleList;
                        break;
                    case 1:
                        lst = ModelManager.m_DicSkillList;
                        break;
                    case 2:
                        lst = ModelManager.m_DicBankList;
                        break;
                    case 3:
                        lst = ModelManager.m_DicIntensifyList;
                        break;
                    default:
                        break;
                }
                //if (_Type == 0)
                //{
                //    list = ModelManager.m_DicSkillList;
                //    path = ModelManager._PathSkill;
                //}
                //else
                //{
                //    list = ModelManager.m_DicMoudleList;
                //    path = ModelManager._PathModule;
                //}
                if (true == ModelManager.DelModelFromList(Id, lst))
                {
                    //TODO:删除数据库的内容
                    if (false == ModelManager.SetListToFile(lst, path))
                    {
                        MessageBox.Show("删除信息失败!id=" + Id, "提示信息", MessageBoxButtons.OK);
                        lst = ModelManager.GetListFromFile(path);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除信息失败!id=" + Id + "  " + ex.Message, "提示信息", MessageBoxButtons.OK);
                return false;
            }
        }

        private bool DeleteModeFromDb(int Id)
        {
            try
            {
                string sqlString = @"delete from groups where id=@Id and type=@Type";

                //SQLiteParameter[] parameters = new SQLiteParameter[23];
                List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                parameters.Add(new SQLiteParameter("@Id", Id));
                parameters.Add(new SQLiteParameter("@type", _Type));

                int result = SQLiteHelper.SQLiteHelper.ExecuteNonQuery(sqlString, parameters.ToArray());
                if (result <= 0)
                {
                    Console.WriteLine("Error Delete GroupID:" + Id + "Type:" + _Type);
                    return false;
                    //MessageBox.Show(ques)
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void ReloadForm()
        {
            return;
        }

        private void cboxSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxSkill.SelectedItem == null)
                return;

            ChapterType chapterType = (ChapterType)cboxSkill.SelectedItem;

            _Type = chapterType.ID;

            RefreshGroups();
        }
    }
}
