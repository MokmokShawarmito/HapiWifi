using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HapiWifi.Web.Models
{
    public class CompanyViewModel
    {
        public string Name { get; set; }
        public string TagLine { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Website { get; set; }

        /// <summary>
        /// Banner image
        /// </summary>
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Banner { get; set; }

        /// <summary>
        /// Logo image
        /// </summary>
        [DataType(DataType.Upload)]
        public HttpPostedFileBase Logo { get; set; }
    }
}