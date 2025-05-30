using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchool.Model;

namespace LanguageSchool.Controllers
{
    public class ServicesController
    {
        private readonly LanguageSchoolContext _context = new LanguageSchoolContext();

        public void AddService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public List<Service> GetAllServices()
        {
            return _context.Services.ToList();
        }

        public void UpdateService(Service service)
        {
            _context.Entry(service).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
