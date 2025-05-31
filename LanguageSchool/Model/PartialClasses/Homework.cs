using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Model
{
    public partial class Homeworks
    {
        public string Group => GroupName;
        public string Title => Description;
        public string DueDate => Deadline.ToShortDateString();
        public string GroupName => Groups != null && Groups.Count > 0
            ? string.Join(", ", Groups.Select(g => g.GroupName))
            : string.Empty;
        /// <summary>
        /// Краткое описание домашнего задания, ограниченное 100 символами.
        /// </summary>
        public string ShortDescription => string.IsNullOrWhiteSpace(Description)
            ? "(без описания)"
            : (Description.Length > 100 ? Description.Substring(0, 100) + "..." : Description);

        /// <summary>
        /// Отображение даты сдачи домашнего задания в коротком формате.
        /// </summary>
        public string DueDisplay => Deadline.ToShortDateString();
    }
}
