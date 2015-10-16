using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUwebNET.Web.Framework.Models;
using System.Web;
using MuwebNET.Bll.GameContext;

namespace MUwebNET.Web.Framework
{
    public class SessionManager
    {
        const string NameCookie = "MUNET_NAME";
        const string NameCtlCode = "MUNET_AUTH";
        const string NameUserID = "MUNET_GUID";
        const string NameID = "MUNET_UNIQUE";

        public static UserContext Current
        {
            get
            {
                var userContext = new UserContext
                {
                    Name = "",
                    ID = 0,
                    CtlCode = 0,
                    Logged = false,
                };

                var cookieName = HttpContext.Current.Request.Cookies[NameCookie];
                var cookieCtlCode = HttpContext.Current.Request.Cookies[NameCtlCode];
                var cookieUserID = HttpContext.Current.Request.Cookies[NameUserID];
                var cookieID = HttpContext.Current.Request.Cookies[NameID];

                if (cookieName != null && !string.IsNullOrEmpty(cookieName.Value)
                    && cookieUserID != null && !string.IsNullOrEmpty(cookieUserID.Value)
                    && cookieCtlCode != null && !string.IsNullOrEmpty(cookieCtlCode.Value)
                    && cookieID != null && !string.IsNullOrEmpty(cookieID.Value))
                {
                    Guid guidCookieId = new Guid(cookieID.Value.Decrypt());
                    var userId = Convert.ToInt32(cookieUserID.Value.Decrypt());

                    userContext.Name = cookieName.Value.Decrypt();
                    userContext.ID = userId;
                    userContext.CookieID = guidCookieId;
                    userContext.CtlCode = cookieCtlCode.Value.Decrypt().ToInt();
                    userContext.Logged = true;
                }

                userContext.IpAddress = HttpContext.Current.Request.UserHostAddress;
                return userContext;
            }
        }

        public static void Logon(string usuario, string senha)
        {
            var u = Account.VerifyLogin(usuario, senha);
            if (u != null)
            {
                HttpContext.Current.Response.Cookies[NameCookie].Value = u.memb_name.Encrypt();
                HttpContext.Current.Response.Cookies[NameUserID].Value = u.memb_guid.ToString().Encrypt();
                HttpContext.Current.Response.Cookies[NameCtlCode].Value = u.ctl1_code.ToString().Encrypt();
                HttpContext.Current.Response.Cookies[NameID].Value = new Guid().ToString().Encrypt();

                HttpContext.Current.Response.Cookies[NameCookie].Expires = DateTime.Now.AddHours(4);
                HttpContext.Current.Response.Cookies[NameUserID].Expires = DateTime.Now.AddHours(4);
                HttpContext.Current.Response.Cookies[NameCtlCode].Expires = DateTime.Now.AddHours(4);
                HttpContext.Current.Response.Cookies[NameID].Expires = DateTime.Now.AddHours(4);
            }
        }

        public static void Logout()
        {
            var cookieID = HttpContext.Current.Request.Cookies[NameID];

            if (cookieID != null && cookieID.Value != null)
            {
                HttpContext.Current.Response.Cookies[cookieID.Value].Expires = DateTime.Now;
            }

            HttpContext.Current.Response.Cookies[NameCookie].Expires = DateTime.Now;
            HttpContext.Current.Response.Cookies[NameCtlCode].Expires = DateTime.Now;
            HttpContext.Current.Response.Cookies[NameUserID].Expires = DateTime.Now;
            HttpContext.Current.Response.Cookies[NameID].Expires = DateTime.Now;
        }
    }
}
