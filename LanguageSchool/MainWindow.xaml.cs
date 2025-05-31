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

namespace LanguageSchool
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Users _user;

        public MainWindow()
        {
            InitializeComponent();
            _user = App.Current.Properties["CurrentUser"] as Users;
            if (_user == null)
            {
                MessageBox.Show("Ошибка авторизации. Пожалуйста, войдите снова.");
                new LoginWindow().Show();
                Close();
                return;
            }

            WelcomeText.Text = $"Добро пожаловать, {_user.FirstName} ({GetRoleName(_user.RoleID)})";
        }

        private string GetRoleName(int roleId)
        {
            switch (roleId)
            {
                case 1: return "Администратор";
                case 2: return "Менеджер";
                case 3: return "Преподаватель";
                case 4: return "Клиент";
                default: return "Пользователь";
            }
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ClientsListPage());
        }

        private void Teachers_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TeachersListPage());
        }

        private void Groups_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new GroupsListPage());
        }

        private void Services_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ServicesListPage());
        }

        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SchedulesListPage());
        }

        private void Homework_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HomeworkListPage());
        }

        private void Messages_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MessagesListPage());
        }

        private void Feedback_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new FeedbackListPage());
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties.Remove("CurrentUser");
            new LoginWindow().Show();
            Close();
        }
    }

}
