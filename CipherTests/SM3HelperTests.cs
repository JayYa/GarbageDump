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
    public class SM3HelperTests
    {
        [TestMethod()]
        public void SignatureTest()
        {
            string sign = SM3Helper.Signature("test");
            Assert.AreEqual("55e12e91650d2fec56ec74e1d3e4ddbfce2ef3a65890c2a19ecf88a307e76a23", sign);
        }
    }
}