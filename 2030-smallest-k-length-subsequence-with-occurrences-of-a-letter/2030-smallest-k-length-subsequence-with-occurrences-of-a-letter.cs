public class Solution
{
    public string SmallestSubsequence(string st, int k, char letter, int repetition)
    {
        int n = st.Length; // Length of the input string
        Dictionary<char, int> ct = new Dictionary<char, int>(); // Character frequency map
        Dictionary<char, int> stackCnt = new Dictionary<char, int>(); // Count of characters in the stack

        // Initialize character counts and stack counts
        for (int i = 0; i < n; i++)
        {
            char currentChar = st[i];
            if (!ct.ContainsKey(currentChar))
            {
                ct[currentChar] = 0;
                stackCnt[currentChar] = 0;
            }
            ct[currentChar]++;
        }

        Stack<char> s = new Stack<char>(); // Stack to maintain the subsequence

        // Iterate through the characters in the input string
        for (int i = 0; i < n; i++)
        {
            char currentChar = st[i];
            ct[currentChar]--; // Decrease the frequency of the current character

            // Check the conditions for popping from the stack
            while (s.Count > 0 &&
                   s.Peek() > currentChar &&
                   s.Count - 1 + n - i >= k && // Ensure enough characters remain to meet length k
                   ((s.Peek() == letter) ? stackCnt[letter] - 1 + ct[letter] >= repetition : true)) // Ensure enough repetitions
            {
                stackCnt[s.Peek()]--; // Decrease count of the character being popped
                s.Pop(); // Pop the top character from the stack
            }

            // Determine whether to add the current character to the stack
            int d = (currentChar == letter) ? 0 : 1; // 0 if the current char is 'letter', otherwise 1

            // Ensure we don't exceed the allowed size of the stack
            if (s.Count < k && s.Count - stackCnt[letter] + d <= k - repetition)
            {
                s.Push(currentChar); // Add current character to the stack
                stackCnt[currentChar]++; // Increment count for the character added
            }
        }

        // Build the result string from the stack
        StringBuilder ans = new StringBuilder();

        while (s.Count > 0)
        {
            ans.Append(s.Pop()); // Append the top character to the result
        }

        // Reverse the result since characters were added in reverse order
        char[] resultArray = ans.ToString().ToCharArray();
        Array.Reverse(resultArray);
        
        return new string(resultArray); // Return the final result
    }
}