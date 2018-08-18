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
    public class BaseFragment : Android.Support.V4.App.Fragment
    {
        public BizLogicMain BizLogic => (Activity as MainActivity).BizLogic;

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
            System.Diagnostics.Debug.WriteLine($"{Class.SimpleName} OnAttach");
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            System.Diagnostics.Debug.WriteLine($"{Class.SimpleName} OnCreate recycle={savedInstanceState != null}");
        }

        public override void OnStart()
        {
            base.OnStart();
            System.Diagnostics.Debug.WriteLine($"{Class.SimpleName} OnStart");
        }

        public override void OnResume()
        {
            base.OnResume();
            System.Diagnostics.Debug.WriteLine($"{Class.SimpleName} OnResume");
        }

        public override void OnPause()
        {
            base.OnPause();
            System.Diagnostics.Debug.WriteLine($"{Class.SimpleName} OnPause");
        }

        public override void OnStop()
        {
            base.OnStop();
            System.Diagnostics.Debug.WriteLine($"{Class.SimpleName} OnStop");
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            System.Diagnostics.Debug.WriteLine($"{Class.SimpleName} OnDestroy");
        }

        public override void OnDetach()
        {
            base.OnDetach();
            System.Diagnostics.Debug.WriteLine($"{Class.SimpleName} OnDetach");
        }
    }
}