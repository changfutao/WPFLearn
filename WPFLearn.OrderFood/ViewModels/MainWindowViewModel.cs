using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFLearn.OrderFood.Models;
using WPFLearn.OrderFood.Services;

namespace WPFLearn.OrderFood.ViewModels
{
    public class MainWindowViewModel: NotificationObject
    {
        public CommandBase SelectMenuItemCommand { get; set; }
        public CommandBase PlaceOrderCommand { get; set; }
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value;
                this.RaisePropertyChanged(nameof(Count));
            }
        }
        private Restaurant restaurant;

        public Restaurant Restaurant
        {
            get { return restaurant; }
            set { restaurant = value;
                this.RaisePropertyChanged(nameof(Restaurant));
            }
        }
        private List<DishMenuItemViewModel> dishMenu;

        public List<DishMenuItemViewModel> DishMenu
        {
            get { return dishMenu; }
            set {
                dishMenu = value;
            }
        }

        public MainWindowViewModel()
        {
            LoadRestaurant();
            LoadDishMenu();
            PlaceOrderCommand = new CommandBase()
            {
                ExecuteAction = new Action<object>(PlaceOrderCommandExecute)
            };
            SelectMenuItemCommand = new CommandBase
            {
                ExecuteAction = new Action<object>(SelectMenuItemExecute)
            };
        }

        public void LoadRestaurant()
        {
            this.Restaurant = new Restaurant();
        }

        public void LoadDishMenu()
        {
            var dishs = new DataService().GetDishList();
            if(dishs != null)
            {
                this.DishMenu = new List<DishMenuItemViewModel>();
                foreach (var dish in dishs)
                {
                    DishMenuItemViewModel item = new DishMenuItemViewModel();
                    item.Dish = dish;
                    this.dishMenu.Add(item);
                }
            }
        }

        private void SelectMenuItemExecute(object parameter)
        {
            this.Count = this.DishMenu.Count(a => a.IsSelected == true);
        }

        private void PlaceOrderCommandExecute(object parameter)
        {
            var selectedDishes = this.DishMenu.Where(a => a.IsSelected ).Select(a => a.Dish.Name).ToList();
            var orderService = new MockOrderService();
            orderService.PlaceOrder(selectedDishes);
            MessageBox.Show("订餐成功");
        }
    }
}
