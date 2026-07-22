public class Solution {
    private static Dictionary<string, Func<int, int, int>> s_Funcs = new () {
      { "+", (a, b) => a + b },
      { "-", (a, b) => b - a },
      { "*", (a, b) => a * b },
      { "/", (a, b) => b / a },   
    };

    public int EvalRPN(string[] tokens) {
      Stack<int> data = new ();
        
      foreach (string token in tokens) 
        if (int.TryParse(token, out int value))
          data.Push(value);
        else   
          data.Push(s_Funcs[token](data.Pop(), data.Pop()));
        
      return data.Pop();
    }
}