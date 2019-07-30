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
    [Activity(Label = "WelcomeNew")]
    public class WelcomeNew : Activity
    {

        String valueFromLoginUser;
        String passwordFromLogin;
        EditText name, email, age, password;
        Button editBtn, deleteBtn, userList;
        DBHelperclass dbcn;
        Android.App.AlertDialog.Builder alert;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.welcomeLayout);
            // Create your application here

            valueFromLoginUser = Intent.GetStringExtra("usernameLogin");
            passwordFromLogin = Intent.GetStringExtra("passwordLogin");
            name = FindViewById<EditText>(Resource.Id.display_name);
            email = FindViewById<EditText>(Resource.Id.display_email);
            age = FindViewById<EditText>(Resource.Id.display_age);
            password = FindViewById<EditText>(Resource.Id.display_password);
            editBtn = FindViewById<Button>(Resource.Id.editBtn);
            deleteBtn = FindViewById<Button>(Resource.Id.DeleteBtn);
            userList = FindViewById<Button>(Resource.Id.userlist);
            alert = new Android.App.AlertDialog.Builder(this);

            //assign value
            name.Text = valueFromLoginUser;
            //Read Only
            name.Enabled = false;
            ICursor myresut1;
            /// ???
            dbcn = new DBHelperclass(this);
            myresut1 = dbcn.SelectUserdata(valueFromLoginUser, passwordFromLogin);

            var myId1 = 1; var nameValue1 = ""; var emailValue1 = ""; var ageValue1 = ""; var passValue1 = "";
            //get cursor values
            if (myresut1.Count > 0)
            {
                while (myresut1.MoveToNext())
                {

                    myId1 = myresut1.GetInt(myresut1.GetColumnIndexOrThrow("id"));
                    System.Console.WriteLine("ID from Database: " + myId1);


                    nameValue1 = myresut1.GetString(myresut1.GetColumnIndexOrThrow("names"));
                    System.Console.WriteLine("Name from Database: " + nameValue1);

                    emailValue1 = myresut1.GetString(myresut1.GetColumnIndexOrThrow("email"));
                    System.Console.WriteLine("Email from Database: " + emailValue1);

                    ageValue1 = myresut1.GetString(myresut1.GetColumnIndexOrThrow("age"));
                    System.Console.WriteLine("Age from Database: " + ageValue1);

                    passValue1 = myresut1.GetString(myresut1.GetColumnIndexOrThrow("password"));
                    System.Console.WriteLine("Password from Database: " + passValue1);


                }
                //assign value
                email.Text = emailValue1;
                //Read Only
                email.Enabled = false;
                //assign value
                age.Text = ageValue1;
                //Read Only
                age.Enabled = false;
                //assign value
                password.Text = passValue1;
                //Read Only
                password.Enabled = false;
                System.Console.WriteLine("Name from Login ---> " + valueFromLoginUser);
                System.Console.WriteLine("Pasword from Login ---> " + passwordFromLogin);


                editBtn.Click += editBtnClicEvent;
                deleteBtn.Click += editBtnClicEvent2;
                userList.Click += delegate
                { 

                Intent newScreen = new Intent(this, typeof(Userlistactivity));



                StartActivity(newScreen);
            };


        }
            else
            {
                Console.WriteLine("User doesnt exitst!");
                alert.SetTitle("Error");

                alert.SetMessage("USER DOESN'T EXIST");

                alert.SetPositiveButton("OK", alertOKButton);

                alert.SetNegativeButton("Cancel", alertOKButton);

                Dialog myDialog = alert.Create();

                myDialog.Show();

                Intent newScreen1 = new Intent(this, typeof(MainActivity));
                StartActivity(newScreen1);
            }


           
        }


        public void editBtnClicEvent(object sender, EventArgs e)
        {


            name.Enabled = true;
            email.Enabled = true;
            age.Enabled = true;
            password.Enabled = true;
            editBtn.Text = "Save";
            string namevalue = name.Text;
            string emailvalue = email.Text;
            string agevalue = age.Text;
            string passwordvalue = password.Text;
            dbcn.UpdateUserdata(namevalue, emailvalue, agevalue, passwordvalue, valueFromLoginUser, passwordFromLogin);
            dbcn.SelectMydata();
            editBtn.Click += delegate
                {
                    Console.WriteLine("UPDATED SUCCESSFULLY");
                    alert.SetTitle("Updated");

                    alert.SetMessage("Details updated");

                    alert.SetPositiveButton("OK", alertOKButton);

                    alert.SetNegativeButton("Cancel", alertOKButton);

                    Dialog myDialog = alert.Create();

                    myDialog.Show();

                    name.Enabled = false;
                    email.Enabled = false;
                    age.Enabled = false;
                    password.Enabled = false;
                    editBtn.Text = "Edit";

                };
        }

        public void editBtnClicEvent2(object sender, EventArgs e)
        {


            dbcn.DeleteUserdata(valueFromLoginUser, passwordFromLogin);

            Console.WriteLine("Deleted SUCCESSFULLY");
            alert.SetTitle("Deleted");

            alert.SetMessage("Details Deleted");

            alert.SetPositiveButton("OK", alertOKButton);

            alert.SetNegativeButton("Cancel", alertOKButton);

            Dialog myDialog = alert.Create();

            myDialog.Show();

        }

        public void alertOKButton(object sender, Android.Content.DialogClickEventArgs e)

        {

            System.Console.WriteLine("OK Button Pressed");

        }
    }


}