using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BizLogicSample.Shared;

namespace BizLogicSampleAndroid
{
    [Application]
    public class CustomApplication : Application
    {
        public BizLogicMain BizLogic { get; set; }

        public CustomApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            BizLogic = new BizLogicMain();
        }

        public override void OnCreate()
        {
            base.OnCreate();
            System.Diagnostics.Debug.WriteLine($"{Class.SimpleName} OnCreate");

            BizLogic.LoadInstanceState();
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            System.Diagnostics.Debug.WriteLine($"{Class.SimpleName} OnTerminate");
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            System.Diagnostics.Debug.WriteLine($"{Class.SimpleName} OnConfigurationChanged {newConfig.ToString()}");
        }

        public override void OnLowMemory()
        {
            base.OnLowMemory();
            System.Diagnostics.Debug.WriteLine($"{Class.SimpleName} OnLowMemory");
        }

        public override void OnTrimMemory([GeneratedEnum] TrimMemory level)
        {
            base.OnTrimMemory(level);
            System.Diagnostics.Debug.WriteLine($"{Class.SimpleName} OnTrimMemory {level.ToString()}");

            BizLogic.SaveInstanceState();
        }
    }
}