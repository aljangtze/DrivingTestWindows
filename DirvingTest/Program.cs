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

            SystemConfig sysConfig = SystemConfig.getInstance();
            QuestionManager.LoadAllQuestion();

            Application.Run(new FormMain());
        }

        static void LoadQuestionFromFile()
        {
            ThreadPool.SetMaxThreads(20, 12);

            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), new ThreadParam(1001, 1500));
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
            
            ThreadPool.QueueUserWorkItem(new WaitCallback(LoadProblems), new ThreadParam(16001, 17000));
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
