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
        public async Task<ActionResult> Index()
        {
            return View(await db.ShortUrls.ToListAsync());
        }

        // GET: ShortUrls/Details/5
        public async Task<ActionResult> Details(int? id)
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

        // GET: ShortUrls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShortUrls/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Original,User,Hash")] ShortUrl shortUrl)
        {
            if (ModelState.IsValid)
            {
                db.ShortUrls.Add(shortUrl);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(shortUrl);
        }

        // GET: ShortUrls/Edit/5
        public async Task<ActionResult> Edit(int? id)
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

        // POST: ShortUrls/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Original,User,Hash")] ShortUrl shortUrl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shortUrl).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(shortUrl);
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
            return RedirectToAction("Index");
        }

        // POST: ShortUrls/Register
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(string url)
        {
            var svc = new ShortUrlService();
            var shortUrl = svc.GetShortUrl(url);

            return View(shortUrl);
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
