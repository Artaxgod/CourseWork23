using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchool.Model;
using LanguageSchool.Model.PartialClasses;

namespace LanguageSchool.Controllers
{
    public class TeachersController
    {
        private readonly LanguageSchoolContext _context = new LanguageSchoolContext();

        public void AddTeacher(User user, string specialization)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            Teacher teacher = new Teacher
            {
                UserID = user.ID,
                Specialization = specialization
            };

            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        public List<Teacher> GetAllTeachers()
        {
            return _context.Teachers.Include("User").ToList();
        }

        public void UpdateTeacher(Teacher teacher)
        {
            _context.Entry(teacher).State = System.Data.Entity.EntityState.Modified;
            _context.Entry(teacher.User).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
