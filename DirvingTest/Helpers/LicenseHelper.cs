using System;
using System.Collections.Generic;
////using System.Linq;
using System.Security.Cryptography;
using System.Text;
//using System.Threading.Tasks;
using System.Management;
using System.IO;

namespace DirvingTest
{
    class LicenseHelper
    {
        static string _pubkey = null;
        static string _prikey = null;

        public static string ComputerGUID = "";
        public static DateTime _validDateTime = System.DateTime.Now.AddYears(-200);
        private static bool _isValid = false;

        public static bool IsValid()
        {
            return _isValid;
        }

        public static void GenKey()
        {

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                //私钥加密
                //公钥解密
                _pubkey = rsa.ToXmlString(false);   // 公钥  
                _prikey = rsa.ToXmlString(true);   // 私钥  

                using (var sw = new StreamWriter("PubKey.xml", false, Encoding.UTF8))
                {
                    sw.Write(_pubkey);
                    sw.Close();
                }

                using (var sw = new StreamWriter("PriKey.xml", false, Encoding.UTF8))
                {
                    sw.Write(_prikey);
                    sw.Close();
                }
            }
        }

        public static bool GetPubKey()
        {
            if (false == File.Exists("PubKey.xml"))
                return false;

            using(var sr = new StreamReader("PubKey.xml", Encoding.UTF8))
            {
                _pubkey = sr.ReadToEnd();
                sr.Close();
            }

            return true;
        }

        public static  void GetPriKey()
        {
            if (false == File.Exists("PriKey.xml"))
                return;

            using (var sr = new StreamReader("PriKey.xml", Encoding.UTF8))
            {
                _prikey = sr.ReadToEnd();
                sr.Close();
            }
        }

        public static string GetCpuId()  
        {
            if (!string.IsNullOrEmpty(ComputerGUID))
                return ComputerGUID;

            ManagementClass mc = new ManagementClass("Win32_Processor");  
            ManagementObjectCollection moc = mc.GetInstances();  
            String strCpuID = null;  
            foreach (ManagementObject mo in moc)  
            {  
            strCpuID = mo.Properties["ProcessorId"].Value.ToString();  
            break;  
            }

            ComputerGUID = strCpuID;

            return ComputerGUID;  
        }

        public static  string GenLicense(string computerGuid)
        {
            string licenseCode = null;
            using(RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())   
            {   
                rsa.FromXmlString(_prikey);   
                RSAPKCS1SignatureFormatter f = new RSAPKCS1SignatureFormatter(rsa);   // 加密对象   
                f.SetHashAlgorithm("SHA1");
                byte[] source = System.Text.ASCIIEncoding.ASCII.GetBytes(computerGuid);
                SHA1Managed sha = new SHA1Managed();   
                byte[] result = sha.ComputeHash(source);
                byte[] b = f.CreateSignature(result);
                licenseCode = Convert.ToBase64String(b);
            }

            return licenseCode;
        }

        public static  bool CheckLicense(string licenseCode, string computerGuid)
        {
            using(RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())   
            {   
            rsa.FromXmlString(_pubkey);   
            RSAPKCS1SignatureDeformatter f = new RSAPKCS1SignatureDeformatter(rsa);   
  
            f.SetHashAlgorithm("SHA1");   
  
            byte[] key = Convert.FromBase64String(licenseCode);   
  
            SHA1Managed sha = new SHA1Managed();
            byte[] name = sha.ComputeHash(ASCIIEncoding.ASCII.GetBytes(computerGuid));   
            if(f.VerifySignature(name,key))   
                return true;
            else 
                return false;
            }
        }

        public static bool AnalysizeLicenseInfo(string licenseInfo, out DateTime validDate, out string licenseCode)
        {
            validDate = DateTime.Now.AddYears(-200);
            licenseCode = "";
            try
            {
                if (licenseInfo.Length < 30)
                {
                    licenseInfo = FileHelper.Decrypt(licenseInfo);
                }
                else
                {
                    licenseInfo = FileHelper.Decrypt(licenseInfo, GetCpuId().Substring(0, 8));
                }

                string date = licenseInfo.Substring(0, 10);
                string license = licenseInfo.Substring(10, licenseInfo.Length - 10);

                //如果没有date license则授权文件不正常
                if (string.IsNullOrEmpty(date) && string.IsNullOrEmpty(license))
                    return false;

                if (date == "0000-00-00")
                {
                    validDate = DateTime.Now.AddYears(100);
                }
                else
                {
                    int Year = Convert.ToInt32(date.Substring(0, 4));
                    int Month = Convert.ToInt32(date.Substring(5, 2));
                    int Day = Convert.ToInt32(date.Substring(8, 2));
                    validDate = new DateTime(Year, Month, Day);
                }

                licenseCode = license;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool GetLinceseInfo()
        {
            try
            { 
                string licenseInfo = FileHelper.ReadTextFile("license.dat");
                if (string.IsNullOrEmpty(licenseInfo))
                    return false;

                string resultInfo = "";
                
                if(false == LicenseChecked(licenseInfo, out resultInfo))
                    return false;
                
                _isValid = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Register(string licenseInfo, out string resultInfo)
        {
            try
            {
                DateTime validDate = System.DateTime.Now.AddYears(-200);
                if (false == LicenseChecked(licenseInfo, out resultInfo))
                {
                    return false;
                }

                if (false == FileHelper.WriteToTextFile(licenseInfo, "license.dat"))
                {
                    resultInfo = "授权信息保存失败，请联系开发人员";
                    return false;
                }

                _isValid = true;

                resultInfo = "授权成功，感谢您使用本软件，祝您考试成功!";
                
                return true;
            }
            catch(Exception ex)
            {
                resultInfo = ex.ToString();
                return false;
            }
        }

        public static bool LicenseChecked(string licenseInfo, out string resultInfo)
        {
            DateTime validDate = System.DateTime.Now.AddYears(-200);
            string licenseCode = "";
            resultInfo = "";
            if (false == AnalysizeLicenseInfo(licenseInfo, out validDate, out licenseCode))
            {
                resultInfo = "授权信息不正确，请重新获取授权！";
                return false;
            }

            if (validDate < DateTime.Now)
            {
                resultInfo = "授权信息已经过了有效使用期，请重新获取授权！";
                return false;
            }

            if (false == GetPubKey())
            {
                resultInfo = "本地授权文件缺失,请联系开发人员!";
                return false;
            }

            if (false == CheckLicense(licenseCode, GetCpuId()))
            {
                resultInfo = "授权信息无法与当前设备绑定，请重新获取授权！";
                return false;
            }

            if (false == FileHelper.WriteToTextFile(licenseInfo, "license.dat"))
            {
                resultInfo = "授权信息保存失败，请联系开发人员";
                return false;
            }

            return true;
        }
    }
}
