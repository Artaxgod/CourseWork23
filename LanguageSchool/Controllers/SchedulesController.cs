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

        public void AddSchedule(Schedule schedule)
        {
            _context.Schedules.Add(schedule);
            _context.SaveChanges();
        }

        public List<Schedule> GetAllSchedules()
        {
            return _context.Schedules.Include("Teacher").ToList();
        }

        public void UpdateSchedule(Schedule schedule)
        {
            _context.Entry(schedule).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
