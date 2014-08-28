using System;
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
            var existsItem = _db.ShortUrls.FirstOrDefault(x => x.Original == url);
            if (existsItem != null)
            {
                return existsItem;
            }

            string hash = HashGenerator.Generate(url);
            while (GetShortUrlByHash(hash) != null)
            {
                // ハッシュが同じになる場合は乱数を加えて取り直し
                hash = HashGenerator.Generate(url + (new Random()).Next());
            }
            var shortedUrl = "http://nkd.jp/" + hash;

            var item = new ShortUrl()
            {
                Original = url,
                Short = shortedUrl,
                Hash = hash
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
