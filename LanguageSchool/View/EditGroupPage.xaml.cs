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
    /// Логика взаимодействия для EditGroupPage.xaml
    /// </summary>
    public partial class EditGroupPage : Page
    {
        private readonly GroupsController _controller = new GroupsController();
        private readonly Model.Groups _group;

        public EditGroupPage(Model.Groups group)
        {
            InitializeComponent();
            _group = group;
            GroupNameBox.Text = group.GroupName;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _group.GroupName = GroupNameBox.Text;
            try
            {
                _controller.UpdateGroup(_group);
                MessageBox.Show("Группа обновлена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении группы: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
