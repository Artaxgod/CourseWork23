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
        private readonly LanguageSchoolContext _context = new LanguageSchoolContext();
        private readonly Teachers _teacher;

        public EditTeacherPage(Teachers teacher)
        {
            InitializeComponent();
            _teacher = _context.Teachers.Include("Users").Include("Groups").FirstOrDefault(t => t.TeacherID == teacher.TeacherID);

            if (_teacher != null && _teacher.Users != null)
            {
                FirstNameBox.Text = _teacher.Users.FirstName;
                LastNameBox.Text = _teacher.Users.LastName;
                MiddleNameBox.Text = _teacher.Users.MiddleName;
                EmailBox.Text = _teacher.Users.Email;
                PhoneBox.Text = _teacher.Users.Phone;
                BirthDatePicker.SelectedDate = _teacher.Users.DateOfBirth;
                GenderBox.SelectedItem = _teacher.Users.Gender;
                SpecializationBox.Text = _teacher.Specialization;
            }

            GroupsComboBox.ItemsSource = _context.Groups.ToList();
            // Установка выбранных групп вручную
            if (_teacher.Groups != null)
            {
                foreach (var group in _teacher.Groups)
                {
                    GroupsComboBox.SelectedItems.Add(group);
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _teacher.Users.FirstName = FirstNameBox.Text;
            _teacher.Users.LastName = LastNameBox.Text;
            _teacher.Users.MiddleName = MiddleNameBox.Text;
            _teacher.Users.Email = EmailBox.Text;
            _teacher.Users.Phone = PhoneBox.Text;
            _teacher.Users.DateOfBirth = BirthDatePicker.SelectedDate ?? DateTime.Now;
            _teacher.Users.Gender = (GenderBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            _teacher.Specialization = SpecializationBox.Text;

            _teacher.Groups.Clear();
            foreach (Groups selected in GroupsComboBox.SelectedItems)
            {
                _teacher.Groups.Add(selected);
            }

            _context.SaveChanges();
            MessageBox.Show("Преподаватель обновлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

}
