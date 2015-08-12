using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HapiWifi.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        //[Required]
        //[MinLength(4)]
        public string Name { get; set; }
        //[Required]
        //[MinLength(4)]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int Order { get; set; }
        public bool isShow { get; set; }
        public bool isFeatured { get; set; }
        public string ImagePath { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
