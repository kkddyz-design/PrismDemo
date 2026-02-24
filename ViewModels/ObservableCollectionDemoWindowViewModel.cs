using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

// 文件放在PrismDemo.ViewModels下只是物理上的。
// 需要在逻辑上声明ObservableCollectionDemoWindowViewModel属于PrismDemo.ViewModels命名空间
// 不然对于xaml不能自动绑定

namespace PrismDemo.ViewModels
{

    public class ObservableCollectionDemoWindowViewModel : BindableBase
    {

        // 定义SelectedDevice属性（绑定ListBox选中项，否则删除时选中项为null）
        private string _selectedDevice;

        public string SelectedDevice
        {
            get => _selectedDevice;

            // 用SetProperty实现双向绑定通知，确保选中项变化时更新
            set => SetProperty(ref _selectedDevice, value);
        }

        // 定义ObservableCollection属性
        public ObservableCollection<string> DeviceList { get; } = new ObservableCollection<string>();

        // 新增元素的命令
        public ICommand AddDeviceCommand { get; }

        // 删除选中元素的命令
        public ICommand RemoveDeviceCommand { get; }

        public ObservableCollectionDemoWindowViewModel()
        {
            AddDeviceCommand = new DelegateCommand(OnAddDevice);
            RemoveDeviceCommand = new DelegateCommand(OnRemoveDevice);

            // 初始化数据
            DeviceList.Add("PLC-192.168.1.100");
            DeviceList.Add("传感器-车间A-01");
        }

        // 添加元素：UI会自动刷新
        private void OnAddDevice()
        {
            // 模拟新增设备（如从Modbus读取的设备名称）
            DeviceList.Add($"新设备-{DateTime.Now:HHmmss}");
        }

        // SelectedDevice双向绑定了,在UI界面选择时同步修改SelectedDevice变量
        private void OnRemoveDevice()
        {
            if(!string.IsNullOrEmpty(SelectedDevice)) {
                DeviceList.Remove(SelectedDevice);
            }
        }

    }

}
