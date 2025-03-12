using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace WPFLearn.MVVMBasic.ViewModels
{
    public class MainWindowViewModel : ObjectPropertyChanged
    {
        private double num1;

        public double Num1
        {
            get { return num1; }
            set
            {
                if (num1 == value) return;
                num1 = value;
                this.RaisePropertyChanged(nameof(Num1));
                addCommand.DoExecuteChanged();
            }
        }
        private double num2;

        public double Num2
        {
            get { return num2; }
            set
            {
                if (num2 == value) return;
                num2 = value;
                this.RaisePropertyChanged(nameof(Num2));
                addCommand.DoExecuteChanged();
            }
        }
        private double result;

        public double Result
        {
            get { return result; }
            set
            {
                if (result == value) return;
                result = value;
                this.RaisePropertyChanged(nameof(Result));
            }
        }
        public AddCommand addCommand { get; set; }
        public MainWindowViewModel()
        {
            addCommand = new AddCommand()
            {
                 ExecuteAction = new Action<object>((obj) =>
                 {
                     this.Result = this.num1 + this.num2;
                 }),
                 ExecuteFunc = new Func<object, bool>((obj) => this.num1 != 0 && this.num2 != 0)
            };
        }

    }
}
