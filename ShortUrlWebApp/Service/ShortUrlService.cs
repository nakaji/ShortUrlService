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
        private AppDbContext _db = new AppDbContext();

        public ShortUrl RegisterUrl(string url)
        {
            // 同じURLが登録されていればそれを返す
            var existsItem =  _db.ShortUrls.FirstOrDefault(x => x.Original == url);
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
                Hash = hash.Substring(0, 6)
            };
            _db.ShortUrls.Add(item);
            _db.SaveChanges();


            return item;
        }

        public ShortUrl GetShortUrlByHash(string hash)
        {
            var item = _db.ShortUrls.FirstOrDefault(x => x.Hash == hash);
            return item;
        }
    }
}
