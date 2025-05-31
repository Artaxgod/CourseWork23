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
    /// Логика взаимодействия для AddClientPage.xaml
    /// </summary>

    public partial class AddClientPage : Page
    {
        private readonly LanguageSchoolContext _context = new LanguageSchoolContext();

        public AddClientPage()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Создаём пользователя
            var user = new Users
            {
                FirstName = FirstNameBox.Text,
                LastName = LastNameBox.Text,
                MiddleName = MiddleNameBox.Text,
                Email = EmailBox.Text,
                Phone = PhoneBox.Text,
                DateOfBirth = BirthDatePicker.SelectedDate ?? DateTime.Now,
                Gender = (GenderBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                Password = PasswordBox.Password,
                RoleID = 4 // Клиент
            };

            _context.Users.Add(user);
            _context.SaveChanges(); // сохраняем, чтобы получить ID

            // Создаём клиента и привязываем к пользователю
            var client = new Clients
            {
                UserID = user.UserID,
                AdditionalInfo = InfoBox.Text
            };

            _context.Clients.Add(client);
            _context.SaveChanges();

            MessageBox.Show("Клиент успешно добавлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
