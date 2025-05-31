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
using System.Windows.Shapes;
using LanguageSchool.Model;

namespace LanguageSchool.View
{
    /// <summary>
    /// Логика взаимодействия для TeacherDashboardWindow.xaml
    /// </summary>
    public partial class TeacherDashboardWindow : Window
    {
        public TeacherDashboardWindow()
        {
            InitializeComponent();
            var user = App.Current.Properties["CurrentUser"] as Users;
            WelcomeText.Text = $"Добро пожаловать, {user?.FirstName}";
        }

        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SchedulesListPage());
        }

        private void Homework_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HomeworkListPage());
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ClientsListPage());
        }

        private void Messages_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MessagesListPage());
        }

        private void Attendance_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TeacherAttendancePage());
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["CurrentUser"] = null;
            new LoginWindow().Show();
            this.Close();
        }
    }
}
