using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Model
{
    public class Message
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Sender")]
        public int SenderID { get; set; }

        [ForeignKey("Receiver")]
        public int ReceiverID { get; set; }

        public string Text { get; set; }
        public DateTime SentAt { get; set; }

        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }

        public Message()
        {
            Text = string.Empty;
            SentAt = DateTime.Now;
        }
    }
}
