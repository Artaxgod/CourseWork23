using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Model
{
    public partial class Feedbacks
    {
        public string AuthorName => Users != null ? Users.FullName : string.Empty;
    }
}
