using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DataType(DataType.Url)]
        public string Website { get; set; }

        //public IEnumerable<Partnership> Partners { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }
        public virtual IEnumerable<Branch> Branches { get; set; }

        public Company()
        {
            this.Products = new List<Product>();
            this.Branches = new List<Branch>();
        }
    }

    //why not make Company.Type as an enum type?
    //enum CompanyType
    //{
    //    Test,
    //    Gay,
    //    Lesbian
    //}
}
