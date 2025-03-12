using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFLearn.OrderFood.Model;

namespace WPFLearn.OrderFood.Services
{
    interface IDataService
    {
        List<Dish>? GetDishList(); 
    }
}
