public class RecentCounter {
    private Queue<int> _queue;
    private const int Interval = 3000;

    public RecentCounter() {
        _queue = new Queue<int>();
    }
    
    public int Ping(int t) {
        _queue.Enqueue(t);
        while (t - _queue.Peek() > Interval)
            _queue.Dequeue();
        return _queue.Count;
    }
}