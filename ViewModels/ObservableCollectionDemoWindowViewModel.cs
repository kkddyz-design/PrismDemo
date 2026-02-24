using Prism.Commands;
using Prism.Mvvm;
using PrismDemo.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace PrismDemo.ViewModels
{

    public class ObservableCollectionDemoWindowViewModel : BindableBase
    {

        // 1. 选中的设备（改为DeviceInfo类型）
        private DeviceInfo _selectedDevice;

        public DeviceInfo SelectedDevice
        {
            get => _selectedDevice;

            // ref让SetProperty方法能够直接修改外部的私有字段 _status 的值
            // 内部调用调用RaisePropertyChanged(nameof(Status))，触发PropertyChanged事件
            set => SetProperty(ref _selectedDevice, value);
        }

        // 2. 设备列表（改为DeviceInfo集合）
        public ObservableCollection<DeviceInfo> DeviceList { get; } = new ObservableCollection<DeviceInfo>();

        // 3. 命令定义（新增状态切换命令）
        public ICommand AddDeviceCommand { get; }

        public ICommand RemoveDeviceCommand { get; }

        public ICommand ToggleStatusCommand { get; }

        public ObservableCollectionDemoWindowViewModel()
        {
            // 初始化命令
            AddDeviceCommand = new DelegateCommand(OnAddDevice);
            RemoveDeviceCommand = new DelegateCommand(OnRemoveDevice);
            ToggleStatusCommand = new DelegateCommand(OnToggleStatus);

            // 初始化数据（带状态）
            DeviceList.Add(new DeviceInfo { DeviceName = "PLC-192.168.1.100", Status = DeviceStatus.Normal });
            DeviceList.Add(new DeviceInfo { DeviceName = "传感器-车间A-01", Status = DeviceStatus.Offline });
        }

        // 新增设备（默认状态为正常）
        private void OnAddDevice()
        {
            DeviceList.Add(new DeviceInfo
            {
                DeviceName = $"新设备-{DateTime.Now:HHmmss}",
                Status = DeviceStatus.Normal
            });
        }

        // 删除选中设备
        private void OnRemoveDevice()
        {
            if(SelectedDevice != null) {
                DeviceList.Remove(SelectedDevice);
                SelectedDevice = null; // 清空选中项
            }
        }

        // 切换选中设备的状态（正常→故障→离线循环）
        private void OnToggleStatus()
        {
            if(SelectedDevice == null) {
                return;
            }

            SelectedDevice.Status = SelectedDevice.Status switch
            {
                DeviceStatus.Normal => DeviceStatus.Error,
                DeviceStatus.Error => DeviceStatus.Offline,
                DeviceStatus.Offline => DeviceStatus.Normal,
                _ => DeviceStatus.Normal
            };

            // 这个方法触发的是 “SelectedDevice 属性（整个对象）的变更通知”-- ObservableCollection感知不到
            // 而非SelectedDevice.Status（对象内部属性）的通知

            // Prism 的SetProperty方法已经自动帮你调用了RaisePropertyChanged
            // RaisePropertyChanged(nameof(SelectedDevice));
        }

    }

}