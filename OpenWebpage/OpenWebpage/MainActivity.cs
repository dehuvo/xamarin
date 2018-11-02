using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Content;

namespace OpenWebpage {
  [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
  public class MainActivity : AppCompatActivity {
    protected override void OnCreate(Bundle bundle) {
      base.OnCreate(bundle);
      SetContentView(Resource.Layout.activity_main);

      FindViewById<Button>(Resource.Id.myButton).Click += (sender, e) => {
        var uri = Android.Net.Uri.Parse("http://ojc.asia");
        StartActivity(new Intent(Intent.ActionView, uri));
      };
    }
  }
}