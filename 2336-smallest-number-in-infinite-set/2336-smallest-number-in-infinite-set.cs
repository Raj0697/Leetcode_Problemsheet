public class SmallestInfiniteSet {

    PriorityQueue<int, int> pq;
    public SmallestInfiniteSet() {
        pq = new PriorityQueue<int, int>(Enumerable.Range(1, 1000).Select(x => (x, x)));
    }
    
    public int PopSmallest() {
        int smallest = pq.Dequeue();
        while (pq.Count > 0 && pq.Peek() == smallest)
            pq.Dequeue();

        return smallest;
    }
    
    public void AddBack(int num) {
        pq.Enqueue(num, num);
    }
}

/**
 * Your SmallestInfiniteSet object will be instantiated and called as such:
 * SmallestInfiniteSet obj = new SmallestInfiniteSet();
 * int param_1 = obj.PopSmallest();
 * obj.AddBack(num);
 */