using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFLearn.MVVMBasic.Models;

namespace WPFLearn.MVVMBasic.ViewModels
{
    public class WindowViewModel
    {
        // 1.必须是属性 2.必须实例化
        public WindowModel mainWindow { get; set; } = new WindowModel();
    }
}
