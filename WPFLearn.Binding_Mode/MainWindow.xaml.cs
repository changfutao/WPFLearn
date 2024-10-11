using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFLearn.Binding_Mode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();

            Task.Run(() =>
            {
                Task.Delay(3000).GetAwaiter().GetResult();
                this.Dispatcher.Invoke(() =>
                {
                    //(this.DataContext as MainViewModel).DM1.Title = "Hello C#";
                });
            });
        }
    }
}