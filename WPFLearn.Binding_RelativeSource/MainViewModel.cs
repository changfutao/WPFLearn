using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLearn.Binding_RelativeSource
{
    class MainViewModel
    {
        public string Title { get; set; } = "Hello WPF";
        public string Other { get; set; } = "其他";
        public List<ViewModel> ViewModels { get; set; } = new List<ViewModel>()
        {
            new ViewModel { Version = "1.0", Remark = "测试1"},
            new ViewModel { Version = "1.1", Remark = "测试2"},
            new ViewModel { Version = "1.2", Remark = "测试3"},
        };
    }

    class ViewModel
    {
        public string Version { get; set; }
        public string Remark { get; set; }
    }
}
