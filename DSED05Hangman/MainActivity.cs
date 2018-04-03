using System;
using System.IO;
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
            CopyTheDB();
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
            //Toast.MakeText(this, "Your name is " + txtName.Text, ToastLength.Long).Show();

            var hangmanActivityIntent = new Intent(this, typeof(HangmanActivity));
            //hangmanActivityIntent.PutExtra("Name", txtName.Text);
            Words.Name = txtName.Text;

            StartActivity(hangmanActivityIntent);
        }

        private void CopyTheDB()
        {
            // Check if your DB has already been extracted. If the file does not exist move it.
            //WARNING!!!!!!!!!!! If your DB changes from the first time you install it, ie: you change the tables, and you get errors then comment out the if wrapper so that it is FORCED TO UPDATE. Otherwise you spend hours staring at code that should run OK but the db, that you can’t see inside of on your phone, is diffferent from the db you are coding to.
            string dbName = "Score.sqlite3";
            string dbPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.ToString(), dbName);

            //if (!File.Exists(dbPath))
            //{
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
            //}
            //}
        }
    }
}

