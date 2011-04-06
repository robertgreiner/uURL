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
            shortUrl.ID = string.Empty;
            shortUrl.URL = @"http://";

            if (string.IsNullOrEmpty(url)) {
                return View(shortUrl);
            }

            return Redirect(@"http://" + url);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection) {

            ShortUrl shortUrl = new ShortUrl();
            UrlRepository repo = new UrlRepository();

            shortUrl.ID = repo.GetNewId();
            shortUrl.URL = collection["url"];

            return View(shortUrl);
        }

    }
}
