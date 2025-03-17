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
using WPFLearn.MVVMBasic.ViewModels;

namespace WPFLearn.MVVMBasic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }
    }

    class CustomText : TextBox
    {


        public int IsView
        {
            get { return (int)GetValue(IsViewProperty); }
            set { SetValue(IsViewProperty, value); }
        }

        public static readonly DependencyProperty IsViewProperty =
            DependencyProperty.Register(
                "IsView",
                typeof(int),
                typeof(CustomText),
                new PropertyMetadata(0));


    }
}