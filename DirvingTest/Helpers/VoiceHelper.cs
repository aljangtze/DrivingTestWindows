using System;
using System.Collections.Generic;
////using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace DirvingTest
{

    class VoiceHelper
    {

        static private VoiceHelper g_VoiceHelper = null;
        private VoiceHelper()
        {
        }
        [DllImport("VoiceTransform.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        extern static void test(string configFile);


        [DllImport("VoiceTransform.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        extern static bool Initialize(string filePath, ref int speekerNum);


        [DllImport("VoiceTransform.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static bool SetSpeeker(int speekerId);


        [DllImport("VoiceTransform.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        extern static void ReadText(string text);

        [DllImport("VoiceTransform.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static void Stop();

        [DllImport("VoiceTransform.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static void Uninitialize();

        public void StopSpeaker()
        {
            Stop();
        }

        ~VoiceHelper()
        {
            Uninit();
        }
        public bool Init()
        {
            int num = 0;
            bool Ret = Initialize(@"SkyVoice.ini", ref num);
            if (false == Ret)
                return false;

            SetSpeeker(1);

            return true;

        }

        public void Speeker(string text)
        {
            ReadText(text);
        }
        public void Uninit()
        {
            Uninitialize();
            g_VoiceHelper = null;
        }

        public void Test()
        {
            int Num = 0;
            Initialize("./SkyVoice.ini",ref Num);
            SetSpeeker(0);
            ReadText("男声测试，测试成功");

            SetSpeeker(1);
            ReadText("女声测试，测试成功");

            Uninitialize();
        }

        static public VoiceHelper getVoiceHelper()
        {
            if(g_VoiceHelper == null)
            {
                g_VoiceHelper = new VoiceHelper();
                g_VoiceHelper.Init();
            }

            return g_VoiceHelper;
        }
    }
}
