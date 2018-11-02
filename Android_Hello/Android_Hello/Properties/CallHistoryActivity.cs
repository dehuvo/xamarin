using Android.App;
using Android.OS;
using Android.Widget;
using Android.Content;

namespace Android_Hello {
  [Activity(Label = "@string/callHistory")]
  public class CallHistoryActivity : ListActivity {
    protected override void OnCreate(Bundle savedInstanceState) {
      base.OnCreate(savedInstanceState);
      var phoneNumbers = Intent.Extras.GetStringArrayList("phone_numbers") ?? new string[0];
      ListAdapter = new ArrayAdapter<string>(this,
        Android.Resource.Layout.SimpleListItem1, phoneNumbers);
    }
  }
}