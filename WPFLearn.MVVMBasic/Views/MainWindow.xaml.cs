﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFLearn.MVVMBasic.Base;
using WPFLearn.MVVMBasic.ViewModels;
using WPFLearn.MVVMBasic.Views;

namespace WPFLearn.MVVMBasic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowManager.Register(typeof(ChildWindow), this);
            this.DataContext = new MainWindowViewModel();
        }
    }
}