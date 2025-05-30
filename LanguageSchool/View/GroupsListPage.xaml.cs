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
    /// Логика взаимодействия для GroupsListPage.xaml
    /// </summary>
    public partial class GroupsListPage : Page
    {
        private readonly GroupsController _controller = new GroupsController();

        public GroupsListPage()
        {
            InitializeComponent();
            LoadGroups();
        }

        private void LoadGroups()
        {
            List<Group> groups = _controller.GetAllGroups();
            GroupsDataGrid.ItemsSource = groups;
        }
    }
}
