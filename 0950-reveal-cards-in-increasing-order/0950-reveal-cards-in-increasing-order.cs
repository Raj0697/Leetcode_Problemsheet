public class Solution {
    public int[] DeckRevealedIncreasing(int[] deck) {
        Queue<int> queue = new Queue<int>();   
        
        Array.Sort(deck);
             
        for(int i = 0; i < deck.Length; i++)
        {
            queue.Enqueue(i);
        }
        
        int j = 0;
        int[] res = new int[deck.Length];        
        
        while(queue.Count > 0)
        {
            int idx = queue.Dequeue();
            res[idx] = deck[j++];
            
            if(queue.Count > 0)
                queue.Enqueue(queue.Dequeue());
        }
        
        return res;
    }
}