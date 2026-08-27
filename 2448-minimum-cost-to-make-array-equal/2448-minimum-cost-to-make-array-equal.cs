public class Solution {
   public long MinCost(int[] nums, int[] cost)
{
    var sortedArrays = nums.Select((num, index) => new { Num = (long)num, Cost = (long)cost[index] })
        .OrderBy(item => item.Num)
        .ToArray();


    long[] sortedNums = sortedArrays.Select(item =>item.Num).ToArray();
    long[] sortedCost = sortedArrays.Select(item =>item.Cost).ToArray();

     long[] prefixCost = new long[sortedCost.Length];
       prefixCost[0] = sortedCost[0];
for (int i = 1; i < sortedCost.Length; ++i)
    prefixCost[i] = sortedCost[i] + prefixCost[i - 1];




    long totalCost = 0;
    long DX;
    for (int i = 1; i < sortedNums.Length; i++)
    {
        DX = sortedNums[i] - sortedNums[0];
        totalCost += DX * (long)sortedCost[i];
    }
    long answer = totalCost;

    for (int i = 1; i < sortedNums.Length; i++)
    {
        DX = sortedNums[i] - sortedNums[i - 1];
            totalCost +=  prefixCost[i - 1] * DX;
            totalCost -=  (prefixCost[sortedCost.Length - 1] - prefixCost[i - 1]) * DX;
        answer = totalCost < answer ? totalCost : answer;
    }

    return answer;
}

}