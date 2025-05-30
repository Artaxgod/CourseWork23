using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchool.Model;
using LanguageSchool.Model.PartialClasses;

namespace LanguageSchool.Controllers
{
    public class HomeworkController
    {
        private readonly LanguageSchoolContext _context = new LanguageSchoolContext();

        public void AddHomework(Homework hw)
        {
            _context.Homeworks.Add(hw);
            _context.SaveChanges();
        }

        public List<Homework> GetAllHomework()
        {
            return _context.Homeworks.Include("Group").ToList();
        }

        public void UpdateHomework(Homework hw)
        {
            _context.Entry(hw).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
