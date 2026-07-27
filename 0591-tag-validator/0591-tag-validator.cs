using System;
using System.Collections.Generic;

public class Solution {
    public bool IsValid(string code) {
        Stack<string> stack = new Stack<string>();
        int i = 0;
        int n = code.Length;

        while (i < n) {
            if (i > 0 && stack.Count == 0) return false; // must be wrapped

            if (i + 9 < n && code.Substring(i, 9) == "<![CDATA[") {
                int j = code.IndexOf("]]>", i + 9);
                if (j < 0) return false;
                i = j + 3;
            } else if (i + 2 < n && code.Substring(i, 2) == "</") {
                int j = code.IndexOf('>', i + 2);
                if (j < 0) return false;
                string tagName = code.Substring(i + 2, j - (i + 2));
                if (!IsValidTagName(tagName)) return false;
                if (stack.Count == 0 || stack.Peek() != tagName) return false;
                stack.Pop();
                i = j + 1;
            } else if (code[i] == '<') {
                int j = code.IndexOf('>', i + 1);
                if (j < 0) return false;
                string tagName = code.Substring(i + 1, j - (i + 1));
                if (!IsValidTagName(tagName)) return false;
                stack.Push(tagName);
                i = j + 1;
            } else {
                i++;
            }
        }

        return stack.Count == 0;
    }

    private bool IsValidTagName(string name) {
        if (name.Length < 1 || name.Length > 9) return false;
        foreach (char c in name) {
            if (c < 'A' || c > 'Z') return false;
        }
        return true;
    }
}