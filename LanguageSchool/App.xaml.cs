using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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

            if (!Current.Properties.Contains("CurrentUser"))
            {
                LoginWindow login = new LoginWindow();
                login.Show();
            }
            else
            {
                MainWindow main = new MainWindow();
                main.Show();
            }
        }
    }
}
