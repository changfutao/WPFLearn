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

namespace WPFLearn.DataGridDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Employee> _employees;
        public MainWindow()
        {
            InitializeComponent();
            _employees = new List<Employee>(Employee.FakeMany(10));
            // 获取CollectionViewSource
            var cvs = this.FindResource("view") as CollectionViewSource;
            cvs.Source = _employees;
        }

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            var em = e.Item as Employee;
            var filterText = filterTextBox.Text;
            // CollectionViewSource会遍历每一条数据去匹配符合过滤条件的【就是返回true的数据】
            e.Accepted = em.FirstName.Contains(filterText) || em.LastName.Contains(filterText);
        }

        private void filterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // 重新展示
            CollectionViewSource.GetDefaultView(dgData.ItemsSource).Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _employees.Add(Employee.FakeOne());
            CollectionViewSource.GetDefaultView(dgData.ItemsSource).Refresh();
        }
    }
}