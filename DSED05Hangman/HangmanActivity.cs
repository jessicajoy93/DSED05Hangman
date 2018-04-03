using System;
using System.Collections;
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
using DSED06Hangman;
using Object = Java.Lang.Object;

namespace DSED05Hangman
{
    [Activity(Label = "Hangman", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class HangmanActivity : Activity
    {
        private TextView txtName;
        private TextView txtScore;
        private Button btnHome;
        private Button btnScore;
        private Button btnNewGame;

        private TextView WordToGuess;
        private ImageView HangmanImage;
        private LinearLayout Keyboard;
        private LinearLayout Status;
        private TextView GameStatus;

        //private scores myScore;
        DatabaseManager db = new DatabaseManager();

        List<string> WordList = new List<string>();
        private string tag = "aaa";

        private Button btnA;
        private Button btnB;
        private Button btnC;
        private Button btnD;
        private Button btnE;
        private Button btnF;
        private Button btnG;
        private Button btnH;
        private Button btnI;
        private Button btnJ;
        private Button btnK;
        private Button btnL;
        private Button btnM;
        private Button btnN;
        private Button btnO;
        private Button btnP;
        private Button btnQ;
        private Button btnR;
        private Button btnS;
        private Button btnT;
        private Button btnU;
        private Button btnV;
        private Button btnW;
        private Button btnX;
        private Button btnY;
        private Button btnZ;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Hangman);
            //Words.Name = Intent.GetStringExtra("Name");
            UsersName();

            Score();

            Home();
            NewGame();
            HighScore();

            AlphabetButtons();

            LoadWordsFromFile();
            GenerateWord();
            //LoadWords();
        }

        private void UsersName()
        {
            txtName = FindViewById<TextView>(Resource.Id.lblName);
            txtName.Text = Words.Name;
        }

        private void Score()
        {
            //Score
            txtScore = FindViewById<TextView>(Resource.Id.lblScore);
            txtScore.Text = Words.Score.ToString();
        }

        #region Loads Words From File
        private void LoadWordsFromFile()
        {
            //need to tie the asset manager to these assets in this project. This method can only run under the activity as it doesn't know what Assets is otherwise, this.Assets doesn't work
            try
            {
                var assets = Assets;
                using (var sr = new StreamReader(assets.Open("words.txt")))
                {
                    while (!sr.EndOfStream)
                    {
                        var text = sr.ReadLine();
                        if (text != string.Empty && text.Length > 4) //ignore empty lines or words less than 4 letters
                        {
                            text = text.Trim();

                            //var word = text.Remove(text.IndexOf(' '));

                            //cut out the stuff you don't want
                            if (text.Contains("-"))
                            {
                                text = text.Replace("-", "");
                            }

                            text = text.Trim();

                            if (!WordList.Contains(text) && text.Length > 4)
                            {
                                WordList.Add(text);
                            }

                            Log.Info(tag, "Dictionary Loaded");


                        }
                    }
                }
            }
            catch (Exception e)
            {
                Toast.MakeText(this, "Database didn't load", ToastLength.Long).Show();
                Console.WriteLine(e);
            }
        }
        #endregion

        #region Generate Word
        private void GenerateWord()
        {
            Log.Info(tag, "Generate Word");
            Random rand = new Random();
            int count = WordList.Count;

            int RndNumber = rand.Next(1, count);

            Log.Info(tag, "RndNumber " + RndNumber);
            Words.word = WordList[RndNumber].ToUpper();
            Log.Info(tag, "Myword = " + Words.word);
            //Toast.MakeText(this, Words.word, ToastLength.Long).Show();
            LoadWord();
        }
        #endregion

        #region Load Word
        private void LoadWord()
        {

            try
            {
                // Hardcoded for testing purposes. To be commented out later.
                //var word = "awkward".ToUpper();

                char[] WordArray = new char[Words.word.Length];
                //int WordArrayLength = WordArray.Length;

                WordArray = Words.word.ToArray();
                Words.Word = WordArray;

                char[] WordGuessArray;
                string WordGuess = null;
                foreach (char letter in Words.Word)
                {
                    WordGuess += "_";
                }

                WordGuessArray = WordGuess.ToArray();
                Words.WordGuess = WordGuessArray;

                Wordtoguess();
            }
            catch (Exception e)
            {
                Toast.MakeText(this, "Database didn't load\n " + e, ToastLength.Short).Show();
            }
        }
        #endregion

        #region Alphabet Buttons
        private void AlphabetButtons()
        {
            btnA = FindViewById<Button>(Resource.Id.btnA);
            btnB = FindViewById<Button>(Resource.Id.btnB);
            btnC = FindViewById<Button>(Resource.Id.btnC);
            btnD = FindViewById<Button>(Resource.Id.btnD);
            btnE = FindViewById<Button>(Resource.Id.btnE);
            btnF = FindViewById<Button>(Resource.Id.btnF);
            btnG = FindViewById<Button>(Resource.Id.btnG);
            btnH = FindViewById<Button>(Resource.Id.btnH);
            btnI = FindViewById<Button>(Resource.Id.btnI);
            btnJ = FindViewById<Button>(Resource.Id.btnJ);
            btnK = FindViewById<Button>(Resource.Id.btnK);
            btnL = FindViewById<Button>(Resource.Id.btnL);
            btnM = FindViewById<Button>(Resource.Id.btnM);
            btnN = FindViewById<Button>(Resource.Id.btnN);
            btnO = FindViewById<Button>(Resource.Id.btnO);
            btnP = FindViewById<Button>(Resource.Id.btnP);
            btnQ = FindViewById<Button>(Resource.Id.btnQ);
            btnR = FindViewById<Button>(Resource.Id.btnR);
            btnS = FindViewById<Button>(Resource.Id.btnS);
            btnT = FindViewById<Button>(Resource.Id.btnT);
            btnU = FindViewById<Button>(Resource.Id.btnU);
            btnV = FindViewById<Button>(Resource.Id.btnV);
            btnW = FindViewById<Button>(Resource.Id.btnW);
            btnX = FindViewById<Button>(Resource.Id.btnX);
            btnY = FindViewById<Button>(Resource.Id.btnY);
            btnZ = FindViewById<Button>(Resource.Id.btnZ);

            btnA.Click += ButtonClick;
            btnB.Click += ButtonClick;
            btnC.Click += ButtonClick;
            btnD.Click += ButtonClick;
            btnE.Click += ButtonClick;
            btnF.Click += ButtonClick;
            btnG.Click += ButtonClick;
            btnH.Click += ButtonClick;
            btnI.Click += ButtonClick;
            btnJ.Click += ButtonClick;
            btnK.Click += ButtonClick;
            btnL.Click += ButtonClick;
            btnM.Click += ButtonClick;
            btnN.Click += ButtonClick;
            btnO.Click += ButtonClick;
            btnP.Click += ButtonClick;
            btnQ.Click += ButtonClick;
            btnR.Click += ButtonClick;
            btnS.Click += ButtonClick;
            btnT.Click += ButtonClick;
            btnU.Click += ButtonClick;
            btnV.Click += ButtonClick;
            btnW.Click += ButtonClick;
            btnX.Click += ButtonClick;
            btnY.Click += ButtonClick;
            btnZ.Click += ButtonClick;
        }
        #endregion

        #region Button Click (Fake Button)
        private void ButtonClick(object sender, EventArgs e)
        {
            //make a fake button
            Button fakeBtn = (Button)sender;

            if (fakeBtn.Clickable)
            {

                SearchesLetterInWord(fakeBtn);

                Wordtoguess();
                NotContainsLetter(fakeBtn);
                GameWon();

                fakeBtn.Enabled = false;
            }

        }
        #endregion

        #region Search Letter in Word
        private static void SearchesLetterInWord(Button fakeBtn)
        {
            //Converts Words.Word to a string as you can not use Contains with a char
            Words.word = new string(Words.Word);

            //searches word to check if the letter clicked is in the word
            for (int i = 0; i < Words.Word.Length; i++)
            {
                var letter = Words.Word[i];

                if (Words.word.Contains(letter))
                {
                    //finds if letter clicked is anywhere in the word
                    if (letter.ToString() == fakeBtn.Tag.ToString())
                    {
                        Words.WordGuess[i] = (char)letter;
                    }
                }


            }
        }
        #endregion

        #region Does Not Contain Letter in Word
        private void NotContainsLetter(Button fakeBtn)
        {
            if (Words.word.Contains(fakeBtn.Tag.ToString()) != true)
            {
                Words.HangmanLevel++;

                //Switch Statement to change image if letter is not in the word
                HangmanImage = FindViewById<ImageView>(Resource.Id.ivHangmanStage);
                HangmanLevels();
            }
        }
        #endregion

        #region Game Won
        private void GameWon()
        {
            //Converts Words.WordGuess to a string as you can not use Contains with a char
            Words.wordGuess = new string(Words.WordGuess);
            if (Words.wordGuess.Contains("_") != true)
            {
                //HangmanImage.SetImageResource(Resource.Drawable.stage6);
                Keyboard = FindViewById<LinearLayout>(Resource.Id.keyboard);
                Keyboard.Visibility = ViewStates.Gone;

                Status = FindViewById<LinearLayout>(Resource.Id.gameStatus);
                GameStatus = FindViewById<TextView>(Resource.Id.txtStatus);
                GameStatus.Text = "You Win!!!";
                Status.Visibility = ViewStates.Visible;

                //Add 1 to score
                Words.Score++;
                Words.HangmanLevel = 0;
                Score();
            }
        }
        #endregion

        #region Hangman Levels
        private void HangmanLevels()
        {
            switch (Words.HangmanLevel)
            {
                case 1:
                    HangmanImage.SetImageResource(Resource.Drawable.stage1);
                    break;
                case 2:
                    HangmanImage.SetImageResource(Resource.Drawable.stage2);
                    break;
                case 3:
                    HangmanImage.SetImageResource(Resource.Drawable.stage3);
                    break;
                case 4:
                    HangmanImage.SetImageResource(Resource.Drawable.stage4);
                    break;
                case 5:
                    HangmanImage.SetImageResource(Resource.Drawable.stage5);
                    break;
                case 6:
                    //display correct word
                    //Words.WordGuess = Words.Word;
                    WordToGuess = FindViewById<TextView>(Resource.Id.lblHangmanWordToGuess);
                    WordToGuess.Text = Words.word;


                    HangmanImage.SetImageResource(Resource.Drawable.stage6);
                    Keyboard = FindViewById<LinearLayout>(Resource.Id.keyboard);
                    Keyboard.Visibility = ViewStates.Gone;

                    Status = FindViewById<LinearLayout>(Resource.Id.gameStatus);
                    GameStatus = FindViewById<TextView>(Resource.Id.txtStatus);
                    GameStatus.Text = "Game Over!!!";
                    Status.Visibility = ViewStates.Visible;

                    FinalScore();

                    //Reset score to 0
                    Words.Score = 0;
                    Words.HangmanLevel = 0;
                    Score();



                    break;
            }
        }
        #endregion

        private void FinalScore()
        {
            Words.CurrentTime = DateTime.Now;
            if (Words.Score == 0)
            {
                Log.Info(tag, "You can do better than that");
            }
            else if (Words.Score > 0)
            {
                // add score to the database
                db.AddItem();
                Log.Info(tag, "Data added to Database");
            }
        }

        #region Buttons
        private void Wordtoguess()
        {
            WordToGuess = FindViewById<TextView>(Resource.Id.lblHangmanWordToGuess);
            WordToGuess.Text = new string(Words.WordGuess);
        }

        private void Home()
        {
            btnHome = FindViewById<Button>(Resource.Id.btnHome);
            btnHome.Click += OnHome_Click;
        }

        private void OnHome_Click(object sender, EventArgs e)
        {
            var homeActivityIntent = new Intent(this, typeof(MainActivity));
            Words.Name = "";
            txtName.Text = "";
            StartActivity(homeActivityIntent);
        }

        private void HighScore()
        {
            btnScore = FindViewById<Button>(Resource.Id.btnScore);
            btnScore.Click += OnHighScore_Click;
        }

        private void OnHighScore_Click(object sender, EventArgs e)
        {
            var scoreActivityIntent = new Intent(this, typeof(ScoreActivity));
            StartActivity(scoreActivityIntent);
        }

        private void NewGame()
        {
            btnNewGame = FindViewById<Button>(Resource.Id.btnNewGame);
            btnNewGame.Click += OnNewGame_Click;
        }

        private void OnNewGame_Click(object sender, EventArgs e)
        {
            var newGameActivityIntent = new Intent(this, typeof(HangmanActivity));
            StartActivity(newGameActivityIntent);
            UsersName();
        }
        #endregion
    }
}