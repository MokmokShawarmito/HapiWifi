using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HapiWifi.Core.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Location { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Type { get; set; }
        public string ImagePath { get; set; }

        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}
