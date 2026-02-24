using Prism.Mvvm; // 引入BindableBase
using System;
using System.Linq;

/*
 * DeviceInfo模型只是普通类，修改Status属性时，没有通知 WPF “这个属性变了”，
 * 所以 UI 不会刷新 —— 哪怕你调用了RaisePropertyChanged(nameof(SelectedDevice))，
 * 也只能刷新 “选中项” 的整体绑定，无法刷新 ListBox 中所有设备项的 Status 显示。
 */


namespace PrismDemo.Models
{

    // 关键修改：继承BindableBase，实现属性通知
    public class DeviceInfo : BindableBase
    {

        private string _deviceName;
        private DeviceStatus _status;

        // 设备名称（加SetProperty实现通知）
        public string DeviceName
        {
            get => _deviceName;
            set => SetProperty(ref _deviceName, value);
        }

        // 设备状态（核心：加SetProperty实现通知）
        public DeviceStatus Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

    }

}