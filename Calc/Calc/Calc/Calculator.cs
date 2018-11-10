using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Calc {
  public class Calculator : INotifyPropertyChanged {
    public string Display {
      private set {
        if (display != value) {
          display = value;
          OnPropertyChanged();
          Clear.ChangeCanExecute();
        }
      }
      get { return display; }
    }
    private string Input {
      set {
        if (input != value) {
          input = value;
          if (value != "") {
            Display = value;
          }
          Back.ChangeCanExecute();
          Digit.ChangeCanExecute();
          Operator.ChangeCanExecute();
          Equal.ChangeCanExecute();
        }
      }
      get { return input; }
    }
    private string  display = "";
    private string  input = "";

    private bool IsNumber {
      get {
        return input != "" && input != "." && input != "-" && input != "-.";
      }
    }
    private double Number { get { return double.Parse(input); } }

    private double? Op1;  // Operand 1
    private string  Op;   // Opertaor

    private double calculate(double a, double b) {
      switch (Op) {
        case "+": return a + b;
        case "-": return a - b;
        case "*": return a * b;
        case "/": return a / b;
      }
      return 0;
    }

    public Calculator() {
      Back = new Command(() => {
        int length = Input.Length - 1;
        if (0 < length) {
          Input = Input.Substring(0, length);
        } else {
          Input = Display = "";
        }
      }, () => Input != "");

      Clear = new Command(() => {
        Input = Display = "";
        Op1 = null;
      }, () => Display != "");

      Digit = new Command<string>(s => {
        Input += s;
      }, s => Input.IndexOf('.') < 0 || s != ".");

      Operator = new Command<string>(s => {
        if (Input == "") {
          Input = s;
        } else {
          Op = s;
          Op1 = Number;
          Input = "";
        }
      }, s => Input == "" && s == "-" || Op1 == null && IsNumber);

      Equal = new Command(() => {
        double result = calculate((double) Op1, Number);
        Op1 = null;
        input = "";
        Input = result.ToString();
      }, () => Op1 != null && IsNumber && (Number != 0 || Op != "/"));
    }
    public Command Back     { private set; get; }
    public Command Clear    { private set; get; }
    public Command Digit    { private set; get; }
    public Command Operator { private set; get; }
    public Command Equal    { private set; get; }

    private void OnPropertyChanged([CallerMemberName] string name = null) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    public event PropertyChangedEventHandler PropertyChanged;
  }
}