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
using LanguageSchool.Controllers;
using LanguageSchool.Model;

namespace LanguageSchool.View
{
    /// <summary>
    /// Логика взаимодействия для TeachersListPage.xaml
    /// </summary>
    public partial class TeachersListPage : Page
    {
        private readonly LanguageSchoolContext _context = new LanguageSchoolContext();

        public TeachersListPage()
        {
            InitializeComponent();
            LoadTeachers();
        }

        private void LoadTeachers()
        {
            var teachers = _context.Teachers.Include("Users").ToList();
            TeachersDataGrid.ItemsSource = teachers;
        }

        private void EditTeacher_Click(object sender, RoutedEventArgs e)
        {
            var teacher = (sender as Button)?.DataContext as Teachers;
            if (teacher != null)
            {
                NavigationService.Navigate(new EditTeacherPage(teacher));
            }
        }
        private void AddTeacher_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTeacherPage());
        }
    }
}
