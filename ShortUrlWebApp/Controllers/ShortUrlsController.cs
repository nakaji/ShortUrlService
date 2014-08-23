using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using ShortUrlWebApp.Models;
using ShortUrlWebApp.Service;

namespace ShortUrlWebApp.Controllers
{
    public class ShortUrlsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ShortUrls
        public async Task<ActionResult> List()
        {
            return View(await db.ShortUrls.ToListAsync());
        }

        // GET: ShortUrls/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShortUrl shortUrl = await db.ShortUrls.FindAsync(id);
            if (shortUrl == null)
            {
                return HttpNotFound();
            }
            return View(shortUrl);
        }

        // POST: ShortUrls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ShortUrl shortUrl = await db.ShortUrls.FindAsync(id);
            db.ShortUrls.Remove(shortUrl);
            await db.SaveChangesAsync();
            return RedirectToAction("List");
        }

        // POST: ShortUrls/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(string url)
        {
            var svc = new ShortUrlService();
            var shortUrl = svc.RegisterUrl(url);

            return PartialView(shortUrl);
        }

        [HttpGet]
        public async Task<ActionResult> RedirectShortUrl(string hash)
        {
            var svc = new ShortUrlService();
            var shortUrl = svc.GetShortUrlByHash(hash);

            return new RedirectResult(shortUrl.Original);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
