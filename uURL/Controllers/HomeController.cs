using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uURL.Models;

namespace uURL.Controllers {
    public class HomeController : Controller {

        public ActionResult Index(string shortName) {
            UrlRepository repo = new UrlRepository();
            string url = repo.GetUrl(shortName);

            if (string.IsNullOrEmpty(url)) {
                return View();
            }

            return Redirect(url);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection) {
            
            //TODO check for valid URL

            ShortUrl shortUrl = new ShortUrl();
            UrlRepository repo = new UrlRepository();

            string shortName = repo.GetShortName(collection["url"]);

            shortUrl.URL = collection["url"];
            shortUrl.ShortName = shortName;
            if (string.IsNullOrEmpty(shortName)) {
                shortUrl.ShortName = repo.GetNewShortName();
                repo.SaveUrl(shortUrl);
            }
            return View(shortUrl);
        }

    }
}
