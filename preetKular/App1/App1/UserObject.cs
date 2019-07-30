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
    public class UserObject
    {
        public String Name { get; set; }
        public String Age { get; set; }
        public int Image { get; set; }

        public UserObject(string nameInfo, string ageInfo, int imgInfo)
        {
            Name = nameInfo;
            Age = ageInfo;
            Image = imgInfo;
        }

        public String getName()
        {
            return Name;
        }

        public override string ToString()
        {
            return string.Format("My name is {0} and I'm {1} years old.", Name, Age);
        }
    }

}