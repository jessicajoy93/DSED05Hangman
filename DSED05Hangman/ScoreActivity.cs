using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Views;
using DSED06Hangman;

namespace DSED05Hangman
{
    [Activity(Label = "Hangman", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ScoreActivity : Activity
    {
        private Button BackToGame;

        private ListView lvHighScores;
        private List<tblscores> myList;
        private DatabaseManager myDbManager;
        private static string dbName = "tblscores.db";
        string dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.GameScore);

            BackToGame = FindViewById<Button>(Resource.Id.btnReturnToGame);
            BackToGame.Click += OnBackToGame_Click;

            lvHighScores = FindViewById<ListView>(Resource.Id.lvHighScores);
            CopyTheDB();
            myDbManager = new DatabaseManager();
            myList = myDbManager.ViewAll();
            lvHighScores.Adapter = new DataAdapter(this, myList);
            lvHighScores.ItemClick += OnLvHighScores_Click;

        }

        private void OnLvHighScores_Click(object sender, AdapterView.ItemClickEventArgs e)
        {
            var Score = myList[e.Position];
            var EditScore = new Intent(this, typeof(ScoreEditItemActivity));
            EditScore.PutExtra("Name", Score.Name);
            EditScore.PutExtra("Score", Score.Score);
            EditScore.PutExtra("Id", Score.Id);
            StartActivity(EditScore);
        }

        private void CopyTheDB()
        {
            // Check if your DB has already been extracted. If the file does not exist move it.
            //WARNING!!!!!!!!!!! If your DB changes from the first time you install it, ie: you change the tables, and you get errors then comment out the if wrapper so that it is FORCED TO UPDATE. Otherwise you spend hours staring at code that should run OK but the db, that you can’t see inside of on your phone, is diffferent from the db you are coding to.

            if (!File.Exists(dbPath))
            {
                using (BinaryReader br = new BinaryReader(Assets.Open(dbName)))
                {
                    using (BinaryWriter bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int len = 0;
                        while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, len);
                        }
                    }
                }
            }
        }

        private void OnBackToGame_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(HangmanActivity));
            this.Finish();
        }
    }
}