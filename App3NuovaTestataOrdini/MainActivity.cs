using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using static Android.App.DatePickerDialog;
using Android.Content;

namespace App3NuovaTestataOrdini
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnDateSetListener
    {
        private const int DATE_DIALOG = 1;
        private int year, month, day;

       
         public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {
            this.year = year;
            this.month = month;
            this.day = dayOfMonth;
            Toast.MakeText(this, "You have selected: " + (month+1) + "/" + day + "/" + year, ToastLength.Short).Show();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            //DatePicker datePicker = FindViewById<DatePicker>(Resource.Id.datePicker);
            //Get our button from the layout resource
            //and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.btnDate);
            button.Click += delegate {
                ShowDialog(DATE_DIALOG);

                 };
          

            Button button2 = FindViewById<Button>(Resource.Id.btnConferma);
            button2.Click += Button2_Click;
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            //throw new System.NotImplementedException();
            Intent nextActivity = new Intent(this, typeof(Activity2));
            StartActivity(nextActivity);

        }

        protected override Dialog OnCreateDialog(int id)
        {
            switch (id)
            {
                case DATE_DIALOG:
                    {
                        return new DatePickerDialog(this, this, year, month, day);
                    }
                    break;
                default:
                    break;

            }
            return null;
        }




    }


}