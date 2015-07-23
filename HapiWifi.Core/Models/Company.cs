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
        public string PicBanner { get; set; }
        public string PicLogo { get; set; }
        public string Website { get; set; }
    }
}
