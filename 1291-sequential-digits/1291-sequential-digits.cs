public class Solution {
    public IList<int> SequentialDigits(int low, int high) {
        List<int> result = new List<int>();
        string digits = "123456789";
        int maxDigits = high.ToString().Length;

        for (int length = 2; length <= maxDigits; length++) {
            for (int i = 0; i <= digits.Length - length; i++) {
                string substring = digits.Substring(i, length);
                int num = int.Parse(substring);

                if (num >= low && num <= high) {
                    result.Add(num);
                }
            }
        }

        result.Sort();
        return result;
    }
}