using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HapiWifi.Core.Models
{
    public class RequestLog
    {
        public int Id { get; set; }
        public string Page { get; set; }
        public DateTime Date { get; set; }
        public string Browser { get; set; }
        public bool IsMobileRequest { get; set; }
        public int CompanyID { get; set; }
    }
}
