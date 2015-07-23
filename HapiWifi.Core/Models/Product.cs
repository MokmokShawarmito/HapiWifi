﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HapiWifi.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Order { get; set; }
        public bool isShow { get; set; }
        public bool isFeatured { get; set; }
        public string Image { get; set; }
    }
}