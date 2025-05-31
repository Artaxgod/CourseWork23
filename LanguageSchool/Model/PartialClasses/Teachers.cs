using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Model
{
    public partial class Teachers
    {
        public string FullName => Users != null ? Users.FullName : string.Empty;
        public string FirstName => Users != null ? Users.FirstName : string.Empty;
        public string LastName => Users != null ? Users.LastName : string.Empty;
        public string Email => Users != null ? Users.Email : string.Empty;
        public string Phone => Users != null ? Users.Phone : string.Empty;
    }
}
