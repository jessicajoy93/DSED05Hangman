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

namespace DSED05Hangman
{
    class Words
    {
        public static char[] Word { get; set; }
        public static char[] WordGuess { get; set; }
        public static int Score { get; set; } = 0;
        public static int HangmanLevel { get; set; } = 0;
        public static string word { get; set; }
        public static string wordGuess { get; set; }
        public static string Name { get; set; }
        public static DateTime CurrentTime { get; set; }
    }
}