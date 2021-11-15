using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using MathematicalOperations.Droid.Adapters;
using MathematicalOperations.Droid.Data;
using MathematicalOperations.Droid.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MathematicalOperations.Droid
{
    [Activity(Label = "HistoryActivity")]
    public class HistoryActivity:Activity
    {
        List<IMenuItemsType> itemMenu = new List<IMenuItemsType>();
        private ListView listView;
        private HistoryAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout_list);

            var operations = Intent.Extras.GetStringArrayList("operations") ?? new string[0];
            List<MenuContentItem> menuContentItems = new List<MenuContentItem>();

            foreach (string item in operations)
            {
                string[] elements = item.Split(",");
                menuContentItems.Add(new MenuContentItem(elements[0], elements[1], elements[2], elements[3]));
            }
            if (operations.Any())
            {
                var itemsResult = menuContentItems.Select(item => double.Parse(item.Result));
                double sum = itemsResult.Sum();
                double average = menuContentItems.Count == 0 ? 0 : sum / menuContentItems.Count;
                var min = itemsResult.Min();
                var max = itemsResult.Max();
                itemMenu.Add(new MenuHeaderItem(average.ToString("N2"), min.ToString(), max.ToString()));
                itemMenu.AddRange(menuContentItems);
            }
            else
            {
                string emptyValue = "0";
                itemMenu.Add(new MenuHeaderItem(emptyValue, emptyValue, emptyValue));
            }

            listView = FindViewById<ListView>(Resource.Id.listViewHistory);
            adapter = new HistoryAdapter(this, itemMenu);
            listView.Adapter = adapter;
        }
	}
}