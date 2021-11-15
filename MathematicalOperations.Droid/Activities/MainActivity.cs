using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using MathematicalOperations.Droid.Data;
using MathematicalOperations.Droid.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MathematicalOperations.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private static readonly List<OperationMathematical> operations = new List<OperationMathematical>();
        private readonly string[] optionsOperation = { "", "Suma", "Resta", "Multiplicación", "División", "Residuo", "Raíz cuadrada" };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Spinner spinner = FindViewById<Spinner>(Resource.Id.options_spinner);
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.options_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            Button translationHistoryButton = FindViewById<Button>(Resource.Id.btnshowhistorical);
            EditText numberOne = FindViewById<EditText>(Resource.Id.number_one);
            EditText numberTwo = FindViewById<EditText>(Resource.Id.number_two);

            translationHistoryButton.Click += (sender, e) =>
            {
                numberOne.Text = string.Empty;
                numberTwo.Text = string.Empty;
                List<string> list = new List<string>();
                operations.ForEach(operation => list.Add(operation.ToString()));
                double promedio = operations.Count == 0 ? 0 : operations.Sum(x => x.Result) / operations.Count;
                Intent intent = new Intent(this, typeof(HistoryActivity));
                intent.PutStringArrayListExtra("operations", list);
                StartActivity(intent);
            };
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            EditText numberOne = FindViewById<EditText>(Resource.Id.number_one);
            EditText numberTwo = FindViewById<EditText>(Resource.Id.number_two);
            TextView textViewResult = FindViewById<TextView>(Resource.Id.textViewResult);

            if (!string.IsNullOrEmpty(numberOne.Text)
                && !string.IsNullOrEmpty(numberTwo.Text))
            {
                double.TryParse(numberOne.Text, out double intnumberOne);
                double.TryParse(numberTwo.Text, out double intnumberTwo);


                double result = OperationHelper.Calculate(intnumberOne, intnumberTwo, e.Position);
                operations.Add(new OperationMathematical 
                {
                    NumberOne = intnumberOne, 
                    NumberTwo = intnumberTwo,
                    TypeOperation = optionsOperation[e.Position],
                    Result = result 
                });
                textViewResult.Text = result.ToString();
            }
        }
    }
}
