/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Wpf.MVVMLight.Demo"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;

namespace Wpf.MVVMLight.Demo.ViewModel
{
    /// <summary>
    /// ViewModel探测器
    /// 低耦合、可重用性、独立开发
    /// 把类与依赖项解耦，从而使这些依赖项可被替换或者更新。
    //类在编译时并不知道依赖项的具体实现。
    //类的隔离性和可测试性非常好。
    //类无需负责依赖项的创建、定位和管理逻辑。
    //通过将应用程序分解为松耦合的模块，达成模块间的无依赖开发、测试、版本控制和部署。
    /// </summary>
    public class ViewModelLocator
    {
        #region Window或Page依赖属性
        /// <summary>
        /// 这里对应的是View中DataContext需要的依赖属性;
        /// 就是这个MainVM属性，关联起了View和ViewModel;
        /// DataContext="{Binding Source={StaticResource Locator}, Path=MainVM}
        /// </summary>
        public MainViewModel MainVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        /// <summary>
        /// 这里对应的是View中DataContext需要的依赖属性;
        /// 就是这个MainPageVM属性，关联起了View和ViewModel;
        /// DataContext="{Binding Source={StaticResource Locator}, Path=MainPageVM}
        /// </summary>
        public MainPageViewModel MainPageVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainPageViewModel>();
            }
        }

        /// <summary>
        /// 第一个模块ViewModel
        /// </summary>
        public FirstPageViewModel FirstPageVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FirstPageViewModel>();
            }
        }

        /// <summary>
        /// 第二个模块ViewModel
        /// </summary>
        public SecondPageViewModel SecondPageVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SecondPageViewModel>();
            }
        }
        #endregion Window或Page依赖属性


        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            RegisterViewModels();
        }

        /// <summary>
        /// 注册所有ViewModel
        /// </summary>
        private void RegisterViewModels()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                // 在Visual Studio中设计预览Xaml文件的时候，在这里注册会起作用;
                SimpleIoc.Default.Register<MainViewModel>();
            }
            else
            {
                // 在运行时，在这里注册会起作用;
                SimpleIoc.Default.Register<MainViewModel>();
            }
            
            //SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<FirstPageViewModel>();
            SimpleIoc.Default.Register<SecondPageViewModel>();
            // 更多的时候，默认在这里注册就可以了;
            //SimpleIoc.Default.Register<MainViewModel>();
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels

            SimpleIoc.Default.Unregister<SecondPageViewModel>();
            SimpleIoc.Default.Unregister<FirstPageViewModel>();
            SimpleIoc.Default.Unregister<MainPageViewModel>();
            SimpleIoc.Default.Unregister<MainViewModel>();
            Messenger.Reset();
            SimpleIoc.Default.Reset();

        }
    }
}