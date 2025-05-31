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
    /// Логика взаимодействия для EditTeacherPage.xaml
    /// </summary>
    public partial class EditTeacherPage : Page
    {
        private readonly TeachersController _controller = new TeachersController();
        private readonly Teachers _teacher;

        public EditTeacherPage(Teachers teacher)
        {
            InitializeComponent();
            _teacher = teacher;
            LoadTeacherData();
        }

        private void LoadTeacherData()
        {
            FirstNameBox.Text = _teacher.Users.FirstName;
            LastNameBox.Text = _teacher.Users.LastName;
            EmailBox.Text = _teacher.Users.Email;
            PhoneBox.Text = _teacher.Users.Phone;
            PasswordBox.Password = _teacher.Users.Password;
            SpecializationBox.Text = _teacher.Specialization;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _teacher.Users.FirstName = FirstNameBox.Text;
            _teacher.Users.LastName = LastNameBox.Text;
            _teacher.Users.Email = EmailBox.Text;
            _teacher.Users.Phone = PhoneBox.Text;
            _teacher.Users.Password = PasswordBox.Password;
            _teacher.Specialization = SpecializationBox.Text;

            try
            {
                _controller.UpdateTeacher(_teacher);
                MessageBox.Show("Информация о преподавателе успешно обновлена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении преподавателя: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
