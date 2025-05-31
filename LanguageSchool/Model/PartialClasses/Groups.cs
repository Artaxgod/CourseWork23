using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LanguageSchool.Model
{
    public partial class Groups
    {
        public string Name => GroupName;
        public string TeacherName => Teachers != null && Teachers.Count > 0
            ? string.Join(", ", Teachers.Select(t => t.FullName))
            : string.Empty;

        public string GroupTitle => GroupName; // используем корректное свойство из модели
    }
}
