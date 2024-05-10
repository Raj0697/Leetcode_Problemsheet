public class Solution {
    public int[] KthSmallestPrimeFraction(int[] arr, int k) {
        PriorityQueue<(int,int),double> pq=new PriorityQueue<(int,int),double>(Comparer<double>.Create((a,b)=>{if(a>b) return -1; else if(b>a) return 1; else return 0;}));

      for(int i=0;i<arr.Length;i++)
      {
        for(int j=arr.Length-1;j>i;j--)
        {
            double fraction=(double)(arr[i]*1.0/arr[j]*1.0);
            pq.Enqueue((arr[i],arr[j]),fraction);

            if(pq.Count>k)
            {
               pq.Dequeue();     
            }
        }
      }
      return new int[]{pq.Peek().Item1,pq.Peek().Item2};
    }
}