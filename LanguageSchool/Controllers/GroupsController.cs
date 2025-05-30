using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchool.Model;

namespace LanguageSchool.Controllers
{
    public class GroupsController
    {
        private readonly LanguageSchoolContext _context = new LanguageSchoolContext();

        public void AddGroup(Group group)
        {
            _context.Groups.Add(group);
            _context.SaveChanges();
        }

        public List<Group> GetAllGroups()
        {
            return _context.Groups.ToList();
        }

        public void UpdateGroup(Group group)
        {
            _context.Entry(group).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
