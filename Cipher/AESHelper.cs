using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    /// <summary>
    /// AES帮助类
    /// </summary>
    public class AESHelper
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text">明文文本</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="mode">模式</param>
        /// <param name="padding">填充方式</param>
        /// <param name="encoding">编码</param>
        /// <returns>密文Base64</returns>
        public static string Encrypt(string text, string key, string iv, string mode = "CBC", string padding = "PKCS7", string encoding = "utf-8")
        {
            var inputBytes = Encoding.GetEncoding(encoding).GetBytes(text);
            var keyBytes = Encoding.GetEncoding(encoding).GetBytes(key);

            var cipher = CipherUtilities.GetCipher($"AES/{mode}/{padding}");
            if (iv != null)
            {
                cipher.Init(true, new ParametersWithIV(new KeyParameter(keyBytes), Encoding.GetEncoding(encoding).GetBytes(iv)));
            }
            else
            {
                cipher.Init(true, new KeyParameter(keyBytes));
            }
            byte[] rv = new byte[cipher.GetOutputSize(inputBytes.Length)];
            int tam = cipher.ProcessBytes(inputBytes, 0, inputBytes.Length, rv, 0);
            cipher.DoFinal(rv, tam);

            return Convert.ToBase64String(rv);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="text">密文Base64</param>
        /// <param name="key">密钥</param>
        /// <param name="iv">向量</param>
        /// <param name="mode">模式</param>
        /// <param name="padding">填充方式</param>
        /// <param name="encoding">编码</param>
        /// <returns>明文文本</returns>
        public static string Decrypt(string base64, string key, string iv, string mode = "CBC", string padding = "PKCS7", string encoding = "utf-8")
        {
            var inputBytes = Convert.FromBase64String(base64);
            var keyBytes = Encoding.GetEncoding(encoding).GetBytes(key);

            var cipher = CipherUtilities.GetCipher($"AES/{mode}/{padding}");
            if (iv != null)
            {
                cipher.Init(false, new ParametersWithIV(new KeyParameter(keyBytes), Encoding.GetEncoding(encoding).GetBytes(iv)));
            }
            else
            {
                cipher.Init(false, new KeyParameter(keyBytes));
            }
            byte[] rv = new byte[cipher.GetOutputSize(inputBytes.Length)];
            int tam = cipher.ProcessBytes(inputBytes, 0, inputBytes.Length, rv, 0);
            cipher.DoFinal(rv, tam);

            return Encoding.UTF8.GetString(rv).TrimEnd('\0');
        }
    }
}