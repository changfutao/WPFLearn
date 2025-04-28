using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Data;

namespace WPFLearn.DataGridDemo
{
    public partial class MainViewModel: ObservableObject
    {
        private List<Employee> employees;
        [ObservableProperty]
        private ICollectionView collectionView;
        [ObservableProperty]
        private string filterText = "";
        partial void OnFilterTextChanged(string value) => CollectionView.Refresh();
        public MainViewModel()
        {
            employees = new List<Employee>(Employee.FakeMany(10));
            CollectionView = CollectionViewSource.GetDefaultView(employees);
            CollectionView.Filter = (item) =>
            {
                var em = item as Employee;
                if(em != null)
                {
                    return em.FirstName.Contains(filterText) || em.LastName.Contains(filterText);
                }
                return false;
            };
        }
        [RelayCommand]
        public void AddEmployee()
        {
            employees.Add(Employee.FakeOne());
            CollectionView.Refresh();
        }
    }
}
