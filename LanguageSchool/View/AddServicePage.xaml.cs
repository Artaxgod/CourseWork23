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
    /// Логика взаимодействия для AddServicePage.xaml
    /// </summary>
    public partial class AddServicePage : Page
    {
        private readonly ServicesController _controller = new ServicesController();

        public AddServicePage()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleBox.Text) || string.IsNullOrWhiteSpace(PriceBox.Text))
            {
                MessageBox.Show("Заполните обязательные поля (название и цена).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            decimal price;
            if (!decimal.TryParse(PriceBox.Text, out price))
            {
                MessageBox.Show("Введите корректную цену.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Services service = new Services
            {
                ServiceName = TitleBox.Text,
                Description = DescriptionBox.Text,
                Price = price
            };

            try
            {
                _controller.AddService(service);
                MessageBox.Show("Услуга добавлена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении услуги: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
