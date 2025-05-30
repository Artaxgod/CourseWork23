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
    /// Логика взаимодействия для EditPaymentPage.xaml
    /// </summary>
    public partial class EditPaymentPage : Page
    {
        private readonly PaymentsController _controller = new PaymentsController();
        private readonly Payment _payment;

        public EditPaymentPage(Payment payment)
        {
            InitializeComponent();
            _payment = payment;
            AmountBox.Text = payment.Amount.ToString();
            DatePaidPicker.SelectedDate = payment.DatePaid;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(AmountBox.Text, out decimal amount))
            {
                MessageBox.Show("Введите корректную сумму.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _payment.Amount = amount;
            _payment.DatePaid = DatePaidPicker.SelectedDate ?? DateTime.Now;

            try
            {
                _controller.UpdatePayment(_payment);
                MessageBox.Show("Оплата обновлена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении оплаты: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
