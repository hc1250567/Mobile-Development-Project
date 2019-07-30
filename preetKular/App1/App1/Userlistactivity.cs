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
    [Activity(Label = "Userlistactivity")]
    public class Userlistactivity : Activity
    {
        ListView listView;
        String[] arraymovie = { "Bollywood", "Hollywood", "Polywood","Lollywood" };
        DBHelperclass vdb;
        ICursor cursor;
        ArrayAdapter myAdapter, myAdapter2;
        SearchView mySearch;
        List<string> newlist = new List<string>();
        List<UserObject> c_result = new List<UserObject>();
        List<UserObject> S_result = new List<UserObject>();
        List<String> termsList = new List<String>();

        EditText name, email, age, password;
        Button goBack;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Userlistlayout);
            // Create your application here
            listView = FindViewById<ListView>(Resource.Id.List);
            mySearch = FindViewById<SearchView>(Resource.Id.searchID);
            vdb = new DBHelperclass(this);
            

            

            //get cursor values
            
                   // c_result.Add(new UserObject("lIST 1", "MENU", Resource.Drawable.user));
           // c_result.Add(new UserObject("lIST 2", "MENU", Resource.Drawable.user));
            //c_result.Add(new UserObject("lIST 3", "MENU", Resource.Drawable.user));


            // c_result.AddRange(newlist);
            //c_result.Add(new UserObject("Mike", "24" , Resource.Drawable.fb));


            myAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, arraymovie);

            listView.Adapter = myAdapter;



            listView.Adapter = myAdapter;
            listView.ItemClick += List_ItemClick;
            mySearch.QueryTextChange += MySearch_QueryTextChange;
        }

       

        private void MySearch_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            //throw new System.NotImplementedException();


            termsList.Clear();
            //something here
            var mySearchValue = e.NewText;
            System.Console.WriteLine("Search Text is :  is \n\n " + mySearchValue);

            foreach (string item in arraymovie)
            {
                if (item.StartsWith(mySearchValue))
                {
                    termsList.Add(item);
                }
            }
            //if (arraymovie.Contains(mySearchValue))
            //{
            //    termsList.Add(mySearchValue);
            //}

            myAdapter2 = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, termsList);
            termsList.ForEach(Console.WriteLine);
            listView.Adapter = myAdapter2;


        }


        private void List_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //throw new System.NotImplementedException();
            
            int index = e.Position;
            //string listvalue = s_result[index];
            
                Console.WriteLine("1");
                //load list1 layout here
                Intent newScreen = new Intent(this, typeof(movielist));
            newScreen.PutExtra("position", index);
            


            StartActivity(newScreen);
           


        }


    }
        
    

}