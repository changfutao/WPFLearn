using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFLearn.OrderFood.Helper;
using WPFLearn.OrderFood.Model;

namespace WPFLearn.OrderFood.Services
{
    class DataService : IDataService
    {
        public List<Dish>? GetDishList()
        {
            return Appsettings.Get<List<Dish>>("dishes");
        }
    }
}
