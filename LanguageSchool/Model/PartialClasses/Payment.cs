using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Model
{
    public class Payment
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Client")]
        public int ClientID { get; set; }

        [ForeignKey("Service")]
        public int ServiceID { get; set; }

        public decimal Amount { get; set; }
        public DateTime DatePaid { get; set; }

        public virtual Client Client { get; set; }
        public virtual Service Service { get; set; }

        public Payment()
        {
            Amount = 0;
            DatePaid = DateTime.Now;
        }
    }
}
