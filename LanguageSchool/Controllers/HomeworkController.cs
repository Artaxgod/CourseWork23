using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchool.Model;

namespace LanguageSchool.Controllers
{
    public class HomeworkController
    {
        private readonly LanguageSchoolContext _context = new LanguageSchoolContext();

        public void AddHomework(Homeworks hw)
        {
            _context.Homeworks.Add(hw);
            _context.SaveChanges();
        }

        public List<Homeworks> GetAllHomework()
        {
            return _context.Homeworks.Include("Groups").ToList();
        }

        public void UpdateHomework(Homeworks hw)
        {
            _context.Entry(hw).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
