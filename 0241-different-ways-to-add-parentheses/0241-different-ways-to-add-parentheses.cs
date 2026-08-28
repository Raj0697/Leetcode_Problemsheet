public class Solution {
    public IList<int> DiffWaysToCompute(string expression) {
                // Dictionary to store results for subexpressions
        Dictionary<string, List<int>> dp = new Dictionary<string, List<int>>();
        
        // Helper function to evaluate expression
        List<int> EvaluateExpression(string expr)
        {
            // Check memoized results
            if (dp.ContainsKey(expr))
            {
                return dp[expr];
            }

            List<int> results = new List<int>();
            // Flag to check if there is no operator in the string, meaning it's a number
            bool isNumber = true;
            
            // Iterate through the expression to find operators
            for (int i = 0; i < expr.Length; i++)
            {
                char c = expr[i];
                if (c == '+' || c == '-' || c == '*')
                {
                    isNumber = false;
                    
                    // Divide into left and right subexpressions
                    string left = expr.Substring(0, i);
                    string right = expr.Substring(i + 1);
                    
                    // Evaluate the left and right parts
                    List<int> leftResults = EvaluateExpression(left);
                    List<int> rightResults = EvaluateExpression(right);
                    
                    // Combine the results using the current operator
                    foreach (int l in leftResults)
                    {
                        foreach (int r in rightResults)
                        {
                            if (c == '+')
                                results.Add(l + r);
                            else if (c == '-')
                                results.Add(l - r);
                            else if (c == '*')
                                results.Add(l * r);
                        }
                    }
                }
            }
            
            // If no operator was found, the whole expression is a number
            if (isNumber)
            {
                results.Add(int.Parse(expr));
            }
            
            // Memoize the results
            dp[expr] = results;
            return results;
        }
        
        // Evaluate the given expression
        return EvaluateExpression(expression);
    }
}