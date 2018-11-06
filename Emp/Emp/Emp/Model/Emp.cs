using System.Collections.Generic;

namespace Emp.Model {
  public class Emp {
    public int    Empno { get; set; }
    public string Ename { get; set; }
    public int      Sal { get; set; }
    public string   Job { get; set; }
  }

  public class EmpList {
    public List<Emp> emps { get; set; }
  }
}