using Android.Content;
using Android.Views;
using Android.Widget;
using MathematicalOperations.Droid.Interfaces;
using System;
using System.Collections.Generic;

namespace MathematicalOperations.Droid.Adapters
{
    public class HistoryAdapter : ArrayAdapter<IMenuItemsType>
    {
        public static int typeItem = 0;
        public static int separator = 1;
        private readonly Context context;
        private readonly List<IMenuItemsType> items;
        private readonly LayoutInflater inflater;

        public HistoryAdapter(Context context, List<IMenuItemsType> items) : base(context, 0, items)
        {
            this.context = context;
            this.items = items;
            this.inflater = (LayoutInflater)this.context.GetSystemService(Context.LayoutInflaterService);
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            try
            {
                IMenuItemsType item = items[position];
                if (item.GetMenuItemsType() == typeItem)
                {
                    MenuHeaderItem _headerItem = (MenuHeaderItem)item;
                    view = inflater.Inflate(Resource.Layout.listViewHeader, null);
                    view.Clickable = false;

                    TextView headerAverage = view.FindViewById<TextView>(Resource.Id.textViewAverage);
                    TextView headerMin = view.FindViewById<TextView>(Resource.Id.textViewMin);
                    TextView headerMax = view.FindViewById<TextView>(Resource.Id.textViewMax);
                    headerAverage.Text = _headerItem.HeaderAverage;
                    headerMin.Text = _headerItem.HeaderMin;
                    headerMax.Text = _headerItem.HeaderMax;
                }
                else if (item.GetMenuItemsType() == separator)
                {
                    MenuContentItem _contentItem = (MenuContentItem)item;
                    view = inflater.Inflate(Resource.Layout.listViewContentItem, null);

                    TextView textViewFirstNumber = view.FindViewById<TextView>(Resource.Id.txtFirstNumber);
                    TextView textViewSecondNumber = view.FindViewById<TextView>(Resource.Id.txtSecondNumber);
                    TextView textViewOperation = view.FindViewById<TextView>(Resource.Id.txtOperation);
                    TextView textViewResult = view.FindViewById<TextView>(Resource.Id.txtResult);

                    textViewFirstNumber.Text = _contentItem.FirstNumber;
                    textViewSecondNumber.Text = _contentItem.SecondNumber;
                    textViewOperation.Text = _contentItem.TypeOperation;
                    textViewResult.Text = _contentItem.Result;
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(context, ex.Message, ToastLength.Long);
            }
            return view;
        }
    }
}