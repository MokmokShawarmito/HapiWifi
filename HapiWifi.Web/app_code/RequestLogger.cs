using HapiWifi.Core.DAL;
using HapiWifi.Core.Models;
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
            //CHECK IF ALREADY LOGGED
            if (HttpContext.Current.Request.Cookies["ishapiwifilogged"] != null) // cookie exist
            {
                base.OnActionExecuting(filterContext);
                return;
            }

            //FETCH REQUIRED DATA
            string browser = string.Empty;
            int majorVersion = 0;
            string userAgent = string.Empty;
            string page = string.Empty;
            bool isMobile = false;

            if (HttpContext.Current.Request.Browser != null)
            {
                if (!String.IsNullOrEmpty(HttpContext.Current.Request.Browser.Browser))
                {
                    browser = (string)HttpContext.Current.Request.Browser.Browser;
                }

                Int32.TryParse(HttpContext.Current.Request.Browser.MajorVersion.ToString(), out majorVersion);
            }

            if (HttpContext.Current.Request.UserAgent != null)
            {
                userAgent = (string)HttpContext.Current.Request.UserAgent;
                userAgent = userAgent.ToLower();
            }

            if (HttpContext.Current.Request.Url.AbsoluteUri != null)
            {
                page = HttpContext.Current.Request.Url.AbsoluteUri;
            }

            isMobile = this.CheckIfMobileRequestHeader(userAgent);

            //SAVE REQUIRED DATA
            HapiWifiDB db = new HapiWifiDB();
            RequestLog log = new RequestLog();
            log.Date = DateTime.Now;
            log.Page = page;
            log.IsMobileRequest = isMobile;
            log.Browser = string.Format("{0} {1}|| {2}",browser,majorVersion,userAgent);
            db.RequestLogs.Add(log);
            db.SaveChanges();

            //set cookie
            if (HttpContext.Current.Request.Cookies["ishapiwifilogged"] == null )
            {
                HttpContext.Current.Response.Cookies["ishapiwifilogged"].Value = "1";
                HttpContext.Current.Response.Cookies["ishapiwifilogged"].Expires = DateTime.Now.AddHours(4);
            }

            base.OnActionExecuting(filterContext);
        }

        private bool CheckIfMobileRequestHeader(string useragent)
        {
            string[] mobileheaders = { "android", "webos", "iphone", "ipad", "ipod", "blackberry", "windows phone" };

            foreach (var item in mobileheaders)
            {
                if (useragent.Contains(item))
                {
                    return true;
                }
            }

            return false;
        }
    }
}