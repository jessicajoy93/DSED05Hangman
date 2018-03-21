using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace DSED05Hangman
{
    [Activity(Label = "Hangman", MainLauncher = true, Icon = "@drawable/stage6", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        public static Button btnPlay;
        private TextView txtName;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            StartUp();
        }

        private void StartUp()
        {
            txtName = FindViewById<TextView>(Resource.Id.etName);
            btnPlay = FindViewById<Button>(Resource.Id.btnPlay);
            btnPlay.Click += OnPlay_Click;
        }

        private void OnPlay_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Your name is " + txtName.Text, ToastLength.Long).Show();

            var hangmanActivityIntent = new Intent(this, typeof(HangmanActivity));
            hangmanActivityIntent.PutExtra("Name", txtName.Text);

            StartActivity(hangmanActivityIntent);
        }
    }
}

