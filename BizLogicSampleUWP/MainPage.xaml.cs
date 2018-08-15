using BizLogicSample.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace BizLogicSampleUWP
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Dictionary<string, Type> viewNames;

        public MainPage()
        {
            this.InitializeComponent();

            // ビュー一覧を作成
            viewNames = new Dictionary<string, Type>
            {
                [nameof(FirstViewModel)] = typeof(FirstPage),
                [nameof(SecondViewModel)] = typeof(SecondPage)
            };

            Loaded += MainPage_Loaded;

            App.Current.BizLogic.MainViewModel.PropertyChanged += MainViewModel_PropertyChangedAsync;
        }

        private async void MainViewModel_PropertyChangedAsync(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var vm = sender as MainViewModel;
            switch (e.PropertyName)
            {
                case nameof(vm.CurrentViewModelName):
                    FrameContent.Navigate(viewNames[vm.CurrentViewModelName]);
                    break;

                case nameof(vm.AlertMessage):
                    await new ContentDialog { Content = vm.AlertMessage, PrimaryButtonText = "OK" }.ShowAsync();
                    break;

                default:
                    Debug.WriteLine($"MainViewModel_PropertyChanged {e.PropertyName}");
                    break;
            }
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var vm = App.Current.BizLogic.MainViewModel;
            FrameContent.Navigate(viewNames[vm.CurrentViewModelName]);
        }
    }
}
