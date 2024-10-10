using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLearn.Binding_ObservableCollection
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set 
            { 
                _userName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UserName"));
            }
        }

        public string UserNo { get; set; }
        public List<Order> Orders { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

    public class Food : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Num { get; set; }
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Description")); }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
    public class Order
    {
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public ObservableCollection<Food> Foods { get; set; }
    }
}
