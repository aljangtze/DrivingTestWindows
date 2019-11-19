using System;
using System.Collections.Generic;
////using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;

namespace DirvingTest
{
    class SystemConfig
    {
        public static string ConfigPath = "config.ini";             //INI文件名  

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key,
                    string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def,
                    StringBuilder retVal, int size, string filePath);

        //类的构造函数，传递INI文件名  
        public static void IniWriteValue(string Section, string Key, string Value, string Path)
        {
            WritePrivateProfileString(Section, Key, Value, Path);
        }

        //写INI文件  
        public static string IniReadValue(string Section, string Key, string Path)
        {
            StringBuilder temp = new StringBuilder(1024);
            int i = GetPrivateProfileString(Section, Key, "", temp, 1024, Path);
            return temp.ToString();
        }

        public static SystemConfig getInstance()
        {
            if (m_Instance == null)
            {
                m_Instance = new SystemConfig();
            }

            SystemConfig.InitAllData();

            return m_Instance;
        }

        public static int Subject1MoudleCount;
        public static int Subject2MoudleCount;
        public static int SkillMoudleCount;
        public static int BankMoudleCount;
        public static List<string> Subject1MoudleInfo = new List<string>();
        public static List<string> Subject2MoudleInfo = new List<string>();
        public static List<string> SkillMoudleInfo = new List<string>();
        public static List<string> BankMoudleInfo = new List<string>();
        public static List<string> IntensifyInfo = new List<string>();
        public static SystemConfig m_Instance = null;

        //各种考试的抽题比例
        public static List<int> CarRule = new List<int>();
        public static List<int> TruckRule = new List<int>();
        public static List<int> BusRule = new List<int>();
        public static List<int> Subject2Rule = new List<int>();
        public static List<int> RecoverExamRule = new List<int>();

        //选择、判断、多选题的题目数量
        public static List<int> ProblemTypeCountRuleSubject1 = new List<int>();
        public static List<int> ProblemTypeCountRuleSubject2 = new List<int>();
        public static List<int> ProblemTypeCountRuleRecoverExam = new List<int>();

        public static Dictionary<int, int> ProblemToMoudle;
        public static Dictionary<int, int> ProblemToSkill;

        public static int _examType = 0; //考试类型 0 科目一 1 科目四 2 恢复资格考试
        public static int _driverType = 0; //车辆类型 0 小车 1客车 2货车
        public static int _maxCount = 0;
        
        public static int _maxModuleId = 0;
        public static int _maxSkillId = 0; //技巧相关
        public static int _maxBankId = 0; //套题相关
        public static int _maxIntensifyId = 0; //强化练习
        public static bool _IsLogin = false;
        public static string _StrPassword = "";
        public static string PathImages  = "Images";
        public static string PathFlashs  = "Flash";
        public static string PathQuestions = "Questions";
        public static string PhoneNumber = "";
        public static string WeChart="";
        public static string QQ = "";
        public static string FitYear = "2016";
    
        public static int GetUserType()
        {
            try
            {
                ConfigPath = Directory.GetCurrentDirectory() + "\\" + "config.ini";
                int userType = Convert.ToInt32(IniReadValue("Setting", "SystemUser", ConfigPath));

                return userType;
            }
            catch
            {
                return 0;
            }
            
        }
        
