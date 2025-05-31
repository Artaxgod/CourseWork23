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
        private readonly LanguageSchoolContext _context = new LanguageSchoolContext();
        private readonly Clients _client;

        public EditClientPage(Clients client)
        {
            InitializeComponent();
            _client = _context.Clients
                              .Include("Users")
                              .FirstOrDefault(c => c.ClientID == client.ClientID);

            if (_client != null && _client.Users != null)
            {
                FirstNameBox.Text = _client.Users.FirstName;
                LastNameBox.Text = _client.Users.LastName;
                EmailBox.Text = _client.Users.Email;
                PhoneBox.Text = _client.Users.Phone;
                PasswordBox.Password = _client.Users.Password;
                InfoBox.Text = _client.AdditionalInfo;
                MiddleNameBox.Text = _client.Users.MiddleName;
                BirthDatePicker.SelectedDate = _client.Users.DateOfBirth;
                GenderBox.SelectedItem = _client.Users.Gender;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (_client == null || _client.Users == null)
            {
                MessageBox.Show("Ошибка загрузки клиента.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _client.Users.FirstName = FirstNameBox.Text;
            _client.Users.LastName = LastNameBox.Text;
            _client.Users.Email = EmailBox.Text;
            _client.Users.Phone = PhoneBox.Text;
            _client.Users.Password = PasswordBox.Password;
            _client.AdditionalInfo = InfoBox.Text;
            _client.Users.MiddleName = MiddleNameBox.Text;
            _client.Users.DateOfBirth = BirthDatePicker.SelectedDate ?? DateTime.Now;
            _client.Users.Gender = (GenderBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            try
            {
                _context.SaveChanges();
                MessageBox.Show("Изменения сохранены.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
