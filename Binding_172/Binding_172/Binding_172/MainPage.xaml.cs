using Xamarin.Forms;

namespace Binding_172 {
  public partial class MainPage : ContentPage {
    public MainPage() {
      InitializeComponent();
      listView.ItemSelected += async (sender, e) => {
        if (e.SelectedItem != null) {
          await Navigation.PushAsync(new NextPage {
            BindingContext = e.SelectedItem as Emp
          });
        }
      };
    }
  }
}