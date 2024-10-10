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
using System.Diagnostics;


namespace WPFLearn.BindingBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Binding binding = new Binding();
            // 绑定源 相当于XAML中的ElementName
            binding.Source = slider2;
            // 模式
            binding.Mode = BindingMode.TwoWay;
            // 监控属性
            binding.Path = new PropertyPath("Value");
            // 目标对象绑定
            txt2.SetBinding(TextBox.TextProperty, binding);

            this.DataContext = new Test { Name = "小明" };
        }
        /// <summary>
        /// 解除绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 移除txt2上的所有绑定
            // BindingOperations.ClearAllBindings(txt2);
            BindingOperations.ClearBinding(txt2, TextBox.TextProperty);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Binding binding = BindingOperations.GetBinding(txt2, TextBox.TextProperty);
            // binding.Source 源对象 Slider
            Slider slider = binding.Source as Slider;
            Trace.WriteLine($"实际值: {slider.Value}");
        }
        /// <summary>
        /// 手动更新值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var expression = txtContent2.GetBindingExpression(TextBox.TextProperty);
            expression.UpdateSource();
        }

    }
    class Data
    {
        public static string Value { get; set; } = "Val";
    }

    class Test
    {
        public string Name { get; set; }
    }
}