        private static void InitAllData()
        {
            ConfigPath = Directory.GetCurrentDirectory() + "\\" + "config.ini";
            //Subject1MoudleCount = Convert.ToInt32(IniReadValue("Moudle", "Subject1Count", ConfigPath));
            //Subject2MoudleCount = Convert.ToInt32(IniReadValue("Moudle", "Subject2Count", ConfigPath));
            //SkillMoudleCount = Convert.ToInt32(IniReadValue("Moudle", "SikillMoudleCount", ConfigPath));
            _maxCount = Convert.ToInt32(IniReadValue("Problems", "MaxProblem", ConfigPath));
            _maxSkillId = Convert.ToInt32(IniReadValue("Problems", "MaxSkillId", ConfigPath));
            _maxModuleId = Convert.ToInt32(IniReadValue("Problems", "MaxModulId", ConfigPath));
            _maxBankId = Convert.ToInt32(IniReadValue("Problems", "MaxBankId", ConfigPath));
            _maxIntensifyId = Convert.ToInt32(IniReadValue("Problems", "MaxIntensifyId", ConfigPath));


            //for (int i = 1; i <= Subject1MoudleCount; i++)
            //{
            //    string MoudleInfo = IniReadValue("Subject1", "Moudle" + i, ConfigPath);
            //    Subject1MoudleInfo.Add(MoudleInfo);
            //}

            //for (int i = 1; i <= Subject2MoudleCount; i++)
            //{
            //    string MoudleInfo = IniReadValue("Subject2", "Moudle" + i, ConfigPath);
            //    Subject2MoudleInfo.Add(MoudleInfo);
            //}

            for (int i = 1; i <= SkillMoudleCount; i++)
            {
                string MoudleInfo = IniReadValue("SkillInfo", "Skill" + i, ConfigPath);
                SkillMoudleInfo.Add(MoudleInfo);
            }

            string value = IniReadValue("ProblemRule", "Car", ConfigPath);
            string [] valueList = value.Split(',');
            for (int i = 0; i < valueList.Length; i++)
            {
                CarRule.Add(Convert.ToInt32(valueList[i]));
            }

            value = IniReadValue("ProblemRule", "Bus", ConfigPath);
            valueList = value.Split(',');
            for (int i = 0; i < valueList.Length; i++)
            {
                BusRule.Add(Convert.ToInt32(valueList[i]));
            }

            value = IniReadValue("ProblemRule", "Truck", ConfigPath);
            valueList = value.Split(',');
            for (int i = 0; i < valueList.Length; i++)
            {
                TruckRule.Add(Convert.ToInt32(valueList[i]));
            }

            value = IniReadValue("ProblemRule", "Subject2", ConfigPath);
            valueList = value.Split(',');
            for (int i = 0; i < valueList.Length; i++)
            {
                Subject2Rule.Add(Convert.ToInt32(valueList[i]));
            }

            value = IniReadValue("ProblemRule", "RecoverExam", ConfigPath);
            valueList = value.Split(',');
            for (int i = 0; i < valueList.Length;i++ )
            {
                RecoverExamRule.Add(Convert.ToInt32(valueList[i]));
            }
            value = IniReadValue("ProblemTypeCountRule", "Subject1", ConfigPath);
            valueList = value.Split(',');
            for (int i = 0; i < valueList.Length; i++)
            {
                ProblemTypeCountRuleSubject1.Add(Convert.ToInt32(valueList[i]));
            }
            value = IniReadValue("ProblemTypeCountRule", "Subject2", ConfigPath);
            valueList = value.Split(',');
            for (int i = 0; i < valueList.Length; i++)
            {
                ProblemTypeCountRuleSubject2.Add(Convert.ToInt32(valueList[i]));
            }

            value = IniReadValue("ProblemTypeCountRule", "RecoverExam", ConfigPath);
            valueList = value.Split(',');
            for (int i = 0; i < valueList.Length; i++)
            {
                ProblemTypeCountRuleRecoverExam.Add(Convert.ToInt32(valueList[i]));
            }

            _examType = Convert.ToInt32(IniReadValue("Setting", "ExamType", ConfigPath));
            _driverType = Convert.ToInt32(IniReadValue("Setting", "DriverType", ConfigPath));
            //_CarType = Convert.ToInt32(IniReadValue("Setting", "CarType", ConfigPath));
            _StrPassword = IniReadValue("Setting", "UserInfo", ConfigPath);
            PhoneNumber = IniReadValue("Setting", "PhoneNumber", ConfigPath);
            WeChart = IniReadValue("Setting", "WeChart", ConfigPath);
            QQ = IniReadValue("Setting", "QQ", ConfigPath);
            FitYear = IniReadValue("Setting", "Year", ConfigPath);

            //LoadProblemToMoudle();
            //LoadProblemToSkill();
        }

        private static void LoadProblemToMoudle()
        {
            var file = File.Open("ProblemToMoudle.txt", FileMode.Open);
            ProblemToMoudle = new Dictionary<int, int>();
            using (var stream = new StreamReader(file))
            {
                while (!stream.EndOfStream)
                {
                    string txtLine = stream.ReadLine();
                    if (string.IsNullOrEmpty(txtLine))
                        continue;

                    string[] splitStr = Regex.Split(txtLine, "==>");
                    ProblemToMoudle.Add(Convert.ToInt32(splitStr[0]), Convert.ToInt32(splitStr[1]));
                }
            }

            file.Close();
        }
        private static void LoadProblemToSkill()
        {
            var file = File.Open("ProblemToSkill.txt", FileMode.Open);
            ProblemToSkill = new Dictionary<int, int>();
            using (var stream = new StreamReader(file))
            {
                while (!stream.EndOfStream)
                {
                    string txtLine = stream.ReadLine();

                    if (string.IsNullOrEmpty(txtLine))
                        continue;

                    string[] splitStr = Regex.Split(txtLine, "==>");
                    

                    ProblemToSkill.Add(Convert.ToInt32(splitStr[0]), Convert.ToInt32(splitStr[1]));
                }
            }

            file.Close();
        }

        public static void SaveProblemToMoudle()
        {
            FileStream aFile = new FileStream("ProblemToMoudle.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFile);
            foreach(var item in ProblemToMoudle)
            {
                sw.WriteLine(item.Key.ToString() + "==>" +item.Value.ToString());
            }

            sw.Close();
        }
        
        public static  void SaveProblemToSkill()
        {
            FileStream aFile = new FileStream("ProblemToSkill.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFile);
            foreach (var item in ProblemToSkill)
            {
                sw.WriteLine(item.Key.ToString() + "==>" + item.Value.ToString());
            }

            sw.Close();
        }

        public static void SaveModelId()
        {
            IniWriteValue("Problems", "MaxSkillId", _maxSkillId.ToString(), ConfigPath);
            IniWriteValue("Problems", "MaxModulId", _maxModuleId.ToString(), ConfigPath);
            IniWriteValue("Problems", "MaxBankId", _maxBankId.ToString(), ConfigPath);
            IniWriteValue("Problems", "MaxIntensifyId", _maxBankId.ToString(), ConfigPath);
        }
    }
}
