using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace DirvingTest
{
    public class UserManager
    {
        public bool GetUserList(out List<UserInfo> userList)
        {
            userList = new List<UserInfo>();
            try
            {
                string sql = @"select * from users where 1=@data";
                DataTable data = SQLiteHelper.SQLiteHelper.GetDataTable(sql, new SQLiteParameter[] { new SQLiteParameter("@data", 1) });
                foreach (DataRow row in data.Rows)
                {
                    UserInfo user = new UserInfo();
                    user.ID = Convert.ToInt32(row["id"].ToString());
                    user.UserName = row["name"].ToString();
                    user.Password = row["password"].ToString();
                    user.Status = Convert.ToInt32(row["status"].ToString()) == 1;
                    user.Type = Convert.ToInt32(row["type"].ToString());
                    userList.Add(user);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool IsLogin { get; set; }


        public static UserInfo LoginUser = new UserInfo();

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        public static bool Login(string name, string password)
        {
            try
            {

                string sql = @"select * from users where name=@name and password=@password";
                DataTable data = SQLiteHelper.SQLiteHelper.GetDataTable(sql, new SQLiteParameter[] { new SQLiteParameter("@name", name), new SQLiteParameter("@password", password) });

                if (data.Rows.Count <= 0)
                {
                    LoginUser.ID = 0;
                    IsLogin = false;
                    return false;
                }
                else
                {
                    var row = data.Rows[0];
                    UserInfo user = new UserInfo();
                    user.ID = Convert.ToInt32(row["id"].ToString());
                    user.Password = row["password"].ToString();
                    user.Status = Convert.ToInt32(row["status"].ToString()) == 1;
                    user.Type = Convert.ToInt32(row["type"].ToString());
                    user.UserName = row["name"].ToString();
                    LoginUser = user;
                    IsLogin = true;
                    return true;
                }
            }
            catch (Exception ex)
            {
                IsLogin = false;
                return false;
            }
        }

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool IsUserExists(string name)
        {
            string sql = @"select * from users where name=@name";
            DataTable data = SQLiteHelper.SQLiteHelper.GetDataTable(sql, new SQLiteParameter[] { new SQLiteParameter("@name", name) });
            return data.Rows.Count > 0;
        }

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool IsUserExists(int id)
        {
            string sql = @"select * from users where id=@id";
            DataTable data = SQLiteHelper.SQLiteHelper.GetDataTable(sql, new SQLiteParameter[] { new SQLiteParameter("@id", id) });
            return data.Rows.Count > 0;
        }

        /// <summary>
        /// 添加用戶
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(UserInfo user)
        {
            if (IsUserExists(user.UserName))
                return false;

            try
            {
                string sql = @"insert into users (name, password, status, type) values(@name, @password, @status, @type)";
                List<SQLiteParameter> listPara = new List<SQLiteParameter>();
                listPara.Add(new SQLiteParameter("@name", user.UserName));
                listPara.Add(new SQLiteParameter("@password", user.Password));
                listPara.Add(new SQLiteParameter("@status", user.Status ? 1:0)) ;
                listPara.Add(new SQLiteParameter("@type", user.Type));

                int result = SQLiteHelper.SQLiteHelper.ExecuteNonQuery(sql, listPara.ToArray());
                return result >= 1;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 刪除用戶
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public bool DelUser(UserInfo user)
        {
            try
            {
                if(!IsUserExists(user.ID))
                {
                    return true;
                }

                string sql = @"delete from users where id=@id";
                List<SQLiteParameter> listPara = new List<SQLiteParameter>();
                listPara.Add(new SQLiteParameter("@id", user.ID));

                int result = SQLiteHelper.SQLiteHelper.ExecuteNonQuery(sql, listPara.ToArray());
                return result >= 1;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///判斷名字是否衝突
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        bool IsConflictName(string name, int id)
        {
            string sql = @"select * from questions where name=@name and id!=@id";
            List<SQLiteParameter> listPara = new List<SQLiteParameter>();
            listPara.Add(new SQLiteParameter("@name", name));
            listPara.Add(new SQLiteParameter("@id", id));

            DataTable data = SQLiteHelper.SQLiteHelper.GetDataTable(sql, listPara.ToArray());
            return data.Rows.Count >= 0;
        }

        /// <summary>
        /// 更新用戶
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UpdateUser(UserInfo user)
        {
            try
            {
                if (IsConflictName(user.UserName, user.ID))
                {
                    return false;
                }

                string sql = @"update users set name=@name, password=@password, status=@status, type=@type where id=@id";
                List<SQLiteParameter> listPara = new List<SQLiteParameter>();
                listPara.Add(new SQLiteParameter("@name", user.UserName));
                listPara.Add(new SQLiteParameter("@password", user.Password));
                listPara.Add(new SQLiteParameter("@status", user.Status ? 1 : 0));
                listPara.Add(new SQLiteParameter("@type", user.Type));
                listPara.Add(new SQLiteParameter("@id", user.ID));

                int result = SQLiteHelper.SQLiteHelper.ExecuteNonQuery(sql, listPara.ToArray());
                return result >= 1;
            }
            catch
            {
                return false;
            }
        }
    }
}
