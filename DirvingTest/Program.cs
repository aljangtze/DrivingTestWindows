using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Threading;
////using System.Linq;
using System.Windows.Forms;

namespace DirvingTest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ThreadPool.SetMaxThreads (20, 12);

            SystemConfig sysConfig = SystemConfig.getInstance();
            QuestionManager.LoadAllQuestion();
            //QuestionManager.LoadQuestion(2001, 2001);

            //for (int i = 0; i < QuestionManager._maxQuestionNum; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), i);
            //    //i = i + 500;
            //}
            QuestionManager.m_QuestionsList.Clear();
            QuestionManager.m_QuestionsDictionary.Clear();

#if _InitailQuestionWithFile
            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), new ThreadParam(1001,1500));
            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), new ThreadParam(2001, 2400));
            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), new ThreadParam(3001, 3400));
            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), new ThreadParam(4001, 4200));
            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), new ThreadParam(5001, 5200));
            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), new ThreadParam(6001, 6200));
            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), new ThreadParam(7001, 7100));
            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), new ThreadParam(8001, 8400));
            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), new ThreadParam(9001, 9300));
            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), new ThreadParam(10001, 10200));
            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), new ThreadParam(11001, 11300));
            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), new ThreadParam(12001, 12200));
            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), new ThreadParam(13001, 13100));
            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), new ThreadParam(13101, 15250));
            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), new ThreadParam(15251, 16000));
            //ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), new ThreadParam(16001, QuestionManager._maxQuestionNum));
            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), new ThreadParam(16001, 17000));
#else
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

                //TODO：统计对应的章节列表
                #region 统计对应的章节列表
                //try
                //{
                //    question.Skill = Convert.ToInt32(configFile.SettingGroups["QuesitonInfo"].Settings["SkillId"].RawValue);
                //    if (0 != question.Skill)
                //    {
                //        m_Relation_Question_Skill[question.Id] = question.Skill;
                //    }
                //}
                //catch
                //{
                //    question.Skill = 0;
                //}

                //try
                //{
                //    question.BankId = Convert.ToInt32(configFile.SettingGroups["QuesitonInfo"].Settings["BankId"].RawValue);
                //    if (0 != question.BankId)
                //    {
                //        m_Relation_Question_Suite[question.Id] = question.BankId;
                //    }
                //}
                //catch
                //{
                //    question.BankId = 0;
                //}

                //try
                //{
                //    question.IntensifyId = Convert.ToInt32(configFile.SettingGroups["QuesitonInfo"].Settings["IntensifyId"].RawValue);
                //}
                //catch
                //{
                //    question.IntensifyId = 0;
                //    if (0 != question.BankId)
                //    {
                //        m_Relation_Question_Intensity[question.Id] = question.IntensifyId;
                //    }
                //}

                #endregion 
                QuestionManager.m_QuestionsDictionary[question.Id] = question;
                QuestionManager.m_QuestionsList.Add(question);
            }


            QuestionManager.GetRealationShipFromDB(1);
            QuestionManager.GetRealationShipFromDB(2);
#endif

            //Thread QuestionThread = new Thread(() =>
            //{

            //    //QuestionManager.LoadQuestion(2001, 17000);


            //    Thread QuestionThread1 = new Thread(() =>
            //    {
            //        QuestionManager.LoadQuestion(1001, 1500);


            //        //MessageBox.Show("加载题目信息1完成");
            //    });

            //    Thread QuestionThread5 = new Thread(() =>
            //    {
            //        QuestionManager.LoadQuestion(2001, 2400);
            //        QuestionManager.LoadQuestion(5001, 5200);
            //        QuestionManager.LoadQuestion(6001, 6200);
            //        //MessageBox.Show("加载题目信息5完成");
            //    });


            //    Thread QuestionThread2 = new Thread(() =>
            //    {
            //        QuestionManager.LoadQuestion(7001, 7100);
            //        QuestionManager.LoadQuestion(8001, 8400);
            //        //MessageBox.Show("加载题目信息2完成");
            //    });

            //    Thread QuestionThread7 = new Thread(() =>
            //    {
            //        QuestionManager.LoadQuestion(9001, 9300);
            //        QuestionManager.LoadQuestion(10001, 10200);
            //        //MessageBox.Show("加载题目信息7完成");
            //    });


            //    Thread QuestionThread3 = new Thread(() =>
            //    {
            //        QuestionManager.LoadQuestion(11001, 11300);
            //        QuestionManager.LoadQuestion(12001, 12200);
            //        QuestionManager.LoadQuestion(13001, 13100);
            //        // MessageBox.Show("加载题目信息3完成");
            //    });

            //    Thread QuestionThread6 = new Thread(() =>
            //    {
            //        QuestionManager.LoadQuestion(3001, 3400);
            //        QuestionManager.LoadQuestion(4001, 4200);
            //        // MessageBox.Show("加载题目信息6完成");
            //    });

            //    Thread QuestionThread8 = new Thread(() =>
            //    {
            //        QuestionManager.LoadQuestion(13101, 15250);
            //        //MessageBox.Show("加载题目信息4完成");
            //    });

            //    Thread QuestionThread9 = new Thread(() =>
            //    {
            //        QuestionManager.LoadQuestion(15251, 16000);
            //        //MessageBox.Show("加载题目信息4完成");
            //    });

            //    Thread QuestionThread4 = new Thread(() =>
            //    {
            //        //QuestionManager.LoadQuestion(16001, QuestionManager._maxQuestionNum);
            //        QuestionManager.LoadQuestion(16001, 17000);
            //        //MessageBox.Show("加载题目信息4完成");
            //    });

            //    QuestionThread1.Start();
            //    QuestionThread5.Start();
            //    QuestionThread6.Start();
            //    QuestionThread3.Start();
            //    QuestionThread2.Start();
            //    QuestionThread7.Start();
            //    QuestionThread8.Start();
            //    QuestionThread9.Start();
            //    QuestionThread4.Start();
            //});
            //QuestionThread.Start();

            Application.Run(new FormMain());
        }

        static void LoadProblems(object paramsInfo)
        {
            ThreadParam threadParam = (ThreadParam)paramsInfo;
            QuestionManager.LoadQuestion(threadParam.Start, threadParam.End);
        }

        class ThreadParam
        {
            public ThreadParam(int start, int end)
            {
                Start = start;
                End = end;
            }
            public int Start;
            public int End;
        }
    }
}
