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
    /// Логика взаимодействия для SendMessagePage.xaml
    /// </summary>
    public partial class SendMessagePage : Page
    {
        private readonly MessagesController _controller = new MessagesController();

        public SendMessagePage()
        {
            InitializeComponent();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            int senderId, receiverId;
            if (!int.TryParse(SenderIdBox.Text, out senderId) || !int.TryParse(ReceiverIdBox.Text, out receiverId))
            {
                MessageBox.Show("Введите корректные ID отправителя и получателя.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(MessageTextBox.Text))
            {
                MessageBox.Show("Введите текст сообщения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Messages message = new Messages
            {
                TeacherID = senderId,
                ClientID = receiverId,
                MessageText = MessageTextBox.Text,
                SentDate = DateTime.Now
            };

            try
            {
                _controller.SendMessage(message);
                MessageBox.Show("Сообщение отправлено.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при отправке: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
