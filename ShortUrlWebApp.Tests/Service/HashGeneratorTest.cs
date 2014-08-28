using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortUrlWebApp.Service;

namespace ShortUrlWebApp.Tests.Service
{
    [TestClass]
    public class HashGeneratorTest
    {
        [TestMethod]
        public void 文字列からハッシュを生成する()
        {
            var actual = HashGenerator.Generate("http://example.com/");

            Assert.AreEqual("a6bf17",actual);
        }
    }
}
