using HapiWifi.Core.Abstracts;
using HapiWifi.Core.Factories;
using HapiWifi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HapiWifi.Core.Controllers
{
    public class CompanyController : IController<Company>
    {

        public IEnumerable<Company> GetAll()
        {
            List<Company> companies = new List<Company>();

            using (var db = ContextFactory.CreateContext())
            {
                companies = db.Companies.ToList();
            }

            return companies;
        }

        public IEnumerable<Company> GetById(int id)
        {
            List<Company> companies = new List<Company>();

            using (var db = ContextFactory.CreateContext())
            {
                companies = db.Companies.Where(company => company.Id == id).ToList();
            }

            return companies;
        }

        public bool Add(Company entity)
        {
            using (var db = ContextFactory.CreateContext())
            {
                db.Companies.Add(entity);
                db.SaveChanges();
            }

            return true;
        }

        public bool Update(Company entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Company entity)
        {
            using (var db = ContextFactory.CreateContext())
            {
                db.Companies.Remove(entity);
                db.SaveChanges();
            }

            return true;
        }
    }
}
