using System;
using System.Collections.Generic;
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
            QuestionManager.LoadQuestion(2001, 2001);

            //for (int i = 0; i < QuestionManager._maxQuestionNum; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), i);
            //    //i = i + 500;
            //}

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
            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), new ThreadParam(16001, QuestionManager._maxQuestionNum));


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
