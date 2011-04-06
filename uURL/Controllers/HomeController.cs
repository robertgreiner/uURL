using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uURL.Models;

namespace uURL.Controllers {
    public class HomeController : Controller {

        public ActionResult Index(string id) {
            UrlRepository repo = new UrlRepository();
            string url = repo.GetUrl(id);

            ShortUrl shortUrl = new ShortUrl();
            shortUrl.ShortName = string.Empty;
            shortUrl.URL = @"http://";

            if (string.IsNullOrEmpty(url)) {
                return View(shortUrl);
            }

            return Redirect(url);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection) {

            ShortUrl shortUrl = new ShortUrl();
            UrlRepository repo = new UrlRepository();

            shortUrl.ShortName = repo.GetNewShortName();
            shortUrl.URL = collection["url"];

            repo.SaveUrl(shortUrl);

            return View(shortUrl);
        }

    }
}
