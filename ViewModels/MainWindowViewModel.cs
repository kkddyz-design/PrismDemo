using Prism.Mvvm;


namespace PrismDemo.ViewModels
{
    /*
     * 当 ViewModel 或 Model 的属性值发生变化时，通过触发 PropertyChanged 事件，
     * 通知绑定到该属性的 UI 元素自动更新显示内容
     * 
     * Prism 提供了 BindableBase 类，它已经实现了 INotifyPropertyChanged 接口，并封装了 SetProperty 方法。
     * ViewModel 只需继承此类，即可轻松实现属性变更通知。
     * */

    public class MainWindowViewModel : BindableBase
    {

        private string _title = "Prism学习";

        public string Title
        {
            get { return _title; }

            // SetProperty 会自动比较新旧值，并在变化时触发 PropertyChanged 事件
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
        }

    }

}
