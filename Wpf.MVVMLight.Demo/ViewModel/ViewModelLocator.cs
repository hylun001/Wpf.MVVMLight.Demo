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
    /// ViewModel̽����
    /// ����ϡ��������ԡ���������
    /// ���������������Ӷ�ʹ��Щ������ɱ��滻���߸��¡�
    //���ڱ���ʱ����֪��������ľ���ʵ�֡�
    //��ĸ����ԺͿɲ����Էǳ��á�
    //�����踺��������Ĵ�������λ�͹����߼���
    //ͨ����Ӧ�ó���ֽ�Ϊ����ϵ�ģ�飬���ģ�������������������ԡ��汾���ƺͲ���
    /// </summary>
    public class ViewModelLocator
    {
        #region Window��Page��������
        /// <summary>
        /// �����Ӧ����View��DataContext��Ҫ����������;
        /// �������MainVM���ԣ���������View��ViewModel;
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
        /// �����Ӧ����View��DataContext��Ҫ����������;
        /// �������MainPageVM���ԣ���������View��ViewModel;
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
        /// ��һ��ģ��ViewModel
        /// </summary>
        public FirstPageViewModel FirstPageVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FirstPageViewModel>();
            }
        }

        /// <summary>
        /// �ڶ���ģ��ViewModel
        /// </summary>
        public SecondPageViewModel SecondPageVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SecondPageViewModel>();
            }
        }
        #endregion Window��Page��������


        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            RegisterViewModels();
        }

        /// <summary>
        /// ע������ViewModel
        /// </summary>
        private void RegisterViewModels()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                // ��Visual Studio�����Ԥ��Xaml�ļ���ʱ��������ע���������;
                SimpleIoc.Default.Register<MainViewModel>();
            }
            else
            {
                // ������ʱ��������ע���������;
                SimpleIoc.Default.Register<MainViewModel>();
            }
            
            //SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<FirstPageViewModel>();
            SimpleIoc.Default.Register<SecondPageViewModel>();
            // �����ʱ��Ĭ��������ע��Ϳ�����;
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