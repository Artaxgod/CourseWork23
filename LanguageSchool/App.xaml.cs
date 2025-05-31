using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using LanguageSchool.Model;
using LanguageSchool.View;

namespace LanguageSchool
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // временная авторизация отладки
            Current.Properties["CurrentUser"] = new Model.Users
            {
                FirstName = "Отладка",
                RoleID = 1
            };

            var main = new MainWindow();
            this.MainWindow = main;
            main.Show();
        }
    }
}
