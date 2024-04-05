public class Solution {
    public string MakeGood(string s) {
        Stack<char> stack = new Stack<char>();
        
        foreach (char c in s) {
            if (stack.Count > 0 && Math.Abs(c - stack.Peek()) == 32) {
                stack.Pop();
            } else {
                stack.Push(c);
            }
        }
        
        char[] resultChars = stack.ToArray();
        Array.Reverse(resultChars);
        
        return new string(resultChars);
    }
}