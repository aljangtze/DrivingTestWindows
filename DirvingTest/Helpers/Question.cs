using System;
using System.Collections.Generic;
////using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace DirvingTest
{
    public class Question : IComparable
    {
        public static string[] _ModelClassificationInfo = new string[] { "全部", "A类", "B类", "C类", "A/B/C科目四", "D-科目一", "D-科目四"};
        public static string[] _TypeInfo = new string[] { "全部", "判断题", "选择题", "多选题"};
        
        /// <summary>
        /// 数据文件或数据库中对应id
        /// </summary>
        public int Id;

        /// <summary>
        /// 所属分类模块1~13,是系统默认的章节的模块
        /// </summary>
        public int Module;

        /// <summary>
        /// 所属技巧模块
        /// </summary>
        public int Skill;

        /// <summary>
        /// 所属套题信息
        /// </summary>
        public int BankId=0;

        /// <summary>
        /// 强化练习的章节
        /// </summary>
        public int IntensifyId = 0;

        /// <summary>
        /// 标题
        /// </summary>
        public string Tittle;

        /// <summary>
        /// 技巧强调内容
        /// </summary>
        public string TittleEmphasize;

        /// <summary>
        /// 正确的答案id
        /// </summary>
        public List<int> CorrectAnswer;

        /// <summary>
        /// 选项信息
        /// </summary>
        public List<string> Options;

        /// <summary>
        /// 选项对应的图片
        /// </summary>
        public List<string> OptionsEmphasize;

        /// <summary>
        /// 选择题0、判断题1、多选题2
        /// </summary>
        public int Type;

        /// <summary>
        /// 题目类别
        /// </summary>
        public int Classification;

        /// <summary>
        /// 技巧解析
        /// </summary>
        public string SkillNotice;

        /// <summary>
        /// 普通解析
        /// </summary>
        public string NormalNotice = "";

        /// <summary>
        /// 对应图片信息路径
        /// </summary>
        public string ImagePath;

        /// <summary>
        /// 对应flash路径
        /// </summary>
        public string FlashPath;

        public int CompareTo(object obj)
        {
            Question question = (Question)obj;
            if (this.Id == question.Id)
                return 0;

            if(this.Type > question.Type)
            {
                return 1;
            }

            else if(this.Type < question.Type)
            {
                return -1;
            }
            else
            {
                if (this.Id > question.Id)
                    return 1;
                else
                    return -1;
            }


        }
    }
}
