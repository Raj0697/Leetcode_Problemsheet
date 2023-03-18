public class BrowserHistory {
    Stack<string> history;
    Stack<string> forward;

    public BrowserHistory(string homepage) {
        history = new Stack<string>();
        forward = new Stack<string>();
        history.Push(homepage);
    }
    
    public void Visit(string url) {
        history.Push(url);
        forward.Clear();
    }
    
    public string Back(int steps) {
        for(var i = 0; i < steps; ++i){
            if(history.Count <= 1) break;
            
            forward.Push(history.Peek());
            history.Pop();
        }
        return history.Peek();
    }
    
    public string Forward(int steps) {
        for(var i = 0; i < steps; ++i){
            if(forward.Count == 0) break;
            
            history.Push(forward.Peek());
            forward.Pop();
        }
        return history.Peek();
    }
}

/**
 * Your BrowserHistory object will be instantiated and called as such:
 * BrowserHistory obj = new BrowserHistory(homepage);
 * obj.Visit(url);
 * string param_2 = obj.Back(steps);
 * string param_3 = obj.Forward(steps);
 */