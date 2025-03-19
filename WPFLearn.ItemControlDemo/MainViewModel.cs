using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLearn.ItemControlDemo
{
    internal class MainViewModel
    {
        public string[] names = new[] { "Jack", "Tom", "Lily", "Jerry", "Hameimei"}; 
        public List<string> Names { get; set; }
        public MainViewModel()
        {
            Names = new List<string>();
            foreach (var item in Enumerable.Range(0, 100))
            {
                Names.Add(names[new Random().Next(5)] + item);
            }
        }
    }
}
