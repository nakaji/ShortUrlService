using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortUrlWebApp.Service;

namespace ShortUrlWebApp.Tests.Service
{
    [TestClass]
    public class ShortUrlServiceTest
    {
        [TestMethod]
        public void Urlを受け取るとShortUrlオブジェクトを返す()
        {
            var sut = new ShortUrlService();

            var actual = sut.RegisterUrl("http://nakaji.hatenablog.com/");

            Assert.AreEqual("http://nkd.jp/129f5f", actual.Short);
        }
    }
}
