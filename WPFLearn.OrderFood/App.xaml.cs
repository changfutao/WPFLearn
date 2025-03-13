using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.Windows;
using WPFLearn.OrderFood.Helper;

namespace WPFLearn.OrderFood
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            var configuration = new ConfigurationBuilder()
                  .SetBasePath(AppContext.BaseDirectory)
                  .AddJsonFile("data.json", false, false)
                  .Build();
            new Appsettings(configuration);
        }
    }

}
