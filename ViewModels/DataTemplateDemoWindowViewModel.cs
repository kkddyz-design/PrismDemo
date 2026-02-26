// ViewModels/DataTemplateDemoWindowViewModel.cs
using Prism.Mvvm;
using PrismDemo.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;


namespace PrismDemo.ViewModels
{

    // 继承 BindableBase 实现属性通知
    public class DataTemplateDemoWindowViewModel : BindableBase
    {

        // 核心数据集合（ViewModel 中定义）
        private ObservableCollection<Student> _students;

        public ObservableCollection<Student> Students
        {
            get => _students;
            set => SetProperty(ref _students, value); // Prism 封装的属性更新方法
        }

        // 构造函数：初始化数据（ViewModel 中处理）
        public DataTemplateDemoWindowViewModel()
        {
            InitializeStudents();
        }

        // 数据初始化逻辑
        private void InitializeStudents()
        {
            // 全局路径
            // string imagePath = "C:\\Users\\Administrator\\source\\repos\\PrismDemo\\Resources\\Images";

            // 使用content的方式，将图片资源放置到 Resources\Images文件下，拼接当前工作路径
            string imageContentPath = $"{Directory.GetCurrentDirectory()}\\Resources\\Images";
            Students = new ObservableCollection<Student>()
                { new Student()
                  {
                      Name = "张三",
                      Age = 20,
                      Avatar = $"{imageContentPath}\\1.webp"
                  },
                new Student()
                {
                    Name = "李四",
                    Age = 21,
                    Avatar = $"{imageContentPath}\\2.webp"
                },
                new Student()
                {
                    Name = "王五",
                    Age = 19,
                    Avatar = $"{imageContentPath}\\3.webp"
                } };

            Console.WriteLine($"当前工作目录：{Directory.GetCurrentDirectory()}\n");
            Console.WriteLine($"图片资源路径{imageContentPath}\n");

            // C:\Users\Administrator\source\repos\PrismDemo\bin\Debug\net6.0-windows\Resources\Images
        }

    }

}