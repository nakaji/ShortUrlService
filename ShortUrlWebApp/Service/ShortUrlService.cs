﻿using System.Security.Cryptography;
using System.Text;
using WebGrease.Css.Extensions;

namespace ShortUrlWebApp.Service
{
    public class ShortUrlService
    {
        public object GetShortUrl(string url)
        {
            var md5 = new MD5CryptoServiceProvider();
            md5.Initialize();
            var buf = Encoding.UTF8.GetBytes(url);
            var hashArray = md5.ComputeHash(buf);
            string hash = "";
            hashArray.ForEach(x =>
            {
                hash += x.ToString("x");
            });
            return hash.Substring(0, 6);
        }
    }
}