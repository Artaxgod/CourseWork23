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
    /// Логика взаимодействия для AddPaymentPage.xaml
    /// </summary>
    public partial class AddPaymentPage : Page
    {
        private readonly PaymentsController _controller = new PaymentsController();

        public AddPaymentPage()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(ClientIdBox.Text, out int clientId) ||
                !int.TryParse(ServiceIdBox.Text, out int serviceId) ||
                !decimal.TryParse(AmountBox.Text, out decimal amount))
            {
                MessageBox.Show("Проверьте корректность введённых значений.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Payment payment = new Payment
            {
                ClientID = clientId,
                ServiceID = serviceId,
                Amount = amount,
                DatePaid = DatePaidPicker.SelectedDate ?? DateTime.Now
            };

            try
            {
                _controller.AddPayment(payment);
                MessageBox.Show("Оплата успешно добавлена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении оплаты: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
