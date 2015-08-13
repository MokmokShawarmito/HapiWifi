using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HapiWifi.Web.app_code
{
    public class RequestLogger : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request["returnurl"] != null)
            {
                //this.url = filterContext.HttpContext.Request["returnurl"] as String;
            }

            base.OnActionExecuting(filterContext);
        }

    }
}