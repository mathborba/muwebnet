using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MuwebNET.Models.WebContext
{
    [Table("MuNetWebNewsletter")]
    public class WebNewsletter
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public bool RemovalFrom { get; set; }
    }
}