public class Solution
{
    // Cache to store previously computed results
    private Dictionary<string, HashSet<int>> cache = new Dictionary<string, HashSet<int>>();

    // Method to solve the expression by applying the multiplication rules
    private int Solve(string s)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(s[0] - '0'); // Push the first digit onto the stack

        for (int i = 1; i < s.Length; i++)
        {
            if (char.IsDigit(s[i])) // Check if the character is a digit
            {
                if (s[i - 1] == '*') // If the previous character is '*', perform multiplication
                {
                    int x = stack.Pop();
                    stack.Push(x * (s[i] - '0'));
                }
                else // Otherwise, just push the digit onto the stack
                {
                    stack.Push(s[i] - '0');
                }
            }
        }

        int sum = 0;
        while (stack.Count > 0) // Sum all elements in the stack
        {
            sum += stack.Pop();
        }
        return sum; // Return the computed sum
    }

    // Recursive method to calculate possible results from the expression
    private HashSet<int> Help(int n, int i, int j, string s, List<int> sav)
    {
        string key = i + "-" + j; // Create a unique key for memoization
        if (cache.ContainsKey(key)) // Return cached result if available
        {
            return cache[key];
        }

        HashSet<int> save = new HashSet<int>(); // Set to store results
        if (i == j) // Base case: single digit
        {
            save.Add(s[j] - '0');
            return save;
        }

        for (int k = i + 1; k < j; k += 2) // Iterate through operators
        {
            var leftEquation = Help(n, i, k - 1, s, sav);
            var rightEquation = Help(n, k + 1, j, s, sav);
            char op = s[k]; // Get the current operator

            if (op == '+') // If the operator is '+'
            {
                foreach (var left in leftEquation)
                {
                    foreach (var right in rightEquation)
                    {
                        if (left + right <= 1000) // Check for valid results
                        {
                            save.Add(left + right);
                        }
                    }
                }
            }
            else // For multiplication
            {
                foreach (var left in leftEquation)
                {
                    foreach (var right in rightEquation)
                    {
                        if (left * right <= 1000) // Check for valid results
                        {
                            save.Add(left * right);
                        }
                    }
                }
            }
        }

        cache[key] = save; // Store computed results in the cache
        return save; // Return the results
    }

    // Main method to calculate the total score of students' answers
    public int ScoreOfStudents(string s, int[] answers) // Change from List<int> to int[]
    {
        int realAnswer = Solve(s); // Calculate the correct answer
        List<int> sav = new List<int>();
        HashSet<int> possibleAnswers = Help(s.Length, 0, s.Length - 1, s, sav);

        Dictionary<int, int> answerCount = new Dictionary<int, int>();
        foreach (var ans in answers) // Count occurrences of each answer
        {
            if (answerCount.ContainsKey(ans))
                answerCount[ans]++;
            else
                answerCount[ans] = 1;
        }

        int totalScore = 0;
        foreach (var result in possibleAnswers) // Calculate the score based on student answers
        {
            if (answerCount.TryGetValue(result, out int count))
            {
                if (result == realAnswer)
                    totalScore += count * 5; // Correct answer gets 5 points
                else
                    totalScore += count * 2; // Incorrect answer but valid gets 2 points
            }
        }

        return totalScore; // Return the total score
    }
}