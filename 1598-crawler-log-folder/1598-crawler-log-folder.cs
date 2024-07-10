public class Solution {
    public int MinOperations(string[] logs) {
        Stack<string> stack = new Stack<string>();
        
        foreach (string log in logs) {
            if (log.Equals("../")) {
                if (stack.Count > 0) {
                    stack.Pop();
                }
            } else if (!log.Equals("./")) {
                stack.Push(log);
            }
        }
        
        return stack.Count;
    }
}