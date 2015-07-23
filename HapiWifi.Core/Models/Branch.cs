using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HapiWifi.Core.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public int CompanyID { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
    }
}
