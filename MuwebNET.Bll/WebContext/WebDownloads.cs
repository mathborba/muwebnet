using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuwebNET.Bll.WebContext
{
    public static class WebDownloads
    {
        public static List<Models.WebContext.WebDownloads> GetDownloads()
        {
            using(var db = new Models.WebContext.WebDbContext())
            {
                var downs = db.Downloads.Where(c => c.Active == true).OrderByDescending(c => c.Principal).ToList();
                return downs;
            }
        }
    }
}
