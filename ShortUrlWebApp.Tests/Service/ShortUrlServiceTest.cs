using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortUrlWebApp.Models;
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

        [TestMethod]
        public void 同じUrlを受け取ると既に登録されているものを返す()
        {
            var db = new AppDbContext();

            db.ShortUrls.RemoveRange(db.ShortUrls.ToList());

            db.ShortUrls.Add(new ShortUrl()
            {
                Original = "http://nakaji.hatenablog.com/",
                Short = "http://nkd.jp/129f5f",
                Hash = "129f5f"
            });
            db.SaveChanges();

            var sut = new ShortUrlService();

            var actual = sut.RegisterUrl("http://nakaji.hatenablog.com/");

            Assert.AreEqual("http://nkd.jp/129f5f", actual.Short);
            Assert.AreEqual(1, db.ShortUrls.Count());
        }
    }
}
