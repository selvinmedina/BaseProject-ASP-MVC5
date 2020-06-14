using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BaseProject.Attribute
{
    public class SessionManager: ActionFilterAttribute
    {
        Models.Helpers General = new Models.Helpers();
        public SessionManager()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sinAcceso = new RouteValueDictionary(new { action = "Index", controller = "Login" });
            if (!General.GetUserLogin())
            {
                filterContext.Result = new RedirectToRouteResult("Default", sinAcceso);
            }
        }
    }
}