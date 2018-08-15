using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        [Required(ErrorMessage = "お名前を入力してください。")]
        [RegularExpression("[^0-9A-Za-z]+", ErrorMessage = "英数字は使用できません。")]
        [StringLength(3, ErrorMessage = "お名前は{1}桁以内で入力してください。")]
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                FirstNameError = ValidateProperty(nameof(FirstName), value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
            }
        }
        /// <summary>
        /// プロパティエラーメッセージ
        /// </summary>
        private string firstNameError;
        /// <summary>
        /// プロパティエラーメッセージ
        /// </summary>
        public string FirstNameError
        {
            get { return firstNameError; }
            set { firstNameError = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstNameError))); }
        }

        public string FirstNamePlaceholder => "山田";

        /// <summary>
        /// 次へボタン
        /// </summary>
        public void CommandCommit()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                MainViewModel.AlertMessage = "入力してください。";
                return;
            }
            if (!string.IsNullOrWhiteSpace(FirstNameError))
            {
                MainViewModel.AlertMessage = "入力に誤りがあります。";
                return;
            }
            // 次画面へ
            MainViewModel.CurrentViewModelName = nameof(SecondViewModel);
        }
        /// <summary>
        /// プロパティバリデーション
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        /// <param name="value">値</param>
        /// <returns>エラーメッセージ</returns>
        public string ValidateProperty(string propertyName, object value)
        {
            var context = new ValidationContext(this) { MemberName = propertyName };
            var validationErrors = new List<ValidationResult>();
            if (!Validator.TryValidateProperty(value, context, validationErrors))
            {
                // エラー有り
                return validationErrors.Select(i => i.ErrorMessage).FirstOrDefault();
            }
            else
            {
                // エラー無し
                return " ";
            }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FirstViewModel()
        {
            FirstName = "";
        }
    }
}
