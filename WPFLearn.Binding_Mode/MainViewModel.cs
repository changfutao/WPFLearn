using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WPFLearn.Binding_Mode
{
    internal class MainViewModel
    {
        public DataModel DM1 { get; set; } = new DataModel() { Title = "哈哈" };
        public DataModel DM2 { get; set; } = new DataModel() { Title = "嘿嘿" };
    }

    class DataModel : INotifyPropertyChanged
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set {
                _title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
    }

    class Test: FrameworkElement
    {
        public int MyProperty
        {
            get { return (int)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(int), typeof(Test), new FrameworkPropertyMetadata(default(int), flags: FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


    }
}
