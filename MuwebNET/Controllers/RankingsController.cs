using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MuwebNET.Controllers
{
    public class RankingsController : Controller
    {
        // GET: Rankings
        [Route("comunidade/rankings")]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Filter(string rankType)
        {
            ViewBag.rankType = rankType;
            return PartialView("Partials/FilterPartial");
        }

        public ActionResult RankingGuilds(string orderBy)
        {
            Models.GameContext.GuildRankingOrderBy OrderBy = Models.GameContext.GuildRankingOrderBy.Score;
            if (orderBy == "name")
                OrderBy = Models.GameContext.GuildRankingOrderBy.Name;

            var model = Bll.GameContext.Guild.GetRankings(150, OrderBy);
            return PartialView("Partials/GuildsPartial", model);
        }

        public ActionResult RankingChars(string type, string orderBy)
        {
            Models.GameContext.CharacterRankingType rankType = Models.GameContext.CharacterRankingType.All;
            Models.GameContext.CharacterRankingOrderBy rankOrderBy = Models.GameContext.CharacterRankingOrderBy.Resets;

            #region .: Facilitar uso da view, depois mudar aqui :.
            switch (type)
            {
                case "bk":
                    rankType = Models.GameContext.CharacterRankingType.OnlyBk;
                    break;
                case "sm":
                    rankType = Models.GameContext.CharacterRankingType.OnlySm;
                    break;
                case "elf":
                    rankType = Models.GameContext.CharacterRankingType.OnlyElf;
                    break;
                case "mg":
                    rankType = Models.GameContext.CharacterRankingType.OnlyMg;
                    break;
                case "dl":
                    rankType = Models.GameContext.CharacterRankingType.OnlyDl;
                    break;
                case "sum":
                    rankType = Models.GameContext.CharacterRankingType.OnlySum;
                    break;
                case "rf":
                    rankType = Models.GameContext.CharacterRankingType.OnlyRf;
                    break;
                default:
                    rankType = Models.GameContext.CharacterRankingType.All;
                    break;
            }

            switch(orderBy)
            {
                case "resets":
                    rankOrderBy = Models.GameContext.CharacterRankingOrderBy.Resets;
                    break;
                case "gresets":
                    rankOrderBy = Models.GameContext.CharacterRankingOrderBy.GResets;
                    break;
                case "level":
                    rankOrderBy = Models.GameContext.CharacterRankingOrderBy.Level;
                    break;
                case "zen":
                    rankOrderBy = Models.GameContext.CharacterRankingOrderBy.Zen;
                    break;
                case "exp":
                    rankOrderBy = Models.GameContext.CharacterRankingOrderBy.Exp;
                    break;
            }
            #endregion

            var model = Bll.GameContext.Character.GetRankings(150, rankType, rankOrderBy);
            return PartialView("Partials/CharsPartial", model);
        }
    }
}