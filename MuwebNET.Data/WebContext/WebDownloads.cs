using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MuwebNET.Models.WebContext
{
    [Table("MuNetWebDownloads")]
    public class WebDownloads
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public Boolean Active { get; set; }
        public Boolean Principal { get; set; }
        public DateTime Date { get; set; }
    }
}