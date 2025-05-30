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
using LanguageSchool.View;
using LanguageSchool.Model.PartialClasses;

namespace LanguageSchool
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User _user;

        public MainWindow()
        {
            InitializeComponent();
            //_user = App.Current.Properties.Contains("CurrentUser")
            //? App.Current.Properties["CurrentUser"] as User
            //: null;
            _user = new User
            {
                FirstName = "Отладка",
                RoleID = 1 // Админ
            };
            //if (_user == null)
            //{
            //    MessageBox.Show("Ошибка авторизации. Пожалуйста, войдите снова.");
            //    new LoginWindow().Show();
            //    Close();
            //    return;
            //}

            WelcomeText.Text = $"Добро пожаловать, {_user.FirstName} ({GetRoleName(_user.RoleID)})";
            ApplyRolePermissions(_user.RoleID);
        }

        private void ApplyRolePermissions(int roleId)
        {
            // Предположим: 1 - Админ, 2 - Клиент, 3 - Преподаватель
            if (roleId == 2) // Клиент
            {
                ClientsBtn.Visibility = Visibility.Collapsed;
                TeachersBtn.Visibility = Visibility.Collapsed;
                GroupsBtn.Visibility = Visibility.Collapsed;
                ServicesBtn.Visibility = Visibility.Collapsed;
                ScheduleBtn.Visibility = Visibility.Collapsed;
                PaymentsBtn.Visibility = Visibility.Collapsed;
            }
            else if (roleId == 3) // Преподаватель
            {
                ClientsBtn.Visibility = Visibility.Collapsed;
                TeachersBtn.Visibility = Visibility.Collapsed;
                ServicesBtn.Visibility = Visibility.Collapsed;
                PaymentsBtn.Visibility = Visibility.Collapsed;
            }
            // Администратору доступно всё
        }

        private string GetRoleName(int roleId)
        {
            switch (roleId)
            {
                case 1: return "Администратор";
                case 2: return "Клиент";
                case 3: return "Преподаватель";
                default: return "Пользователь";
            }
        }

        private void Clients_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new ClientsListPage());
        private void Teachers_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new TeachersListPage());
        private void Groups_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new GroupsListPage());
        private void Services_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new ServicesListPage());
        private void Schedule_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new SchedulesListPage());
        private void Homework_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new HomeworkListPage());
        private void Messages_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new MessagesListPage());
        private void Feedback_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new FeedbackListPage());
        private void Payments_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new PaymentsListPage());
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties.Remove("CurrentUser");
            LoginWindow login = new LoginWindow();
            login.Show();
            Close();
        }
    }
}
