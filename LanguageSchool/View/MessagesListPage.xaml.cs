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
    /// Логика взаимодействия для MessagesListPage.xaml
    /// </summary>
    public partial class MessagesListPage : Page
    {
        private readonly MessagesController _controller = new MessagesController();

        public MessagesListPage()
        {
            InitializeComponent();
            LoadMessages();
        }

        private void LoadMessages()
        {
            List<Message> messages = _controller.GetAllMessages();
            MessagesDataGrid.ItemsSource = messages;
        }
    }
}
