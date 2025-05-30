using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Model
{
    public class Service
    {
        [Key]
        public int ID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Service()
        {
            Title = string.Empty;
            Description = string.Empty;
            Price = 0;
        }
    }
}
