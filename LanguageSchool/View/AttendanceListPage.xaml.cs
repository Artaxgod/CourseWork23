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
    /// Логика взаимодействия для AttendanceListPage.xaml
    /// </summary>
    public partial class AttendanceListPage : Page
    {
        private readonly LanguageSchoolDBEntities _context = new LanguageSchoolDBEntities();

        public AttendanceListPage()
        {
            InitializeComponent();
            LoadAttendances();
        }

        private void LoadAttendances()
        {
            var currentUser = App.Current.Properties["CurrentUser"] as Users;
            if (currentUser == null)
                return;

            var attendances = _context.Attendances
                .Where(a => a.Clients.UserID == currentUser.UserID)
                .Select(a => new
                {
                    Date = a.Schedules.LessonDate,
                    GroupName = a.Schedules.Groups.Select(g => g.GroupName).FirstOrDefault(),
                    IsPresent = a.IsPresent
                })
                .ToList();

            AttendanceDataGrid.ItemsSource = attendances;
        }
    }
}
