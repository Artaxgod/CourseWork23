using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchool.Model;

namespace LanguageSchool.Controllers
{
    public class MessagesController
    {
        private readonly LanguageSchoolContext _context = new LanguageSchoolContext();

        public void SendMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public List<Message> GetAllMessages()
        {
            return _context.Messages.Include("Sender").Include("Receiver").ToList();
        }
    }
}
