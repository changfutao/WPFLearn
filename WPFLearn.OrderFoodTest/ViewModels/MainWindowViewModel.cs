using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFLearn.OrderFoodTest.Models;

namespace WPFLearn.OrderFoodTest.ViewModels
{
    internal class MainWindowViewModel : NotifyPropertyChange
    {
        public CommandBase SelectedCommand { get; set; }
        private Restaurant restaurant;

        public Restaurant Restaurant
        {
            get { return restaurant; }
            set
            {
                restaurant = value;
                this.RaisePropertyChanged(nameof(Restaurant));
            }
        }
        private List<DishMenuItemViewModel> dishMenu;

        public List<DishMenuItemViewModel> DishMenu
        {
            get { return dishMenu; }
            set
            {
                dishMenu = value;
                this.RaisePropertyChanged(nameof(DishMenu));
            }
        }

        private int count;

        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                this.RaisePropertyChanged(nameof(Count));
            }
        }


        public MainWindowViewModel()
        {
            this.Restaurant = new Restaurant() { Name = "盛涛大饭店", Address = "城阳区温阳路221号", Phone = "123123123123" };
            this.DishMenu = new List<DishMenuItemViewModel>();
            LoadDish();
            this.SelectedCommand = new CommandBase()
            {
                ExecuteAction = new Action<object>(SelectedCount)
            };
        }

        private void LoadDish()
        {
            List<Dish> dishes = new List<Dish>()
            {
                new Dish{ Name = "水果披萨", Category="披萨", Comment = "爆款", Score = 4.5},
                new Dish{ Name = "牛肉披萨", Category="披萨", Comment = "镇店之宝", Score = 5},
                new Dish{ Name = "小龙虾披萨", Category="披萨", Comment = "爆款", Score = 4.5},
                new Dish{ Name = "鱼香肉丝", Category="川菜", Comment = "爆款", Score = 4.5},
                new Dish{ Name = "回锅肉", Category="川菜", Comment = "爆款", Score = 4.5},
            };
            foreach (Dish dish in dishes)
            {
                this.DishMenu.Add(new DishMenuItemViewModel { Dish = dish });
            }
        }

        public void SelectedCount(object obj)
        {
            this.Count = this.DishMenu.Count(a => a.IsSelected == true);
        }
    }
}
