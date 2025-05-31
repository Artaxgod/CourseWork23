using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LanguageSchool.Model
{
    /// <summary>
    /// Расширение класса Client: возвращает имя клиента на основе связанного пользователя.
    /// </summary>
    public partial class Clients
    {
        public string FullName => Users != null ? Users.FullName : string.Empty;
        public string Email => Users != null ? Users.Email : string.Empty;
        public string Phone => Users != null ? Users.Phone : string.Empty;
    }
}

