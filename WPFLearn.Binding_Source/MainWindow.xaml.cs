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

namespace WPFLearn.Binding_Source
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
                    Task.Delay(1000).GetAwaiter().GetResult();
                    this.Dispatcher.Invoke(() =>
                    {
                        (this.Resources["mc"] as MyClass).Value++;
                        (this.Resources["mc"] as MyClass).Num++;
                    });
                }
            });
        }
    }
    // 依赖属性和INotifyPropertyChanged都可以通知,但是依赖属性是静态的,会始终在内存中,所以推荐INotifyPropertyChanged
    class MyClass: FrameworkElement, INotifyPropertyChanged
    {
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(MyClass), new PropertyMetadata(10));
        private int _num;

        public int Num
        {
            get { return _num; }
            set { _num = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Num")); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}