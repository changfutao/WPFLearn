using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFLearn.MVVMBasic.Base;

namespace WPFLearn.MVVMBasic.Models
{
    public class WindowModel: INotifyPropertyChanged
    {
        public WindowModel()
        {
            this.Btn2Command = new CommandBase
            {
                DoVisibleExecute = obj =>
                {
                    return this.total != 0;
                }
            };
        }
        private double num1;

        public double Num1
        {
            get { return num1; }
            set {
                if (value == num1) return;
                num1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Num1)));
                this.Total = value + this.Num2;
            }
        }

        public double Num2 { get; set; }
        private double total;

        public double Total
        {
            get { return total; }
            set 
            {
                if (value == total) return;
                total = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
                Btn2Command.DoCanExecuteChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        // 按钮1命令
        public CommandBase Btn1Command { get; set; }
        // 按钮2命令
        public CommandBase Btn2Command { get; set; }
    }
}
