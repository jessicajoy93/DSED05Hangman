using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
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


        public override tblscores this[int position]
        {//return an item at this position
            get { return items[position]; }
        }

        public override int Count
        {//count how many items there are
            get { return items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            throw new NotImplementedException();
        }


        //public override View GetView(int position, View convertView, ViewGroup parent)
        //{
        //    var item = items[position];
        //    var view = convertView;
        //    if (view == null) // no view to re-use, create new
        //        view = context.LayoutInflater.Inflate(Resource.Layout., null); 
        //}





    }
}