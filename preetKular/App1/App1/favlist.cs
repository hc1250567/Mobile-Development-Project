using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    [Activity(Label = "favlist")]
    public class favlist : Activity
    {
        Fragment[] _fragmentsArray;
        string name = "Welcome To my App";
        List<String> movieArray = new List<String>();
        List<String> movieArray2 = new List<String>();
        DBHelperclass dbcn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            // Set our view from the "main" layout resource
            RequestWindowFeature(Android.Views.WindowFeatures.ActionBar);
            //enable navigation mode to support tab layout
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.favlist);
            //get data from database fro the list

            dbcn = new DBHelperclass(this);

            ICursor myresut1 = dbcn.selectmovienames();

            var nameValue1 = "";
            //get cursor values
            if (myresut1.Count > 0)
            {
                while (myresut1.MoveToNext())
                {

                    nameValue1 = myresut1.GetString(myresut1.GetColumnIndexOrThrow("names"));
                    System.Console.WriteLine("Name from Database: " + nameValue1);

                    movieArray.Add(nameValue1);

                }
            }
            //databse code ends here
            ICursor myresut2 = dbcn.selectwatchlaternames();

            var nameValue2 = "";
            //get cursor values
            if (myresut2.Count > 0)
            {
                while (myresut2.MoveToNext())
                {




                    nameValue2 = myresut2.GetString(myresut1.GetColumnIndexOrThrow("names"));
                    System.Console.WriteLine("Name from Database: " + nameValue2);

                    movieArray2.Add(nameValue2);

                }
            }
            //databse code ends here

            _fragmentsArray = new Fragment[]
            {
            new Fragment1( this, movieArray ),
            new Fragment2(this, movieArray2),
            
            };
            

            AddTabToActionBar("Favorites"); //First Tab
            AddTabToActionBar("Watch Later"); //First Tab
            

        }


        void AddTabToActionBar(string tabTitle)
        {
            Android.App.ActionBar.Tab tab = ActionBar.NewTab();
            tab.SetText(tabTitle);

            tab.SetIcon(Android.Resource.Drawable.IcInputAdd);

            tab.TabSelected += TabOnTabSelected;

            ActionBar.AddTab(tab);
        }



        void TabOnTabSelected(object sender, Android.App.ActionBar.TabEventArgs
            tabEventArgs)
        {
            Android.App.ActionBar.Tab tab = (Android.App.ActionBar.Tab)sender;

            //Log.Debug(Tag, "The tab {0} has been selected.", tab.Text);
            Fragment frag = _fragmentsArray[tab.Position];

            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
        }



    
}
}