﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Wpf.MVVMLight.Demo.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        /// <summary>
        /// 依赖命令：改变字符显示;
        /// </summary>
        public RelayCommand Button_Click_ChangeText { get; set; }

        /// <summary>
        /// 依赖属性：显示字符;
        /// </summary>
        private string _LabelShow;
        public string Label1Show
        {
            get { return _LabelShow; }

            // MvvmLight实现的Set方法,好处就是不用自己实现RaisePropertyChanged函数了;
            set { Set(ref _LabelShow, value); }
        }

        public MainPageViewModel()
        {
            Button_Click_ChangeText = new RelayCommand(ChangeText);
            Button_Click_ChangeText.CanExecute(1);

            Messenger.Default.Register(this,"MainPage", (string msg) =>
            {
                Label1Show = string.Format("上一个模块是:{0} 当前模块是:首页",msg);
            });

            Label1Show = "ShowOne";
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ChangeText()
        {
            Label1Show = "ShowOneChange";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (Count > 65534)
                Count = 0;

            Count++;
            Label1Show = "ShowTimerCount:" + Count.ToString();
        }

        private DispatcherTimer timer = new DispatcherTimer();
        private int Count = 0;
        public override void Cleanup()
        {
            base.Cleanup();
            Messenger.Default.Unregister(this);
        }
    }
}
