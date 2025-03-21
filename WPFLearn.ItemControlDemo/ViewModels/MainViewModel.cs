using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPFLearn.ItemControlDemo.Base;

namespace WPFLearn.ItemControlDemo.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public CommandBase SwitchPage { get; set; }
        public List<Menu> Menus { get; set; }
        private object page;

        public event PropertyChangedEventHandler? PropertyChanged;

        public object Page
        {
            get { return page; }
            set
            {
                page = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Page)));
            }
        }

        public MainViewModel()
        {
            Menus = new List<Menu>()
            {
                new Menu { Title = "ItemTemplate", Page= "WPFLearn.ItemControlDemo.Views.ItemTemplate"},
                new Menu { Title = "ItemPanel", Page= "WPFLearn.ItemControlDemo.Views.ItemPanel"},
                new Menu { Title = "Template", Page= "WPFLearn.ItemControlDemo.Views.Template"},
                new Menu { Title = "ShapeStyle", Page= "WPFLearn.ItemControlDemo.Views.ShapeStyle"},
                new Menu { Title = "ItemResources", Page= "WPFLearn.ItemControlDemo.Views.ItemResources"},
                new Menu { Title = "DataTemplateSelector", Page= "WPFLearn.ItemControlDemo.Views.DataTemplateSelector"},
            };
            ShowPage(Menus[0].Page);
            SwitchPage = new CommandBase()
            {
                ActionExecute = ShowPage
            };

            Shapes = new List<Shape>
            {
                new Shape(0, new Point{ X = 10, Y = 20}, Brushes.Yellow),
                new Shape(1, new Point{ X = 120, Y = 50}, Brushes.Green),
                new Shape(1, new Point{ X = 50, Y = 220}, Brushes.Blue),
                new Shape(0, new Point{ X = 70, Y = 130}, Brushes.Red),
            };

            Fruits = new List<Fruit>
            {
                new Apple{ Amount = 2 },
                new Apple{ Amount = 3 },
                new Banana{ Amount = 1 },
                new Apple{ Amount = 6 },
                new Banana{ Amount = 12 },
            };

            Employees = new List<Employee>
            {
                new Employee ("Lily",Gender.Female),
                new Employee ("Jack",Gender.Male),
                new Employee ("Tom", Gender.Male),
                new Employee ("Hameimei", Gender.Female),
                new Employee ("Jim",  Gender.Male)
            };
        }

      

        private void ShowPage(object page)
        {
            var type = GetType().Assembly.GetType(page.ToString());
            if (type != null)
            {
                object obj = Activator.CreateInstance(type);
                Page = obj;
            }
        }

        public List<Shape> Shapes { get; set; }

        public List<Fruit> Fruits { get; set; }

        public List<Employee> Employees { get; set; }
    }

    class EmployeeSelector : DataTemplateSelector
    {
        public DataTemplate MaleTemplate { get; set; }
        public DataTemplate FemaleTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;
            var employee = item as Employee;
            return employee.Gender switch
            {
                Gender.Male => MaleTemplate,
                Gender.Female => FemaleTemplate,
                _ => throw new ArgumentException()
            };
        }
    }

    class Menu
    {
        public string Title { get; set; }
        public string Page { get; set; }
    }

    record class Shape(int Type, Point Pos, Brush Color);
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    abstract class Fruit
    {
        public int Amount { get; set; }
    }

    class Apple : Fruit
    {
    }

    class Banana : Fruit
    {
    }

    record class Employee(string Name, Gender Gender);

    enum Gender
    {
        Male,
        Female
    }
}
