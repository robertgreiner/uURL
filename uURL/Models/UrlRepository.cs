using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uURL.Models {
    public class UrlRepository {

        public string GetUrl(string shortName) {
            string url = string.Empty;
            using (var ctx = new UrlDataDataContext()) {
                url = (from row in ctx.uURLs
                             where row.ShortName == shortName
                             select row.URL).FirstOrDefault();
            }
            return url;
        }

        //TODO Use Base16 for now, find a better way to do this later.
        public string GetNewId() {
            string shortName = string.Empty;
            using (var ctx = new UrlDataDataContext()) {
                var query = (from row in ctx.uURLs
                             orderby row.ID descending
                       select row.ID).Take(1);

                shortName = System.Convert.ToString(query.First() + 11111, 16);
            }

            return shortName;
        }
    }
}