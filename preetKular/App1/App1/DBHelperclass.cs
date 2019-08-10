using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App1
{
    [Activity(Label = "DBHelperclass")]
    public class DBHelperclass : SQLiteOpenHelper
    {
        Context myContex;


        public static string DBName = "myDatabse.db";
        public static string tableName = "UserTable";
        public static string nameFiled = "names";
        public static string id = "id";
        public static string email = "email";
        public static string age = "age";
        public static string pass = "password";

        //create database
        public string creatTable = "Create Table " +
            tableName + "(" + id + " Interger" + ", " + nameFiled + " Text, " + email + " Text, " +
        age + " Text, " + pass + " Text" + ");";

        SQLiteDatabase connectionObj;

        public DBHelperclass(Context context) : base(context, name: DBName, factory: null, version: 1)
        {
            myContex = context;
            connectionObj = WritableDatabase;
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            System.Console.WriteLine("My Create Table STM \n \n" + creatTable);

            db.ExecSQL(creatTable);
        }

        //insert data in database
        public void InsertValue(int id, string value_username, string value_email, string value_age, string value_pass)
        {

            string insertStm = "Insert into " +
            tableName + " values (" + id + "," + "'" + value_username + "'" + "," + "'" +
            value_email + "'" + "," + "'" +
        value_age + "'" + "," + "'" + value_pass + "'" + ");";
            Console.WriteLine(insertStm);

            System.Console.WriteLine("My SQL  Insert STM \n  \n" + insertStm);

            connectionObj.ExecSQL(insertStm);

        }

        //show data on screen
        public void SelectMydata()
        {
            String selectStm = "Select * from " + tableName;

            ICursor myresut = connectionObj.RawQuery(selectStm, null);


            //String selectStmwithId = "Select * from "+ tableName " where id="+id +"and name="+nameFiled;
            //myresut.Count >0


            while (myresut.MoveToNext())
            {

                var myId = myresut.GetInt(myresut.GetColumnIndexOrThrow(id));
                System.Console.WriteLine("ID from Database: " + myId);


                var nameValue = myresut.GetString(myresut.GetColumnIndexOrThrow(nameFiled));
                System.Console.WriteLine("Name from Database: " + nameValue);

                var emailValue = myresut.GetString(myresut.GetColumnIndexOrThrow(email));
                System.Console.WriteLine("Email from Database: " + emailValue);

                var ageValue = myresut.GetString(myresut.GetColumnIndexOrThrow(age));
                System.Console.WriteLine("Age from Database: " + ageValue);

                var passValue = myresut.GetString(myresut.GetColumnIndexOrThrow(pass));
                System.Console.WriteLine("Password from Database: " + passValue);


            }

        }

        //select data based on username and password
        public ICursor SelectUserdata(string val1, string val2)
        {
            String selectStm = "Select * from " + tableName + " where names='" + val1 + "' and password='" + val2 + "'";
            Console.WriteLine(selectStm);
            ICursor myresut1 = connectionObj.RawQuery(selectStm, null);

            return myresut1;
            //String selectStmwithId = "Select * from "+ tableName " where id="+id +"and name="+nameFiled;
            //myresut.Count >0


        }

        public ICursor SelectUserdetails(string val1)
        {
            String selectStm = "Select * from " + tableName + " where names='" + val1 + "'";
            Console.WriteLine(selectStm);
            ICursor myresut1 = connectionObj.RawQuery(selectStm, null);

            return myresut1;
            //String selectStmwithId = "Select * from "+ tableName " where id="+id +"and name="+nameFiled;
            //myresut.Count >0


        }

        public ICursor selectmovienames()
        {
            String selectStm = "Select * from " + tableName + " where id='500'";
            Console.WriteLine(selectStm);
            ICursor myresut1 = connectionObj.RawQuery(selectStm, null);

            return myresut1;
            //String selectStmwithId = "Select * from "+ tableName " where id="+id +"and name="+nameFiled;
            //myresut.Count >0


        }
        public ICursor selectwatchlaternames()
        {
            String selectStm = "Select * from " + tableName + " where id='501'";
            Console.WriteLine(selectStm);
            ICursor myresut1 = connectionObj.RawQuery(selectStm, null);

            return myresut1;
            //String selectStmwithId = "Select * from "+ tableName " where id="+id +"and name="+nameFiled;
            //myresut.Count >0


        }
        public void deletemovienames()
        {
            String selectStm = "DELETE from " + tableName + " where id='500' OR id='501'";
            Console.WriteLine(selectStm);
            connectionObj.ExecSQL(selectStm);
            //String selectStmwithId = "Select * from "+ tableName " where id="+id +"and name="+nameFiled;
            //myresut.Count >0


        }

        public void DeleteUserdata(string val1, string val2)
        {
            String selectStm = "DELETE from " + tableName + " where names='" + val1 + "' and password='" + val2 + "'";
            Console.WriteLine(selectStm);
            connectionObj.ExecSQL(selectStm);
            //ICursor myresut1 = connectionObj.RawQuery(selectStm, null);


            //String selectStmwithId = "Select * from "+ tableName " where id="+id +"and name="+nameFiled;
            //myresut.Count >0


        }


        //update user data
        public void UpdateUserdata(string val1, string val2, string val3, string val4, string val5, string val6)
        {
            String selectStm = "UPDATE " + tableName + " SET " + nameFiled + "='" + val1 + "'," + email + "='" + val2 + "'," + age + "='" + val3 + "'," + pass + "='" + val4 + "'" + " where names='" + val5 + "' and password='" + val6 + "';";
            Console.WriteLine(selectStm);

            //String selectStmwithId = "Select * from "+ tableName " where id="+id +"and name="+nameFiled;
            //myresut.Count >0
            connectionObj.ExecSQL(selectStm);

        }




        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            throw new NotImplementedException();
        }
    }


}