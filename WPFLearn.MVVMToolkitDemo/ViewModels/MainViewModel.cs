using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace WPFLearn.MVVMToolkitDemo.ViewModels
{
    public partial class MainViewModel: ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Content))]
        private string title = "我是标题";
        [ObservableProperty]
        private string content = $"123";
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ClickCommand))]
        private bool isEnabled = false;
        [ObservableProperty]
        public DateTime searchDate = DateTime.Now;
        [RelayCommand(CanExecute = nameof(CanExecuteClick))]
        public void Click()
        {
            Title = "哈哈";
            Content = "aaa";
        }

        public bool CanExecuteClick()
        {
            return IsEnabled;
        }
        [ObservableProperty]
        public List<Person> persons = new List<Person>()
        {
            new Person{ Name = "Jim", Age = 23, Address = "America"},
            new Person{ Name = "Tom", Age = 27, Address = "French"},
            new Person{ Name = "Hanmeimei", Age = 23, Address = "China"}
        };
        [RelayCommand]
        public void Edit(string obj)
        {

        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}
