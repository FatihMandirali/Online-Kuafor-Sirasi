using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KuaforBeef.Belgeler.BaseController
{
    public class BaseController : System.Web.Mvc.Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

 
            if (Session["kuaforsahip"] == null)
            {
                if (Session["yoneticiYonet"] != null)
                {
                    base.OnActionExecuting(filterContext);
                }
                else
                {filterContext.Result = new RedirectResult("~/Home/KuaforAdminLogin/");
                    return;
                }
                    
               
            }
          

            //  }
            base.OnActionExecuting(filterContext);
        }
    }
}