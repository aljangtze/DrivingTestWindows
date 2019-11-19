using EasyConfig;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
////using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirvingTest
{
    public class AnswerQuestion
    {
        public int seq;
        public Question question;
        public string CorrectString;
        public string AnswerString;
        public int RightStatus; //0 1 2 0未答 1正确 2错误
    }
    class QuestionManager
    {
        public static List<Question> m_QuestionsList = new List<Question>();
        public static List<Question> m_SelectedOneList = new List<Question>();
        public static List<Question> m_ChargeOneList = new List<Question>();
        public static List<Question> m_SelectedMultList = new List<Question>();



        public static ConcurrentDictionary<int, Question> m_QuestionsDictionary = new ConcurrentDictionary<int, Question>();
        /// <summary>
        /// 题目目与分组之间的关系列表，字典存储
        /// </summary>
        /// 
        public static SerializableDictionary<int, int> m_Relation_Question_Skill = new SerializableDictionary<int,int>();
        public static SerializableDictionary<int, int> m_Relation_Question_Suite = new SerializableDictionary<int, int>();
        public static SerializableDictionary<int, int> m_Relation_Question_Intensity = new SerializableDictionary<int, int>();

        public static string g_QuestionDir =　"Images";
        //static int QUESTION_NUM = 0;
        static readonly Random rnd = new Random(Guid.NewGuid().GetHashCode());

        static Array ArrayQuestionByMoudleSubject1;
        static Array ArrayQuestionByMoudleSubject2;
        static Array ArrayQuestionBySkill;

        public static int _maxQuestionNum = 0;
        internal const string SPLIT_STR = "======================";
        static Regex regImgFile = new Regex(@"\[\[(.*?)\]\]", RegexOptions.Compiled);
        static void AnalysizeQuestion(string Text, out string Title, out List<int> CorrectAnswer, out List<string> Options, out int Type)
        {
            Title = "";
            CorrectAnswer = new List<int>();
            Options = new List<string>();
            Type = 0;
        }

        #region 不知道是否有用的函数
        private static void initParams()
        {
            ArrayQuestionByMoudleSubject1 = new List<Question>[SystemConfig.Subject1MoudleCount];
            for (int i = 0; i < SystemConfig.Subject1MoudleCount; i++)
            {
                ArrayQuestionByMoudleSubject1.SetValue(new List<Question>(), i);    
            }
            ArrayQuestionByMoudleSubject2 = new List<Question>[SystemConfig.Subject2MoudleCount];
            for (int i = 0; i < SystemConfig.Subject2MoudleCount; i++)
            {
                ArrayQuestionByMoudleSubject2.SetValue(new List<Question>(), i);
            }

            ArrayQuestionBySkill = new List<Question>[SystemConfig.SkillMoudleCount];
            for (int i = 0; i < SystemConfig.SkillMoudleCount; i++)
            {
                ArrayQuestionBySkill.SetValue(new List<Question>(), i);
            }
        }

        //public static Question LoadQuestion(int id)
        //{
        //    var file = Path.Combine(g_QuestionDir, id.ToString() + ".txt");
        //    if (!File.Exists(file))
        //    {
        //        //MessageBox.Show("题目" + id + "不存在：" + file);
        //        return null;
        //    }

        //    string txt;
        //    using (var sr = new StreamReader(file, Encoding.ASCII))
        //    {
        //        txt = sr.ReadToEnd().Replace("\r\n", "");
        //    }

        //    // 拆分文本文件
        //    var arr = Regex.Split(txt, SPLIT_STR);

        //    //获取图片与视频信息
        //    var pic = string.Empty;
        //    var m = regImgFile.Match(arr[0]);
        //    if (m.Success)
        //    {
        //        pic = Path.Combine(g_QuestionDir, m.Result("$1"));
        //        arr[0] = arr[0].Replace(m.Value, "[参考图片]");
        //    }
        //    else if (!string.IsNullOrEmpty(arr[1]))
        //    {
        //        pic = Path.Combine(g_QuestionDir, arr[1].Trim(','));
        //        pic = arr[1].Trim(',');
        //    }

        //    Question ret = new Question();
        //    ret.Id = id;

        //    ret.Tittle = arr[0];
        //    if (pic.IndexOf(".swf") != -1)
        //    {
        //        ret.ImagePath = "";
        //        ret.FlashPath = (string)pic;
        //    }
        //    else
        //    {
        //        ret.ImagePath = (string)pic;
        //        ret.FlashPath = "";
        //    }

        //    ret.CorrectAnswer = new List<int>();
        //    ret.CorrectAnswer.Add(Convert.ToInt32(arr[2]));

        //    ret.NormalExplain = arr[3];
        //    if (arr.Length >= 8)
        //    {
        //        ret.Options = new List<string>();
        //        ret.Options.Add(arr[4]);
        //        ret.Options.Add(arr[5]);
        //        ret.Options.Add(arr[6]);
        //        ret.Options.Add(arr[7]);
        //        ret.Type = 0;
        //    }
        //    else
        //    {
        //        ret.Type = 1;
        //    }


        //    string newFile = Directory.GetCurrentDirectory() + "//New//" + id + ".txt";
        //    using (var sw = new StreamWriter(newFile, false, Encoding.UTF8))
        //    {
        //        sw.WriteLine(ret.Tittle);            // 问题
        //        sw.WriteLine(SPLIT_STR);
        //        if (!string.IsNullOrEmpty(ret.ImagePath))
        //            sw.WriteLine(ret.ImagePath);          // 问题图片列表，以逗号分隔
        //        if (!string.IsNullOrEmpty(ret.FlashPath))
        //            sw.WriteLine(ret.FlashPath);
        //        if (string.IsNullOrEmpty(ret.ImagePath) && string.IsNullOrEmpty(ret.FlashPath))
        //            sw.WriteLine("");
        //        sw.WriteLine(SPLIT_STR);
        //        sw.WriteLine(ret.CorrectAnswer[0]);      // 答案序号
        //        sw.WriteLine(SPLIT_STR);
        //        sw.WriteLine(ret.NormalExplain);//技巧
        //        sw.WriteLine(SPLIT_STR);
        //        sw.WriteLine(ret.TittleEmphasize);  //强调
        //        sw.WriteLine(SPLIT_STR);
        //        sw.WriteLine(ret.NormalExplain);  // 答案简要说明

        //        if (ret.Options != null)
        //        {
        //            foreach (var opn in ret.Options)
        //            {
        //                sw.WriteLine(SPLIT_STR);
        //                sw.WriteLine(opn);  // 答案选项
        //            }
        //        }
        //    }

        //    ret.SkillExplain = "技巧讲解";
        //    ret.SkillModule = 0;
        //    ret.Module = 1;
        //    ret.TittleEmphasize = "强调";

        //    return ret;
        //}

        //public static Question LoadQuestion(int id)
        //{
        //    int a = 0;
        //    if(id == 776)
        //    {
        //        a = a + id;
        //    }
        //    var file = Path.Combine(g_QuestionDir, id.ToString() + ".txt");
        //    if (!File.Exists(file))
        //    {
        //        return null;
        //    }

        //    string txt;
        //    using (var sr = new StreamReader(file, Encoding.ASCII))
        //    {
        //        txt = sr.ReadToEnd().Replace("\r\n", "");
        //    }

        //    // 拆分文本文件
        //    var arr = Regex.Split(txt, SPLIT_STR);

        //    //获取图片与视频信息
        //    var pic = "";
        //    var m = regImgFile.Match(arr[0]);
        //    if (m.Success)
        //    {
        //        pic = Path.Combine(g_QuestionDir, m.Result("$1"));
        //        arr[0] = arr[0].Replace(m.Value, "[参考图片]");
        //    }
        //    else if (!string.IsNullOrEmpty(arr[1]))
        //    {
        //        pic = Path.Combine(g_QuestionDir, arr[1].Trim(','));
        //    }

        //    Question ret = new Question();
        //    ret.Id = id;

        //    ret.Tittle = arr[0];
        //    if (pic.IndexOf(".swf") != -1)
        //    {
        //        ret.ImagePath = "";
        //        ret.FlashPath = (string)pic;
        //    }
        //    else
        //    {
        //        ret.ImagePath = (string)pic;
        //        ret.FlashPath = "";
        //    }

        //    ret.CorrectAnswer = new List<int>();
        //    ret.CorrectAnswer.Add(Convert.ToInt32(arr[2]));

        //    ret.SkillNotice = arr[3];
        //    ret.TittleEmphasize = arr[4];
        //    ret.NormalNotice = arr[5];
        //    if (arr.Length >= 10)
        //    {
        //        ret.Options = new List<string>();
        //        ret.Options.Add(arr[6]);
        //        ret.Options.Add(arr[7]);
        //        ret.Options.Add(arr[8]);
        //        ret.Options.Add(arr[9]);
        //        ret.Type = 0;
        //    }
        //    else
        //    {
        //        ret.Type = 1;
        //    }

        //    ret.SkillNotice = ret.NormalNotice;
        //    ret.Skill = 0;
        //    ret.Module = 1;
        //    ret.TittleEmphasize = "";

        //    return ret;
        //}

        /// <summary>
        /// 从文件中读取题目信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Question LoadQuestionByIniBak(int id)
        {
            DateTime dateStart = DateTime.Now;
            var filePath = Path.Combine("Questions", id.ToString() + ".txt");
            if (!File.Exists(filePath))
            {
                return null;
            }

            Question question = new Question();
            question.Id = Convert.ToInt32(SystemConfig.IniReadValue("QuesitonInfo", "Id", filePath));
            question.Tittle = SystemConfig.IniReadValue("QuesitonInfo", "Tittle", filePath);
            question.TittleEmphasize = SystemConfig.IniReadValue("QuesitonInfo", "SkillEmphasize", filePath);
            question.ImagePath = SystemConfig.IniReadValue("QuesitonInfo", "ImagePath", filePath);
            question.FlashPath = SystemConfig.IniReadValue("QuesitonInfo", "FlashPath", filePath);
            question.Module = Convert.ToInt32(SystemConfig.IniReadValue("QuesitonInfo", "MoudleId", filePath));

            try
            {
                question.Skill = Convert.ToInt32(SystemConfig.IniReadValue("QuesitonInfo", "SkillId", filePath));
                if (0 != question.Skill)
                {
                    m_Relation_Question_Skill[question.Id] = question.Skill;
                }
            }
            catch
            {
                question.Skill = 0;
            }

            try
            {
                question.BankId = Convert.ToInt32(SystemConfig.IniReadValue("QuesitonInfo", "BankId", filePath));
                if (0 != question.BankId)
                {
                    m_Relation_Question_Suite[question.Id] = question.BankId;
                }
            }
            catch
            {
                question.BankId = 0;
            }

            try
            {
                question.IntensifyId = Convert.ToInt32(SystemConfig.IniReadValue("QuesitonInfo", "IntensifyId", filePath));
            }
            catch
            {
                question.IntensifyId = 0;
                if (0 != question.BankId)
                {
                    m_Relation_Question_Intensity[question.Id] = question.IntensifyId;
                }
            }

            question.Type = Convert.ToInt32(SystemConfig.IniReadValue("QuesitonInfo", "Type", filePath));
            question.Classification = Convert.ToInt32(SystemConfig.IniReadValue("QuesitonInfo", "Classification", filePath));

            question.Options = new List<string>();
            question.OptionsEmphasize = new List<string>();
            question.CorrectAnswer = new List<int>();
            if (question.Type != 1)
            {
                HashSet<int> questionOrder = new HashSet<int>();
                for (var i = 0; i < 4; i++)
                {
                    var ret = rnd.Next(1, 5);
                    if (ret == 5)
                        MessageBox.Show("error");

                    while (!questionOrder.Add(ret))
                    {
                        ret = rnd.Next(1, 5);
                    }
                }
                int index = 0;
                foreach (var i in questionOrder)
                {
                    index++;
                    question.Options.Add(SystemConfig.IniReadValue("Options", "Options" + i.ToString(), filePath));
                    question.OptionsEmphasize.Add(SystemConfig.IniReadValue("Options", "Image" + i.ToString(), filePath));

                    if ("1".Equals(SystemConfig.IniReadValue("AnswerInfo", "Answer" + i.ToString(), filePath)))
                        question.CorrectAnswer.Add(index);
                }
            }
            else
            {
                for (int i = 1; i <= 4; i++)
                {
                    question.Options.Add(SystemConfig.IniReadValue("Options", "Options" + i.ToString(), filePath));
                    question.OptionsEmphasize.Add(SystemConfig.IniReadValue("Options", "Image" + i.ToString(), filePath));

                    if ("1".Equals(SystemConfig.IniReadValue("AnswerInfo", "Answer" + i.ToString(), filePath)))
                        question.CorrectAnswer.Add(i);
                }
            }
            if (question.CorrectAnswer.Count == 0)
            {
                MessageBox.Show("没有正确答案的题目" + question.Id.ToString());
            }

            question.SkillNotice = SystemConfig.IniReadValue("SkillInfo", "SkillNotice", filePath);
            question.NormalNotice = SystemConfig.IniReadValue("SkillInfo", "NormalNotice", filePath);

            TimeSpan timeSpan = DateTime.Now - dateStart;
            Console.WriteLine(string.Format("Question ID: {0} Read Time: {1} ms", question.Id, timeSpan.TotalMilliseconds));
            return question;
        }


        public static Question LoadQuestionByIni(int id)
        {
            DateTime dateStart = DateTime.Now;
            var filePath = Path.Combine("Questions", id.ToString() + ".txt");
            if (!File.Exists(filePath))
            {
                return null;
            }

            ConfigFile configFile = new ConfigFile(filePath);

            //遍历Config文件
            //foreach (var group in configFile.SettingGroups)
            //{
            //    foreach (var value in group.Value.Settings)
            //        Console.WriteLine("{0} = {1} (Is Array? {2})", value.Key, value.Value.RawValue, value.Value.IsArray);

            //    Console.WriteLine();
            //}


            Question question = new Question();
            question.Id = Convert.ToInt32(configFile.SettingGroups["QuesitonInfo"].Settings["Id"].RawValue);

            question.Tittle = configFile.SettingGroups["QuesitonInfo"].Settings["Tittle"].RawValue;
            question.TittleEmphasize = configFile.SettingGroups["QuesitonInfo"].Settings["SkillEmphasize"].RawValue;
            question.ImagePath = configFile.SettingGroups["QuesitonInfo"].Settings["ImagePath"].RawValue; 
            question.FlashPath = configFile.SettingGroups["QuesitonInfo"].Settings["FlashPath"].RawValue; 
            question.Module = Convert.ToInt32(configFile.SettingGroups["QuesitonInfo"].Settings["MoudleId"].RawValue); 

            try
            {
                question.Skill = Convert.ToInt32(configFile.SettingGroups["QuesitonInfo"].Settings["SkillId"].RawValue); 
                if (0 != question.Skill)
                {
                    m_Relation_Question_Skill[question.Id] = question.Skill;
                }
            }
            catch
            {
                question.Skill = 0;
            }

            try
            {
                question.BankId = Convert.ToInt32(configFile.SettingGroups["QuesitonInfo"].Settings["BankId"].RawValue); 
                if (0 != question.BankId)
                {
                    m_Relation_Question_Suite[question.Id] = question.BankId;
                }
            }
            catch
            {
                question.BankId = 0;
            }

            try
            {
                question.IntensifyId = Convert.ToInt32(configFile.SettingGroups["QuesitonInfo"].Settings["IntensifyId"].RawValue); 
            }
            catch
            {
                question.IntensifyId = 0;
                if (0 != question.BankId)
                {
                    m_Relation_Question_Intensity[question.Id] = question.IntensifyId;
                }
            }

            question.Type = Convert.ToInt32(configFile.SettingGroups["QuesitonInfo"].Settings["Type"].RawValue);
            question.Classification = Convert.ToInt32(configFile.SettingGroups["QuesitonInfo"].Settings["Classification"].RawValue); 

            question.Options = new List<string>();
            question.OptionsEmphasize = new List<string>();
            question.CorrectAnswer = new List<int>();
            if (question.Type != 1)
            {
                HashSet<int> questionOrder = new HashSet<int>();
                for (var i = 0; i < 4; i++)
                {
                    var ret = rnd.Next(1, 5);
                    if (ret == 5)
                        MessageBox.Show("error");

                    while (!questionOrder.Add(ret))
                    {
                        ret = rnd.Next(1, 5);
                    }
                }
                int index = 0;
                foreach (var i in questionOrder)
                {
                    index++;
                    question.Options.Add(configFile.SettingGroups["Options"].Settings["Options" + i.ToString()].RawValue);
                    question.OptionsEmphasize.Add(configFile.SettingGroups["Options"].Settings["Image" + i.ToString()].RawValue);

                    if ("1".Equals(configFile.SettingGroups["AnswerInfo"].Settings["Answer" + i.ToString()].RawValue))
                        question.CorrectAnswer.Add(index);
                }
            }
            else
            {
                for (int i = 1; i <= 4; i++)
                {
                    question.Options.Add(configFile.SettingGroups["Options"].Settings["Options" + i.ToString()].RawValue);
                    question.OptionsEmphasize.Add(configFile.SettingGroups["Options"].Settings["Image" + i.ToString()].RawValue);

                    if ("1".Equals(configFile.SettingGroups["AnswerInfo"].Settings["Answer" + i.ToString()].RawValue))
                        question.CorrectAnswer.Add(i);
                }
            }
            if (question.CorrectAnswer.Count == 0)
            {
                MessageBox.Show("没有正确答案的题目" + question.Id.ToString());
            }

            question.SkillNotice = configFile.SettingGroups["SkillInfo"].Settings["SkillNotice"].RawValue;
            question.NormalNotice = configFile.SettingGroups["SkillInfo"].Settings["NormalNotice"].RawValue; 

            TimeSpan timeSpan = DateTime.Now - dateStart;
            Console.WriteLine(string.Format("Question ID: {0} Read Time: {1} ms", question.Id, timeSpan.TotalMilliseconds));
            return question;
        }


        public static void SaveQuestionMaxNum()
        {
            SystemConfig.IniWriteValue("Problems", "MaxProblem", _maxQuestionNum.ToString(), SystemConfig.ConfigPath);
        }
        public static void LoadAllQuestion()
        {
            try
            {
                _maxQuestionNum = Convert.ToInt32(SystemConfig.IniReadValue("Problems", "MaxProblem", SystemConfig.ConfigPath));
                ModelManager.GetListModel();
                initParams();

                m_QuestionsList.Clear();
                m_QuestionsDictionary.Clear();
                
                //QUESTION_NUM = m_QuestionsList.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 通过ID加载题目列表
        /// </summary>
        /// <param name="minId"></param>
        /// <param name="maxId"></param>
        public static void LoadQuestion(int minId, int maxId)
        {
            for (int i = minId; i <= maxId; i++)
            {
                try
                {
                    Question question = LoadQuestionByIni(i);
                    if (null == question)
                        continue;

                    m_QuestionsDictionary[question.Id] = question;
                    m_QuestionsList.Add(question);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error load question of question id = " + i.ToString());
                }

                //int MoudelId = 0;
                //SystemConfig.ProblemToMoudle.TryGetValue(question.Id, out MoudelId);

                //int SkillId = 0;
                //SystemConfig.ProblemToSkill.TryGetValue(question.Id, out SkillId);
                //question.Module = MoudelId;
                //question.Skill = SkillId;

                //SaveQuestion(question, @"D:\Projects\CSharp\DirvingTest\DirvingTest\bin\Debug\Questions\" + i.ToString() + ".txt");


                //if (question.Type == 1)
                //    m_ChargeOneList.Add(question);
                //if(question.Type == 2)
                //    m_SelectedOneList.Add(question);

                //if (question.Type == 3)
                //    m_SelectedMultList.Add(question);
                    
            }
        }

        //public static bool SaveQuestion(Question question, string path)
        //{
        //    try
        //    {
        //        if (0 == getClassificationById(question.Id))
        //            return false;

        //        if(question.Id == 776)
        //        {
        //            int a = question.Id;
        //        }
        //        SystemConfig.IniWriteValue("QuesitonInfo", "Id", question.Id.ToString(), path);
        //        SystemConfig.IniWriteValue("QuesitonInfo", "Tittle", question.Tittle, path);
        //        SystemConfig.IniWriteValue("QuesitonInfo", "SkillEmphasize", question.TittleEmphasize, path);
        //        SystemConfig.IniWriteValue("QuesitonInfo", "ImagePath", question.ImagePath, path);
        //        SystemConfig.IniWriteValue("QuesitonInfo", "FlashPath", question.FlashPath, path);
        //        SystemConfig.IniWriteValue("QuesitonInfo", "SkillId", question.Skill.ToString(), path);
        //        SystemConfig.IniWriteValue("QuesitonInfo", "MoudleId", question.Module.ToString(), path);
        //        if (1 == question.Type)
        //            SystemConfig.IniWriteValue("QuesitonInfo", "Type", question.Type.ToString(), path);
        //        else
        //            SystemConfig.IniWriteValue("QuesitonInfo", "Type", "2", path);

        //        SystemConfig.IniWriteValue("QuesitonInfo", "Classification", getClassificationById(question.Id).ToString(), path);

        //        //if(question.Module <=4)
        //        //    SystemConfig.IniWriteValue("QuesitonInfo", "Classification", "3", path);

        //        //if(question.Module == 5)
        //        //    SystemConfig.IniWriteValue("QuesitonInfo", "Classification", "2", path);

        //        //if (question.Module == 6)
        //        //    SystemConfig.IniWriteValue("QuesitonInfo", "Classification", "1", path);

        //        //if (question.Module > 6)
        //        //    SystemConfig.IniWriteValue("QuesitonInfo", "Classification", "4", path);

        //        if (null != question.Options && question.Options.Count > 0)
        //        {
        //            for (int i = 1; i <= question.Options.Count; i++)
        //                SystemConfig.IniWriteValue("Options", "Options" + i.ToString(), question.Options[i - 1], path);
        //            //SystemConfig.IniWriteValue("Options", "Options2", question.Options[1], path);
        //            //SystemConfig.IniWriteValue("Options", "Options3", question.Options[2], path);
        //            //SystemConfig.IniWriteValue("Options", "Options4", question.Options[3], path);

        //            SystemConfig.IniWriteValue("Options", "Image1", "", path);
        //            SystemConfig.IniWriteValue("Options", "Image2", "", path);
        //            SystemConfig.IniWriteValue("Options", "Image3", "", path);
        //            SystemConfig.IniWriteValue("Options", "Image4", "", path);
        //        }
        //        else
        //        {
        //            SystemConfig.IniWriteValue("Options", "Options1", "正确", path);
        //            SystemConfig.IniWriteValue("Options", "Options2", "错误", path);
        //            SystemConfig.IniWriteValue("Options", "Options1", "", path);
        //            SystemConfig.IniWriteValue("Options", "Options2", "", path);
        //            SystemConfig.IniWriteValue("Options", "Image1", "", path);
        //            SystemConfig.IniWriteValue("Options", "Image2", "", path);
        //            SystemConfig.IniWriteValue("Options", "Image3", "", path);
        //            SystemConfig.IniWriteValue("Options", "Image4", "", path);
        //        }

        //        if (question.Options != null)
        //        {
        //            string CorrectAnswer = question.CorrectAnswer[0].ToString();
        //            for (int i = 1; i <= question.Options.Count; i++)
        //            {
        //                SystemConfig.IniWriteValue("AnswerInfo", "Answer" + i.ToString(), CorrectAnswer.IndexOf(i.ToString()) != -1 ? "1" : "0", path);
        //            }

        //            if (CorrectAnswer.Length > 1)
        //                SystemConfig.IniWriteValue("QuesitonInfo", "Type", "3", path);
        //        }
        //        else
        //        {
        //            for (int i = 1; i < 3; i++)
        //            {
        //                SystemConfig.IniWriteValue("AnswerInfo", "Answer" + i.ToString(), question.CorrectAnswer[0] == i ? "1" : "0", path);
        //            }
        //        }

        //        SystemConfig.IniWriteValue("SkillInfo", "SkillNotice", question.NormalNotice, path);
        //        SystemConfig.IniWriteValue("SkillInfo", "NormalNotice", question.NormalNotice, path);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public static bool SaveQuestion3(Question question, out bool isUpdate, string path)
        {
            try
            {
                isUpdate = false;
                foreach(var ques in m_QuestionsList)
                {
                    if (ques.Id == question.Id)
                    {
                        isUpdate = true;
                        break;
                    }
                }
                SystemConfig.IniWriteValue("QuesitonInfo", "Id", question.Id.ToString(), path);
                SystemConfig.IniWriteValue("QuesitonInfo", "Tittle", question.Tittle, path);
                SystemConfig.IniWriteValue("QuesitonInfo", "SkillEmphasize", question.TittleEmphasize, path);
                SystemConfig.IniWriteValue("QuesitonInfo", "ImagePath", question.ImagePath, path);
                SystemConfig.IniWriteValue("QuesitonInfo", "FlashPath", question.FlashPath, path);
                SystemConfig.IniWriteValue("QuesitonInfo", "SkillId", question.Skill.ToString(), path);
                SystemConfig.IniWriteValue("QuesitonInfo", "MoudleId", question.Module.ToString(), path);
                SystemConfig.IniWriteValue("QuesitonInfo", "BankId", question.BankId.ToString(), path);
                SystemConfig.IniWriteValue("QuesitonInfo", "Type", question.Type.ToString(), path);
                SystemConfig.IniWriteValue("QuesitonInfo", "Classification", question.Classification.ToString(), path);
                SystemConfig.IniWriteValue("SkillInfo", "SkillNotice", question.SkillNotice, path);
                SystemConfig.IniWriteValue("SkillInfo", "NormalNotice", question.NormalNotice, path);

                if (null != question.Options && question.Options.Count > 0)
                {
                    for (int i = 1; i <= question.Options.Count; i++)
                    {
                        SystemConfig.IniWriteValue("Options", "Options" + i.ToString(), question.Options[i - 1], path);
                        SystemConfig.IniWriteValue("Options", "Image" + i.ToString(), question.OptionsEmphasize[i - 1], path);
                    }
                }
                else
                {
                    SystemConfig.IniWriteValue("Options", "Options1", "", path);
                    SystemConfig.IniWriteValue("Options", "Options2", "", path);
                    SystemConfig.IniWriteValue("Options", "Options3", "", path);
                    SystemConfig.IniWriteValue("Options", "Options4", "", path);
                    SystemConfig.IniWriteValue("Options", "Image1", "", path);
                    SystemConfig.IniWriteValue("Options", "Image2", "", path);
                    SystemConfig.IniWriteValue("Options", "Image3", "", path);
                    SystemConfig.IniWriteValue("Options", "Image4", "", path);
                }

                for (int i = 1; i <= 4; i++)
                {
                    SystemConfig.IniWriteValue("AnswerInfo", "Answer" + i.ToString(), "0", path);
                }

                for(int i= 0; i<question.CorrectAnswer.Count;i++)
                {
                    SystemConfig.IniWriteValue("AnswerInfo", "Answer" + question.CorrectAnswer[i].ToString(), "1", path);
                }

                return true;
            }
            catch
            {
                isUpdate = false;
                return false;
            }
        }

        #region 不使用的数据
        //public static void SaveQuestion2(Question question, string path)
        //{
        //    SystemConfig.IniWriteValue("QuesitonInfo", "Id", question.Id.ToString(), path);
        //    SystemConfig.IniWriteValue("QuesitonInfo", "Tittle", question.Tittle, path);
        //    SystemConfig.IniWriteValue("QuesitonInfo", "SkillEmphasize", question.TittleEmphasize, path);
        //    SystemConfig.IniWriteValue("QuesitonInfo", "ImagePath", question.ImagePath, path);
        //    SystemConfig.IniWriteValue("QuesitonInfo", "FlashPath", question.FlashPath, path);
        //    SystemConfig.IniWriteValue("QuesitonInfo", "SkillId", question.Skill.ToString(), path);
        //    SystemConfig.IniWriteValue("QuesitonInfo", "MoudleId", question.Module.ToString(), path);
        //    SystemConfig.IniWriteValue("QuesitonInfo", "Classification", question.Classification.ToString(), path);
        //    SystemConfig.IniWriteValue("QuesitonInfo", "Type", question.Type.ToString(), path);
        //    SystemConfig.IniWriteValue("QuesitonInfo", "Classification", getClassificationById(question.Id).ToString(), path);

        //    if (null != question.Options)
        //    {
        //        for (int i = 1; i <= question.Options.Count; i++)
        //            SystemConfig.IniWriteValue("Options", "Options" + i.ToString(), question.Options[i - 1], path);


        //        SystemConfig.IniWriteValue("Options", "Image1", "", path);
        //        SystemConfig.IniWriteValue("Options", "Image2", "", path);
        //        SystemConfig.IniWriteValue("Options", "Image3", "", path);
        //        SystemConfig.IniWriteValue("Options", "Image4", "", path);
        //    }
        //    else
        //    {
        //        SystemConfig.IniWriteValue("Options", "Options1", "正确", path);
        //        SystemConfig.IniWriteValue("Options", "Options2", "错误", path);
        //        SystemConfig.IniWriteValue("Options", "Options1", "", path);
        //        SystemConfig.IniWriteValue("Options", "Options2", "", path);
        //        SystemConfig.IniWriteValue("Options", "Image1", "", path);
        //        SystemConfig.IniWriteValue("Options", "Image2", "", path);
        //        SystemConfig.IniWriteValue("Options", "Image3", "", path);
        //        SystemConfig.IniWriteValue("Options", "Image4", "", path);
        //    }

        //    if (question.Options != null)
        //    {
        //        string CorrectAnswer = question.CorrectAnswer[0].ToString();
        //        for (int i = 1; i <= question.Options.Count; i++)
        //        {
        //            SystemConfig.IniWriteValue("AnswerInfo", "Answer" + i.ToString(), CorrectAnswer.IndexOf(i.ToString()) != -1 ? "1" : "0", path);
        //        }

        //        if (CorrectAnswer.Length > 1)
        //            SystemConfig.IniWriteValue("QuesitonInfo", "Type", "3", path);
        //    }
        //    else
        //    {
        //        for (int i = 1; i < 3; i++)
        //        {
        //            SystemConfig.IniWriteValue("AnswerInfo", "Answer" + i.ToString(), question.CorrectAnswer[0] == i ? "1" : "0", path);
        //        }
        //    }

        //    SystemConfig.IniWriteValue("SkillInfo", "SkillNotice", question.NormalNotice, path);
        //    SystemConfig.IniWriteValue("SkillInfo", "NormalNotice", question.NormalNotice, path);
        //}

        //public static int getClassificationById(int id)
        //{
        //    if (id >= 1 && id <= 365)
        //    {
        //        return 3;
        //    }
        //    if (id >= 2541 && id <= 2640)
        //    {
        //        return 3;
        //    }
        //    if (id >= 366 && id <= 677)
        //    {
        //        return 3;
        //    }
        //    if (id >= 678 && id <= 864)
        //    {
        //        return 3;
        //    }
        //    if (id >= 865 && id <= 973)
        //    {
        //        return 3;
        //    }
        //    if (id >= 9710 && id <= 9714)
        //    {
        //        return 2;
        //    }
        //    if (id >= 1026 && id <= 1091)
        //    {
        //        return 2;
        //    }
        //    if (id >= 974 && id <= 1025)
        //    {
        //        return 1;
        //    }
        //    if (id >= 9699 && id <= 9709)
        //    {
        //        return 1;
        //    }

        //    if (id >= 1537 && id <= 1573)
        //    {
        //        return 4;
        //    }
        //    if (id >= 1574 && id <= 1765)
        //    {
        //        return 4;
        //    }
        //    if (id >= 2641 && id <= 2716)
        //    {
        //        return 4;
        //    }
        //    if (id >= 1766 && id <= 1980)
        //    {
        //        return 4;
        //    }
        //    if (id >= 1981 && id <= 2042)
        //    {
        //        return 4;
        //    }
        //    if (id >= 2717 && id <= 2727)
        //    {
        //        return 4;
        //    }
        //    if (id >= 2043 && id <= 2207)
        //    {
        //        return 4;
        //    }
        //    if (id >= 2728 && id <= 2740)
        //    {
        //        return 4;
        //    }
        //    if (id >= 2208 && id <= 2301)
        //    {
        //        return 4;
        //    }
        //    if (id >= 2302 && id <= 2336)
        //    {
        //        return 4;
        //    }

        //    return 0;
        //}

        //public static int getMoudleById(int id)
        //{
        //    if(id>=1 && id<=365)
        //    {
        //        return 1;
        //    }
        //    if (id >=2541 && id <= 2640)
        //    {
        //        return 1;
        //    }
        //    if (id >= 366 && id <= 677)
        //    {
        //        return 2;
        //    }
        //    if (id >= 678 && id <= 864)
        //    {
        //        return 3;
        //    }
        //    if (id >= 865 && id <= 973)
        //    {
        //        return 4;
        //    }
        //    if (id >= 9710 && id <= 9714)
        //    {
        //        return 5;
        //    }
        //    if (id >= 1026 && id <= 1091)
        //    {
        //        return 5;
        //    }
        //    if (id >= 974 && id <= 1025)
        //    {
        //        return 6;
        //    }
        //    if (id >= 9699 && id <= 9709)
        //    {
        //        return 6;
        //    }

        //    if (id >= 1537 && id <= 1573)
        //    {
        //        return 7;
        //    }
        //    if (id >= 1574 && id <= 1765)
        //    {
        //        return 8;
        //    }
        //    if (id >= 2641 && id <= 2716)
        //    {
        //        return 8;
        //    }
        //    if (id >= 1766 && id <= 1980)
        //    {
        //        return 9;
        //    }
        //    if (id >= 1981 && id <= 2042)
        //    {
        //        return 10;
        //    }
        //    if (id >= 2717 && id <= 2727)
        //    {
        //        return 10;
        //    }
        //    if (id >= 2043 && id <= 2207)
        //    {
        //        return 11;
        //    }
        //    if (id >= 2728 && id <= 2740)
        //    {
        //        return 11;
        //    }
        //    if (id >= 2208 && id <= 2301)
        //    {
        //        return 12;
        //    }
        //    if (id >= 2302 && id <= 2336)
        //    {
        //        return 13;
        //    }

        //    return 0;
        //}

        //public static void GenClassificationProblems()
        //{
        //    foreach(var question in m_QuestionsList)
        //    {
        //        int MoudelId = question.Module;
        //        int SkillId = question.Skill;

        //        if (0 <MoudelId && MoudelId < SystemConfig.Subject1MoudleCount + 1)
        //        {
        //            List<Question> questionList = (List <Question>)ArrayQuestionByMoudleSubject1.GetValue(MoudelId-1);
        //            questionList.Add(question);
        //        }
        //        else if(MoudelId>0)
        //        {
        //            List<Question> questionList = (List<Question>)ArrayQuestionByMoudleSubject2.GetValue(MoudelId - SystemConfig.Subject1MoudleCount - 1);
        //            questionList.Add(question);
        //        }

        //        if(0 < SkillId)
        //        {
        //            List<Question> questionList = (List<Question>)ArrayQuestionBySkill.GetValue(SkillId - 1);
        //            questionList.Add(question);
        //        }
        //    }
        //}

        ///// <summary>
        ///// 通过考试信息生成考试题目
        ///// </summary>
        ///// <param name="examType"></param>
        ///// <param name="driverType"></param>
        ///// <returns></returns>
        //public static List<Question> GenQuestionsByExam1(int examType, int driverType)
        //{
        //    List<Question> questionList = new List<Question>();
        //    //0 C1 科目一
        //    if (examType == 0)
        //    {
        //        if(driverType == 0)
        //        {
        //            for (int i = 0; i < SystemConfig.CarRule.Count; i++ )
        //            {
        //                List<Question> list = GenQuestions(SystemConfig.CarRule[i], (List<Question>)ArrayQuestionByMoudleSubject1.GetValue(i));
        //                questionList.AddRange(list);
        //            }
        //        }
        //        else if(driverType == 1)
        //        {
        //            //bus
        //            for (int i = 0; i < SystemConfig.BusRule.Count-1; i++)
        //            {
        //                List<Question> list = GenQuestions(SystemConfig.BusRule[i], (List<Question>)ArrayQuestionByMoudleSubject1.GetValue(i));
        //                questionList.AddRange(list);
        //            }
        //            int index = SystemConfig.BusRule.Count - 1;
        //            List<Question> listTmpe = GenQuestions(SystemConfig.BusRule[index], (List<Question>)ArrayQuestionByMoudleSubject1.GetValue(index + 1));
        //            questionList.AddRange(listTmpe);
        //        }
        //        else
        //        {
        //            for (int i = 0; i < SystemConfig.TruckRule.Count; i++)
        //            {
        //                List<Question> list = GenQuestions(SystemConfig.TruckRule[i], (List<Question>)ArrayQuestionByMoudleSubject1.GetValue(i));
        //                questionList.AddRange(list);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < SystemConfig.Subject2Rule.Count; i++)
        //        {
        //            List<Question> list = GenQuestions(SystemConfig.Subject2Rule[i], (List<Question>)ArrayQuestionByMoudleSubject2.GetValue(i));
        //            questionList.AddRange(list);
        //        }
        //    }

            
        //    return questionList;
        //}
        #endregion

        public static List<Question> GenQuestionsByExam(int examType, int driverType)
        {
            List<Question> questionList = new List<Question>();
            Dictionary<int, int> rule = new Dictionary<int, int>();
            Dictionary<int, int> currentQuestion = new Dictionary<int, int>();
            //0 C1 科目一,考试,消分考试
            if (examType == 0 || examType ==3)
            {
                if (driverType == 0)
                {
                    //生成小车题目
                    for (int i = 0; i < SystemConfig.CarRule.Count; i++)
                    {
                        rule.Add(i + 1, SystemConfig.CarRule[i]);
                        currentQuestion.Add(i + 1, 0);
                    }

                    questionList = GenChargeQuestion(100, rule, currentQuestion, examType);
                }
                else if (driverType == 1)
                {
                    //生成bus题目
                    for (int i = 0; i < SystemConfig.BusRule.Count; i++)
                    {
                        rule.Add(i + 1, SystemConfig.BusRule[i]);
                        currentQuestion.Add(i + 1, 0);
                    }

                    questionList = GenChargeQuestion(100, rule, currentQuestion, examType);
                }
                else if(driverType == 2)
                {
                    //生成货车题目
                    for (int i = 0; i < SystemConfig.TruckRule.Count; i++)
                    {
                        rule.Add(i + 1, SystemConfig.TruckRule[i]);
                        currentQuestion.Add(i + 1, 0);
                    }
                    //rule.Add(6, SystemConfig.TruckRule[4]);
                    //currentQuestion.Add(6, 0);

                    questionList = GenChargeQuestion(100, rule, currentQuestion, examType);
                }
                else if(driverType ==3)
                {
                    //摩托车
                    questionList = GenChargeQuestionMotor(50, currentQuestion, examType);
                }
            }
            else if (examType == 1)
            {
                //科目四考试
                //rule里面存储的是章节id
                for (int i = 0; i < SystemConfig.Subject2Rule.Count; i++)
                {
                    rule.Add(i + 7, SystemConfig.Subject2Rule[i]);
                    currentQuestion.Add(i + 7, 0);
                }

                //科目四有5道多选题
                questionList = GenChargeQuestion(50, rule, currentQuestion, examType);
                List<Question> question1 = new List<Question>();
                foreach(Question question in questionList)
                {
                    if (question.Type == 1)
                        question1.Add(question);
                }
                List<Question> question2 = new List<Question>();
                foreach (Question question in questionList)
                {
                    if (question.Type == 2)
                        question2.Add(question);
                }

                List<Question> question3 = new List<Question>();
                foreach (Question question in questionList)
                {
                    if (question.Type == 3)
                        question3.Add(question);
                }

                questionList.Clear();
                questionList.AddRange(question1);
                questionList.AddRange(question2);
                questionList.AddRange(question3);
            }
            else
            {
                //生成恢复考试题目
                for (int i = 0; i < SystemConfig.RecoverExamRule.Count; i++)
                {
                    rule.Add(i + 1, SystemConfig.RecoverExamRule[i]);
                    currentQuestion.Add(i + 1, 0);
                }

                rule[14] = rule[4];
                rule[4] = 0;

                currentQuestion[14] = currentQuestion[4];
                currentQuestion[4] = 0;


                questionList = GenChargeQuestion(50, rule, currentQuestion, examType);

                //以下是排序
                List<Question> question1 = new List<Question>();
                foreach (Question question in questionList)
                {
                    if (question.Type == 1)
                        question1.Add(question);
                }
                List<Question> question2 = new List<Question>();
                foreach (Question question in questionList)
                {
                    if (question.Type == 2)
                        question2.Add(question);
                }

                List<Question> question3 = new List<Question>();
                foreach (Question question in questionList)
                {
                    if (question.Type == 3)
                        question3.Add(question);
                }

                questionList.Clear();
                questionList.AddRange(question1);
                questionList.AddRange(question2);
                questionList.AddRange(question3);
            }

            return questionList;
        }

        /// <summary>
        /// /// <summary>
        /// 生成题目
        /// 
        /// <param name="questionCount"></param>
        /// <param name="rule"></param>
        /// <param name="curQuestionList"></param>
        /// <param name="examType"></param>
        /// <returns></returns>
        public static List<Question> GenChargeQuestion(int questionCount, Dictionary<int, int> rule, Dictionary<int, int> curQuestionList, int examType)
        {
            //生成题目的数量判断~选择~多选[ProblemTypeCountRule]
            List<Question> lst = new List<Question>();
            //消分考试跟科目一考试是一样的抽题
            List<int> TypeCountRule;
            if (examType == 0 || examType == 3)
                TypeCountRule = SystemConfig.ProblemTypeCountRuleSubject1;
            else if (examType == 1)
                TypeCountRule = SystemConfig.ProblemTypeCountRuleSubject2;
            else if (examType == 2)
                TypeCountRule = SystemConfig.ProblemTypeCountRuleRecoverExam;
            else
                return lst;

            List<Question> tempQuestionList  = new List<Question>();
            foreach(Question question in m_QuestionsList)
            {
                int chapterId = question.Module;
                int count = 0;
                if(true == rule.TryGetValue(chapterId, out count))
                {
                    if (count > 0)
                        tempQuestionList.Add(question);
                }


            }
            
            HashSet<int> arrExam = new HashSet<int>();//剔除重复抽取的题目
            for (var i = 0; i < Math.Min(questionCount, tempQuestionList.Count); i++)
            {
                //随机选出题目并且剔除已经选中过的题目
                var ret = rnd.Next(0, tempQuestionList.Count);
                while (!arrExam.Add(ret))
                {
                    ret = rnd.Next(0, tempQuestionList.Count);
                }
                
                //抽题
                Question ques = tempQuestionList[ret];

                //科目1 40判断 60选择 科目四： 19,26,5（判断 选择 多选）
                //1.抽多选 
                //2.抽选择
                //3.抽判断
                bool needNew = false;
                if (lst.Count < TypeCountRule[2])
                {
                    needNew = IsNeedGenerationAgain(ques, ref rule, ref curQuestionList, 3);
                }
                else if (lst.Count >= TypeCountRule[2] && lst.Count < TypeCountRule[2] + TypeCountRule[0])
                {
                    needNew = IsNeedGenerationAgain(ques, ref rule, ref curQuestionList, 1);
                }
                else
                {
                    needNew = IsNeedGenerationAgain(ques, ref rule, ref curQuestionList, 2);
                }

                if (needNew)
                {
                    //判断重复抽题
                    arrExam.Remove(ret);
                    i--;
                }
                else
                    lst.Add(ques);
            }

            return lst;
        }


        /// <summary>
        /// 生成摩托车的试题
        /// </summary>
        /// <param name="questionCount"></param>
        /// <param name="curQuestionList"></param>
        /// <param name="examType"></param>
        /// <returns></returns>
        public static List<Question> GenChargeQuestionMotor(int questionCount, Dictionary<int, int> curQuestionList, int examType)
        {
            List<Question> lst = new List<Question>();


            //摩托车30个选择题 20个判断题
            List<int> TypeCountRule;
            TypeCountRule = SystemConfig.ProblemTypeCountRuleRecoverExam;
            Dictionary<int, int> rule = new Dictionary<int, int>();
            int moduleId = 0;
            if (examType == 2)
            {
                curQuestionList[15] = 0;
                rule[15] = 50;
                moduleId = 15;
            }
            else
            {
                curQuestionList[14] = 0;
                rule[14] =50;
                moduleId = 14;
            }

            
            List<Question> tempQuestionsList = new List<Question>();
            foreach(Question question in m_QuestionsList)
            {
                if(question.Module == moduleId)
                {
                    tempQuestionsList.Add(question);
                }
            }

            HashSet<int> arrExam = new HashSet<int>();//剔除重复抽取的题目
            for (var i = 0; i < Math.Min(questionCount, tempQuestionsList.Count); i++)
            {
                //随机选出题目并且剔除已经选中过的题目
                var ret = rnd.Next(0, tempQuestionsList.Count);
                while (!arrExam.Add(ret))
                {
                    ret = rnd.Next(0, tempQuestionsList.Count);
                }

                //抽题
                Question ques = tempQuestionsList[ret];
                if (ques.Module <= 13)
                {
                    i--;
                    continue;
                }

                //科目1 20判断 30选择 科目四： 20,30,0（判断 选择 多选）
                //1.抽多选 
                //2.抽选择
                //3.抽判断
                bool needNew = false;
                if (lst.Count < TypeCountRule[2])
                {
                    needNew = IsNeedGenerationAgain(ques, ref rule, ref curQuestionList, 3);
                }
                else if (lst.Count >= TypeCountRule[2] && lst.Count < TypeCountRule[2] + TypeCountRule[0])
                {
                    needNew = IsNeedGenerationAgain(ques, ref rule, ref curQuestionList, 1);
                }
                else
                {
                    needNew = IsNeedGenerationAgain(ques, ref rule, ref curQuestionList, 2);
                }

                if (needNew)
                {
                    //判断重复抽题
                    arrExam.Remove(ret);
                    i--;
                }
                else
                    lst.Add(ques);
            }

            return lst;
        }

        /// <summary>
        /// 判断生成的题目是否满足条件
        /// </summary>
        
        /// <returns></returns>
        ///
        private static bool IsNeedGenerationAgain(Question question, ref Dictionary<int, int> rule, ref Dictionary<int, int> curQuestionList, int type)
        {
            int count1 = 0;
            int count2 = 0;

            if (question.Module <= 0 || question.Module > 16)
                return true;

            //生成的不是允许的章节
            if (false == rule.TryGetValue(question.Module, out count1))
                return true;

            if (false == curQuestionList.TryGetValue(question.Module, out count2))
                return true;

            //已经在此章节抽了足够的题
            if (count1 <= count2)
                return true;

            if (type != question.Type)
                return true;

            //rule[question.Module] = count1;
            curQuestionList.Remove(question.Module);
            curQuestionList.Add(question.Module, count2 + 1);
            

            return false;
        }

        /// <summary>
        /// 获取某类技巧所有题目列表 
        /// </summary>
        /// <param name="skillId"></param>
        /// <returns></returns>
        public static List<Question> GenQuestionBySkill(int skillId)
        {           
            //以前的方法
            //List<Question> list = new List<Question>();
            //foreach (var question in QuestionManager.m_QuestionsList)
            //{
            //    if (question.Module == 0)
            //        continue;
                
            //    if(question.Skill == skillId)
            //    {
            //        list.Add(question);
            //    }
            //}

            //使用新的方法进行获取
            return GenQuestionFromRelation(skillId, QuestionManager.m_Relation_Question_Skill);
        }

        /// <summary>
        /// 利用关联信息获取题目列表
        /// </summary>
        /// <param name="chapterId"></param>
        /// <param name="relationDictionary"></param>
        /// <returns></returns>
        public static List<Question> GenQuestionFromRelation(int chapterId, SerializableDictionary<int, int> relationDictionary)
        {
            List<Question> list = new List<Question>();
            foreach (var data in relationDictionary)
            {
                //if (question.Module == 0)
                //    continue;

                if (data.Value == chapterId)
                {
                    Question question = new Question();
                    if (false == QuestionManager.m_QuestionsDictionary.TryGetValue(data.Key, out question))
                        continue;

                    list.Add(question);
                }
            }

            list.Sort();

            return list;
        }

        /// <summary>
        /// 获取某类套题所有题目列表
        /// </summary>
        /// <param name="bankId"></param>
        /// <returns></returns>
        public static List<Question> GenQuestionByBankId(int bankId)
        {
            //List<Question> list = new List<Question>();

            //foreach (var question in QuestionManager.m_QuestionsList)
            //{
            //    if (question.Module == 0)
            //        continue;

            //    if (question.BankId == bankId)
            //    {
            //        list.Add(question);
            //    }
            //}

            //list.Sort();
            //return list;

            //使用新的方法进行获取
            return GenQuestionFromRelation(bankId, QuestionManager.m_Relation_Question_Suite);
        }

        /// <summary>
        /// 获取某类强化练习所有题目列表
        /// </summary>
        /// <param name="intensifyId"></param>
        /// <returns></returns>
        public static List<Question> GenQuestionByIntensifyId(int intensifyId)
        {
            //List<Question> list = new List<Question>();

            //foreach (var question in QuestionManager.m_QuestionsList)
            //{
            //    if (question.Module == 0)
            //        continue;

            //    if (question.BankId == bankId)
            //    {
            //        list.Add(question);
            //    }
            //}

            //list.Sort();

            //return list;

            //使用新的方法进行获取
            return GenQuestionFromRelation(intensifyId, QuestionManager.m_Relation_Question_Suite);
        }


        /// <summary>
        /// 以某个Num开始，获取题目信息
        /// </summary>
        /// <param name="ExamNum"></param>
        /// <param name="fromQuestionList"></param>
        /// <returns></returns>
        public static List<Question> GenQuestions(int ExamNum, List<Question> fromQuestionList)
        {
            List<Question> questionList = new List<Question>();
            HashSet<int> arrExam = new HashSet<int>();

            for (var i = 0; i < Math.Min(ExamNum, fromQuestionList.Count); i++)
            {
                var ret = rnd.Next(0, fromQuestionList.Count);
                while (!arrExam.Add(ret))
                {
                    ret = rnd.Next(0, fromQuestionList.Count);
                }

                Question ques = fromQuestionList[ret];
                questionList.Add(ques);
            }

            return questionList;
        }

        /// <summary>
        /// 将skillID转正描述信息
        /// </summary>
        /// <param name="SkillId"></param>
        /// <returns></returns>
        public static string SkillToString(int SkillId)
        {
            if (0 == SkillId || SkillId > SystemConfig.SkillMoudleCount)
                return "未分类";

            return SystemConfig.SkillMoudleInfo[SkillId - 1];
        }

        public static string BankIdToString(int BankId)
        {
            if (0 == BankId || BankId > SystemConfig.SkillMoudleCount)
                return "未分类";

            return SystemConfig.SkillMoudleInfo[BankId - 1];
        }

        public static string IntensifyIdToString(int IntensifyId)
        {
            if (0 == IntensifyId || IntensifyId > SystemConfig.SkillMoudleCount)
                return "未分类";

            return SystemConfig.IntensifyInfo[IntensifyId - 1];
        }

        public static string MoudleToString(int MoudleId)
        {
            if (MoudleId == 0 || MoudleId > SystemConfig.Subject1MoudleCount + SystemConfig.Subject2MoudleCount)
                return "未分类";

            if(MoudleId <= SystemConfig.Subject1MoudleCount)
            {
                return SystemConfig.Subject1MoudleInfo[MoudleId-1];
            }
            else
            {
                return SystemConfig.Subject2MoudleInfo[MoudleId - SystemConfig.Subject1MoudleCount - 1];
            }
        }

        public static string MoudelToSubject(int MoudleId)
        {
            if (MoudleId == 0)
                return "";

            if (MoudleId <= SystemConfig.Subject1MoudleCount)
            {
                return "科目一";
            }
            else
            {
                return "科目四";
            }
        }

        public static bool Compare(Question question1, Question question2)
        {
            if (question1.Id != question2.Id)
                return false;

            if (question1.Tittle != question2.Tittle)
                return false;

            if (question1.TittleEmphasize != question2.TittleEmphasize)
                return false;

            if (question1.NormalNotice != question2.NormalNotice)
                return false;

            if (question1.SkillNotice != question2.SkillNotice)
                return false;

            if (question1.CorrectAnswer[0] != question2.CorrectAnswer[0])
                return false;

            if (question1.Skill != question2.Skill)
                return false;

            if (question1.Module != question2.Module)
                return false;

            if (question1.ImagePath != question2.ImagePath)
                return false;

            if (question1.FlashPath != question2.FlashPath)
                return false;

            if(question1.Options == null || question2.Options == null)
            {
                if(question1.Options != question2.Options)
                    return false;
            }
            else
            {
                if (question1.Options[0] != question2.Options[0])
                    return false;

                if (question1.Options[1] != question2.Options[1])
                    return false;

                if (question1.Options[2] != question2.Options[2])
                    return false;

                if (question1.Options[3] != question2.Options[3])
                    return false;
            }

            return true;
        }

        public static Question ComposeQuestion(string strTitle, string strTittleEmphasize, string strNomalExplain, string strSkillExplain,
                int MoudleId, int SkillId, string strImagePath, string strFlashPath, int corectAnswer, List<string>Options)
        {
            Question question = new Question();
            question.Id = SystemConfig._maxCount + 1;
            question.Tittle = strTitle;
            question.TittleEmphasize = strTittleEmphasize;
            question.NormalNotice = strNomalExplain;
            question.SkillNotice = strSkillExplain;
            question.Module = MoudleId;
            question.Skill = SkillId;
            question.ImagePath = strImagePath;
            if (!string.IsNullOrEmpty(strFlashPath))
            {
                question.FlashPath = Path.Combine("Flash", Path.GetFileName(strFlashPath));
            }

            question.CorrectAnswer = new List<int>();
            question.CorrectAnswer.Add(corectAnswer);

            question.Type = 1;
            if(Options  != null)
            {
                question.Type = 0;
                question.Options = new List<string>();
                foreach(var option in Options)
                {
                    question.Options.Add(option);
                }
            }

            return question;
        }

        private static bool SaveQuestion(Question question)
        {
            string newFile = Directory.GetCurrentDirectory() + "//Questions//" +  question.Id + ".txt";
            using (var sw = new StreamWriter(newFile, false, Encoding.UTF8))
            {
                sw.WriteLine(question.Tittle);            // 问题
                sw.WriteLine(SPLIT_STR);
                if (!string.IsNullOrEmpty(question.ImagePath))
                { 
                    sw.WriteLine(Path.GetFileName(question.ImagePath));          // 问题图片列表，以逗号分隔
                }
                if (!string.IsNullOrEmpty(question.FlashPath))
                {
                    sw.WriteLine(Path.GetFileName(question.FlashPath));
                }
                if (string.IsNullOrEmpty(question.ImagePath) && string.IsNullOrEmpty(question.FlashPath))
                    sw.WriteLine(question.ImagePath);

                sw.WriteLine(SPLIT_STR);
                sw.WriteLine(question.CorrectAnswer[0]);      // 答案序号
                sw.WriteLine(SPLIT_STR);
                sw.WriteLine(question.NormalNotice);//技巧
                sw.WriteLine(SPLIT_STR);
                sw.WriteLine(question.TittleEmphasize);  //强调
                sw.WriteLine(SPLIT_STR);
                sw.WriteLine(question.NormalNotice);  // 答案简要说明

                if (question.Options != null)
                {
                    foreach (var opn in question.Options)
                    {
                        sw.WriteLine(SPLIT_STR);
                        sw.WriteLine(opn);  // 答案选项
                    }
                }

                sw.Close();
            }

            return true;
        }

        public static bool UpdateQuestion(Question question)
        {
            if(false == SaveQuestion(question))
                return false;

            if (question.Id > SystemConfig._maxCount)
            {
                SystemConfig.IniWriteValue("Problems", "MaxProblem", (SystemConfig._maxCount + 1).ToString(), SystemConfig.ConfigPath);
                SystemConfig._maxCount += 1;
                UpdateQuestionList(question, true);
            }
            else
            {
                UpdateQuestionList(question, false);
            }

            //更新MoudleId SkillId到对应文件
            SystemConfig.ProblemToMoudle.Remove(question.Id);
            SystemConfig.ProblemToSkill.Remove(question.Id);

            SystemConfig.ProblemToSkill.Add(question.Id, question.Skill);
            SystemConfig.ProblemToMoudle.Add(question.Id, question.Module);

            SystemConfig.SaveProblemToMoudle();
            SystemConfig.SaveProblemToSkill();
            
            return true;
        }

        private static void UpdateQuestionList(Question question, bool isNew)
        {
            if (true == isNew)
            {
                m_QuestionsList.Add(question);
                return;
            }

            for (int i = 0; i < m_QuestionsList.Count;i++ )
            {
                Question obj = m_QuestionsList[i];
                if (obj.Id != question.Id)
                    continue;

                if (true == Compare(obj, question))
                    return;

                Copy(question, ref obj);

                return;
            }
        }

        private static void Copy(Question questionSrc, ref Question questionDst)
        {
            questionDst.Id = questionSrc.Id;
            questionDst.Tittle = questionSrc.Tittle;
            questionDst.TittleEmphasize = questionSrc.TittleEmphasize;
            questionDst.NormalNotice =questionSrc.NormalNotice;
            questionDst.SkillNotice =questionSrc.SkillNotice;
            questionDst.Module=questionSrc.Module;
            questionDst.Skill=questionSrc.Skill;
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

        public static bool FileCopy(string filePathSrc, string filePathDst)
        {
            try
            {
                byte[] buffer = new byte[1000000];

                if (!File.Exists(filePathSrc))
                    return false;

                var rStream = new FileStream(filePathSrc, FileMode.Open, FileAccess.Read, FileShare.Read);

                var wStream = new FileStream(filePathDst, FileMode.Create, FileAccess.Write, FileShare.Write);

                if (rStream == null)
                {
                    return false;
                }

                long s = wStream.Length, l = rStream.Length;

                int read;
                while (s < l && (read = rStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    wStream.Write(buffer, 0, read);
                    wStream.Flush();
                    s += read;
                }

                rStream.Close();
                wStream.Close();

                return true;
            }
            catch
            {
                MessageBox.Show("拷贝图片或视频信息出错！", "错误提示", MessageBoxButtons.OK);
                return false;
            }
        }

        public static bool DeleteQuestion(Question question)
        {
            //删除只是将模块信息删除，并不会删除文件
            question.Skill = 0;
            question.Module = 0;

            //question.Id += 10000;
            string path = Directory.GetCurrentDirectory() + "\\" + SystemConfig.PathQuestions +"\\" + question.Id.ToString() + ".txt";
            bool isUpdate = false;
            SaveQuestion3(question,out isUpdate, path);

            return true;
        }
        #endregion

    }
}
