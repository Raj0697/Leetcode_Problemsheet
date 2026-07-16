public class Solution {
    public string GetPermutation(int n, int k) {
        List<int> numbers = new List<int>();
        int[] factorial = new int[n + 1];
        StringBuilder sb = new StringBuilder();
        int sum = 1;
        factorial[0] = 1;
        for (int i = 1; i <= n; i++) {
            numbers.Add(i);
            sum *= i;
            factorial[i] = sum;
        }
        k--;
        for (int i = 1; i <= n; i++) {
            int groupSize = factorial[n - i];
            int index = k / groupSize;
            sb.Append(numbers[index]);
            numbers.RemoveAt(index);
            k %= groupSize;
        }

        return sb.ToString();
    }
}