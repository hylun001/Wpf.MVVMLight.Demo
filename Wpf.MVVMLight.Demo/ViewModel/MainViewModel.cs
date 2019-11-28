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
        /// �������ڶ���ģ��;
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
        /// ��������һ��ģ��;
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
        /// ��������ҳģ��;
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
        /// �����ı�ֵ�����ı�;
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
        /// ��ҳFrame;
        /// </summary>
        private Frame _MainWindowFrame;
        public Frame MainWindowFrame
        {
            get { return _MainWindowFrame; }
            set { Set(ref _MainWindowFrame, value); }
        }
        /// <summary>
        /// ��ҳFrame;
        /// </summary>
        private string _MainTitle;
        public string MainTitle
        {
            get { return _MainTitle; }
            set { Set(ref _MainTitle, value); }
        }

        private UserModel _UserModel;
        /// <summary>
        /// ��ӭ������
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
        /// ����ǩҳ;
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
            MainTitle = "��ҳ";

            //ʹ�����̲߳���
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
        /// ��һ��ģ��;
        /// </summary>
        private void OnFirstPageCommand()
        {
            Messenger.Default.Send<string>(GetPrePageName(), "FirstPage");
            MainWindowFrame.Content = FirstPage;
        }

        /// <summary>
        /// �ڶ���ģ��;
        /// </summary>
        private void OnSecondPageCommand()
        {
            Messenger.Default.Send<string>(GetPrePageName(), "SecondPage");
            MainWindowFrame.Content = SecondPage;
        }

        /// <summary>
        /// ��ҳ;
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
            MainTitle = string.Format("��ҳ{0}", string.IsNullOrWhiteSpace(word) ? string.Empty : string.Format("({0})", word));
        }


    }
}