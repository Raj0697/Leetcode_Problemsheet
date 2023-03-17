public class Trie {

    private class TrieNode
    {
        public char Key { get; set; }
        public bool IsEndOfWord { get; set; }
        public Dictionary<char, TrieNode> Children { get; set; }

        public TrieNode(char key)
        {
            Key = key;
            Children = new Dictionary<char, TrieNode>();
        }
    }

    private TrieNode root;

    public Trie()
    {
        root = new TrieNode('*');
    }

    public void Insert(string word)
    {
        var current = root;
        foreach (var c in word)
        {
            if (!current.Children.TryGetValue(c, out var childNode))
                current.Children[c] = childNode = new TrieNode(c);
            current = childNode;
        }
        current.IsEndOfWord = true;
    }

    public bool Search(string word)
    {
        var current = root;
        foreach (var c in word)
        {
            if (!current.Children.TryGetValue(c, out var childNode))
                return false;
            current = childNode;
        }
        return current.IsEndOfWord;
    }

    public bool StartsWith(string prefix)
    {
        var current = root;
        foreach (var c in prefix)
        {
            if (!current.Children.TryGetValue(c, out var child))
                return false;
            current = child;
        }
        return true;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */