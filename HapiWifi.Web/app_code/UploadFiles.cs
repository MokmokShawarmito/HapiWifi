using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HapiWifi.Web.app_code
{

    public class UploadFiles : ActionFilterAttribute
    {
        string key = "";

        public UploadFiles(params string[] key)
        {
            //this.key = key;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request["returnurl"] != null)
            {
                //this.url = filterContext.HttpContext.Request["returnurl"] as String;
            }

            base.OnActionExecuting(filterContext);
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //filterContext.Result = new RedirectResult(String.IsNullOrEmpty(this.url) ? HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) : this.url);
            }
        }


    }
}