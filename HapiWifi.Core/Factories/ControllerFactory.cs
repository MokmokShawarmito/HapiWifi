using HapiWifi.Core.Abstracts;
using HapiWifi.Core.Controllers;
using HapiWifi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HapiWifi.Core.Factories
{
    public class ControllerFactory
    {
        public static IController<Company> CreateCompanyController()
        {
            return new CompanyController();
        }
    }
}
