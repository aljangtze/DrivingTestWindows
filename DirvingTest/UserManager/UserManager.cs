using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace DirvingTest.UserManager
{
    public class UserManager
    {
        bool GetUserList(out List<UserInfo> userList)
        {userList = null;
            try
            { 

                
                string sqlString = @"delete from groups where id=@Id and type=@Type";

                //SQLiteParameter[] parameters = new SQLiteParameter[23];
                List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                //parameters.Add(new SQLiteParameter("@Id", Id));
                //parameters.Add(new SQLiteParameter("@type", _Type));

                int result = SQLiteHelper.SQLiteHelper.ExecuteNonQuery(sqlString, parameters.ToArray());
                if (result <= 0)
                {
                    //Console.WriteLine("Error Delete GroupID:" + Id + "Type:" + _Type);
                    return false;
                    //MessageBox.Show(ques)
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
