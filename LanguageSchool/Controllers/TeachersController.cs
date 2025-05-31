using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchool.Model;

namespace LanguageSchool.Controllers
{
    public class TeachersController
    {
        private readonly LanguageSchoolContext _context = new LanguageSchoolContext();

        public void AddTeacher(Model.Users user, string specialization)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            Teachers teacher = new Teachers
            {
                UserID = user.UserID,
                Specialization = specialization
            };

            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        public List<Teachers> GetAllTeachers()
        {
            return _context.Teachers.Include("Users").ToList();
        }

        public void UpdateTeacher(Teachers teacher)
        {
            _context.Entry(teacher).State = System.Data.Entity.EntityState.Modified;
            _context.Entry(teacher.Users).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
