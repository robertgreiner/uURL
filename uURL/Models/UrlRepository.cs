using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uURL.Models {
    public class UrlRepository {

        //TODO Handle empty URL
        //TODO Handle duplicate URL
        public string GetUrl(string shortName) {
            string url = string.Empty;
            using (var ctx = new UrlDataDataContext()) {
                url = (from row in ctx.uURLs
                             where row.ShortName == shortName
                             select row.URL).FirstOrDefault();
            }

            if (url != null && !url.StartsWith("http")) {
                url = @"http://" + url;
            }

            return url;
        }

        public string GetShortName(string url) {
            string shortName = string.Empty;
            using (var ctx = new UrlDataDataContext()) {
                shortName = (from row in ctx.uURLs
                       where row.URL == url
                       select row.ShortName).FirstOrDefault();
            }

            return shortName;
        }

        public void SaveUrl(ShortUrl shortUrl) {
            using (var ctx = new UrlDataDataContext()) {
                uURL url = new uURL();
                url.ShortName = shortUrl.ShortName;
                url.URL = shortUrl.URL;
                ctx.uURLs.InsertOnSubmit(url);
                ctx.SubmitChanges();
            }
        }

        //TODO Use Base16 for now, find a better way to do this later.
        public string GetNewShortName() {
            string shortName = string.Empty;
            using (var ctx = new UrlDataDataContext()) {
                var query = (from row in ctx.uURLs
                             orderby row.ID descending
                       select row.ID).Take(1);

                shortName = System.Convert.ToString(query.FirstOrDefault() + 11111, 16);
            }

            return shortName;
        }
    }
}