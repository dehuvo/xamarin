using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Binding_159.ViewModel {
 public class EmpViewModel : INotifyPropertyChanged {
    public string Ename { get; set; }

    public string Message {
      private set {
        message = value;
        OnPropertyChanged();
      }
      get { return message; }
    }
    private string message;

    public Command Introduce {
      get { return new Command(() => { Message = "My name is " + Ename; }); }
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public event PropertyChangedEventHandler PropertyChanged;
  }
}