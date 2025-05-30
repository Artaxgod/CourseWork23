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
        /// <summary>
        /// Свойство IsOverdue определяет, просрочено ли домашнее задание.
        /// Возвращает true, если текущая дата превышает дату дедлайна (Deadline), иначе false.
        /// </summary>
        public bool IsOverdue
        {
            get => DateTime.Now > Deadline;
        }
    }
}
