using System;
using System.Collections.Generic;
////using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace DirvingTest
{
    public class Question : IComparable, ICloneable
    {
        public static string[] _ModelClassificationInfo = new string[] { "全部", "A类客车", "B类货车", "C类小车", "A/B/C科目四", "D-科目一", "D-科目四"};
        public static string[] _TypeInfo = new string[] { "全部", "判断题", "选择题", "多选题"};
        
        /// <summary>
        /// 数据文件或数据库中对应id
        /// </summary>
        public int Id;

        /// <summary>
        /// 所属分类模块1~13,是系统默认的章节的模块
        /// </summary>
        public int Module;

        public string Url = "";

        [Obsolete]
        /// <summary>
        /// 所属技巧模块
        /// </summary>
        public int Skill;

        [Obsolete]
        /// <summary>
        /// 所属套题信息
        /// </summary>
        public int BankId=0;

        [Obsolete]
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

        public object Clone()
        {
            Question questionDst = new Question();
            Question questionSrc = this;
            questionDst.Id = questionSrc.Id;
            questionDst.Tittle = questionSrc.Tittle;
            questionDst.TittleEmphasize = questionSrc.TittleEmphasize;
            questionDst.NormalNotice = questionSrc.NormalNotice;
            questionDst.SkillNotice = questionSrc.SkillNotice;
            questionDst.Module = questionSrc.Module;
            questionDst.Skill = questionSrc.Skill;
            questionDst.Type = questionSrc.Type;
            questionDst.ImagePath = questionSrc.ImagePath;
            questionDst.FlashPath = questionSrc.FlashPath;
            if (questionSrc.Options == null)
                questionDst.Options = null;
            else
            {
                questionDst.Options = new List<string>();
                questionDst.Options.Add(questionSrc.Options[0]);
                questionDst.Options.Add(questionSrc.Options[1]);
                questionDst.Options.Add(questionSrc.Options[2]);
                questionDst.Options.Add(questionSrc.Options[3]);
            }

            return questionDst;
        }

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

        public void Copy(ref Question questionDst)
        {
            Question questionSrc = this;
            questionDst.Id = questionSrc.Id;
            questionDst.Tittle = questionSrc.Tittle;
            questionDst.TittleEmphasize = questionSrc.TittleEmphasize;
            questionDst.NormalNotice = questionSrc.NormalNotice;
            questionDst.SkillNotice = questionSrc.SkillNotice;
            questionDst.Module = questionSrc.Module;
            questionDst.Skill = questionSrc.Skill;
            questionDst.Type = questionSrc.Type;
            questionDst.ImagePath = questionSrc.ImagePath;
            questionDst.FlashPath = questionSrc.FlashPath;
            if (questionSrc.Options == null)
                questionDst.Options = null;
            else
            {
                questionDst.Options = new List<string>();
                questionDst.Options.Add(questionSrc.Options[0]);
                questionDst.Options.Add(questionSrc.Options[1]);
                questionDst.Options.Add(questionSrc.Options[2]);
                questionDst.Options.Add(questionSrc.Options[3]);
            }
        }
    }
}
