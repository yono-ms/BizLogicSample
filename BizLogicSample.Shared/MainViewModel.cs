using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BizLogicSample.Shared
{
    /// <summary>
    /// フレームのViewModel
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// 現在の画面名
        /// </summary>
        private string currentViewModelName;
        /// <summary>
        /// 現在の画面名.
        /// 値をセットされたらView側で画面遷移する.
        /// </summary>
        public string CurrentViewModelName
        {
            get { return currentViewModelName; }
            set { currentViewModelName = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentViewModelName))); }
        }
        /// <summary>
        /// アラートダイアログメッセージ
        /// </summary>
        private string alertMessage;
        /// <summary>
        /// アラートダイアログメッセージ.
        /// 値をセットされたらView側でアラート表示する.
        /// </summary>
        public string AlertMessage
        {
            get { return alertMessage; }
            set { alertMessage = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AlertMessage))); }
        }

    }
}
