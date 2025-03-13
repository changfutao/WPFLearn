using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFLearn.OrderFood.Model;

namespace WPFLearn.OrderFood.ViewModels
{
    public class DishMenuItemViewModel : NotificationObject
    {
        public Dish Dish { get; set; }
		private bool isSelected;

		public bool IsSelected
		{
			get { return isSelected; }
			set { isSelected = value;
				this.RaisePropertyChanged(nameof(IsSelected));
			}
		}

	}
}
