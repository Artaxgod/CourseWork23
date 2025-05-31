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
    /// Логика взаимодействия для EditFeedbackPage.xaml
    /// </summary>
    public partial class EditFeedbackPage : Page
    {
        private readonly FeedbackController _controller = new FeedbackController();
        private readonly Feedbacks _feedback;

        public EditFeedbackPage(Feedbacks feedback)
        {
            InitializeComponent();
            _feedback = feedback;
            TextBoxFeedback.Text = feedback.Content;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _feedback.Content = TextBoxFeedback.Text;
            _feedback.FeedbackDate = DateTime.Now;

            try
            {
                _controller.UpdateFeedback(_feedback);
                MessageBox.Show("Отзыв обновлён.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении отзыва: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
