using Prism.Ioc;
using PrismDemo.Views;
using System.Windows;


namespace PrismDemo
{

    public partial class App
    {

        protected override Window CreateShell()
        {
            // 通过依赖注入解析指定窗口（Prism推荐）
            return Container.Resolve<ObservableCollectionDemoWindow>();

            // return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

    }

}
