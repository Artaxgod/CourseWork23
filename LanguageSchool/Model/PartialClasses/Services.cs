using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Model
{
    public partial class Services
    {
        public string Title => ServiceName;
        public string TitleAndPrice => $"{ServiceName} - {Price:C}";
    }
}
