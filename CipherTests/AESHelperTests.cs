using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cipher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher.Tests
{
    [TestClass()]
    public class AESHelperTests
    {
        [TestMethod()]
        public void EncryptTest()
        {
            string text = "test";
            string key = "testtesttesttest";
            string iv = "testtesttesttest";

            string encryptResult = AESHelper.Encrypt(text, key, iv);
            Assert.AreEqual("bjt1UATPu/dzzr1IO1ayXw==", encryptResult);
        }

        [TestMethod()]
        public void DecryptTest()
        {
            string base64 = "bjt1UATPu/dzzr1IO1ayXw==";
            string key = "testtesttesttest";
            string iv = "testtesttesttest";

            string decryptResult = AESHelper.Decrypt(base64, key, iv);
            Assert.AreEqual("test", decryptResult);
        }
    }
}