using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WPFLearn.Binding_ObservableCollection.Base
{
    public class AttachBase
    {
        // 依赖附加属性 关心的是被附加的对象
        public static ObservableCollection<Food> GetItemsSource(DependencyObject obj)
        {
            return (ObservableCollection<Food>)obj.GetValue(ItemsSourceProperty);
        }

        public static void SetItemsSource(DependencyObject obj, ObservableCollection<Food> value)
        {
            obj.SetValue(ItemsSourceProperty, value);
        }

     
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.RegisterAttached("ItemsSource", typeof(ObservableCollection<Food>), typeof(AttachBase), new PropertyMetadata(null, new PropertyChangedCallback(PropertyChanged)));

        // 当ItemsSource = new ObservableCollection<> 时, 触发PropertyChanged【当更新对象中属性的值不会触发】
        // 向ItemsSource里添加子项,并不会触发值变化回调,需要通过CollectionChanged
        public static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var panel = d as WrapPanel;
            var list = e.NewValue as ObservableCollection<Food>;
            list.CollectionChanged += (sender, e) => 
            {
                FillChildren(panel, list);
            };
            FillChildren(panel, list);
        }
        /// <summary>
        /// 填充数据
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="list"></param>
        static void FillChildren(WrapPanel panel, ObservableCollection<Food> list)
        {
            panel.Children.Clear();
            foreach (var item in list)
            {
                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Horizontal;
                TextBlock tbName = new TextBlock();
                tbName.Text = "名称:";
                sp.Children.Add(tbName);

                Binding binding = new Binding();
                binding.Source = item.Name;
                TextBlock textBlock = new TextBlock();
                textBlock.Margin = new Thickness(10, 0, 10, 0);
                BindingOperations.SetBinding(textBlock, TextBlock.TextProperty, binding);
                sp.Children.Add(textBlock);

                TextBlock tbNum = new TextBlock();
                tbNum.Text = "数量:";
                sp.Children.Add(tbNum);

                Binding binding1 = new Binding();
                binding1.Source = item.Num;
                TextBlock textNum = new TextBlock();
                textNum.Margin = new Thickness(10, 0, 10, 0);
                BindingOperations.SetBinding(textNum, TextBlock.TextProperty, binding1);
                sp.Children.Add(textNum);

                TextBlock tbPrice = new TextBlock();
                tbPrice.Text = "数量:";
                sp.Children.Add(tbPrice);

                Binding binding2 = new Binding();
                binding2.Source = item.Price;
                binding2.StringFormat = "￥{0}";
                TextBlock textPrice = new TextBlock();
                textPrice.Margin = new Thickness(10, 0, 10, 0);
                BindingOperations.SetBinding(textPrice, TextBlock.TextProperty, binding2);
                sp.Children.Add(textPrice);
                panel.Children.Add(sp);
            }
        }
    }
}
