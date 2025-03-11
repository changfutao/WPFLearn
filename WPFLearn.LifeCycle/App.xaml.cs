using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows;

namespace WPFLearn.LifeCycle
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // 在调用Application 对象的Run方法时发生
            this.Startup += App_Startup;

            #region Browser类型的应用
            // 在应用程序中的导航器请求新导航时发生
            this.Navigating += App_Navigating;
            // 在已经加载、分析并开始呈现应用程序中的导航器导航到的内容时发生
            this.LoadCompleted += App_LoadCompleted;
            // 在应用程序中的导航器在导航到所请求内容时出现错误的情况下发生
            this.Navigated += App_Navigated;
            // 在应用程序中的导航器在导航到所请求内容时出现错误的情况下发生。
            this.NavigationFailed += App_NavigationFailed;
            // 在由应用程序中的导航器管理的下载过程中定期发生，以提供导航进度信息。    
            this.NavigationProgress += App_NavigationProgress;
            // 在调用应用程序中的导航器的 StopLoading 方法时发生，或者当导航器在当前导航正在进行期间请求了一个新导航时发生。
            this.NavigationStopped += App_NavigationStopped;
            #endregion

            // 在用户通过注销或关闭操作系统而结束Windows会话时发生
            this.SessionEnding += App_SessionEnding;
            // 当应用程序成为前台应用程序时发生
            // 当应用程序任意窗体激活时触发
            this.Activated += App_Activated;
            // 当应用程序任意窗体非激活时触发
            this.Deactivated += App_Deactivated;
            // 在应用程序关闭之前发生,无法取消
            this.Exit += App_Exit;

            #region 全局异常捕获
            // 异常由应用程序引发但未进行处理时发生【只针对于UI线程】
            // 注意: 无法捕获多线程异常
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            #endregion
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Debug.WriteLine($"==App_DispatcherUnhandledException==: {e.Exception.Message}");
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            Debug.WriteLine($"==App_Exit==");
        }

        private void App_Deactivated(object? sender, EventArgs e)
        {
            Debug.WriteLine($"==App_Deactivated==");
        }

        private void App_Activated(object? sender, EventArgs e)
        {
            Debug.WriteLine($"==App_Activated==");
        }

        private void App_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            Debug.WriteLine($"==App_SessionEnding==");
            e.Cancel = true;
        }

        private void App_NavigationStopped(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            Debug.WriteLine($"==App_NavigationStopped==");
        }

        private void App_NavigationProgress(object sender, System.Windows.Navigation.NavigationProgressEventArgs e)
        {
            Debug.WriteLine($"==App_NavigationProgress==");
        }

        private void App_NavigationFailed(object sender, System.Windows.Navigation.NavigationFailedEventArgs e)
        {
            Debug.WriteLine($"==App_NavigationFailed==");
        }

        /// <summary>
        /// 在应用程序中的导航器在导航到所请求内容时出现错误的情况下发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void App_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            Debug.WriteLine($"==App_Navigated==");
        }

        /// <summary>
        /// 在已经加载、分析并开始呈现应用程序中的导航器导航到的内容时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void App_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            Debug.WriteLine($"==App_LoadCompleted==");
        }

        /// <summary>
        /// 在应用程序中的导航器请求新导航时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void App_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            Debug.WriteLine($"==App_Navigating==");
        }

        /// <summary>
        /// 程序已启动执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void App_Startup(object sender, StartupEventArgs e)
        {
            // 可以在这里做一些初始化操作
            Debug.WriteLine($"==1.App_Startup执行==");
        }
    }

}
