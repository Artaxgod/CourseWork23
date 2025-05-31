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
    /// Логика взаимодействия для AddSchedulePage.xaml
    /// </summary>
    public partial class AddSchedulePage : Page
    {
        private readonly SchedulesController _controller = new SchedulesController();

        public AddSchedulePage()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SubjectBox.Text) || string.IsNullOrWhiteSpace(TeacherIdBox.Text))
            {
                MessageBox.Show("Заполните все обязательные поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(TeacherIdBox.Text, out int teacherId))
            {
                MessageBox.Show("Некорректный ID преподавателя.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (StartDatePicker.SelectedDate == null || EndDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Укажите дату и время.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var start = StartDatePicker.SelectedDate.Value;
            var end = EndDatePicker.SelectedDate.Value;
            var time = end - start;

            Schedules schedule = new Schedules
            {
                Topic = SubjectBox.Text,
                TeacherID = teacherId,
                LessonDate = start.Date,
                LessonTime = time
            };

            try
            {
                _controller.AddSchedule(schedule);
                MessageBox.Show("Расписание успешно добавлено!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении расписания: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
