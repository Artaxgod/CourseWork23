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
using LanguageSchool.Model.PartialClasses;
namespace LanguageSchool.View
{
    /// <summary>
    /// Логика взаимодействия для ClientsListPage.xaml
    /// </summary>
    public partial class ClientsListPage : Page
    {
        private readonly ClientsController _controller = new ClientsController();

        public ClientsListPage()
        {
            InitializeComponent();
            LoadClients();
        }

        private void LoadClients()
        {
            List<Client> client = _controller.GetAllClients();
            ClientsDataGrid.ItemsSource = client;
        }
    }
}
