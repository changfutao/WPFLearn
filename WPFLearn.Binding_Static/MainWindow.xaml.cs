using System.ComponentModel;
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

namespace WPFLearn.Binding_Static
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Task.Run(() =>
            {
                while(true)
                {
                    Task.Delay(500).GetAwaiter().GetResult();
                    this.Dispatcher.Invoke(() =>
                    {
                        ViewModel.Num++;
                    });
                }
            });
        }
    }
    class ViewModel
    {
        // Binding 只能是属性,字段不可用
        public static string Title { get; set; } = "静态数据";
        private static int _num;

        public static int Num
        {
            get { return _num; }
            set {
                _num = value;
                // StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs("Num"));
                NumChanged?.Invoke(null, new PropertyChangedEventArgs("Num"));
            }
        }
        // 方式一: 静态属性StaticPropertyChanged【推荐】
        // public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;
        // 方式二: 属性名 等于 属性名+Changed 才能生效
        public static event EventHandler<PropertyChangedEventArgs> NumChanged;
    }
}