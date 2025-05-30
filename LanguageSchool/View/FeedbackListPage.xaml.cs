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
    /// Логика взаимодействия для FeedbackListPage.xaml
    /// </summary>
    public partial class FeedbackListPage : Page
    {
        private readonly FeedbackController _controller = new FeedbackController();

        public FeedbackListPage()
        {
            InitializeComponent();
            LoadFeedback();
        }

        private void LoadFeedback()
        {
            List<Feedback> feedbacks = _controller.GetAllFeedback();
            FeedbackDataGrid.ItemsSource = feedbacks;
        }
    }
}
