using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uURL.Models {
    public class UrlRepository {

        public string GetUrl(string id) {
            string url = string.Empty;
            using (var ctx = new UrlDataDataContext()) {
                url = (from row in ctx.uURLs
                             where row.ID == id
                             select row.URL).FirstOrDefault();
            }
            return url;
        }

    }
}