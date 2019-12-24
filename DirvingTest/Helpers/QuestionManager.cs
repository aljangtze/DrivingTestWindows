using EasyConfig;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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

    public class QuestionManager
    {
        /// <summary>
        /// 所有题目列表
        /// </summary>
        public static List<Question> m_QuestionsList = new List<Question>();

        /// <summary>
        /// 单选题列表
        /// </summary>
        public static List<Question> m_SelectedOneList = new List<Question>();

        /// <summary>
        /// 判断题列表
        /// </summary>
        public static List<Question> m_ChargeOneList = new List<Question>();

        /// <summary>
        /// 多选题列表
        /// </summary>
        public static List<Question> m_SelectedMultList = new List<Question>();

        /// <summary>
        /// 所有题目的id对应字典
        /// </summary>
        public static ConcurrentDictionary<int, Question> m_QuestionsDictionary = new ConcurrentDictionary<int, Question>();

        /// <summary>
        /// 题目目与技巧之间的关系列表，字典存储
        /// </summary>
        /// 
        public static SerializableDictionary<int, int> m_Relation_Question_Skill = new SerializableDictionary<int, int>();

        /// <summary>
        /// 题目与套题练习分组
        /// </summary>
        public static SerializableDictionary<int, int> m_Relation_Question_Suite = new SerializableDictionary<int, int>();

        /// <summary>
        /// 题目与易错题练习分组
        /// </summary>
        public static SerializableDictionary<int, int> m_Relation_Question_Intensity = new SerializableDictionary<int, int>();

        [Obsolete]
        /// <summary>
        /// </summary>
        public static string g_QuestionDir = "Images";
        //static int QUESTION_NUM = 0;
        static readonly Random rnd = new Random(Guid.NewGuid().GetHashCode());

        /// <summary>
        /// 科目一考试的各个章节题目数
        /// </summary>
        [Obsolete]
        static Array ArrayQuestionByMoudleSubject1;
        [Obsolete]
        /// <summary>
        /// 科目二考试的各个章节题目数
        /// </summary>
        static Array ArrayQuestionByMoudleSubject2;
        [Obsolete]
        static Array ArrayQuestionBySkill;
        /// <summary>
        /// 最大题目编号
        /// </summary>
        public static int _maxQuestionNum = 0;
        [Obsolete]
        /// <summary>
        /// 分隔符
        /// </summary>
        internal const string SPLIT_STR = "======================";

        static Regex regImgFile = new Regex(@"\[\[(.*?)\]\]", RegexOptions.Compiled);

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
            string txt = File.ReadAllText(filePath);

            Question question = new Question();
            question.Id = Convert.ToInt32(configFile.SettingGroups["QuesitonInfo"].Settings["Id"].RawValue);
            try
            {
                question.Url = configFile.SettingGroups["QuesitonInfo"].Settings["Url"].RawValue;
            }
            catch
            {
                question.Url = "";
            }
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

#if _SaveToSqlite
                //HACK:这里不随机
                questionOrder.Clear();
                questionOrder.Add(1);
                questionOrder.Add(2);
                questionOrder.Add(3);
                questionOrder.Add(4);
#endif
                int index = 0;
                foreach (var i in questionOrder)
                {
                    index++;
                    question.Options.Add(configFile.SettingGroups["Options"].Settings["Options" + i.ToString()].RawValue);
                    question.OptionsEmphasize.Add(configFile.SettingGroups["Options"].Settings["Image" + i.ToString()].RawValue);
#if! _SaveToSqlite
                    if ("1".Equals(configFile.SettingGroups["AnswerInfo"].Settings["Answer" + i.ToString()].RawValue))
                        question.CorrectAnswer.Add(index);
#else
                    //HACK:
                    question.CorrectAnswer.Add(Convert.ToInt32(configFile.SettingGroups["AnswerInfo"].Settings["Answer" + i.ToString()].RawValue));
#endif
                }
            }
            else
            {
                for (int i = 1; i <= 4; i++)
                {
                    question.Options.Add(configFile.SettingGroups["Options"].Settings["Options" + i.ToString()].RawValue);
                    question.OptionsEmphasize.Add(configFile.SettingGroups["Options"].Settings["Image" + i.ToString()].RawValue);
#if! _SaveToSqlite
                    if ("1".Equals(configFile.SettingGroups["AnswerInfo"].Settings["Answer" + i.ToString()].RawValue))
                        question.CorrectAnswer.Add(i);
#else
                    //HACK:
                    question.CorrectAnswer.Add(Convert.ToInt32(configFile.SettingGroups["AnswerInfo"].Settings["Answer" + i.ToString()].RawValue));
#endif
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

        public static void GetRealationShipFromDB(int type)
        {
            try
            {
                Dictionary<int, ChapterInfo> m_List = new Dictionary<int, ChapterInfo>();
                string sql = @"SELECT r.* FROM group_questions r
                                left join groups g on g.id = r.group_id
                                left join questions q on q.id = r.question_id
                                where r.type = @type";
                DataTable data = SQLiteHelper.SQLiteHelper.GetDataTable(sql, new SQLiteParameter[] { new SQLiteParameter("@type", type) });
                foreach (DataRow row in data.Rows)
                {
                    int chapterId = Convert.ToInt32(row["group_id"].ToString());
                    int questionId = Convert.ToInt32(row["question_id"].ToString());
                    if (type == 2)
                        m_Relation_Question_Suite[questionId] = chapterId;
                    if (type == 1)
                        m_Relation_Question_Skill[questionId] = chapterId;
                    if (type == 3)
                        m_Relation_Question_Intensity[questionId] = chapterId;
                }
            }
            catch
            {
                return;
            }


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
                //initParams();

                m_QuestionsList.Clear();
                m_QuestionsDictionary.Clear();

                GetQuestionsFromDB();

                QuestionManager.GetRealationShipFromDB(1);
                QuestionManager.GetRealationShipFromDB(2);

                //QUESTION_NUM = m_QuestionsList.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private static bool GetQuestionsFromDB()
        {
            QuestionManager.m_QuestionsDictionary.Clear();
            QuestionManager.m_QuestionsList.Clear();

            DataTable data = SQLiteHelper.SQLiteHelper.GetDataTable("select * from questions where 1=@data", new SQLiteParameter[] { new SQLiteParameter("@data", 1) });
            foreach (DataRow row in data.Rows)
            {
                Question question = new Question();
                question.Id = Convert.ToInt32(row["id"].ToString());
                question.Tittle = row["tittle"].ToString();
                if (!string.IsNullOrEmpty(row["image"].ToString()))
                {

                    string imagePath = string.Format("{0}.jpg", question.Id);

                    if (!File.Exists("Images\\" + imagePath))
                    {
                        FileStream imageStream = new FileStream("Images\\" + imagePath, FileMode.Create);
                        Byte[] imageByte = (Byte[])row["image"];
                        imageStream.Write(imageByte, 0, imageByte.Length);
                        imageStream.Close();
                    }
                    question.ImagePath = imagePath;
                }
                else
                {
                    question.ImagePath = "";
                }

                question.FlashPath = row["flash"].ToString();

                if (!string.IsNullOrEmpty(row["flash"].ToString()))
                {
                    string flashPath = string.Format("{0}.swf", question.Id);

                    if (!File.Exists("Flash\\" + flashPath))
                    {
                        FileStream imageStream = new FileStream("Flash\\" + flashPath, FileMode.Create);
                        Byte[] imageByte = (Byte[])row["flash"];
                        imageStream.Write(imageByte, 0, imageByte.Length);
                        imageStream.Close();
                    }
                    question.FlashPath = flashPath;
                }
                else
                {
                    question.FlashPath = "";
                }

                question.Type = Convert.ToInt32(row["type"].ToString()); ;
                question.Module = Convert.ToInt32(row["moudle"].ToString());
                question.Classification = Convert.ToInt32(row["classification"].ToString());
                question.Options = new List<string>();
                question.OptionsEmphasize = new List<string>();
                question.CorrectAnswer = new List<int>();

                if (question.Type != 1)
                {
                    Random rnd = new Random();
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
                        question.Options.Add(row["option" + i.ToString()].ToString());
                        question.OptionsEmphasize.Add(row["option" + i.ToString() + "Emphasize"].ToString());
                        if ("1".Equals(row["answer" + i.ToString()].ToString()))
                            question.CorrectAnswer.Add(index);

                    }
                }
                else
                {
                    for (int i = 1; i <= 4; i++)
                    {
                        question.Options.Add(row["option" + i.ToString()].ToString());
                        question.OptionsEmphasize.Add(row["option" + i.ToString() + "Emphasize"].ToString());
                        if ("1".Equals(row["answer" + i.ToString()].ToString()))
                            question.CorrectAnswer.Add(i);
                    }
                }

                question.TittleEmphasize = row["tittleEmphasize"].ToString(); ;
                question.SkillNotice = row["skillEmphasize"].ToString(); ;
                question.NormalNotice = row["notice"].ToString();

                QuestionManager.m_QuestionsDictionary[question.Id] = question;
                QuestionManager.m_QuestionsList.Add(question);
            }

            return true;
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

                    if (question.Id != i)
                    {
                        int x = 100;
                    }
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

        #region 生成题目
        /// <summary>
        /// 依据选中的考试类型和题目类型，从题库中抽取题目
        /// </summary>
        /// <param name="examType"></param>
        /// <param name="driverType"></param>
        /// <returns></returns>
        public static List<Question> GenQuestionsByExam(int examType, int driverType)
        {
            List<Question> questionList = new List<Question>();
            Dictionary<int, int> rule = new Dictionary<int, int>();
            Dictionary<int, int> currentQuestion = new Dictionary<int, int>();
            //0 C1 科目一,考试,消分考试
            if (examType == 0 || examType == 3)
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
                else if (driverType == 2)
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
                else if (driverType == 3)
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
        /// 生成判断题目
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

            List<Question> tempQuestionList = new List<Question>();
            foreach (Question question in m_QuestionsList)
            {
                int chapterId = question.Module;
                int count = 0;
                if (true == rule.TryGetValue(chapterId, out count))
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
                rule[14] = 50;
                moduleId = 14;
            }


            List<Question> tempQuestionsList = new List<Question>();
            foreach (Question question in m_QuestionsList)
            {
                if (question.Module == moduleId)
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
        /// 判断生成的题目是否满足条件，
        /// </summary>
        /// <returns>是否需要重新抽题</returns>
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

        #endregion

        #region 获取章节、套题中的题目
        /// <summary>
        /// 获取某类技巧所有题目列表 
        /// </summary>
        /// <param name="skillId"></param>
        /// <returns></returns>
        public static List<Question> GenQuestionBySkill(int skillId)
        {
            //使用新的方法进行获取
            return GenQuestionFromRelation(skillId, QuestionManager.m_Relation_Question_Skill);
        }

        /// <summary>
        /// 获取某类套题所有题目列表
        /// </summary>
        /// <param name="bankId"></param>
        /// <returns></returns>
        public static List<Question> GenQuestionByBankId(int bankId)
        {
            //使用新的方法进行获取
            return GenQuestionFromRelation(bankId, QuestionManager.m_Relation_Question_Suite);
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

        public static List<Question> GetQuestionsFromDB(int group_id)
        {
            List<Question> list = new List<Question>();
            try
            {
                List<int> questionList = new List<int>();
                string sql = @"select * from group_questions where group_id=@group_id";
                DataTable data = SQLiteHelper.SQLiteHelper.GetDataTable(sql, new SQLiteParameter[] { new SQLiteParameter("@group_id", group_id) });
                foreach (DataRow row in data.Rows)
                {
                    questionList.Add(Convert.ToInt32(row["question_id"]));
                }

                return GetQuestionListWidthList(questionList);
            }
            catch (Exception ex)
            {
                return list;
            }
        }

        public static List<Question> GetErrorQuestionFromDB(ChapterInfo chapterInfo)
        {   
            List<Question> list = new List<Question>();
            try
            {
                if (string.IsNullOrEmpty(chapterInfo.ChapterSqlString))
                    return list;

                List<int> questionList = new List<int>();
                string sql = string.Format(chapterInfo.ChapterSqlString, UserManager.LoginUser.ID, chapterInfo.Classification, chapterInfo.SqlParamter);
                DataTable data = SQLiteHelper.SQLiteHelper.GetDataTable(sql, new SQLiteParameter[] { new SQLiteParameter("@user_id", UserManager.LoginUser.ID) });

                foreach (DataRow row in data.Rows)
                {
                    questionList.Add(Convert.ToInt32(row["question_id"]));
                }

                return GetQuestionListWidthList(questionList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return list;
            }
        }


        private static List<Question> GetQuestionListWidthList(List<int> idList)
        {
            List<Question> list = new List<Question>();
            foreach (int question_id in idList)
            {
                m_QuestionsDictionary.TryGetValue(question_id, out Question question);
                list.Add(question);
            }
            return list;
        }

        #endregion

        #region 过时的函数
        [Obsolete]
        static void AnalysizeQuestion(string Text, out string Title, out List<int> CorrectAnswer, out List<string> Options, out int Type)
        {
            Title = "";
            CorrectAnswer = new List<int>();
            Options = new List<string>();
            Type = 0;
        }


        [Obsolete]
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

        [Obsolete]
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


        /// <summary>
        /// 获取某类强化练习所有题目列表
        /// </summary>
        /// <param name="intensifyId"></param>
        /// <returns></returns>
        public static List<Question> GenQuestionByIntensifyId(int intensifyId)
        {
            //使用新的方法进行获取
            return GenQuestionFromRelation(intensifyId, QuestionManager.m_Relation_Question_Suite);
        }

        [Obsolete]
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

        [Obsolete]
        /// <summary>
        /// 将skillID转成描述信息
        /// </summary>
        /// <param name="SkillId"></param>
        /// <returns></returns>
        public static string SkillToString(int SkillId)
        {
            if (0 == SkillId || SkillId > SystemConfig.SkillMoudleCount)
                return "未分类";

            return SystemConfig.SkillMoudleInfo[SkillId - 1];
        }

        [Obsolete]
        public static string BankIdToString(int BankId)
        {
            if (0 == BankId || BankId > SystemConfig.BankMoudleCount)
                return "未分类";

            return SystemConfig.SkillMoudleInfo[BankId - 1];
        }

        [Obsolete]
        public static string IntensifyIdToString(int IntensifyId)
        {
            if (0 == IntensifyId || IntensifyId > SystemConfig.SkillMoudleCount)
                return "未分类";

            return SystemConfig.IntensifyInfo[IntensifyId - 1];
        }

        [Obsolete]
        public static string MoudleToString(int MoudleId)
        {
            if (MoudleId == 0 || MoudleId > SystemConfig.Subject1MoudleCount + SystemConfig.Subject2MoudleCount)
                return "未分类";

            if (MoudleId <= SystemConfig.Subject1MoudleCount)
            {
                return SystemConfig.Subject1MoudleInfo[MoudleId - 1];
            }
            else
            {
                return SystemConfig.Subject2MoudleInfo[MoudleId - SystemConfig.Subject1MoudleCount - 1];
            }
        }

        [Obsolete]
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

            if (question1.Options == null || question2.Options == null)
            {
                if (question1.Options != question2.Options)
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

        [Obsolete]
        public static Question ComposeQuestion(string strTitle, string strTittleEmphasize, string strNomalExplain, string strSkillExplain,
                int MoudleId, int SkillId, string strImagePath, string strFlashPath, int corectAnswer, List<string> Options)
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
            if (Options != null)
            {
                question.Type = 0;
                question.Options = new List<string>();
                foreach (var option in Options)
                {
                    question.Options.Add(option);
                }
            }

            return question;
        }
        #endregion

        #region 增、删、改、查题目信息
        /// <summary>
        /// 保存题目
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        private static bool SaveQuestion(Question question)
        {
            string newFile = Directory.GetCurrentDirectory() + "//Questions//" + question.Id + ".txt";
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

        /// <summary>
        /// 删除题目，删除时，只是设置为禁用
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public static bool DeleteQuestion(Question question)
        {
            //删除只是将模块信息删除，并不会删除文件
            question.Skill = 0;
            question.Module = 0;

            //question.Id += 10000;
            string path = Directory.GetCurrentDirectory() + "\\" + SystemConfig.PathQuestions + "\\" + question.Id.ToString() + ".txt";
            bool isUpdate = false;
            SaveQuestion(question, out isUpdate, path);

            return true;
        }

        [Obsolete]
        /// <summary>
        /// 保存题目信息
        /// </summary>
        /// <param name="question"></param>
        /// <param name="isUpdate"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool SaveQuestion(Question question, out bool isUpdate, string path)
        {
            try
            {
                isUpdate = false;
                foreach (var ques in m_QuestionsList)
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

                for (int i = 0; i < question.CorrectAnswer.Count; i++)
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

        /// <summary>
        /// 更新题目
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public static bool UpdateQuestion(Question question)
        {
            if (false == SaveQuestion(question))
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

        /// <summary>
        /// 更新题目列表
        /// </summary>
        /// <param name="question"></param>
        /// <param name="isNew"></param>
        private static void UpdateQuestionList(Question question, bool isNew)
        {
            if (true == isNew)
            {
                m_QuestionsList.Add(question);
                return;
            }

            for (int i = 0; i < m_QuestionsList.Count; i++)
            {
                Question obj = m_QuestionsList[i];
                if (obj.Id != question.Id)
                    continue;

                if (true == Compare(obj, question))
                    return;

                question.Copy(ref obj);

                return;
            }
        }
        #endregion

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


        /// <summary>
        /// 记录题目的结果
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="isRight"></param>
        /// <returns></returns>
        public static bool RecordQuestionAnswer(int question_id, bool isRight = true)
        {
            if (UserManager.LoginUser.ID <= 0 && UserManager.IsLogin == false)
            {
                return true;
            }

            bool isExists = IsRecordExists(question_id, UserManager.LoginUser.ID);
            int result = 0;
            if (isExists)
            {
                string sql = "";
                if (isRight == true)
                    sql = @"update answers set answerNumber=answerNumber+1, rightNumber=rightNumber+1 ";
                else
                    sql = @"update answers set answerNumber=answerNumber+1, errorNumber=errorNumber+1 ";

                sql = sql + " where question_id=@question_id and user_id=@user_id";
                result = SQLiteHelper.SQLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter[] { new SQLiteParameter("@question_id", question_id), new SQLiteParameter("@user_id", UserManager.LoginUser.ID) });
            }
            else
            {
                string sql = "";
                if (isRight)
                {
                    sql = @"insert into answers (question_id, user_id, answerNumber, rightNumber, lastupdatetime) values (@question_id, @user_id, 1, @rightNumber, @lastupdatetime)";
                    result = SQLiteHelper.SQLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter[] { new SQLiteParameter("@question_id", question_id), new SQLiteParameter("@user_id", UserManager.LoginUser.ID), new SQLiteParameter("@rightNumber", 1), new SQLiteParameter("@lastupdatetime", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")) });
                }
                else
                {
                    sql = @"insert into answers (question_id, user_id, answerNumber, errorNumber, lastupdatetime) values (@question_id, @user_id, 1, @errorNumber, @lastupdatetime)";
                    result = SQLiteHelper.SQLiteHelper.ExecuteNonQuery(sql, new SQLiteParameter[] { new SQLiteParameter("@question_id", question_id), new SQLiteParameter("@user_id", UserManager.LoginUser.ID), new SQLiteParameter("@errorNumber", 1), new SQLiteParameter("@lastupdatetime", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")) });
                }
            }



            return result > 0;
        }

        private static bool IsRecordExists(int question_id, int user_id)
        {
            string sql = @"select * from answers where question_id=@question_id and user_id=@user_id";
            DataTable data = SQLiteHelper.SQLiteHelper.GetDataTable(sql, new SQLiteParameter[] { new SQLiteParameter("@question_id", question_id), new SQLiteParameter("@user_id", user_id) });
            return data.Rows.Count > 0;
        }
    }
}
