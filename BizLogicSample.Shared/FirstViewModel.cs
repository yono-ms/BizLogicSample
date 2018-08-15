using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BizLogicSample.Shared
{
    /// <summary>
    /// 最初の画面のViewModel
    /// </summary>
    public class FirstViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// フレームの参照を持つ
        /// </summary>
        public MainViewModel MainViewModel { get; set; }
        /// <summary>
        /// 最初の画面の文字
        /// </summary>
        private string firstName;
        /// <summary>
        /// 最初の画面の文字
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName))); }
        }
        /// <summary>
        /// 次へボタン
        /// </summary>
        public void CommandCommit()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                MainViewModel.AlertMessage = "入力してください";
                return;
            }
            // 次画面へ
            MainViewModel.CurrentViewModelName = nameof(SecondViewModel);
        }
    }
}
