using System;
using System.Collections.Generic;

public class Solution {
    public int Evaluate(string expression) {
        return Evaluate(expression, new Dictionary<string, int>());
    }

    private int Evaluate(string expression, Dictionary<string, int> outerScope) {
        // Parse the expression
        if (expression[0] != '(') {
            // If the expression is a variable or a number
            if (Char.IsDigit(expression[0]) || expression[0] == '-') {
                return int.Parse(expression);
            }
            return outerScope[expression];
        }
        
        // Remove the outer parentheses
        expression = expression.Substring(1, expression.Length - 2);
        var tokens = ParseTokens(expression);
        
        // Determine the type of expression
        var type = tokens[0];
        
        if (type == "add") {
            return Evaluate(tokens[1], new Dictionary<string, int>(outerScope)) +
                   Evaluate(tokens[2], new Dictionary<string, int>(outerScope));
        } 
        else if (type == "mult") {
            return Evaluate(tokens[1], new Dictionary<string, int>(outerScope)) *
                   Evaluate(tokens[2], new Dictionary<string, int>(outerScope));
        } 
        else if (type == "let") {
            var newScope = new Dictionary<string, int>(outerScope);
            for (int i = 1; i < tokens.Count - 1; i += 2) {
                newScope[tokens[i]] = Evaluate(tokens[i + 1], newScope);
            }
            return Evaluate(tokens[tokens.Count - 1], newScope);
        }
        
        throw new Exception("Invalid expression");
    }

    private List<string> ParseTokens(string expression) {
        var tokens = new List<string>();
        int start = 0, count = 0;
        for (int i = 0; i < expression.Length; i++) {
            if (expression[i] == ' ') {
                if (count > 0) {
                    tokens.Add(expression.Substring(start, count));
                }
                start = i + 1;
                count = 0;
            } else if (expression[i] == '(') {
                if (count > 0) {
                    tokens.Add(expression.Substring(start, count));
                }
                int j = i, balance = 0;
                do {
                    if (expression[j] == '(') balance++;
                    if (expression[j] == ')') balance--;
                    j++;
                } while (balance != 0);
                tokens.Add(expression.Substring(i, j - i));
                i = j - 1;
                start = i + 1;
                count = 0;
            } else {
                count++;
            }
        }
        if (count > 0) {
            tokens.Add(expression.Substring(start, count));
        }
        return tokens;
    }
}