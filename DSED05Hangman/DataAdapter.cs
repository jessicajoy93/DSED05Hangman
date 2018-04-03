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
    public class DataAdapter : BaseAdapter<scores>
    {
        private readonly Activity context;
        private readonly List<scores> items;  //make a list of items using the scores

        public DataAdapter(Activity context, List<scores> items)
        {
            //pass that list and the context to the DA
            this.context = context;
            this.items = items;
        }


        public override scores this[int position]
        {
            //return an item at this position
            get { return items[position]; }
        }

        public override int Count
        {
            //count how many items there are
            get { return items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        //this creates the new view to be used, ie: the new custom view for each entry, if there is already a view available, it resues that. 

        //public override View GetView(int position, View convertView, ViewGroup parent)
        //{
        //    throw new NotImplementedException();
        //}

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.SimpleListItem1, null);

            //view.FindViewById<TextView>(Resource.Id.lblName).Text = item.Name;
            //view.FindViewById<TextView>(Resource.Id.lblDate).Text = item.Date.ToString();
            //view.FindViewById<TextView>(Resource.Id.lblScore).Text = item.Score.ToString();

            return view;
        }
    }
}