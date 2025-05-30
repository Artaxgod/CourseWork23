using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Model
{
    public class Teacher
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public string Specialization { get; set; }
        public virtual User User { get; set; }

        public Teacher()
        {
            Specialization = string.Empty;
            User = new User();
        }
    }
}
