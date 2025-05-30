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
    /// Логика взаимодействия для EditServicePage.xaml
    /// </summary>
    public partial class EditServicePage : Page
    {
        private readonly ServicesController _controller = new ServicesController();
        private readonly Service _service;

        public EditServicePage(Service service)
        {
            InitializeComponent();
            _service = service;
            TitleBox.Text = service.Title;
            DescriptionBox.Text = service.Description;
            PriceBox.Text = service.Price.ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            decimal price;
            if (!decimal.TryParse(PriceBox.Text, out price))
            {
                MessageBox.Show("Введите корректную цену.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _service.Title = TitleBox.Text;
            _service.Description = DescriptionBox.Text;
            _service.Price = price;

            try
            {
                _controller.UpdateService(_service);
                MessageBox.Show("Услуга обновлена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении услуги: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
