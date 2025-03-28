﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFLearn.MVVMBasic.ViewModels
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
            ActionExecute?.Invoke(parameter);
        }
        public Action<object> ActionExecute { get; set; }
    }
}
