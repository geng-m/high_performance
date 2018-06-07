using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace Search
{
    /// <summary>
    /// 对称加密算法类
    /// </summary>
    public class obEncrypt
    {

        public obEncrypt()
        {
            //
            // 对称加密类的构造函数
            //

        }

        public static string GetKeyStr()
        {
            return ")D)WDdKL:L3$QE+_@#24)sfw(#)FJFO)";
        }

        public static string GetIvStr()
        {
            return "@D|WeKL:LaE+_@#*";
        }

        private static byte[] GetKey()
        {
            string key = ")D)WDdKL:L3$QE+_@#24)sfw(#)FJFO)";
            byte[] byteKey = ASCIIEncoding.ASCII.GetBytes(key);
            return byteKey;
        }

        private static byte[] GetIv()
        {
            string iv = "@D|WeKL:LaE+_@#*";
            byte[] byteIv = ASCIIEncoding.ASCII.GetBytes(iv);
            return byteIv;
        }

        public static string EncrypTo(string Source)
        {
            byte[] bytIn = UTF8Encoding.UTF8.GetBytes(Source);
            MemoryStream ms = new MemoryStream();

            Rijndael encryptCard = Rijndael.Create();
            encryptCard.Key = GetKey();
            encryptCard.IV = GetIv();

            ICryptoTransform encrypto = encryptCard.CreateEncryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
            cs.Write(bytIn, 0, bytIn.Length);
            cs.FlushFinalBlock();
            ms.Close();
            byte[] bytOut = ms.ToArray();
            return Convert.ToBase64String(bytOut);
        }

        public static string DecrypTo(string Source)
        {
            byte[] bytIn = Convert.FromBase64String(Source);
            MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length);
            Rijndael encryptCard = Rijndael.Create();
            encryptCard.Key = GetKey();
            encryptCard.IV = GetIv();
            ICryptoTransform encrypto = encryptCard.CreateDecryptor();
            CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cs);
            return sr.ReadToEnd();
        }

        private static byte[] GetBytes(string src)
        {
            byte[] byteSrc = ASCIIEncoding.ASCII.GetBytes(src);
            return byteSrc;
        }

        private static string GetStr(byte[] src)
        {
            string srcTo;
            srcTo = ASCIIEncoding.ASCII.GetString(src);
            return srcTo;
        }

        public static string EncryptToMD5(string pwd)
        {
            byte[] bytIn = GetBytes(pwd);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(bytIn);
            return GetStr(result);
        }

    }


}