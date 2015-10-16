using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MUwebNET.Web.Framework.Filters
{
    public class VerifyAuthOrPermissionAttribute : AuthorizeAttribute
    {
        private string[] _userType { get; set; }

        public VerifyAuthOrPermissionAttribute(string UsersType = "")
        {
            var tempUserType = UsersType.Split(',');
            if (tempUserType.Count() > 0)
                _userType = tempUserType;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            var sessionUser = SessionManager.Current;

            if (filterContext == null)
            {
                throw new ArgumentNullException("Filter Context cant be null parameter");
            }

            if (sessionUser.Logged)
            {
                if(_userType.Count() > 0)
                {
                    string userType = sessionUser.CtlCode == 8 ? "Gamemaster"
                        : sessionUser.CtlCode == 16 ? "Gamemaster16"
                        : sessionUser.CtlCode == 24 ? "Gamemaster24"
                        : sessionUser.CtlCode == 32 ? "Admin"
                        : "Player";

                    if(!_userType.Contains(userType))
                    {
                        filterContext.Result = new RedirectResult("~/NoPermission");
                    }
                }
            }
            else
            {
                filterContext.Result = new RedirectResult("~/InvalidSession");
            }
        }
    }
}
