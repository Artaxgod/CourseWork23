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
    /// Логика взаимодействия для AddFeedbackPage.xaml
    /// </summary>
    public partial class AddFeedbackPage : Page
    {
        private readonly FeedbackController _controller = new FeedbackController();

        public AddFeedbackPage()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ClientIdBox.Text) || string.IsNullOrWhiteSpace(TextBoxFeedback.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Feedback feedback = new Feedback
            {
                ClientID = int.Parse(ClientIdBox.Text),
                Text = TextBoxFeedback.Text,
                DateSubmitted = DateTime.Now
            };

            try
            {
                _controller.AddFeedback(feedback);
                MessageBox.Show("Отзыв успешно отправлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении отзыва: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
