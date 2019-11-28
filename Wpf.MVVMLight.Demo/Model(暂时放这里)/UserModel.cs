using GalaSoft.MvvmLight;

namespace Wpf.MVVMLight.Demo.Model
{
    public class UserModel : ObservableObject
    {
        private int _Id;
        /// <summary>
        /// 主键ID
        /// </summary>
        public int  Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                RaisePropertyChanged(() => Id);
            }
        }

        private int _Name;
        /// <summary>
        /// 名称
        /// </summary>
        public int Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                RaisePropertyChanged(() => Name);
            }
        }
    }
}
