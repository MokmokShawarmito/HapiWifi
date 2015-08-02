using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HapiWifi.Core.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TagLine { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string BannerImagePath { get; set; }
        public string LogoImagePath { get; set; }
        public string Website { get; set; }

        //public IEnumerable<Partnership> Partners { get; set; }
    }

    //why not make Company.Type as an enum type?
    //enum CompanyType
    //{
    //    Test,
    //    Gay,
    //    Lesbian
    //}
}
