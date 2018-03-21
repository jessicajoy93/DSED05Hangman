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

namespace DSED06Hangman
{
    public class DataAdapter : BaseAdapter<tblscores>
    {
        private readonly Activity context;
        private readonly List<tblscores> items;

        public DataAdapter(Activity context, List<tblscores> items)
        {
            this.context = context;
            this.items = items;
        }


        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            throw new NotImplementedException();
        }

        public override int Count { get { return items.Count; } }

        public override tblscores this[int position]
        {
            get { throw new NotImplementedException(); }
        }


    }
}