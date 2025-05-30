using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchool.Model;
using LanguageSchool.Model.PartialClasses;

namespace LanguageSchool.Controllers
{
    public class FeedbackController
    {
        private readonly LanguageSchoolContext _context = new LanguageSchoolContext();

        public void AddFeedback(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
        }

        public List<Feedback> GetAllFeedback()
        {
            return _context.Feedbacks.Include("Client").ToList();
        }

        public void UpdateFeedback(Feedback feedback)
        {
            _context.Entry(feedback).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
