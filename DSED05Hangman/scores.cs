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
using SQLite;

namespace DSED06Hangman
{
    public class scores
    {
        [PrimaryKey, AutoIncrement]  //this is really important!
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }

        //public tblscores()
        //{
        //}
    }
}