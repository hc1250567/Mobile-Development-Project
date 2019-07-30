using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace App1
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {

        EditText myUserName;

        EditText myPass;

        Button myLoginbtn;

        Button signupBtn;



        //variables for signup page 

        // prefix "s_" used for signup page variables 

        EditText s_username;

        EditText s_pass;

        EditText s_email;

        EditText s_age;

        Button s_signupBtn;



        Android.App.AlertDialog.Builder alert;

        DBHelperclass myDB;

        protected override void OnCreate(Bundle savedInstanceState)

        {

            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource 

            SetContentView(Resource.Layout.activity_main);

            //fatching information from login page 

            myUserName = FindViewById<EditText>(Resource.Id.userNameID);

            myPass = FindViewById<EditText>(Resource.Id.pass);

            myLoginbtn = FindViewById<Button>(Resource.Id.button1);

            signupBtn = FindViewById<Button>(Resource.Id.signup);







            alert = new Android.App.AlertDialog.Builder(this);

            myDB = new DBHelperclass(this); //create constructor 







            signupBtn.Click += delegate

            {

                SetContentView(Resource.Layout.signup);

                // Intent newScreen = new Intent(this, typeof(DBHelperClass)); 



                // StartActivity(newScreen);
                //fatching information from signup page 

                s_username = FindViewById<EditText>(Resource.Id.s_userNameID);

                s_email = FindViewById<EditText>(Resource.Id.s_email);

                s_age = FindViewById<EditText>(Resource.Id.s_age);

                s_pass = FindViewById<EditText>(Resource.Id.s_pass);

                s_signupBtn = FindViewById<Button>(Resource.Id.s_button1);

                s_signupBtn.Click += delegate

                {

                    var value5 = s_username.Text;

                    var value6 = s_email.Text;

                    var value7 = s_age.Text;

                    var value8 = s_pass.Text;

                    if (value5.Trim().Equals("") || value5.Length < 0 || value6.Trim().Equals("") ||

                    value6.Length < 0 || value7.Trim().Equals("") ||

                    value7.Length < 0 || value8.Trim().Equals("") ||

                    value8.Length < 0)

                    {



                        alert.SetTitle("Error");

                        alert.SetMessage("Please Enter Valid Data");

                        alert.SetPositiveButton("OK", alertOKButton);

                        alert.SetNegativeButton("Cancel", alertOKButton);

                        Dialog myDialog = alert.Create();

                        myDialog.Show();

                    }

                    else

                    {

                        //insert in database here 

                        //order to insert (int id, string value_username, string value_email, string value_age, string value_pass) 



                        myDB.InsertValue(1, value5, value6, value7, value8);

                        //System.Console.WriteLine(value,value2, value3, value4); 

                        myDB.SelectMydata();



                        //SetContentView(Resource.Layout.activity_main);
                        Intent newScreen = new Intent(this, typeof(MainActivity));



                        StartActivity(newScreen);




                    }





                };

            };





            myLoginbtn.Click += delegate

            {



                var value = myUserName.Text;

                var value2 = myPass.Text;



                System.Console.WriteLine("Username: ---- > " + value);

                System.Console.WriteLine("Password: ---- > " + value2);

                if (value.Trim().Equals("") || value.Length < 0 || value2.Trim().Equals("") || value2.Length < 0)

                {



                    alert.SetTitle("Error");

                    alert.SetMessage("Please Enter Valid Data");

                    alert.SetPositiveButton("OK", alertOKButton);

                    alert.SetNegativeButton("Cancel", alertOKButton);

                    Dialog myDialog = alert.Create();

                    myDialog.Show();

                }

                else

                {  // some value  



                    //myDB.insertValue(1, value); 



                    //myDB.SelectMydata();

                    Intent newScreen1 = new Intent(this, typeof(WelcomeNew));
                    newScreen1.PutExtra("usernameLogin", value);
                    newScreen1.PutExtra("passwordLogin", value2);


                    StartActivity(newScreen1);






                }



            };



        }



        public void alertOKButton(object sender, Android.Content.DialogClickEventArgs e)

        {



            System.Console.WriteLine("OK Button Pressed");

        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)

        {

            //Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);



            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        }

    }

}