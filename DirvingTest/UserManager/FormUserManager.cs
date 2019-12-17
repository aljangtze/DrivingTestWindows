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
    public partial class FormUserManager : Form
    {
        private int _Type = 0;
        private FormModelAdd _formModelAdd = null;
        public FormUserManager()
        {
            InitializeComponent();
        }


        private void FormSkillManager_Load(object sender, EventArgs e)
        {
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleTurquoise;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            UpdateUsers();

            
        }
        UserManager userManager = new UserManager();

        bool UpdateUsers()
        {
            dataGridView1.Rows.Clear();

            if (true == userManager.GetUserList(out List<UserInfo> userList))
            {
                foreach (UserInfo user in userList)
                {
                    AddItem(user, user.ID, user.UserName, user.Password, user.Status, user.Type);
                }
                return true;
            }
            else
            {
                MessageBox.Show("获取用户列表失败", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void AddItem(UserInfo user, int id, string name, string password, bool status, int type)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.Tag = user;

            DataGridViewCheckBoxCell chkBoxCell = new DataGridViewCheckBoxCell();
            chkBoxCell.Value = false;
            row.Cells.Add(chkBoxCell);

            DataGridViewTextBoxCell txtBox1 = new DataGridViewTextBoxCell();
            txtBox1.Value = (dataGridView1.Rows.Count + 1).ToString();
            txtBox1.Tag = id.ToString();

            row.Cells.Add(txtBox1);
            txtBox1.ReadOnly = true;


            DataGridViewTextBoxCell txtBox2 = new DataGridViewTextBoxCell();
            txtBox2.Value = name;
            txtBox2.ToolTipText = name;
            row.Cells.Add(txtBox2);
            txtBox2.ReadOnly = true;


            DataGridViewTextBoxCell txtBox5 = new DataGridViewTextBoxCell();
            txtBox5.Value = password;
            txtBox5.ToolTipText = password;
            row.Cells.Add(txtBox5);
            txtBox5.ReadOnly = true;

            DataGridViewTextBoxCell txtBox3 = new DataGridViewTextBoxCell();
            txtBox3.Value = type==1 ? "管理员" : "学员";
            txtBox3.ToolTipText = "用户类型";
            row.Cells.Add((DataGridViewTextBoxCell)txtBox3);
            txtBox3.ReadOnly = true;
            txtBox3.Tag = type;


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
            //编辑
            if (e.ColumnIndex == 6)
            {
                UserInfo user = new UserInfo();
                user.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Tag);
                user.UserName = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                user.Password = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                user.Type = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Tag);
                user.Status = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[5].Tag.ToString() == "1");

                FormUserModify formUserModify = new FormUserModify();
                formUserModify.SetUser(user);
                formUserModify.ShowDialog();

                UpdateUsers();
                
            }
            //删除
            if (e.ColumnIndex == 7)
            {
                UserInfo user= new UserInfo();
                user.ID= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Tag);
                if (DialogResult.Yes == MessageBox.Show("您确认删除此条信息?", "确认窗口", MessageBoxButtons.YesNo))
                {
                    if (true == userManager.DelUser(user))
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
            FormUserAdd formUserAdd = new FormUserAdd();
            if(DialogResult.OK == formUserAdd.ShowDialog())
            {
                UpdateUsers();
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
                    if(false == userManager.DelUser(new UserInfo { ID = id }))
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
    }
}
