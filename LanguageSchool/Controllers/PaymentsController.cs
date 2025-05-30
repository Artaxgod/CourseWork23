using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchool.Model;
using LanguageSchool.Model.PartialClasses;

namespace LanguageSchool.Controllers
{
    public class PaymentsController
    {
        private readonly LanguageSchoolContext _context = new LanguageSchoolContext();

        public void AddPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();
        }

        public List<Payment> GetAllPayments()
        {
            return _context.Payments.Include("Client").Include("Service").ToList();
        }

        public void UpdatePayment(Payment payment)
        {
            _context.Entry(payment).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
