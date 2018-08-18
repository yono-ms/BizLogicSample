using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using BizLogicSample.Shared;

namespace BizLogicSampleAndroid
{
    public class FirstFragment : BaseFragment
    {
        public FirstViewModel ViewModel => BizLogic.FirstViewModel;

        private TextView textViewFirstNameError;
        private EditText editTextFirstName;
        private Button buttonCommit;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            var itemView = inflater.Inflate(Resource.Layout.fragment_first, container, false);

            textViewFirstNameError = itemView.FindViewById<TextView>(Resource.Id.textViewNameError);
            editTextFirstName = itemView.FindViewById<EditText>(Resource.Id.editTextName);
            buttonCommit = itemView.FindViewById<Button>(Resource.Id.button);

            editTextFirstName.Hint = ViewModel.FirstNamePlaceholder;

            ViewModel_PropertyChanged(ViewModel, new System.ComponentModel.PropertyChangedEventArgs("init"));

            return itemView;
        }

        public override void OnResume()
        {
            base.OnResume();
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            editTextFirstName.TextChanged += EditTextFirstName_TextChanged;
            buttonCommit.Click += ButtonCommit_Click;
        }

        private void ButtonCommit_Click(object sender, EventArgs e)
        {
            ViewModel.CommandCommit();
        }

        private void EditTextFirstName_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            ViewModel.FirstName = e.Text.ToString();
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"ViewModel_PropertyChanged {e.PropertyName}");

            textViewFirstNameError.Text = ViewModel.FirstNameError;
            if (!editTextFirstName.Text.Equals(ViewModel.FirstName))
            {
                editTextFirstName.Text = ViewModel.FirstName;
            }
        }

        public override void OnPause()
        {
            base.OnPause();
            ViewModel.PropertyChanged -= ViewModel_PropertyChanged;
            editTextFirstName.TextChanged -= EditTextFirstName_TextChanged;
            buttonCommit.Click -= ButtonCommit_Click;
        }
    }
}