using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace DirvingTest
{
    public class ChpaterQuestionManager
    {
        public static int GetChapterQuestionsCount(int chapterType, int chapterId,  int classification, int type, string filter)
        {
            try
            {
                string sql= "select count(1) from question_details where 1=1 ";
                if(chapterId != 0)
                {
                    switch(chapterType)
                    {
                        case 0:
                            if (chapterId != -1)
                                sql += " and chapter_id=@chapter_id";
                            else
                                sql += " and chapter_id is null";
                            break;
                        case 1:
                            if (chapterId != -1)
                                sql += " and skill_id=@chapter_id";
                            else
                                sql += " and skill_id is null";
                            break;
                        case 2:
                            if (chapterId != -1)
                                sql += " and bank_id=@chapter_id";
                            else
                                sql += " and bank_id is null";
                            break;
                        default:
                            return 0;
                    }
                }
                if(type > 0)
                {
                    sql += " and type=@type";
                }

                if(classification > 0)
                {
                    sql += " and classification=@classification";
                }

                if(!string.IsNullOrEmpty(filter))
                {
                    sql += " and tittle like @filter";
                }


                List<SQLiteParameter> listParas = new List<SQLiteParameter>();
                listParas.Add(new SQLiteParameter("@chapter_id", chapterId));
                listParas.Add(new SQLiteParameter("@classification", classification));
                listParas.Add(new SQLiteParameter("@type", type));
                listParas.Add(new SQLiteParameter("@filter", filter));

                object data = SQLiteHelper.SQLiteHelper.ExecuteScalar(sql, listParas.ToArray());
                //return SQLiteHelper.SQLiteHelper.GetDataTable(sql, sqlPara);
                return Convert.ToInt32(data);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static DataTable GetChapterQuestions(int chapterType, int chapterId, int classification, int type, string filter, int pageNum=1, int page=1)
        {
            try
            {
                string sqlHeader = "select id, tittle,";

                //string sql = @"type, cliassfication  from question_details where 1=1 ";

                string sql = @"select * from question_details where 1=1 ";
                if (chapterId != 0)
                {
                    switch (chapterType)
                    {
                        case 0:
                            sqlHeader += " chapter_id as group_id, chapter_name as group_name,";
                            if (chapterId != -1)
                                sql += " and chapter_id=@chapter_id";
                            else
                                sql += " and chapter_id is null";
                            break;
                        case 1:
                            sqlHeader += " skill_id as group_id, skill_name as group_name,";
                            if (chapterId != -1)
                                sql += " and skill_id=@chapter_id";
                            else
                                sql += " and skill_id is null";
                            break;
                        case 2:
                            sqlHeader += " bank_idas group_id, bank_name as group_name,";
                            if (chapterId != -1)
                                sql += " and bank_id=@chapter_id";
                            else
                                sql += " and bank_id is null";
                            break;
                        default:
                            return null;
                    }
                }
                if (type > 0)
                {
                    sql += " and type=@type";
                }

                if (classification > 0)
                {
                    sql += " and classification=@classification";
                }

                if (!string.IsNullOrEmpty(filter))
                {
                    sql += " and tittle like @filter ";
                }

                sql += string.Format(" order by id limit {0} offset {0}*{1}", pageNum, page-1);

                //sql = sqlHeader + sql;

                List<SQLiteParameter> listParas = new List<SQLiteParameter>();
                listParas.Add(new SQLiteParameter("@chapter_id", chapterId));
                listParas.Add(new SQLiteParameter("@classification", classification));
                  listParas.Add(new SQLiteParameter("@type", type));
                listParas.Add(new SQLiteParameter("@filter", filter));

                return SQLiteHelper.SQLiteHelper.GetDataTable(sql, listParas.ToArray());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
