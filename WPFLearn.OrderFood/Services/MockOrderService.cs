using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFLearn.OrderFood.Model;

namespace WPFLearn.OrderFood.Services
{
    internal class MockOrderService : IOrderService
    {
        public void PlaceOrder(List<string> dishs)
        {
            System.IO.File.WriteAllLines(@"d:\1.txt", dishs.ToArray());
        }
    }
}
