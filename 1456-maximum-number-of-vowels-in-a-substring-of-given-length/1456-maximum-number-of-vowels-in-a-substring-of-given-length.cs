public class Solution {
    private HashSet<char> _vowel = new(){'a','e','i','o','u'};
    
    public int MaxVowels(string s, int k) {
        // initializing counters to fulfill 1st window 
        int count=s.Take(k).Count(c=>_vowel.Contains(c)), maxCount=count;
        for(int i=k;i<s.Length;i++){

            // if vowel letter, increase a counter
            if(_vowel.Contains(s[i])) count++;

            // if vowel letter from left handside we shrink the window
            // i-k => points exactly to the beginning of the window
            if(_vowel.Contains(s[i-k])) count--;

            maxCount=Math.Max(maxCount,count);
        }
        return maxCount;
    }
}