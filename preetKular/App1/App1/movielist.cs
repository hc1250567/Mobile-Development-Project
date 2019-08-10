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
    [Activity(Label = "movielist")]
    public class movielist : Activity
    {
        int valueFromLoginUser,list;
        ListView listView;
        SearchView mysearch;
        ArrayAdapter myAdapter;
        String[] list1 = { "Special 26", "Chak De India", "Parmanu", "Dangal", "Sanju" };
        String[] list2 = { "Black Panther", "Inception", "Iron Man", "Aladdin", "Spider Man" };
        String[] list3 = { "Ardaas", "Asees", "Udta Punjab", "The Black Prince", "Sardaar Ji" };
        String[] list4 = { "Dukhtar", "Moor", "Rangreza", "Janaan", "Pinky Memsaab" };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            valueFromLoginUser = Intent.GetIntExtra("position",0);
            // Create your application here
            SetContentView(Resource.Layout.movielist);

            listView = FindViewById<ListView>(Resource.Id.myListView2);
            mysearch = FindViewById<SearchView>(Resource.Id.searchID2);

            
            Console.WriteLine("valueFromLoginUser"+valueFromLoginUser);


            if (valueFromLoginUser == 0)
            {
                myAdapter = new ArrayAdapter
                (this, Android.Resource.Layout.SimpleListItem1, list1);
                list = 1;
                Console.WriteLine("Bollywood");
            }
            if (valueFromLoginUser == 1)
            {
                myAdapter = new ArrayAdapter
                (this, Android.Resource.Layout.SimpleListItem1, list2);
                list = 2;
                Console.WriteLine("Hollywood");
            }
            if (valueFromLoginUser == 2)
            {
                myAdapter = new ArrayAdapter
                (this, Android.Resource.Layout.SimpleListItem1, list3);
                list = 3;
                Console.WriteLine("Polywood");
            }
            else if(valueFromLoginUser == 3)
            {
                myAdapter = new ArrayAdapter
                (this, Android.Resource.Layout.SimpleListItem1, list4);
                list = 4;
                Console.WriteLine("Lollywood");
            }
            listView.Adapter = myAdapter;
            listView.ItemClick += myIteamClickMethod;
            
            //Search Events
            mysearch.QueryTextChange += mySearchMethod;
        }
        public void mySearchMethod(object sender, SearchView.QueryTextChangeEventArgs e)
        {

            var mySearchValue = e.NewText;
            System.Console.WriteLine("Search Text is :  is \n\n " + mySearchValue);



        }

        public void myIteamClickMethod(object sender, AdapterView.ItemClickEventArgs e)
        {
            System.Console.WriteLine("I am clicking on the list item \n\n");
            var indexValue = e.Position;
            Intent newScreen1 = new Intent(this, typeof(moviedetails));
            if (list == 1)
            {
                newScreen1.PutExtra("movie", list1[e.Position]);
            }
            if (list == 2)
            {
                newScreen1.PutExtra("movie", list2[e.Position]);
            }
            if (list == 3)
            {
                newScreen1.PutExtra("movie", list3[e.Position]);
            }
            if (list == 4)
            {
                newScreen1.PutExtra("movie", list4[e.Position]);
            }



            StartActivity(newScreen1);



        }
    }
}