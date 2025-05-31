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

        public void AddClient(Users user, string additionalInfo)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            Clients client = new Clients
            {
                UserID = user.UserID,
                AdditionalInfo = additionalInfo
            };

            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public List<Clients> GetAllClients()
        {
            return _context.Clients.Include("Users").ToList();
        }

        public void UpdateClient(Clients client)
        {
            _context.Entry(client).State = System.Data.Entity.EntityState.Modified;
            _context.Entry(client.Users).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }

}
