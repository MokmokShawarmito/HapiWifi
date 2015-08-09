using HapiWifi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HapiWifi.Core.Abstracts
{
    public interface ICompanyController:IController<Company>
    {
        IEnumerable<Company> GetAllCompanyPartners(int id);
    }
}
