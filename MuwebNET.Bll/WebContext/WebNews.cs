using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuwebNET.Bll.WebContext
{
    public static class WebNews
    {
        public static Models.WebContext.WebNews Get(int id)
        {
            using (var db = new Models.WebContext.WebDbContext())
            {
                return db.News.Find(id);
            }
        }

        public static List<Models.WebContext.WebNews> GetNewsHomepage()
        {
            using(var db = new Models.WebContext.WebDbContext())
            {
                var news = db.News.Where(c => c.Active == true).OrderByDescending(c => c.Date).Take(15).ToList();
                return news;
            }
        }
    }
}
