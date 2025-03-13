using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFLearn.OrderFoodTest.Models;

namespace WPFLearn.OrderFoodTest.ViewModels
{
    internal class DishMenuItemViewModel : NotifyPropertyChange
    {
        private Dish dish;

        public Dish Dish
        {
            get { return dish; }
            set
            {
                dish = value;
                this.RaisePropertyChanged(nameof(Dish));
            }
        }
        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                this.RaisePropertyChanged(nameof(Dish));
            }
        }


    }
}
