using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortUrlWebApp.Service;

namespace ShortUrlWebApp.Tests.Service
{
    [TestClass]
    public class ShortUrlServiceTest
    {
        [TestMethod]
        public void Urlを受け取るとハッシュを返す()
        {
            var sut = new ShortUrlService();

            var actual = sut.GetShortUrl("http://nakaji.hatenablog.com/");

            Assert.AreEqual("http://nkz.pw/129f5f", actual);
        }
    }
}
