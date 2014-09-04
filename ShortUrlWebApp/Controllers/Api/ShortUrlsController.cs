using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.Ajax.Utilities;
using ShortUrlWebApp.Models;
using ShortUrlWebApp.Service;

namespace ShortUrlWebApp.Controllers.Api
{
    public class ShortUrlsController : ApiController
    {
        private AppDbContext db = new AppDbContext();

        // GET api/Shortner
        public IEnumerable<ShortUrl> Get()
        {
            return db.ShortUrls.ToList();
        }

        // GET api/Shortner/5
        public ShortUrl Get(string id)
        {
            var svc = new ShortUrlService();
            var shortUrl = svc.GetShortUrlByHash(id);
            if (shortUrl == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return shortUrl;
        }

        // POST api/Shortner
        public ShortUrl Post([FromBody]PostShortUrlRequest model)
        {
            if (model == null || model.Url.IsNullOrWhiteSpace())
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var svc = new ShortUrlService();
            var shortUrl = svc.RegisterUrl(model.Url);

            return shortUrl;
        }
    }
}