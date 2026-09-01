public class Solution {
    public int LongestValidSubstring(string word, IList<string> forbidden) {
        var s = new HashSet<char>();

        // Loop to traverse the string and add characters to the set
        foreach (char c in word) {
            s.Add(c);
        }

        // If the set only contains one character and the word length is greater than 1000, return the word length
        if (s.Count == 1 && word.Length > 1000) {
            return word.Length;
        }

        int n = word.Length;
        var automaton = new AhoCorasickAutomaton(forbidden);
        var lastOccurrence = new int[n];
        Array.Fill(lastOccurrence, -1);
        
        var node = automaton.Root;

        // Traverse the word to build the last occurrences of forbidden substrings
        for (int i = 0; i < n; i++) {
            while (node != null && !node.Children.ContainsKey(word[i])) {
                node = node.Fail;
            }
            node = node?.Children.ContainsKey(word[i]) == true ? node.Children[word[i]] : automaton.Root;

            var temp = node;
            while (temp != null && temp != automaton.Root) {
                if (temp.End) {
                    lastOccurrence[i] = Math.Max(lastOccurrence[i], i - temp.Length + 1);
                }
                temp = temp.Fail;
            }
        }

        int maxLen = 0;
        int start = 0;

        // Calculate the maximum valid substring length
        for (int end = 0; end < n; end++) {
            while (start <= lastOccurrence[end]) {
                start++;
            }
            maxLen = Math.Max(maxLen, end - start + 1);
        }

        return maxLen;
    }
}

public class TrieNode {
    public Dictionary<char, TrieNode> Children { get; set; } = new Dictionary<char, TrieNode>();
    public TrieNode Fail { get; set; }
    public bool End { get; set; }
    public int Length { get; set; }
}

public class AhoCorasickAutomaton {
    public TrieNode Root { get; set; }

    public AhoCorasickAutomaton(IList<string> forbidden) {
        Root = new TrieNode();
        BuildTrie(forbidden);
        BuildFailureFunction();
    }

    // Build the Trie for forbidden words
    private void BuildTrie(IList<string> forbidden) {
        foreach (var word in forbidden) {
            var node = Root;
            foreach (var c in word) {
                if (!node.Children.ContainsKey(c)) {
                    node.Children[c] = new TrieNode();
                }
                node = node.Children[c];
            }
            node.End = true;
            node.Length = word.Length;
        }
    }

    // Build the failure function for the Trie
    private void BuildFailureFunction() {
        var queue = new Queue<TrieNode>();
        queue.Enqueue(Root);

        while (queue.Count > 0) {
            var node = queue.Dequeue();
            foreach (var child in node.Children) {
                // If it's the root, fail goes to root
                if (node == Root) {
                    child.Value.Fail = Root;
                } else {
                    var fail = node.Fail;
                    while (fail != null) {
                        if (fail.Children.ContainsKey(child.Key)) {
                            child.Value.Fail = fail.Children[child.Key];
                            break;
                        }
                        fail = fail.Fail;
                    }
                    if (fail == null) {
                        child.Value.Fail = Root;
                    }
                }
                queue.Enqueue(child.Value);
            }
        }
    }
}