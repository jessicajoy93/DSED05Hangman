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
        private string dbConnection;

        public DatabaseManager()
        {
            dbConnection = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), "Scores.db");
            SQLiteConnection db = Database();
        }

        private SQLiteConnection Database()
        {
            return new SQLiteConnection(dbConnection);
        }

        public List<tblscores> ViewAll()
        {
            try
            {
                SQLiteConnection db = Database();
                return db.Query<tblscores>("select * from tblscores");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return null;
            }
        }

        public void AddItem(string name, int score)
        {
            try
            {
                SQLiteConnection db = Database();

                var AddThis = new tblscores() { Name = name, Score = score };
                db.Insert(AddThis);
            }
            catch (Exception e)
            {
                Console.WriteLine("Add Error: " + e.Message);
            }
        }


        public void EditItem(string name, int score, int id)
        {
            try
            {
                SQLiteConnection db = Database();

                var EditThis = new tblscores() { Name = name, Score = score, Id = id };
                db.Update(EditThis);

                //or this
                //db.Execute("UPDATE tblscores Set")
            }
            catch (Exception e)
            {
                Console.WriteLine("Update Error: " + e.Message);
            }
        }

        public void DeleteItem(int id)
        {
            try
            {
                SQLiteConnection db = Database();
                db.Delete<tblscores>(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Delete Error: " + e.Message);
            }
        }
    }
}