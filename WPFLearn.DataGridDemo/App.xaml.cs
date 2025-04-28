using Bogus;
using System.Configuration;
using System.Data;
using System.Windows;

namespace WPFLearn.DataGridDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Randomizer seed = new Randomizer(1334);
        }
    }

}
