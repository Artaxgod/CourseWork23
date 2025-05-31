using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Model
{
    public partial class Schedules
    {
        public string Subject => Topic;
        public string StartTime => LessonTime.ToString("hh':'mm");
        public string EndTime => LessonTime.Add(TimeSpan.FromMinutes(45)).ToString("hh':'mm");
        public string TeacherName => Teachers != null ? Teachers.FullName : string.Empty;
        public string GroupDisplay => Groups != null && Groups.Count > 0
            ? string.Join(", ", Groups.Select(g => g.GroupTitle))
            : string.Empty;

        public string TimeDisplay => LessonTime.ToString("hh':'mm") + " | " + LessonDate.ToShortDateString();
    }
}
