using Foundation;
using System;
using UIKit;

namespace Hello_iOS {
  public partial class ViewController : UIViewController {
    public ViewController(IntPtr handle) : base(handle) {
    }

    public override void ViewDidLoad() {
      base.ViewDidLoad();
      CallButton.TouchUpInside += (sender, e) => {
        var url = new NSUrl("tel:" + PhoneNumberText.Text);
        if (!UIApplication.SharedApplication.OpenUrl(url)) {
          var alert = UIAlertController.Create("Not Supported",
            "Schema 'tel:' is not supported on this device", UIAlertControllerStyle.Alert);
          alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
          PresentViewController(alert, true, null);
        }
      };
    }

    public override void DidReceiveMemoryWarning() {
      base.DidReceiveMemoryWarning();
      // Release any cached data, images, etc that aren't in use.
    }
  }
}