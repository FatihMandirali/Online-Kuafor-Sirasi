using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeefKuaforSiram.Belgeler.BaseController
{
    public class BaseControllerYonetici : System.Web.Mvc.Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (Session["yonetici"] == null)
            {
                filterContext.Result = new RedirectResult("~/Home/YoneticiAdminLogin/");
                return;
            }
          


            //  }
            base.OnActionExecuting(filterContext);
        }
    }
}