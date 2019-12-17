using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DirvingTest
{
    public class UserInfo
    {
        public int ID;
        public string UserName;
        public string Password;
        public bool Status;
        /// <summary>
        /// 类型 0为普通 1为管理员
        /// </summary>
        public int Type;

    }
}
