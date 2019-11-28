using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.MVVMLight.Demo.ViewModel
{
    public class FirstPageViewModel : ViewModelBase
    {
        /// <summary>
        /// 依赖属性：显示字符;
        /// </summary>
        private string _LabelShow;
        public string LabelShow
        {
            get { return _LabelShow; }

            // MvvmLight实现的Set方法,好处就是不用自己实现RaisePropertyChanged函数了;
            set { Set(ref _LabelShow, value); }
        }

        public FirstPageViewModel()
        {
            Messenger.Default.Register(this,"FirstPage", (string msg) =>
            {
                LabelShow = string.Format("上一个模块是:{0} 当前模块是:Page1", msg);
            });
        }

        public override void Cleanup()
        {
            base.Cleanup();
            Messenger.Default.Unregister(this);
        }
    }
}
