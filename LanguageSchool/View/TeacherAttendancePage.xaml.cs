using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LanguageSchool.Model;

namespace LanguageSchool.View
{
    /// <summary>
    /// Логика взаимодействия для TeacherAttendancePage.xaml
    /// </summary>
    public partial class TeacherAttendancePage : Page
    {
        private readonly LanguageSchoolContext _context = new LanguageSchoolContext();
        private List<Attendances> _attendances;

        public TeacherAttendancePage()
        {
            InitializeComponent();
            LoadAttendances();
        }

        private void LoadAttendances()
        {
            var currentUser = App.Current.Properties["CurrentUser"] as Users;
            if (currentUser == null)
            {
                MessageBox.Show("Ошибка: пользователь не найден.");
                return;
            }

            var teacher = _context.Teachers.FirstOrDefault(t => t.UserID == currentUser.UserID);
            if (teacher == null)
            {
                MessageBox.Show("Преподаватель не найден.");
                return;
            }

            _attendances = _context.Attendances
                .Include("Clients.Users")
                .Include("Schedules.Groups")
                .Where(a => a.Schedules.TeacherID == teacher.TeacherID)
                .ToList();

            AttendanceDataGrid.ItemsSource = _attendances;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _context.SaveChanges();
            MessageBox.Show("Изменения сохранены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

}
