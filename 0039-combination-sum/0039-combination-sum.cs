public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        IList<IList<int>> result = new List<IList<int>>();

        //Sorting is to reduce the number of recursions.
        Array.Sort(candidates);
        BackTrackCombiSum(candidates, target, 0, new List<int>(), result);

        return result;
    }

    private void BackTrackCombiSum(int[] candidates, int target, int idx
        , List<int> temp, IList<IList<int>> result)
    {
        if (target == 0)
        {
            result.Add(temp.ToList());
            return;
        }
        else
        {
            while (idx < candidates.Length)
            {
                if (candidates[idx] > target)
                {
                    break;
                }

                temp.Add(candidates[idx]);
                BackTrackCombiSum(candidates, target - candidates[idx], idx, temp, result);
                temp.RemoveAt(temp.Count - 1);

                idx++;
            }
        }
    }
}