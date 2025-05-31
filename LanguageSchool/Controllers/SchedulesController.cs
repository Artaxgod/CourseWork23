using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchool.Model;

namespace LanguageSchool.Controllers
{
    public class SchedulesController
    {
        private readonly LanguageSchoolContext _context = new LanguageSchoolContext();

        public void AddSchedule(Schedules schedule)
        {
            _context.Schedules.Add(schedule);
            _context.SaveChanges();
        }

        public List<Schedules> GetAllSchedules()
        {
            return _context.Schedules.Include("Teachers").ToList();
        }

        public void UpdateSchedule(Schedules schedule)
        {
            _context.Entry(schedule).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
