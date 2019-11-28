using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using System.Windows.Controls;
using Wpf.MVVMLight.Demo.Model;
using Wpf.MVVMLight.Demo.Pages;

namespace Wpf.MVVMLight.Demo.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// 导航到第二个模块;
        /// </summary>
        private RelayCommand _SecondPageCommand;
        public RelayCommand SecondPageCommand
        {
            get
            {
                if (_SecondPageCommand == null)
                    _SecondPageCommand = new RelayCommand(OnSecondPageCommand);
                return _SecondPageCommand;
            }
        }
        /// <summary>
        /// 导航到第一个模块;
        /// </summary>
        private RelayCommand _FirstPageCommand;
        public RelayCommand FirstPageCommand
        {
            get
            {
                if (_FirstPageCommand == null)
                    _FirstPageCommand = new RelayCommand(OnFirstPageCommand);
                return _FirstPageCommand;
            }
        }
        /// <summary>
        /// 导航到首页模块;
        /// </summary>
        private RelayCommand<string> _HomePageCommand;
        public RelayCommand<string> HomePageCommand
        {
            get
            {
                if (_HomePageCommand == null)
                    _HomePageCommand = new RelayCommand<string>(OnHomePageCommand);
                return _HomePageCommand;
            }
        }
        /// <summary>
        /// 输入文本值发生改变;
        /// </summary>
        private RelayCommand<System.Windows.Controls.TextChangedEventArgs> _TextChangedCommand;
        public RelayCommand<System.Windows.Controls.TextChangedEventArgs> TextChangedCommand
        {
            get
            {
                if (_TextChangedCommand == null)
                    _TextChangedCommand = new RelayCommand<System.Windows.Controls.TextChangedEventArgs>(OnTextChangedCommand);
                return _TextChangedCommand;
            }
        }
        /// <summary>
        /// 主页Frame;
        /// </summary>
        private Frame _MainWindowFrame;
        public Frame MainWindowFrame
        {
            get { return _MainWindowFrame; }
            set { Set(ref _MainWindowFrame, value); }
        }
        /// <summary>
        /// 主页Frame;
        /// </summary>
        private string _MainTitle;
        public string MainTitle
        {
            get { return _MainTitle; }
            set { Set(ref _MainTitle, value); }
        }

        private UserModel _UserModel;
        /// <summary>
        /// 欢迎词属性
        /// </summary>
        public UserModel UserModel
        {
            get { return _UserModel; }
            set
            {
                Set(ref _UserModel, value);          
            }
        }

        /// <summary>
        /// 主标签页;
        /// </summary>
        private Page HomePage { get; set; }
        private Page FirstPage { get; set; }
        private Page SecondPage { get; set; }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ///

            MainWindowFrame = new Frame();
            HomePage = new MainPage();
            FirstPage = new PageOne();
            SecondPage = new PageTwo();
            MainTitle = "首页";

            //使用主线程操作
            DispatcherHelper.CheckBeginInvokeOnUI(() =>
            {
                OnHomePageCommand(string.Empty);
            });
        }

        private string GetPrePageName()
        {
            if (MainWindowFrame == null || MainWindowFrame.Content == null)
                return "N/A";
            else
            {
                Page prePage = MainWindowFrame.Content as Page;
                return prePage.Title;
            }
        }

        /// <summary>
        /// 第一个模块;
        /// </summary>
        private void OnFirstPageCommand()
        {
            Messenger.Default.Send<string>(GetPrePageName(), "FirstPage");
            MainWindowFrame.Content = FirstPage;
        }

        /// <summary>
        /// 第二个模块;
        /// </summary>
        private void OnSecondPageCommand()
        {
            Messenger.Default.Send<string>(GetPrePageName(), "SecondPage");
            MainWindowFrame.Content = SecondPage;
        }

        /// <summary>
        /// 首页;
        /// </summary>
        /// 

        private void OnHomePageCommand(string word)
        {
            Messenger.Default.Send<string>(GetPrePageName(), "MainPage");
            MainWindowFrame.Content = HomePage;
        }

        private void OnTextChangedCommand(System.Windows.Controls.TextChangedEventArgs e)
        {
            string word = (e.Source as TextBox).Text;
            MainTitle = string.Format("首页{0}", string.IsNullOrWhiteSpace(word) ? string.Empty : string.Format("({0})", word));
        }


    }
}