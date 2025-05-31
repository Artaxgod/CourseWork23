using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LanguageSchool.Model
{
    public partial class Messages
    {
        /// <summary>
        /// Имя отправителя (преподаватель).
        /// </summary>
        public string FromName => Teachers != null ? Teachers.FullName : string.Empty;
        /// <summary>
        /// Имя получателя (клиент).
        /// </summary>
        public string ToName => Clients != null ? Clients.FullName : string.Empty;
    }
}
