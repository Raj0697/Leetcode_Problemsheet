public class Solution {
    public long CountSubarrays(int[] elements, int k) {
        long arrayLength = elements.Length;
        long maxElement = elements.Max();
        long leftIndex = 0, rightIndex = 0, maxElementCount = 0, subarrayCount = 0;

        while (rightIndex < arrayLength) {
            if (elements[rightIndex] == maxElement) {
                maxElementCount++;
            }
            if (maxElementCount >= k) {
                while (maxElementCount >= k) {
                    subarrayCount += arrayLength - rightIndex;
                    if (elements[leftIndex] == maxElement) {
                        maxElementCount--;
                    }
                    leftIndex++;
                }
            }
            rightIndex++;
        }
        return subarrayCount;
    }
}