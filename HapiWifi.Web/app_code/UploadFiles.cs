using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HapiWifi.Web.app_code
{

    public class UploadFiles : ActionFilterAttribute
    {
        List<string> keys = new List<string>();
        string key = "";
        ImageCategory imageCategory = ImageCategory.Logo;
        private const string SERVERPATHBANNER = "~/images/uploads/banner/";
        private const string SERVERPATHLOGO = "~/images/uploads/logo/";
        private const string SERVERPATHPRODUCT = "~/images/uploads/products/";
        private const string SERVERPATHLOCATION = "~/images/uploads/branches/";



        //public UploadFiles(ImageCategory category,params string[] keys)
        //{
        //    this.imageCategory = category;
        //    //add value to keys
        //    foreach (var item in keys)
        //    {
        //        this.keys.Add(item);
        //    }
        //}

        public UploadFiles(ImageCategory category, string key)
        {
            this.imageCategory = category;
            //add value to keys
            this.key = key; 
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request["returnurl"] != null)
            {
                //this.url = filterContext.HttpContext.Request["returnurl"] as String;
            }

            if (filterContext.HttpContext.Request.Files[key] != null)
            {
                string savedPath = "";
            }

            base.OnActionExecuting(filterContext);
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //filterContext.Result = new RedirectResult(String.IsNullOrEmpty(this.url) ? HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) : this.url);
            }
        }

        //saving files
        private string SaveImage(ActionExecutingContext filterContext,HttpPostedFileBase file, string filename, bool isLogo = false)
        {
            string filePath = string.Empty;
            string serverPath = SERVERPATHLOGO;

            if (isLogo == false)
                serverPath = SERVERPATHBANNER;


            var test =  filterContext.HttpContext.Server.MapPath(serverPath);
            if (!Directory.Exists(filterContext.HttpContext.Server.MapPath(serverPath)))
            {
                Directory.CreateDirectory(filterContext.HttpContext.Server.MapPath(serverPath));
            }

            // Get the complete file path then save.
            string fileSavePath = Path.Combine(filterContext.HttpContext.Server.MapPath(serverPath), filename);
            file.SaveAs(fileSavePath);
            filePath = String.Format("{0}{1}", serverPath, filename);

            filePath = filePath.Replace("~", "");

            return filePath;
        }

        //validates image.
        private bool ValidateFile(HttpPostedFileBase file)
        {
            int size = file.ContentLength;

            if (file == null)
                return false;

            if (size > 20000000)
                return false;

            if (!(file.FileName.ToLower().Contains(".jpg") || file.FileName.ToLower().Contains(".png") || file.FileName.ToLower().Contains(".jpeg")))
                return false;

            return true;
        }
    }

    public enum ImageCategory
    {
        Logo,
        Banner,
        Product,
        Location
    }
}