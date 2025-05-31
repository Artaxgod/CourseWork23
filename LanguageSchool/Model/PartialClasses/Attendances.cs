using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Model
{
    public partial class Attendances
    {
        public string Student => Clients?.Users?.FullName ?? "—";

        public string Date => Schedules?.LessonDate.ToShortDateString() ?? "—";

        public string GroupName => Schedules?.Groups.FirstOrDefault()?.GroupName ?? "—";
    }
}
