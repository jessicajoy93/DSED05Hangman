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
        private List<scores> myList;
        private DatabaseManager myDbManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.GameScore);

            BackToGame = FindViewById<Button>(Resource.Id.btnReturnToGame);
            BackToGame.Click += OnBackToGame_Click;

            lvHighScores = FindViewById<ListView>(Resource.Id.lvHighScores);
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

        private void OnBackToGame_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(HangmanActivity));
            this.Finish();
        }

        //Basically reload stuff when the app resumes operation after being pauused
        protected override void OnResume()
        {
            base.OnResume();
            myDbManager = new DatabaseManager();
            myList = myDbManager.ViewAll();
            lvHighScores.Adapter = new DataAdapter(this, myList);
        }
    }
}