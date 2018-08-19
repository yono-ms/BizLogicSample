using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using BizLogicSample.Shared;

namespace BizLogicSampleAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        public BizLogicMain BizLogic => (Application as CustomApplication).BizLogic;
        public MainViewModel MainViewModel => (Application as CustomApplication).BizLogic.MainViewModel;

        private Dictionary<string, Type> viewNames;

        public BaseFragment GetFragmentFromName(string name)
        {
            return Activator.CreateInstance(viewNames[name]) as BaseFragment;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            System.Diagnostics.Debug.WriteLine($"{Class.SimpleName} OnCreate recycle={savedInstanceState != null}");

            viewNames = new Dictionary<string, Type>
            {
                [nameof(FirstViewModel)] = typeof(FirstFragment),
                [nameof(SecondViewModel)] = typeof(SecondFragment)
            };

            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            if (savedInstanceState == null)
            {
                var fragment = GetFragmentFromName(MainViewModel.CurrentViewModelName);
                SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayoutContent, fragment).Commit();
            }
        }

        protected override void OnStart()
        {
            base.OnStart();
            System.Diagnostics.Debug.WriteLine($"{Class.SimpleName} OnStart");
        }

        protected override void OnRestart()
        {
            base.OnRestart();
            System.Diagnostics.Debug.WriteLine($"{Class.SimpleName} OnRestart");
        }

        protected override void OnResume()
        {
            base.OnResume();
            System.Diagnostics.Debug.WriteLine($"{Class.SimpleName} OnResume");

            MainViewModel.PropertyChanged += MainViewModel_PropertyChanged;
        }

        private void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"MainViewModel_PropertyChanged {e.PropertyName}");

            switch (e.PropertyName)
            {
                case nameof(MainViewModel.CurrentViewModelName):
                    var fragment = GetFragmentFromName(MainViewModel.CurrentViewModelName);
                    SupportFragmentManager.BeginTransaction().Replace(Resource.Id.frameLayoutContent, fragment).Commit();
                    break;

                case nameof(MainViewModel.AlertMessage):
                    var dialog = AlertDialogFragment.NewInstance(MainViewModel.AlertMessage);
                    dialog.Show(SupportFragmentManager, nameof(AlertDialogFragment));
                    break;

                default:
                    System.Diagnostics.Debug.WriteLine(" unknown.");
                    break;
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
            System.Diagnostics.Debug.WriteLine($"{Class.SimpleName} OnPause");

            MainViewModel.PropertyChanged -= MainViewModel_PropertyChanged;
        }

        protected override void OnStop()
        {
            base.OnStop();
            System.Diagnostics.Debug.WriteLine($"{Class.SimpleName} OnStop");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            System.Diagnostics.Debug.WriteLine($"{Class.SimpleName} OnDestroy");
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public class AlertDialogFragment : Android.Support.V4.App.DialogFragment
        {
            private const string KEY_MESSAGE = "KEY_MESSAGE";

            public static AlertDialogFragment NewInstance(string message)
            {
                var bundle = new Bundle();
                bundle.PutString(KEY_MESSAGE, message);

                var dialog = new AlertDialogFragment();
                dialog.Arguments = bundle;

                return dialog;
            }

            public override Dialog OnCreateDialog(Bundle savedInstanceState)
            {
                Cancelable = false;

                var dialog = new Android.Support.V7.App.AlertDialog.Builder(Context)
                    .SetMessage(Arguments.GetString(KEY_MESSAGE))
                    .SetPositiveButton("OK", (s, e)=> { });

                return dialog.Create();
            }
        }
	}
}

