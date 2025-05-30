using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Model
{
    public class Client
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public string AdditionalInfo { get; set; }
        public virtual User User { get; set; }

        public Client()
        {
            AdditionalInfo = string.Empty;
            User = new User();
        }
    }
}
