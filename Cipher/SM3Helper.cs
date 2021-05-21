using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    /// <summary>
    /// SM3帮助类
    /// </summary>
    public class SM3Helper
    {
        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="text">原文</param>
        /// <param name="encodingName">编码名称</param>
        /// <returns>签名</returns>
        public static string Signature(string text, string encodingName = "utf-8")
        {
            Encoding encoding = Encoding.GetEncoding(encodingName);

            byte[] msg = encoding.GetBytes(text);

            var digest = DigestUtilities.GetDigest("SM3");
            byte[] md = new byte[digest.GetDigestSize()];
            digest.BlockUpdate(msg, 0, msg.Length);
            digest.DoFinal(md, 0);

            return Hex.ToHexString(md);
        }
    }
}