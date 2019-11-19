using System;
using System.Collections.Generic;
//using System.Linq;
using System.Security.Cryptography;
using System.Text;
//using System.Threading.Tasks;
using System.Management;
using System.IO;

namespace LicenseTool
{
    class LicenseHelper
    {
         static string _pubkey = null;
         static string _prikey = null;

         public static DateTime _ValidDate = DateTime.Now;
        public static string ComputerGUID = null;

        //static string licenseCode = null;
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

        public static void GetPubKey()
        {
            if (false == File.Exists("PubKey.xml"))
                return;

            using(var sr = new StreamReader("PubKey.xml", Encoding.UTF8))
            {
                _pubkey = sr.ReadToEnd();
                sr.Close();
            }
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

        public static  bool AnalysizeLicenseInfo(string licenseInfo, out DateTime validDate, out string licenseCode)
        {
            validDate = DateTime.Now;
            licenseCode = "";
            try
            {
                licenseInfo = FileHelper.Decrypt(licenseInfo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public static bool CheckLicenseDate(string license)
        //{
            
        //}

        //public static DateTime GetValidDate(string license)
        //{
        //    FileHelper.Decrypt(license);
        //    string 
        //    _ValidDate = ;
        //}

    }
}
