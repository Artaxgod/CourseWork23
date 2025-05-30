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
    /// Логика взаимодействия для HomeworkListPage.xaml
    /// </summary>
    public partial class HomeworkListPage : Page
    {
        private readonly HomeworkController _controller = new HomeworkController();

        public HomeworkListPage()
        {
            InitializeComponent();
            LoadHomework();
        }

        private void LoadHomework()
        {
            List<Homework> homeworkList = _controller.GetAllHomework();
            HomeworkDataGrid.ItemsSource = homeworkList;
        }
    }
}
