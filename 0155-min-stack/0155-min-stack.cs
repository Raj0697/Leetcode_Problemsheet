public class MinStack {
    Stack<(int val, int minVal)> stack; 
    int minVal = int.MaxValue;
    public MinStack() {
        stack = new Stack<(int, int)>();
    }
    
    public void Push(int val) {
        if(minVal > val)
        {
            minVal = val;
        }
        stack.Push((val, minVal));
    }
    
    public void Pop() {
        stack.Pop();
        if(stack.Count > 0)
        {
            minVal = stack.Peek().minVal;
        }
        else
        {
            minVal = int.MaxValue;
        }
    }
    
    public int Top() {
        return stack.Peek().val;
    }
    
    public int GetMin() {
        return stack.Peek().minVal;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */