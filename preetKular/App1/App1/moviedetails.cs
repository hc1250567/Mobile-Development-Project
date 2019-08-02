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

namespace App1
{
    [Activity(Label = "moviedetails")]
    public class moviedetails : Activity
    {
        string moviename;
        TextView movienamefromxml;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.moviedetails);
            moviename = Intent.GetStringExtra("movie");
            movienamefromxml= FindViewById<TextView>(Resource.Id.movieNameId);

            movienamefromxml.Text = moviename;
        }
    }
}