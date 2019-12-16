using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DirvingTest
{
    public class ModelManager
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

        /// <summary>
        /// 获取所有的列表
        /// </summary>
        /// <returns></returns>
        public static bool GetListModel()
        {
            try
            {
                //TODO:这里使用数据库获取数据
                //m_DicSkillList = GetListFromFile(_PathSkill);
                //m_DicMoudleList = GetListFromFile(_PathModule);
                //m_DicBankList = GetListFromFile(_PathBank);
                //m_DicIntensifyList = GetListFromFile(_PathEasyError);
                m_DicMoudleList = GetChapterListFromDB(0);
                m_DicBankList = GetChapterListFromDB(2);
                m_DicSkillList = GetChapterListFromDB(1);
                m_DicIntensifyList = GetChapterListFromDB(3);
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

        /// <summary>
        /// 从数据库获取列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Dictionary<int, ModelChapter>GetChapterListFromDB(int type)
        {
            Dictionary<int, ModelChapter> m_List = new Dictionary<int, ModelChapter>();
            string sql = @"select g.id,g.name, g.type, g.classification, g.status, count(gq.question_id) as count from groups as g 
                            left join group_questions as gq on gq.group_id=g.id and gq.type=g.type
                                where g.type=@type group by g.id,g.name,g.type, g.classification, g.status";
            DataTable data = SQLiteHelper.SQLiteHelper.GetDataTable(sql, new SQLiteParameter[] { new SQLiteParameter("@type", type) });
            foreach (DataRow row in data.Rows)
            {
                ModelChapter modelChapter = new ModelChapter();
                modelChapter.Id = Convert.ToInt32(row["id"].ToString());
                modelChapter.Classification = Convert.ToInt32(row["classification"].ToString());
                modelChapter.IsEnable = row["status"].ToString() =="1";
                modelChapter.Tittle = row["name"].ToString();
                modelChapter.Count= Convert.ToInt32(row["count"].ToString());
                
                m_List.Add(modelChapter.Id, modelChapter);
            }

            return m_List;
        }

        [Obsolete]
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

        /// <summary>
        /// 更新添加或更新的章节信息到列表中
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modelList"></param>
        /// <param name="isReplace"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 从列表中删除章节信息
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="modelList"></param>
        /// <returns></returns>
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
