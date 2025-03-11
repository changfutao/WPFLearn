using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFLearn.MVVMBasic.Base
{
    public class CommandBase : ICommand
    {
        // 通知: 当前按钮检查可用条件,执行触发CanExecute
        public event EventHandler? CanExecuteChanged;
        // 执行CanExecuteChanged事件
        public void DoCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object? parameter)
        {
            // 可执行条件的委托调用
            return DoVisibleExecute?.Invoke(parameter) == true;
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public Action<object> DoExecute { get; set; }
        public Func<object, bool> DoVisibleExecute { get; set; }
    }
}
