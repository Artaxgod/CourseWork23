using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Model
{
    public class Feedback
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Client")]
        public int ClientID { get; set; }

        public string Text { get; set; }
        public DateTime DateSubmitted { get; set; }

        public virtual Client Client { get; set; }

        public Feedback()
        {
            Text = string.Empty;
            DateSubmitted = DateTime.Now;
            Client = new Client();
        }
    }
}
