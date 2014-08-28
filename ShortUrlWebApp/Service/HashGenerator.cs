using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using WebGrease.Css.Extensions;

namespace ShortUrlWebApp.Service
{
    public class HashGenerator
    {
        public static string Generate(string str)
        {
            var md5 = new MD5CryptoServiceProvider();
            md5.Initialize();
            var buf = Encoding.UTF8.GetBytes(str);
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