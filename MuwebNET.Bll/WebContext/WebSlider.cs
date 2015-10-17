using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuwebNET.Bll.WebContext
{
    public static class WebSlider
    {
        public static List<Models.WebContext.WebSlider> GetSlidersHomepage()
        {
            using(var db = new Models.WebContext.WebDbContext())
            {
                var sliders = db.Sliders.Where(c => c.Active == true).OrderByDescending(c => c.Id).ToList();
                return sliders;
            }
        }
    }
}
