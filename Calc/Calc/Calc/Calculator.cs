using System.ComponentModel;
using Xamarin.Forms;

namespace Calc {
  public class Calculator : INotifyPropertyChanged {
    public string Input {
      private set {
        if (input != value) {
          input = value;
          if (value != "") {
            Display = value;
          }
          Back.ChangeCanExecute();
          Operator.ChangeCanExecute();
          Digit.ChangeCanExecute();
          Equal.ChangeCanExecute();
        }
      }
      get { return input; }
    }
    public string Display {
      private set {
        if (display != value) {
          display = value;
          OnPropertyChanged("Display");
          Clear.ChangeCanExecute();
        }
      }
      get { return display; }
    }
    private string input = "";
    private string display = "";

    public bool IsNumber() {
      return input != "" && input != "." && input != "-" && input != "-.";
    }
    public double Number { get { return double.Parse(input); } }

    public string  Op  { private set; get; }  // Opertaor
    public double? Op1 { private set; get; }  // Operand 1

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
          Operator.ChangeCanExecute();
        }
      }, s => Input == "" && s == "-" || Op1 == null && IsNumber());

      Equal = new Command(() => {
        Input = calculate(Op, (double) Op1, Number).ToString();
        Op1 = null;
        Operator.ChangeCanExecute();
      }, () => Op1 != null && IsNumber() && (Number != 0 || Op != "/"));
    }
    public Command Back     { private set; get; }
    public Command Clear    { private set; get; }
    public Command Digit    { private set; get; }
    public Command Operator { private set; get; }
    public Command Equal    { private set; get; }

    private static double calculate(string op, double op1, double op2) {
      switch (op) {
        case "+": return op1 + op2;
        case "-": return op1 - op2;
        case "*": return op1 * op2;
        case "/": return op1 / op2;
      }
      return 0;
    }

    private void OnPropertyChanged(string propertyName) {
      if (PropertyChanged != null) {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
    public event PropertyChangedEventHandler PropertyChanged;
  }
}