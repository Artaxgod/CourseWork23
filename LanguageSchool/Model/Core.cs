using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageSchool.Model
{
    public class Core
    {
        /// <summary>
        /// Поле _context хранит ссылку на экземпляр контекста базы данных LanguageSchoolDBEntities.
        /// Это поле используется для взаимодействия с базой данных.
        /// </summary>
        private readonly LanguageSchoolDBEntities _context;

        /// <summary>
        /// Конструктор класса Core инициализирует экземпляр класса с указанным контекстом базы данных.
        /// Если переданный контекст равен null, выбрасывается исключение ArgumentNullException.
        /// </summary>
        /// <param name="context">Экземпляр контекста базы данных LanguageSchoolDBEntities.</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, если переданный контекст равен null.</exception>
        public Core(LanguageSchoolDBEntities context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Свойство Context предоставляет доступ к текущему контексту базы данных.
        /// Оно возвращает экземпляр LanguageSchoolDBEntities, который был передан в конструктор.
        /// </summary>
        public LanguageSchoolDBEntities Context => _context;
    }
}
