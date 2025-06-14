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
    /// Логика взаимодействия для EditSchedulePage.xaml
    /// </summary>
    public partial class EditSchedulePage : Page
    {
        private readonly SchedulesController _controller = new SchedulesController();
        private readonly Schedules _schedule;

        public EditSchedulePage(Schedules schedule)
        {
            InitializeComponent();
            _schedule = schedule;
            LoadScheduleData();
        }

        private void LoadScheduleData()
        {
            SubjectBox.Text = _schedule.Topic;
            StartDatePicker.SelectedDate = _schedule.LessonDate;
            EndDatePicker.SelectedDate = _schedule.LessonDate.Add(_schedule.LessonTime); // если ты хочешь имитировать EndTime
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _schedule.Topic = SubjectBox.Text;
            _schedule.LessonDate = StartDatePicker.SelectedDate ?? DateTime.Now;

            var endTime = EndDatePicker.SelectedDate ?? DateTime.Now.AddHours(1);
            _schedule.LessonTime = endTime.TimeOfDay; 

            try
            {
                _controller.UpdateSchedule(_schedule);
                MessageBox.Show("Расписание успешно обновлено.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении расписания: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
