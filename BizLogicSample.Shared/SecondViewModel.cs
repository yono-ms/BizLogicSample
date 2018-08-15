using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BizLogicSample.Shared
{
    /// <summary>
    /// 二枚目の画面のViewModel
    /// </summary>
    public class SecondViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// フレームの参照を持つ
        /// </summary>
        public MainViewModel MainViewModel { get; set; }
        /// <summary>
        /// 二枚目の画面の文字
        /// </summary>
        private string secondName;
        /// <summary>
        /// 二枚目の画面の文字
        /// </summary>
        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SecondName))); }
        }
    }
}
