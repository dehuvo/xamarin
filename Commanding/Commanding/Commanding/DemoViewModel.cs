using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Commanding {
  public class DemoViewModel : INotifyPropertyChanged {
    bool canDownload = true;
    string simulatedDownloadResult;

    public int Number { get; set; }

    public double SquareRootResult { get; private set; }

    public double SquareRootWithParameterResult { get; private set; }

    public string SimulatedDownloadResult {
      get { return simulatedDownloadResult; }
      private set {
        if (simulatedDownloadResult != value) {
          simulatedDownloadResult = value;
          OnPropertyChanged("SimulatedDownloadResult");
        }
      }
    }

    public Command SquareRootCommand { get; private set; }

    public Command SquareRootWithParameterCommand { get; private set; }

    public Command SimulateDownloadCommand { get; private set; }

    public DemoViewModel() {
      Number = 25;
      SquareRootCommand = new Command(CalculateSquareRoot);
      SquareRootWithParameterCommand = new Command<string>(CalculateSquareRoot);
      SimulateDownloadCommand = new Command(async () => await SimulateDownloadAsync(), () => canDownload);
    }

    void CalculateSquareRoot() {
      SquareRootResult = Math.Sqrt(Number);
      OnPropertyChanged("SquareRootResult");
    }

    void CalculateSquareRoot(string value) {
      double num = Convert.ToDouble(value);
      SquareRootWithParameterResult = Math.Sqrt(num);
      OnPropertyChanged("SquareRootWithParameterResult");
    }

    async Task SimulateDownloadAsync() {
      CanInitiateNewDownload(false);
      SimulatedDownloadResult = string.Empty;
      await Task.Run(() => {
        var endTime = DateTime.Now.AddSeconds(5);
        while (DateTime.Now < endTime) ;
      });
      SimulatedDownloadResult = "Simulated download complete";
      CanInitiateNewDownload(true);
    }

    void CanInitiateNewDownload(bool value) {
      canDownload = value;
      SimulateDownloadCommand.ChangeCanExecute();
    }

    protected virtual void OnPropertyChanged(string propertyName) {
      if (PropertyChanged != null) {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
    public event PropertyChangedEventHandler PropertyChanged;
  }
}