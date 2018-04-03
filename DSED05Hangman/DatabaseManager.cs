using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using DSED05Hangman;
using SQLite;

namespace DSED06Hangman
{
    class DatabaseManager
    {
        //https://components.xamarin.com/gettingstarted/sqlite-net 
        //https://github.com/praeclarum/sqlite-net
        //https://developer.xamarin.com/guides/cross-platform/application_fundamentals/data/part_3_using_sqlite_orm/

        //https://github.com/praeclarum/sqlite-net/blob/master/src/SQLite.cs


        //YOUR CLASS NAME MUST BE YOUR TABLE NAME
        private string tag = "aaa";
        private SQLiteConnection db;

        public DatabaseManager()
        {
            DBConnect();
        }

        private void DBConnect()
        {
            db = new SQLiteConnection(System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), "Score.sqlite3"));
        }

        //private SQLiteConnection Database()
        //{
        //    return new SQLiteConnection(dbConnection);
        //}

        public List<scores> ViewAll()
        {
            try
            {
                //SQLiteConnection db = Database();
                return db.Query<scores>("select * from scores");
            }
            catch (Exception e)
            {
                Log.Info(tag, "ERROR Did the DB move across??:" + e.Message);
                return null;
            }
        }

        public void AddItem()
        {
            Log.Info(tag,
                       "AddItem Name = " + Words.Name + " AddItem Score = " + Words.Score + " AddItem Date = " +
                       Words.CurrentTime);
            try
            {
                var AddThis = new scores
                {
                    Name = Words.Name,
                    Score = Words.Score
                };
                db.Insert(AddThis);

                Log.Info(tag, "Data Added " + AddThis);
            }
            catch (Exception e)
            {
                Log.Info(tag, "Add Error:  " + e.Message);
            }
        }


        //public void EditItem(string name, int score, int id)
        //{
        //    try
        //    {
        //        SQLiteConnection db = Database();

        //        var EditThis = new tblscores() { Name = name, Score = score, Id = id };
        //        db.Update(EditThis);

        //        //or this
        //        //db.Execute("UPDATE tblscores Set")
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Update Error: " + e.Message);
        //    }
        //}

        //public void DeleteItem(int id)
        //{
        //    try
        //    {
        //        SQLiteConnection db = Database();
        //        db.Delete<tblscores>(id);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Delete Error: " + e.Message);
        //    }
        //}
    }
}