using System.Collections.Generic;

namespace Binding_169 {
  public class Emp {
    public int    Empno { get; set; }
    public string Ename { get; set; }

    public static List<Emp> Emps { get; set; }

    static Emp() {
      Emps = new List<Emp> {
        new Emp() { Empno = 1, Ename = "홍길동" },
        new Emp() { Empno = 2, Ename = "박길동" },
        new Emp() { Empno = 3, Ename = "정길동" },
        new Emp() { Empno = 4, Ename = "나길동" },
        new Emp() { Empno = 5, Ename = "김길동" }
      };
    }

    public override string ToString() {
      return string.Format("Empno : {0}, Ename : {1}", Empno, Ename);
    }
  }
}