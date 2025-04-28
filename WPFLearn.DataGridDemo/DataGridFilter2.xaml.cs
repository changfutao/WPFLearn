using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFLearn.DataGridDemo
{
    /// <summary>
    /// DataGridFilter2.xaml 的交互逻辑
    /// </summary>
    public partial class DataGridFilter2 : Window
    {
        private List<Employee> _employees;
        private ICollectionView _collectionView;
        public DataGridFilter2()
        {
            InitializeComponent();
            _employees = new List<Employee>(Employee.FakeMany(10));
            _collectionView = CollectionViewSource.GetDefaultView(_employees);
            dgData.ItemsSource = _collectionView;
            _collectionView.Filter = (item) =>
            {
                var em = item as Employee;
                if (em != null)
                {
                    var text = filterTextBox.Text;
                    return em.FirstName.Contains(text) || em.LastName.Contains(text);
                }
                return false;
            };
        }

        private void filterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _collectionView.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _employees.Add(Employee.FakeOne());
            _collectionView.Refresh();
        }
    }
}
