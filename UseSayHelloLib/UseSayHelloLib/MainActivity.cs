using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Com.Example.Topcredu.Helloaar;

namespace UseSayHelloLib {
  [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
  public class MainActivity : AppCompatActivity {
    ISayHello hello;

    protected override void OnCreate(Bundle savedInstanceState) {
      base.OnCreate(savedInstanceState);
      // Set our view from the "main" layout resource
      SetContentView(Resource.Layout.activity_main);

      Button button = FindViewById<Button>(Resource.Id.button1);
      TextView textView = FindViewById<TextView>(Resource.Id.textView1);

      hello = new SayHelloImpl();
      button.Click += (sender, e) => textView.Text = hello.SayHello("홍길동");
    }
  }
}