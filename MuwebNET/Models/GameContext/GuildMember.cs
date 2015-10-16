using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MuwebNET.Models.GameContext
{
    [Table("GuildMember")]
    public class GuildMember
    {
        [Key]
        public string Name { get; set; }
        public string G_Name { get; set; }
    }
}