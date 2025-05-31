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
    /// Логика взаимодействия для TeachersListPage.xaml
    /// </summary>
    public partial class TeachersListPage : Page
    {
        private readonly TeachersController _controller = new TeachersController();

        public TeachersListPage()
        {
            InitializeComponent();
            LoadTeachers();
        }

        private void LoadTeachers()
        {
            List<Teachers> teachers = _controller.GetAllTeachers();
            TeachersDataGrid.ItemsSource = teachers;
        }
    }
}
