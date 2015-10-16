using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MuwebNET.Models.GameContext
{
    [Table("Character")]
    public class Character
    {
        public string AccountID { get; set; }
        [Key]
        public string Name { get; set; }
        public int cLevel { get; set; }
        public int LevelUpPoint { get; set; }
        public Byte Class { get; set; }
        public long Experience { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Vitality { get; set; }
        public int Energy { get; set; }
        public Int16 MapNumber { get; set; }
        public Int16 MapPosX { get; set; }
        public Int16 MapPosY { get; set; }
        public Byte CtlCode { get; set; }
        public int Resets { get; set; }
        public int GrandResets { get; set; }
        public int Money { get; set; }
    }
}