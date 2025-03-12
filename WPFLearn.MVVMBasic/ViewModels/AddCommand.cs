using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFLearn.MVVMBasic.ViewModels
{
    public class AddCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public void DoExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object? parameter)
        {
            return ExecuteFunc?.Invoke(parameter) ?? true;
        }

        public void Execute(object? parameter)
        {
            ExecuteAction?.Invoke(parameter);
        }

        public Action<object> ExecuteAction { get; set; }
        public Func<object, bool> ExecuteFunc { get; set; }
    }
}
