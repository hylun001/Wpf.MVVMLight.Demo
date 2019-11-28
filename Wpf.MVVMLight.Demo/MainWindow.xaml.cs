using GalaSoft.MvvmLight;
using System.Windows;

namespace Wpf.MVVMLight.Demo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, ICleanup
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Cleanup()
        {
          
        }
    }
}
