using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace App1
{
    public class Fragment1 : Fragment
    {

        

        List<String> movieArray;

        
        public Activity myContext;
        
        public Fragment1( Activity context, List<String> array)
        {
            
            myContext = context;
            movieArray = array;
        }
        

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            
                // Use this to return your custom view for this Fragment
                View myView = inflater.Inflate(Resource.Layout.fragment1,
                container, false);
            ListView myList = myView.FindViewById<ListView>(Resource.Id.listID);
            

            myList.Adapter = new ArrayAdapter(myContext, Android.Resource.Layout.SimpleListItem1, movieArray);


            return myView;

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}