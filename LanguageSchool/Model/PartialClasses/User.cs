using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchool.Model;

namespace LanguageSchool.Model
{
    public partial class Users
    {
        /// <summary>
        /// Свойство FullName возвращает полное имя пользователя, состоящее из имени, отчества и фамилии.
        /// Если какое-либо из значений отсутствует, оно игнорируется, а лишние пробелы удаляются.
        /// Например: "Иван Иванович Иванов" или "Иван Иванов".
        /// </summary>
        public string FullName => $"{FirstName} {MiddleName} {LastName}".Trim();
    }
}
