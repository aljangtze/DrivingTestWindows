using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
////using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DirvingTest
{
    public class ModelChapter : IComparable
    {
        public int Id = -1;
        public string Tittle = "";
        public bool IsEnable = true;
        public int Classification = 0;
        public int Count = 0;
        public override string ToString()
        {
            return Tittle.ToString();
        }

        public int CompareTo(object obj)
        {
            return Tittle.CompareTo(((ModelChapter)obj).Tittle);
        }
    }

    class ModelManager
    {
        #region 技巧管理
        public static Dictionary<int, ModelChapter> m_DicSkillList = null;
        public static Dictionary<int, ModelChapter> m_DicMoudleList = null;
        public static Dictionary<int, ModelChapter> m_DicBankList = null;
        public static Dictionary<int, ModelChapter> m_DicIntensifyList = null;

        //public static Dictionary<int, string> m_DicSkillList = null;
        //public static Dictionary<int, string> m_DicMoudleList = null;
        public const string _PathModule = "ChapterList.txt";
        public const string _PathSkill = "SkillList.txt";
        public const string _PathBank = "BankList.ini";
        public const string _PathEasyError = "IntensifyChapterList.ini";

        public static bool GetListModel()
        {
            try
            {
                m_DicSkillList = GetListFromFile(_PathSkill);
                m_DicMoudleList = GetListFromFile(_PathModule);
                m_DicBankList = GetListFromFile(_PathBank);
                m_DicIntensifyList = GetListFromFile(_PathEasyError);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取技巧信息失败，请检测配置文件！" + ex.ToString(), "错误提示", MessageBoxButtons.OK);
                return false;
            }
        }

        public static Dictionary<int, ModelChapter> GetListFromFile(string filePath)
        {
            Dictionary<int, ModelChapter> m_List = new Dictionary<int, ModelChapter>();

            var file = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            using (var stream = new StreamReader(file, Encoding.UTF8))
            {
                while (!stream.EndOfStream)
                {
                    string txtLine = stream.ReadLine();
                    if (string.IsNullOrEmpty(txtLine))
                        continue;

                    if (txtLine.IndexOf("====&&====") != -1)
                        continue;

                    ModelChapter model = new ModelChapter();

                    string[] splitStr = Regex.Split(txtLine, "==>");
                    model.Id = Convert.ToInt32(splitStr[0]);
                    model.Tittle = splitStr[1];
                    model.IsEnable = "1" == splitStr[2] ? true : false;
                    model.Classification = Convert.ToInt32(splitStr[3]);
                    model.Count = Convert.ToInt32(splitStr[4]);
                    m_List.Add(model.Id, model);
                }
            }

            file.Close();
            return m_List;

        }

        public static bool SetListToFile(Dictionary<int, ModelChapter> modelList, string filePath)
        {
            FileStream aFile = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(aFile);
            foreach (var model in modelList)
            {
                string txtLine = model.Key.ToString();
                txtLine += "==>";
                txtLine += model.Value.Tittle;
                txtLine += "==>";
                txtLine += model.Value.IsEnable ? 1 : 0;
                txtLine += "==>";
                txtLine += model.Value.Classification;
                txtLine += "==>";
                txtLine += model.Value.Count.ToString();

                sw.WriteLine(txtLine);
            }

            sw.Close();

            return true;
        }

        public static bool AddModelToList(ModelChapter model, Dictionary<int, ModelChapter> modelList, out bool isReplace)
        {
            isReplace = false;
            foreach (var tmp in modelList)
            {
                
                if (tmp.Key== model.Id)
                {
                    isReplace = true;
                    tmp.Value.Tittle = model.Tittle;
                    tmp.Value.IsEnable = model.IsEnable;
                    tmp.Value.Classification = model.Classification;
                    return true;
                }
            }

            modelList.Add(model.Id, model);

            return true;
        }

        public static bool DelModelFromList(int modelId, Dictionary<int, ModelChapter> modelList)
        {
            foreach (var model in modelList)
            {
                if (model.Key== modelId)
                {
                    modelList.Remove(modelId);
                    return true;
                }
            }

            return true;
        }
        #endregion
    }
}
