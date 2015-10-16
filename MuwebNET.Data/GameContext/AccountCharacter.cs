using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MuwebNET.Models.GameContext
{
    [Table("AccountCharacter")]
    public class AccountCharacter
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Number { get; set; }
        [Key]
        public string Id { get; set; }
        public string GameID1 { get; set; }
        public string GameID2 { get; set; }
        public string GameID3 { get; set; }
        public string GameID4 { get; set; }
        public string GameID5 { get; set; }
        public string GameIDC { get; set; }
    }
}