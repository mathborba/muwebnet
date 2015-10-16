using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MuwebNET.Models.GameContext
{
    [Table("MEMB_STAT")]
    public class AccountStat
    {
        [Key]
        public string memb___id { get; set; }
        public Byte ConnectStat { get; set; }
        public string ServerName { get; set; }
        public string IP { get; set; }
        public DateTime ConnectTM { get; set; }
        public DateTime DisConnectTM { get; set; }
    }
}