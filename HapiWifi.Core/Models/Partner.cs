using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HapiWifi.Core.Models
{
    public class Partnership
    {
        public int Id { get; set; }
        public int companyID { get; set; }
        public int partnerID { get; set; }
        public int partnerOrder { get; set; }
        public bool isShow { get; set; }
        public bool isFeatured { get; set; }

        //public Company Company { get; set; }
        //public Company Partner { get; set; }
    }
}
