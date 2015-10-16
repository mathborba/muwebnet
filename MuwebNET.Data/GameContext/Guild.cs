using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MuwebNET.Models.GameContext
{
    [Table("Guild")]
    public class Guild
    {
        [Key]
        public string G_Name { get; set; }
        public Byte[] G_Mark { get; set; }
        public string G_Master { get; set; }
    }
}