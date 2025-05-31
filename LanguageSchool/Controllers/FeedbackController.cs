using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchool.Model;

namespace LanguageSchool.Controllers
{
    public class FeedbackController
    {
        private readonly LanguageSchoolContext _context = new LanguageSchoolContext();

        /// <summary>
        /// Получает все отзывы, включая информацию о пользователе.
        /// </summary>
        public List<Feedbacks> GetAllFeedbacks()
        {
            return _context.Feedbacks.Include("Users").ToList();
        }

        /// <summary>
        /// Добавляет новый отзыв.
        /// </summary>
        public void AddFeedback(Feedbacks feedback)
        {
            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
        }

        /// <summary>
        /// Обновляет существующий отзыв (например, отмечает как прочитанный).
        /// </summary>
        public void UpdateFeedback(Feedbacks feedback)
        {
            _context.Entry(feedback).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
