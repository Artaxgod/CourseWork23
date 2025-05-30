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
        /// <summary>
        /// Свойство FormattedDateTime возвращает отформатированную строку даты и времени занятия.
        /// Формат: "дата (в формате короткой даты) время (в формате чч:мм)".
        /// Например: "15.10.2023 14:30".
        /// </summary>
        public string FormattedDateTime
        {
            get => $"{LessonDate.ToShortDateString()} {LessonTime:hh\\:mm}";
        }
    }
}
