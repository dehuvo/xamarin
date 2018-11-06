using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;

namespace Emp {
  public partial class MainPage : ContentPage {
    public MainPage() {
      InitializeComponent();
    }
    const string URL = "http://192.168.0.205:8080/emp/";

    private void Button1_Click(object sender, System.EventArgs e) {
      Do("all", data => {
          listView.ItemsSource = JsonConvert.DeserializeObject<List<Model.Emp>>(data);
      });
    }

    private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
      var Emp = e.SelectedItem as Model.Emp;
      Do(Emp.Empno.ToString(), async data => {
          var nextPage = new View.EmpViewPage();
          nextPage.BindingContext = JsonConvert.DeserializeObject<Model.Emp>(data);
          await Navigation.PushAsync(nextPage);
      });
    }

    private async void Do(string arg, Action<string> action) {
      activityIndicator.IsVisible = true;
      if (CrossConnectivity.Current.IsConnected) {
        var response = await new HttpClient().GetAsync(URL + arg);
        string  data = await response.Content.ReadAsStringAsync();
        if (!string.IsNullOrEmpty(data)) {
          action(data);
        }
      } else {
        await DisplayAlert("에러!", "네트워크 연결상태를 확인하세요.", "Ok");
      }
      activityIndicator.IsVisible = false;
    }
  }
}