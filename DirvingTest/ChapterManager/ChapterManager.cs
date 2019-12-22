using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace DirvingTest
{
    public class ChapterManager
    {
        /// <summary>
        /// 获取支持的章节类型列表
        /// </summary>
        /// <param name="chapterTypeList"></param>
        /// <returns></returns>
        public bool GetChapterTypeList(out List<ChapterType> chapterTypeList)
        {
            chapterTypeList = new List<ChapterType>();
            try
            {
                string sql = @"select * from group_type where 1=@data";
                DataTable data = SQLiteHelper.SQLiteHelper.GetDataTable(sql, new SQLiteParameter[] { new SQLiteParameter("@data", 1) });
                foreach (DataRow row in data.Rows)
                {
                    ChapterType typeData = new ChapterType();
                    typeData.ID = Convert.ToInt32(row["id"].ToString());
                    typeData.Name = row["name"].ToString();
                    chapterTypeList.Add(typeData);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool GetChapterList(int type, out DataTable data)
        {
            data = null;
            try
            {
                Dictionary<int, ChapterInfo> m_List = new Dictionary<int, ChapterInfo>();
                string sql = @"select  g.sql, g.sql_parameter, g.id,g.name, g.type, g.classification as classification_id, g.status, count(gq.question_id) as count, g.name as classification_name, gt.name as group_type from groups as g 
                            left join group_questions as gq on gq.group_id=g.id and gq.type=g.type
							left join classfication as c on g.classification=c.id
							left join group_type as gt on g.type = gt.id
                                where g.type=@type group by g.id,g.name,g.type, g.classification, g.status order by g.name";
                data = SQLiteHelper.SQLiteHelper.GetDataTable(sql, new SQLiteParameter[] { new SQLiteParameter("@type", type) });
                
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }


        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool GetChapterList(int type, out List<ChapterInfo> chapterInfos)
        {
            chapterInfos = new List<ChapterInfo>();
            try
            {
                Dictionary<int, ChapterInfo> m_List = new Dictionary<int, ChapterInfo>();
                string sql = @"select g.sql, g.sql_parameter, g.id,g.name, g.type, g.classification as classification_id, g.status, count(gq.question_id) as count, g.name as classification_name, gt.name as group_type from groups as g 
                            left join group_questions as gq on gq.group_id=g.id and gq.type=g.type
							left join classfication as c on g.classification=c.id
							left join group_type as gt on g.type = gt.id
                                where g.type=@type group by g.id,g.name,g.type, g.classification, g.status order by g.id";
                DataTable data = SQLiteHelper.SQLiteHelper.GetDataTable(sql, new SQLiteParameter[] { new SQLiteParameter("@type", type) });

                foreach (DataRow row in data.Rows)
                {
                    ChapterInfo modelChapter = new ChapterInfo();
                    modelChapter.ID = Convert.ToInt32(row["id"].ToString());
                    modelChapter.Classification = Convert.ToInt32(row["classification_id"].ToString());
                    modelChapter.IsEnable = row["status"].ToString() == "1";
                    modelChapter.Name = row["name"].ToString();
                    modelChapter.Count = Convert.ToInt32(row["count"].ToString());
                    modelChapter.ChapterType = Convert.ToInt32(row["type"].ToString());
                    modelChapter.ChapterSqlString = row["sql"].ToString();
                    modelChapter.SqlParamter = row["sql_parameter"].ToString();
                    string classficationName = row["classification_name"].ToString();

                    chapterInfos.Add(modelChapter);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 判断分组是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool IsChapterExists(int id)
        {
            string sql = @"select * from groups where id=@id";
            DataTable data = SQLiteHelper.SQLiteHelper.GetDataTable(sql, new SQLiteParameter[] { new SQLiteParameter("@id", id)});
            return data.Rows.Count > 0;
        }

        public bool AddChapter(ChapterInfo chapter)
        {
            try
            {
                string sqlString = @"insert into groups (name, type, status, count, classification)
                                values
                                (@name, @type, 1, @count, @classification)";

                List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                parameters.Add(new SQLiteParameter("@name", chapter.Name));
                parameters.Add(new SQLiteParameter("@type", chapter.ChapterType));
                parameters.Add(new SQLiteParameter("@count", chapter.Count));
                parameters.Add(new SQLiteParameter("@classification", chapter.Classification));

                int result = SQLiteHelper.SQLiteHelper.ExecuteNonQuery(sqlString, parameters.ToArray());
                if (result <= 0)
                {
                    Console.WriteLine("Error" + chapter.ID);
                    //MessageBox.Show(ques)
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateChapter(ChapterInfo chapter)
        {
            try
            {
                string sqlString = @"update groups set name=@name, type=@type, status=@status, count=@count, classification=@classification where id=@id";

                //SQLiteParameter[] parameters = new SQLiteParameter[23];
                List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                parameters.Add(new SQLiteParameter("@id", chapter.ID));
                parameters.Add(new SQLiteParameter("@name", chapter.Name));
                parameters.Add(new SQLiteParameter("@status", chapter.IsEnable ? 1 : 0));
                parameters.Add(new SQLiteParameter("@type", chapter.ChapterType));
                parameters.Add(new SQLiteParameter("@count", chapter.Count));
                parameters.Add(new SQLiteParameter("@classification", chapter.Classification));

                int result = SQLiteHelper.SQLiteHelper.ExecuteNonQuery(sqlString, parameters.ToArray());
                if (result <= 0)
                {
                    Console.WriteLine("Error" + chapter.ID);
                    //MessageBox.Show(ques)
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteChapter(ChapterInfo chapter)
        {
            try
            {
                if (!IsChapterExists(chapter.ID))
                {
                    return true;
                }

                string sql = @"delete from groups where id=@id";
                List<SQLiteParameter> listPara = new List<SQLiteParameter>();
                listPara.Add(new SQLiteParameter("@id", chapter.ID));

                int result = SQLiteHelper.SQLiteHelper.ExecuteNonQuery(sql, listPara.ToArray());
                string sqlRelation= @"delete from group_questions where group_id=@id";
                listPara.Clear();
                listPara.Add(new SQLiteParameter("@id", chapter.ID));
                SQLiteHelper.SQLiteHelper.ExecuteNonQuery(sqlRelation, listPara.ToArray());

                return result >= 1;
            }
            catch
            {
                return false;
            }
        }
    }
}
