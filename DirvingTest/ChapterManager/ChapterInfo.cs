using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DirvingTest
{
    public class ChapterInfo : IComparable
    {
        /// <summary>
        /// id
        /// </summary>
        public int ID = -1;
        /// <summary>
        /// 章节名称
        /// </summary>
        public string Name = "";
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable = true;
        /// <summary>
        /// 分类
        /// </summary>
        public int Classification = 0;

        /// <summary>
        /// 题目数量
        /// </summary>
        public int Count = 0;

        /// <summary>
        /// 分组类别
        /// </summary>
        public int ChapterType = 0;

        public string ChapterSqlString = "";

        public string SqlParamter = "";

        public override string ToString()
        {
            return Name.ToString();
        }

        public int CompareTo(object obj)
        {
            return Name.CompareTo(((ChapterInfo)obj).Name);
        }
    }
}
