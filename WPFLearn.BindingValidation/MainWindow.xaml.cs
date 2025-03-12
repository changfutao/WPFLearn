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

namespace WPFLearn.BindingValidation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        #region 验证方式一: 依赖属性
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(MainWindow), new PropertyMetadata(""), new ValidateValueCallback(OnValidate));

        /// <summary>
        /// 验证值
        /// </summary>
        /// <param name="value">依赖属性值</param>
        /// <returns></returns>

        public static bool OnValidate(object value)
        {
            if (value != null && value.ToString() == "cft")
            {
                return false;
            }
            return true;
        } 
        #endregion
    }
}