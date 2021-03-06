﻿using GalaSoft.MvvmLight.Threading;
using System.Windows;
using Wpf.MVVMLight.Demo.ViewModel;

namespace Wpf.MVVMLight.Demo
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        ///Key:Locator表示所有ViewModel都应该指向该ViewModelLocator
        /// </summary>
        public App()
        {         
            Application.Current.Exit += Current_Exit;
            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
            //初始化用来保存主线程的Dispatcher
            DispatcherHelper.Initialize();
        }

        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("未处理异常!");
        }

        private void Current_Exit(object sender, ExitEventArgs e)
        {
            ViewModelLocator.Cleanup();
        }
    }
}
