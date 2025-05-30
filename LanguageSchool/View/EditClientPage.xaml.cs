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
    /// Логика взаимодействия для EditClientPage.xaml
    /// </summary>
    public partial class EditClientPage : Page
    {
        private readonly ClientsController _controller = new ClientsController();
        private readonly Client _client;

        public EditClientPage(Client client)
        {
            InitializeComponent();
            _client = client;
            LoadClientData();
        }

        private void LoadClientData()
        {
            FirstNameBox.Text = _client.User.FirstName;
            LastNameBox.Text = _client.User.LastName;
            EmailBox.Text = _client.User.Email;
            PhoneBox.Text = _client.User.Phone;
            PasswordBox.Password = _client.User.Password;
            InfoBox.Text = _client.AdditionalInfo;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _client.User.FirstName = FirstNameBox.Text;
            _client.User.LastName = LastNameBox.Text;
            _client.User.Email = EmailBox.Text;
            _client.User.Phone = PhoneBox.Text;
            _client.User.Password = PasswordBox.Password;
            _client.AdditionalInfo = InfoBox.Text;

            try
            {
                _controller.UpdateClient(_client);
                MessageBox.Show("Информация о клиенте успешно обновлена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении информации о клиенте: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
