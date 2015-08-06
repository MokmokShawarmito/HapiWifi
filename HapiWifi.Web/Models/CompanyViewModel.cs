using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HapiWifi.Web.Models
{
    public class CompanyViewModel
    {
        [MinLength(4)]
        public string Name { get; set; }
        [MinLength(4)]        
        public string TagLine { get; set; }
        [MinLength(4)]        
        public string Description { get; set; }
        public string Type { get; set; }
        [DataType(DataType.Url)]
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