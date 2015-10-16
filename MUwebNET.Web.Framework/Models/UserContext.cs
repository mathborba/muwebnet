using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUwebNET.Web.Framework.Models
{
    public class UserContext
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CtlCode { get; set; }
        public Guid CookieID { get; set; }
        public string IpAddress { get; set; }
        public bool Logged { get; set; }
    }
}
