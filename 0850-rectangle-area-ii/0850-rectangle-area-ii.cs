public class Solution {
   public int RectangleArea(int[][] rectangles)
{
    int OPEN = 1, CLOSE = -1;

    int[][] events = new int[rectangles.Length * 2][];
    HashSet<int> Xvals = new HashSet<int>();

    int t = 0;

    foreach (var rec in rectangles)
    {
        if (rec[0] < rec[2] && rec[1] < rec[3])
        {
            events[t++] = new int[] { rec[1], OPEN, rec[0], rec[2] };
            events[t++] = new int[] { rec[3], CLOSE, rec[0], rec[2] };

            Xvals.Add(rec[0]);
            Xvals.Add(rec[2]);
        }
    }

    Array.Sort(events, 0, t, Comparer<int[]>.Create((a, b) => a[0].CompareTo(b[0])));

    int[] X = Xvals.ToArray();
    Array.Sort(X);

    Dictionary<int, int> Xi = new Dictionary<int, int>();
    for (int i = 0; i < X.Length; i++)
    {
        Xi[X[i]] = i;
    }

    Node active = new Node(0, X.Length - 1, X);

    long ans = 0;
    long cur_x_sum = 0;
    int cur_y = events[0][0];

    foreach (var ev in events)
    {
        if (ev == null) break;

        int y = ev[0];
        int typ = ev[1];
        int x1 = ev[2];
        int x2 = ev[3];

        ans += cur_x_sum * (y - cur_y);
        cur_x_sum = active.Update(Xi[x1], Xi[x2], typ);
        cur_y = y;
    }

    ans %= 1_000_000_007;
    return (int)ans;
}

 public class Node
 {
     int start, end;
     int[] X;
     Node left, right;
     int count;
     long total;

     public Node(int start, int end, int[] X)
     {
         this.start = start;
         this.end = end;
         this.X = X;
         left = null;
         right = null;
         count = 0;
         total = 0;
     }

     public int GetRangeMid()
     {
         return start + (end - start) / 2;
     }

     public Node GetLeft()
     {
         if (left == null)
             left = new Node(start, GetRangeMid(), X);

         return left;
     }

     public Node GetRight()
     {
         if (right == null)
             right = new Node(GetRangeMid(), end, X);

         return right;
     }

     public long Update(int i, int j, int val)
     {
         if (i >= j)
             return 0;

         if (start == i && end == j)
         {
             count += val;
         }
         else
         {
             GetLeft().Update(i, Math.Min(GetRangeMid(), j), val);
             GetRight().Update(Math.Max(GetRangeMid(), i), j, val);
         }

         if (count > 0)
         {
             total = X[end] - X[start];
         }
         else
         {
             total = (GetLeft()?.total ?? 0) + (GetRight()?.total ?? 0);
         }

         return total;
     }
 }
}