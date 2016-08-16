using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTest
{
    public class Security
    {
        const string DES_KEY = "Q*1_3@c!";
        const string AES_KEY = "Q*1_3@c!4kd^j&g%";

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <returns>加密后字符串</returns>
        public static string DesEncrypt(string str)
        {
            try
            {
                string key = DES_KEY;
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(str);
                des.Key = Encoding.UTF8.GetBytes(key);
                //des.IV = Encoding.UTF8.GetBytes(key);
                des.Mode = CipherMode.ECB;
                des.Padding = PaddingMode.PKCS7;
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                byte[] EncryptData = (byte[])ms.ToArray();
                return System.Convert.ToBase64String(EncryptData);
            }
            catch { }
            return str;
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="str">待解密字符串</param>
        /// <returns>解密后字符串</returns>
        public static string DesDecrypt(string str)
        {
            try
            {
                string key = DES_KEY;
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Convert.FromBase64String(str);
                des.Key = Encoding.UTF8.GetBytes(key);
                //des.IV = Encoding.UTF8.GetBytes(key);
                des.Mode = CipherMode.ECB;
                des.Padding = PaddingMode.PKCS7;
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return System.Text.Encoding.UTF8.GetString(ms.ToArray());
            }
            catch { }
            return str;
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <returns>加密后字符串</returns>
        public static string AesEncrypt(string str)
        {
            try
            {
                string key = AES_KEY;
                //分组加密算法
                AesCryptoServiceProvider aes =new AesCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(str);//得到需要加密的字节数组 
                //设置密钥及密钥向量
                aes.Key = Encoding.UTF8.GetBytes(key);
                //aes.IV = Encoding.UTF8.GetBytes(key);
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;
                byte[] cipherBytes = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        cipherBytes = ms.ToArray();//得到加密后的字节数组
                        cs.Close();
                        ms.Close();
                    }
                }
                return Convert.ToBase64String(cipherBytes);
            }
            catch { }
            return str;
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="str">待解密字符串</param>
        /// <returns>解密后字符串</returns>
        public static string AesDecrypt(string str)
        {
            try
            {
                string key = AES_KEY;
                byte[] cipherText = Convert.FromBase64String(str);
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                aes.Key = Encoding.UTF8.GetBytes(key);
                //aes.IV = Encoding.UTF8.GetBytes(key);
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;
                byte[] decryptBytes = new byte[cipherText.Length];
                using (MemoryStream ms = new MemoryStream(cipherText))
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        cs.Read(decryptBytes, 0, decryptBytes.Length);
                        cs.Close();
                        ms.Close();
                    }
                }
                return Encoding.UTF8.GetString(decryptBytes).Replace("\0", "");   //将字符串后尾的'\0'去掉
            }
            catch { }
            return str;
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">待加密字符串</param>
        /// <returns>加密后字符串</returns>
        public static string Md5Encrypt(string str)
        {
            try
            {
                string pwd = "";
                MD5 md5 = MD5.Create();
                byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                for (int i = 0; i < s.Length; i++)
                {
                    pwd = pwd + s[i].ToString("x");
                }
                return pwd;
            }
            catch { }
            return str;
        }
    }
}
