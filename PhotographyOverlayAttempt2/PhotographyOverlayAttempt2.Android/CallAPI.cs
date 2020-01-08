using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.CurrentActivity;

namespace PhotographyOverlayAttempt2.Droid
{

    public class CallAPI
    {
        
        // Gets or sets the activity.
        Activity Activity { get; set; }

        
        // Gets the current Application Context.
        Context AppContext { get; }

        
        // Fires when activity state events are fired.
        //event EventHandler<ActivityEventArgs> ActivityStateChanged;

        void Register()
        {
            CrossCurrentActivity.Current.ActivityStateChanged += Current_ActivityStateChanged;
        }

        private void Current_ActivityStateChanged(object sender, ActivityEventArgs e)
        {
            Toast.MakeText(Application.Context, $"Activity Changed: {e.Activity.LocalClassName} - {e.Event}", ToastLength.Short).Show();
        }
    }
}