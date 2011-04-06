using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uURL.Models;

namespace uURL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string id) {
            UrlRepository repo = new UrlRepository();
            string url = repo.GetUrl(id);

            if (string.IsNullOrEmpty(url)) {
                return View();
            }

            return Redirect(@"http://" + url);
        }
    }
}
