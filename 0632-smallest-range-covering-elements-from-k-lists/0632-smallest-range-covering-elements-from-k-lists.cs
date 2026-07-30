public class Solution {
    public int[] SmallestRange(IList<IList<int>> nums) {
         List<int[]> allNumbers = new List<int[]>();
        for (int i = 0; i < nums.Count; i++) {
            for (int j = 0; j < nums[i].Count; j++) {
                allNumbers.Add(new int[] { nums[i][j], i });
            }
        }

        allNumbers.Sort((a, b) => a[0] - b[0]);

        int[] result = new int[2] { allNumbers[0][0], allNumbers[allNumbers.Count - 1][0] };
        int[] count = new int[nums.Count]; 
        int uniqueListsCovered = 0;        
        int left = 0;      
        for (int right = 0; right < allNumbers.Count; right++) {
            int num = allNumbers[right][0];
            int listIndex = allNumbers[right][1];

            if (count[listIndex] == 0) {
                uniqueListsCovered++;
            }
            count[listIndex]++;

            while (uniqueListsCovered == nums.Count) {
                int currentRange = allNumbers[right][0] - allNumbers[left][0];
                int bestRange = result[1] - result[0];
                if (currentRange < bestRange) {
                    result[0] = allNumbers[left][0];
                    result[1] = allNumbers[right][0];
                }

                int leftListIndex = allNumbers[left][1];
                count[leftListIndex]--;
                if (count[leftListIndex] == 0) {
                    uniqueListsCovered--; 
                }
                left++;
            }
        }

        return result;
    }
}