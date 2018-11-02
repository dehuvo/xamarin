using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Content;
using System.Collections.Generic;

namespace Android_Hello {
  [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
  public class MainActivity : AppCompatActivity {
    static readonly List<string> phoneNumbers = new List<string>();

    protected override void OnCreate(Bundle savedInstanceState) {
      base.OnCreate(savedInstanceState);
      SetContentView(Resource.Layout.activity_main);

      Button callHistoryButton = FindViewById<Button>(Resource.Id.CallHistoryButton);
      callHistoryButton.Click += (sender, e) => {
        var intent = new Intent(this, typeof(CallHistoryActivity));
        intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
        StartActivity(intent);
      };

      EditText phoneNumbertext = FindViewById<EditText>(Resource.Id.PhoneNumberText);

      Button callButton = FindViewById<Button>(Resource.Id.CallButton);
      callButton.Enabled = false;
      phoneNumbertext.TextChanged += (sender, e) => {
        callButton.Enabled = !string.IsNullOrWhiteSpace(phoneNumbertext.Text);
      };
      callHistoryButton.Enabled = false;
      callButton.Click += (sender, e) => {
        new Android.App.AlertDialog.Builder(this)
          .SetMessage("Call " + phoneNumbertext.Text + "?")
          .SetNeutralButton("Call", delegate {
            phoneNumbers.Add(phoneNumbertext.Text);
            callHistoryButton.Enabled = true;
            var callIntent = new Intent(Intent.ActionCall);
            callIntent.SetData(Android.Net.Uri.Parse("tel:" + phoneNumbertext.Text));
            StartActivity(callIntent);
          })
          .SetNegativeButton("Cancel", delegate { })
          .Show();
      };
    }
  }
}