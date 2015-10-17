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

        public static List<Models.GameContext.Character> GetRankings(int topNumber = 0, Models.GameContext.CharacterRankingType rankType = CharacterRankingType.All, Models.GameContext.CharacterRankingOrderBy orderBy = CharacterRankingOrderBy.Resets)
        {
            List<Models.GameContext.Character> chars = new List<Models.GameContext.Character>();

            if (topNumber > 0)
            {
                if (topNumber > 300)
                    topNumber = 300;
            }

            using (var context = new GameDbContext())
            {
                if(rankType != CharacterRankingType.All)
                {
                    int firstClass, lastClass;
                    switch (rankType)
                    {
                        case CharacterRankingType.OnlyBk:
                            firstClass = 16;
                            lastClass = 19;
                            break;
                        case CharacterRankingType.OnlySm:
                            firstClass = 0;
                            lastClass = 3;
                            break;
                        case CharacterRankingType.OnlyElf:
                            firstClass = 32;
                            lastClass = 35;
                            break;
                        case CharacterRankingType.OnlySum:
                            firstClass = 80;
                            lastClass = 83;
                            break;
                        case CharacterRankingType.OnlyMg:
                            firstClass = 48;
                            lastClass = 50;
                            break;
                        case CharacterRankingType.OnlyDl:
                            firstClass = 64;
                            lastClass = 66;
                            break;
                        case CharacterRankingType.OnlyRf:
                            firstClass = 96;
                            lastClass = 98;
                            break;
                        default:
                            return null;
                    }

                    if (orderBy == CharacterRankingOrderBy.Resets)
                    {
                        chars = context.Characters.Where(cr => cr.Class >= firstClass && cr.Class <= lastClass).OrderByDescending(c => c.Resets)
                                     .ThenByDescending(c => c.GrandResets)
                                     .ThenByDescending(c => c.cLevel).Take(topNumber).ToList();
                    }

                    if (orderBy == CharacterRankingOrderBy.GResets)
                    {
                        chars = context.Characters.Where(cr => cr.Class >= firstClass && cr.Class <= lastClass).OrderByDescending(c => c.GrandResets)
                                     .ThenByDescending(c => c.Resets)
                                     .ThenByDescending(c => c.cLevel).Take(topNumber).ToList();
                    }

                    if (orderBy == CharacterRankingOrderBy.Level)
                    {
                        chars = context.Characters.Where(cr => cr.Class >= firstClass && cr.Class <= lastClass).OrderByDescending(c => c.cLevel)
                                     .ThenByDescending(c => c.Resets)
                                     .ThenByDescending(c => c.Experience).Take(topNumber).ToList();
                    }

                    if (orderBy == CharacterRankingOrderBy.Exp)
                    {
                        chars = context.Characters.Where(cr => cr.Class >= firstClass && cr.Class <= lastClass).OrderByDescending(c => c.Experience)
                                     .ThenByDescending(c => c.cLevel)
                                     .ThenByDescending(c => c.Resets).Take(topNumber).ToList();
                    }

                    if (orderBy == CharacterRankingOrderBy.Zen)
                    {
                        chars = context.Characters.Where(cr => cr.Class >= firstClass && cr.Class <= lastClass).OrderByDescending(c => c.Money).Take(topNumber).ToList();
                    }
                }
                else
                {
                    if (orderBy == CharacterRankingOrderBy.Resets)
                    {
                        chars = context.Characters.OrderByDescending(c => c.Resets)
                                     .ThenByDescending(c => c.GrandResets)
                                     .ThenByDescending(c => c.cLevel).Take(topNumber).ToList();
                    }

                    if (orderBy == CharacterRankingOrderBy.GResets)
                    {
                        chars = context.Characters.OrderByDescending(c => c.GrandResets)
                                     .ThenByDescending(c => c.Resets)
                                     .ThenByDescending(c => c.cLevel).Take(topNumber).ToList();
                    }

                    if (orderBy == CharacterRankingOrderBy.Level)
                    {
                        chars = context.Characters.OrderByDescending(c => c.cLevel)
                                     .ThenByDescending(c => c.Resets)
                                     .ThenByDescending(c => c.Experience).Take(topNumber).ToList();
                    }

                    if (orderBy == CharacterRankingOrderBy.Exp)
                    {
                        chars = context.Characters.OrderByDescending(c => c.Experience)
                                     .ThenByDescending(c => c.cLevel)
                                     .ThenByDescending(c => c.Resets).Take(topNumber).ToList();
                    }

                    if (orderBy == CharacterRankingOrderBy.Zen)
                    {
                        chars = context.Characters.OrderByDescending(c => c.Money).Take(topNumber).ToList();
                    }
                }
            }

            return chars;
        }
    }
}