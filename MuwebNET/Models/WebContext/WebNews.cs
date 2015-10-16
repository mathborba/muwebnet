using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MuwebNET.Models.WebContext
{
    [Table("MuNetWebNews")]
    public class WebNews
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
        public string HtmlContent { get; set; }
    }
}