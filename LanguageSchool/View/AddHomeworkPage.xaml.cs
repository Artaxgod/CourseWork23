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
    /// Логика взаимодействия для AddHomeworkPage.xaml
    /// </summary>
    public partial class AddHomeworkPage : Page
    {
        private readonly HomeworkController _controller = new HomeworkController();

        public AddHomeworkPage()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleBox.Text) || string.IsNullOrWhiteSpace(GroupIdBox.Text))
            {
                MessageBox.Show("Введите обязательные поля (название и ID группы).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Homeworks hw = new Homeworks
            {
                Description = DescriptionBox.Text,
                Deadline = DueDatePicker.SelectedDate ?? DateTime.Now.AddDays(7)
            };

            try
            {
                _controller.AddHomework(hw);
                MessageBox.Show("Домашнее задание добавлено.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении задания: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
