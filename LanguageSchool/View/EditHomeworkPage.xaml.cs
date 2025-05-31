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
    /// Логика взаимодействия для EditHomeworkPage.xaml
    /// </summary>
    public partial class EditHomeworkPage : Page
    {
        private readonly HomeworkController _controller = new HomeworkController();
        private readonly Homeworks _homework;

        public EditHomeworkPage(Homeworks homework)
        {
            InitializeComponent();
            _homework = homework;
            LoadHomework();
        }

        private void LoadHomework()
        {
            TitleBox.Text = _homework.Description; // если используешь одно поле как "название"
            DescriptionBox.Text = _homework.Description;
            DueDatePicker.SelectedDate = _homework.Deadline;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _homework.Description = DescriptionBox.Text;
            _homework.Deadline = DueDatePicker.SelectedDate ?? DateTime.Now.AddDays(7);

            try
            {
                _controller.UpdateHomework(_homework);
                MessageBox.Show("Задание успешно обновлено.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении задания: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
