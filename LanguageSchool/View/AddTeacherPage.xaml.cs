﻿using System;
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
    /// Логика взаимодействия для AddTeacherPage.xaml
    /// </summary>
    public partial class AddTeacherPage : Page
    {
        private readonly LanguageSchoolContext _context = new LanguageSchoolContext();

        public AddTeacherPage()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
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
                RoleID = 3 // Преподаватель
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            var teacher = new Teachers
            {
                UserID = user.UserID,
                Specialization = SpecializationBox.Text
            };

            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            MessageBox.Show("Преподаватель успешно добавлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
