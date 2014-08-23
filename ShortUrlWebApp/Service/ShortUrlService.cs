using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using ShortUrlWebApp.Models;
using WebGrease.Css.Extensions;
using System.Threading.Tasks;

namespace ShortUrlWebApp.Service
{
    public class ShortUrlService
    {
        public ShortUrl GetShortUrl(string url)
        {
            var db = new AppDbContext();
            // 同じURLが登録されていればそれを返す
            var existsItem =  db.ShortUrls.FirstOrDefault(x => x.Original == url);
            if (existsItem != null)
            {
                return existsItem;
            }

            var md5 = new MD5CryptoServiceProvider();
            md5.Initialize();
            var buf = Encoding.UTF8.GetBytes(url);
            var hashArray = md5.ComputeHash(buf);
            string hash = "";
            hashArray.ForEach(x =>
            {
                hash += x.ToString("x");
            });
            var shortedUrl = "http://nkd.jp/" + hash.Substring(0, 6);
            
            // ToDo:データベースへ登録する

            var item = new ShortUrl()
            {
                Original = url,
                Short = shortedUrl,
                Hash = hash
            };
            db.ShortUrls.Add(item);
            db.SaveChanges();


            return item;
        }
    }
}
