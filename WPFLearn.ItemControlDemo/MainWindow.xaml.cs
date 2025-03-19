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

namespace WPFLearn.ItemControlDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /**
         * ItemControl: WPF中用于显示一组数据的控件
         * 本身不提供任何样式(几乎等于一个只能纵向排布的StackPanel), 但提供丰富的定制功能
         *      1. Template: 自身的模板(ControlTemplate)
         *      2. ItemPanel: 用于排布的容器
         *      3. ItemTemplate: 单个项目的模板(DataTemplate)
         *          3.1 DataTemplate.Triggers: 模板相同,样式略微不同
         *          3.2 ItemTemplateSelector: 可以根据项目的属性等来选择不同的模板
         *          3.3 ItemContainerStyle: 放置单个项目的容器的样式
         *          3.4 ItemContainerStyleSelector: 依次类推
         *      4. ItemsSource: 数据源
         *      5. Alternation: Index&Count 实现交替效果
         *      6. 其他: Padding、Style、Resources
         *      
         * 继承关系： FrameworkElement -> Control -> ItemsControl -> Selector -> ListBox -> ListView
         * 
         * 常用技巧: 
         *     1. 展示数据,并添加样式: ItemTemplate
         *     2. 在画布上展示几何图形: ItemTemplate + ItemContainerStyle
         *     3. 奇偶行拥有不同背景色: AlternationIndex
         *     4. 修改数据的排布方式
         *          4.1 修改排布方式: ItemsPanel
         *          4.2 添加标题: Template
         *     5.为不同的数据类型应用不同的模板
         *          5.1 Resources + DataTemplate
         *          5.2 ItemTemplateSelector + ItemContainerStyleSelector
         */
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
    }
}