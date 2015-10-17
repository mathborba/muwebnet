using MuwebNET.Models.GameContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuwebNET.Bll.GameContext
{
    public static class Guild
    {
        public static Models.GameContext.Guild Get(string name)
        {
            using (var c = new GameDbContext())
            {
                var guild = c.Guilds.Where(a => a.G_Name == name).FirstOrDefault();
                return guild;
            }
        }

        public static List<Models.GameContext.Guild> GetRankings(int topNumber = 0, Models.GameContext.GuildRankingOrderBy orderBy = GuildRankingOrderBy.Score)
        {
            List<Models.GameContext.Guild> guilds = new List<Models.GameContext.Guild>();

            using (var context = new GameDbContext())
            {
                guilds = context.Guilds.ToList();

                if(orderBy == GuildRankingOrderBy.Name)
                {
                    guilds = guilds.OrderByDescending(x => x.G_Name).ToList();
                }

                if(orderBy == GuildRankingOrderBy.Score)
                {
                    guilds = guilds.OrderByDescending(x => x.G_Score).ToList();
                }

                
                if(topNumber > 0)
                {
                    guilds = guilds.Take(topNumber).ToList();
                }
            }

            return guilds;
        }
    }
}