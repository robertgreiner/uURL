using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace uURL.Models {
    public class ShortUrl {
        public string ShortName { get; set; }

        [Required(ErrorMessage = "Please enter a URL.")]
        [RegularExpression(@"((http|https|ftp)://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", ErrorMessage = "Please enter a valid URL.")]
        public string URL { get; set; }
    }
}