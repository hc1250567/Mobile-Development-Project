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
    [Activity(Label = "MyCustomAdapter")]
    public class MyCustomAdapter : BaseAdapter<UserObject>
    {
        List<UserObject> userList;
        Activity mycontext;

        public MyCustomAdapter(Activity contex, List<UserObject> userArray)
        {
            userList = userArray;
            mycontext = contex;
        }

        public override UserObject this[int position]
        {

            get { return userList[position]; }
        }

        public override int Count
        {
            get
            {
                return userList.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View myView = convertView;
            UserObject myObj = userList[position];

            if (myView == null)
            {
                myView = mycontext.LayoutInflater.Inflate(Resource.Layout.CellLayout, null);
            }

            myView.FindViewById<TextView>(Resource.Id.nameID).Text = myObj.Name;
            myView.FindViewById<TextView>(Resource.Id.ageID).Text = myObj.Age;
            myView.FindViewById<ImageView>(Resource.Id.userImageId).SetImageResource(myObj.Image);
            return myView;
        }

    }
}