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
    /// Логика взаимодействия для ManagerDashboardWindow.xaml
    /// </summary>
    public partial class ManagerDashboardWindow : Window
    {
        public ManagerDashboardWindow()
        {
            InitializeComponent();

            var user = App.Current.Properties["CurrentUser"] as Users;
            WelcomeText.Text = $"Добро пожаловать, {user?.FirstName}";

            MainFrame.Navigate(new ClientsListPage());
        }

        private void Clients_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new ClientsListPage());
        private void Teachers_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new TeachersListPage());
        private void Services_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new ServicesListPage());
        private void Reports_Click(object sender, RoutedEventArgs e) => MainFrame.Navigate(new ManagerReportsPage());
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Properties["CurrentUser"] = null;
            var login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}
