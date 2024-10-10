using System.Collections.ObjectModel;
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

namespace WPFLearn.Binding_ObservableCollection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var mainViewModel = new MainViewModel()
            {
                UserName = "Ross",
                UserNo = "1001",
                Orders = new List<Order>
                {
                    new Order
                    {
                        OrderNo = "2024101000001",
                        OrderDate = new DateTime(2024, 10, 9, 11, 20, 33),
                        // 动态更新的话,需要使用ObservableCollection,而不是List
                        Foods = new ObservableCollection<Food>
                        {
                            new Food() { Name = "Banana", Price = 2.53M, Num = 3.1M, Description = "香蕉" },
                            new Food() { Name = "Apple", Price = 1.53M, Num = 2.3M, Description = "苹果" },
                            new Food() { Name = "Orange", Price = 3.53M, Num = 4.5M, Description = "橘子" },
                        }
                    }
                }
            };
            this.DataContext = mainViewModel;

            Task.Run(() =>
            {
                Task.Delay(5000).GetAwaiter().GetResult();
                // 更改对象中的属性值
                mainViewModel.UserName = "cft";
                // 新增项必须在UI线程中操作
                Application.Current.Dispatcher.Invoke(() =>
                {
                    // 向数组中新增新项
                    mainViewModel.Orders[0].Foods.Add(new Food { Name = "grape", Num = 3.1M, Price = 2.3M, Description = "葡萄" });
                });
                mainViewModel.Orders[0].Foods[0].Description = "东南亚香蕉";
            });

        }
    }
}