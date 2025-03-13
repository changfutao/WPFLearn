using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFLearn.OrderFood.ViewModels
{
    public class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            ExecuteAction?.Invoke(parameter);
        }

        public Action<object> ExecuteAction { get; set; }
        public Func<object,bool> ExecuteFunc { get; set; }
    }
}
