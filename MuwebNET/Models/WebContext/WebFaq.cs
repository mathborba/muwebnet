using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MuwebNET.Models.WebContext
{
    [Table("MuNetWebFAQCategory")]
    public class WebFAQCategory
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }

    [Table("MuNetWebFAQ")]
    public class WebFAQ
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryID { get; set; }
        public string HtmlDescription { get; set; }
        public string UrlFriendly { get; set; }
        public string Author { get; set; }
        public bool Active { get; set; }
    }
}