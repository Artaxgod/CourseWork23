using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Model
{
    public class Schedule
    {
        [Key]
        public int ID { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherID { get; set; }

        public string Subject { get; set; }
        public virtual Teacher Teacher { get; set; }

        public Schedule()
        {
            Subject = string.Empty;
            Teacher = new Teacher();
        }
    }
}
