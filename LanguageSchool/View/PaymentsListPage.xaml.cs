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
    /// Логика взаимодействия для PaymentsListPage.xaml
    /// </summary>
    public partial class PaymentsListPage : Page
    {
        private readonly PaymentsController _controller = new PaymentsController();

        public PaymentsListPage()
        {
            InitializeComponent();
            LoadPayments();
        }

        private void LoadPayments()
        {
            List<Payment> payments = _controller.GetAllPayments();
            PaymentsDataGrid.ItemsSource = payments;
        }
    }
}
