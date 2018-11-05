using Android.Content;
using Android.Telephony;
using Phoneword.Droid;
using System.Linq;
using Xamarin.Forms;
using Uri = Android.Net.Uri;

[assembly: Dependency(typeof(PhoneDialer))]
namespace Phoneword.Droid {
  public class PhoneDialer : IDialer {
    public bool Dial(string number) {
      var context = MainActivity.Instance;
      if (context != null) {
        var intent = new Intent(Intent.ActionDial);
        intent.SetData(Uri.Parse("tel:" + number));
        if (IsIntentAvailable(context, intent)) {
          context.StartActivity(intent);
          return true;
        }
      }
      return false;
    }

    public static bool IsIntentAvailable(Context context, Intent intent) {
      var pm = context.PackageManager;
      return pm.QueryIntentServices(intent, 0).Union(pm.QueryIntentActivities(intent, 0)).Any() ||
             TelephonyManager.FromContext(context).PhoneType != PhoneType.None;
    }
  }
}