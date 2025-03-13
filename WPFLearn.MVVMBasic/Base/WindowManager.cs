using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFLearn.MVVMBasic.Base
{
    public class WindowManager
    {
        public static Dictionary<string, WinEntity> _store = new Dictionary<string, WinEntity>();
        public static void Register(Type type, Window owner)
        {
            if(!_store.ContainsKey(type.Name))
            {
                _store.Add(type.Name, new WinEntity { WinType = type, Owner = owner});
            }
        }
    }

    public class WinEntity
    {
        public Type WinType { get; set; }
        public Window Owner { get; set; }
    }
}
