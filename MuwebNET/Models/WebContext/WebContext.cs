using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MuwebNET.Models.WebContext
{
    public class WebDbContext : DbContext
    {
        public WebDbContext() : base("WebDbConnection")
        {
        }

        public DbSet<WebNews> News { get; set; }
        public DbSet<WebDownloads> Downloads { get; set; }
        public DbSet<WebSlider> Sliders { get; set; }
        public DbSet<WebFAQCategory> FaqsCategory { get; set; }
        public DbSet<WebFAQ> Faqs { get; set; }
    }
}