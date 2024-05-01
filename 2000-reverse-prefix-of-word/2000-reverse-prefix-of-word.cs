public class Solution {
    public string ReversePrefix(string word, char ch) {
                return word.IndexOf(ch) == -1 ? word : word.IndexOf(ch) == word.Length - 1 ? String.Concat(word.Reverse()) : String.Concat(word.Substring(0, word.IndexOf(ch) + 1).Reverse()) + word.Substring(word.IndexOf(ch) + 1);

    }
}