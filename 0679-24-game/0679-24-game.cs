public class Solution {
     private const double EPS = 1e-6;

 public bool JudgePoint24(int[] cards)
 {
     var nums = new List<double>();
     foreach (int n in cards) nums.Add((double)n);
     return Dfs(nums);
 }

 private bool Dfs(List<double> nums)
 {
     if (nums.Count == 1)
     {
         return Math.Abs(nums[0] - 24.0) < EPS;
     }

     for (int i = 0; i < nums.Count; i++)
     {
         for (int j = 0; j < nums.Count; j++)
         {
             if (i == j) continue;

             var next = new List<double>();
             for (int k = 0; k < nums.Count; k++)
             {
                 if (k != i && k != j) next.Add(nums[k]);
             }

             foreach (double val in Compute(nums[i], nums[j]))
             {
                 next.Add(val);
                 if (Dfs(next)) return true;
                 next.RemoveAt(next.Count - 1);
             }
         }
     }
     return false;
 }

 private List<double> Compute(double a, double b)
 {
     var res = new List<double>();
     res.Add(a + b);
     res.Add(a - b);
     res.Add(b - a);
     res.Add(a * b);
     if (Math.Abs(b) > EPS) res.Add(a / b);
     if (Math.Abs(a) > EPS) res.Add(b / a);
     return res;
 }
}