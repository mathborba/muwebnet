using MuwebNET.Models.GameContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuwebNET.Bll.GameContext
{
    public static class Character
    {
        public static Models.GameContext.Character Get(string name)
        {
            using (var c = new GameDbContext())
            {
                var person = c.Characters.Where(a => a.Name == name).FirstOrDefault();
                return person;
            }
        }

        public static ICollection<Models.GameContext.Character> GetCharsByUser(string user)
        {
            using (var c = new GameDbContext())
            {
                return c.Characters.Where(a => a.AccountID == user).ToArray<Models.GameContext.Character>();
            }
        }

        public static bool IsCharacterFromUser(string user, string character)
        {
            using (var c = new GameDbContext())
            {
                AccountCharacter ac = c.AccountChars.Find(user);

                if (ac.GameID1 != null && ac.GameID1.Equals(character)) 
                    return true;
                if (ac.GameID2 != null && ac.GameID2.Equals(character)) 
                    return true;
                if (ac.GameID3 != null && ac.GameID3.Equals(character)) 
                    return true;
                if (ac.GameID4 != null && ac.GameID4.Equals(character)) 
                    return true;
                if (ac.GameID5 != null && ac.GameID5.Equals(character)) 
                    return true;
            }
            return false;
        }
    }
}