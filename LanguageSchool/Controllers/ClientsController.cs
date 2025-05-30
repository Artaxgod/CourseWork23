using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchool.Model;

namespace LanguageSchool.Controllers
{
    public class ClientsController
    {
        private readonly LanguageSchoolContext _context = new LanguageSchoolContext();

        public void AddClient(User user, string additionalInfo)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            Client client = new Client
            {
                UserID = user.ID,
                AdditionalInfo = additionalInfo
            };

            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public List<Client> GetAllClients()
        {
            return _context.Clients.Include("User").ToList();
        }

        public void UpdateClient(Client client)
        {
            _context.Entry(client).State = System.Data.Entity.EntityState.Modified;
            _context.Entry(client.User).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
