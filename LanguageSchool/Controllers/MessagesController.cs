using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchool.Model;

namespace LanguageSchool.Controllers
{
    public class MessagesController
    {
        private readonly LanguageSchoolContext _context = new LanguageSchoolContext();

        /// <summary>
        /// Получает все сообщения с включением преподавателя и клиента.
        /// </summary>
        public List<Messages> GetAllMessages()
        {
            return _context.Messages
                .Include("Teachers")
                .Include("Clients")
                .ToList();
        }

        /// <summary>
        /// Добавляет новое сообщение.
        /// </summary>
        /// <param name="message">Сообщение для добавления</param>
        public void SendMessage(Messages message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        /// <summary>
        /// Обновляет существующее сообщение (например, отметку о прочтении).
        /// </summary>
        /// <param name="message">Сообщение для обновления</param>
        public void UpdateMessage(Messages message)
        {
            _context.Entry(message).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
