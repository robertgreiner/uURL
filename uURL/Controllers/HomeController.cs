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

            if (string.IsNullOrEmpty(url)) {
                return View();
            }

            return Redirect(url);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection) {

            ShortUrl shortUrl = new ShortUrl();
            UrlRepository repo = new UrlRepository();

            shortUrl.ShortName = repo.GetNewShortName();
            shortUrl.URL = collection["url"];

            //TODO check for valid URL
            repo.SaveUrl(shortUrl);

            return View(shortUrl);
        }

    }
}
