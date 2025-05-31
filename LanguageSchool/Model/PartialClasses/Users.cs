using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Model
{
    /// <summary>
    /// Расширение класса User: возвращает полное имя пользователя.
    /// </summary>
    public partial class Users
    {
        /// <summary>
        /// Возвращает полное имя, включая имя, отчество и фамилию.
        /// </summary>
        public string FullName => $"{FirstName} {MiddleName} {LastName}".Trim();
    }
}

