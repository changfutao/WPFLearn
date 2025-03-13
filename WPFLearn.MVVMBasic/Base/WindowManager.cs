using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFLearn.MVVMBasic.Base
{
    public class WindowManager
    {
        public static Dictionary<string, Type> _store = new Dictionary<string, Type>();
        public static void Register(Type type)
        {
            if(!_store.ContainsKey(type.Name))
            {
                _store.Add(type.Name, type);
            }
        }
    }
}
