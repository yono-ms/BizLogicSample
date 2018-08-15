using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BizLogicSample.Shared
{
    /// <summary>
    /// ビジネスロジック
    /// </summary>
    public class BizLogicMain
    {
        /// <summary>
        /// フレームのViewModel
        /// </summary>
        public MainViewModel MainViewModel { get; set; }
        /// <summary>
        /// 最初の画面のViewModel
        /// </summary>
        public FirstViewModel FirstViewModel { get; set; }
        /// <summary>
        /// 二枚目の画面のViewModel
        /// </summary>
        public SecondViewModel SecondViewModel { get; set; }
        /// <summary>
        /// 状態を復元する
        /// </summary>
        public void LoadInstanceState()
        {
            Debug.WriteLine("---- BizLogicMain LoadInstanceState ----");
        }
        /// <summary>
        /// 状態を保存する
        /// </summary>
        public void SaveInstanceState()
        {
            Debug.WriteLine("---- BizLogicMain SaveInstanceState ----");
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BizLogicMain()
        {
            Debug.WriteLine("---- BizLogicMain ctor ----");
            MainViewModel = new MainViewModel { CurrentViewModelName = nameof(FirstViewModel) };
            FirstViewModel = new FirstViewModel { MainViewModel = MainViewModel };
            SecondViewModel = new SecondViewModel { MainViewModel = MainViewModel };
        }
    }
}
