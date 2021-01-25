using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Com.Syncfusion.Calendar;
using Android.Graphics;
using System.Globalization;
using System.Collections.Generic;
using Android.Icu.Text;
using Java.Util;

namespace CalendarXamarinAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        SfCalendar sfCalendar;
        IList<Java.Util.Calendar> visibleDates;
        TextView headerTextView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            LinearLayout mainLayout = new LinearLayout(this);
            mainLayout.Orientation = Orientation.Vertical;

            headerTextView = new TextView(this);
            headerTextView.Typeface = Typeface.Create("Roboto-Medium", TypefaceStyle.Bold);

            sfCalendar = new SfCalendar(this);
            sfCalendar.HeaderHeight = 0;
            sfCalendar.MonthChanged += SfCalendar_MonthChanged;

            mainLayout.AddView(headerTextView);
            mainLayout.AddView(sfCalendar);

            SetContentView(mainLayout);
        }

        private void SfCalendar_MonthChanged(object sender, MonthChangedEventArgs e)
        {
            visibleDates = sfCalendar.VisibleDates;
            SimpleDateFormat dateFormat = new SimpleDateFormat("MMMM, yyyy", Locale.Us);
            headerTextView.Text = dateFormat.Format(visibleDates[visibleDates.Count / 2].Time).ToUpper();
        }
    }
}