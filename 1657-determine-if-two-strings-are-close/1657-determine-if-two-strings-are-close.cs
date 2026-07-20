public class Solution {
    public bool CloseStrings(string word1, string word2) {
        if (word1.Length != word2.Length) {
            return false;
        }

        int[] count1 = new int[26];
        int[] count2 = new int[26];
        HashSet<char> set1 = new HashSet<char>();
        HashSet<char> set2 = new HashSet<char>();

        for (int i = 0; i < word1.Length; i++) {
            count1[word1[i] - 'a']++;
            set1.Add(word1[i]);
        }

        for (int i = 0; i < word2.Length; i++) {
            count2[word2[i] - 'a']++;
            set2.Add(word2[i]);
        }

        Array.Sort(count1);
        Array.Sort(count2);

        return set1.SetEquals(set2) && ArraysEqual(count1, count2);
    }
    private bool ArraysEqual(int[] arr1, int[] arr2) {
        for (int i = 0; i < arr1.Length; i++) {
            if (arr1[i] != arr2[i]) {
                return false;
            }
        }
        return true;
    }
}