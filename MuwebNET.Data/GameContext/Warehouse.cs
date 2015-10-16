using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MuwebNET.Models.GameContext
{
    [Table("warehouse")]
    public class Warehouse
    {
        [Key]
        public string AccountID { get; set; }
        public Byte[] Items { get; set; }
        public int Money { get; set; }
    }
}