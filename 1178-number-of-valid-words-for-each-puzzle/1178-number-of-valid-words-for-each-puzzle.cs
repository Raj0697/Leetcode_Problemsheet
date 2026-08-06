using System;
using System.Collections.Generic;

public class Solution {
    public IList<int> FindNumOfValidWords(string[] words, string[] puzzles) {
        var wordMaskCount = new Dictionary<int, int>();
        
        // Helper to convert a string to a bitmask
        int GetBitmask(string s) {
            int mask = 0;
            foreach (var ch in s) {
                mask |= 1 << (ch - 'a');
            }
            return mask;
        }

        // Populate wordMaskCount dictionary
        foreach (var word in words) {
            int mask = GetBitmask(word);
            wordMaskCount[mask] = wordMaskCount.GetValueOrDefault(mask, 0) + 1;
        }

        var results = new List<int>();
        
        foreach (var puzzle in puzzles) {
            int puzzleMask = GetBitmask(puzzle);
            int firstCharMask = 1 << (puzzle[0] - 'a');
            int count = 0;

            // Check all subsets of puzzleMask
            for (int submask = puzzleMask; submask > 0; submask = (submask - 1) & puzzleMask) {
                if ((submask & firstCharMask) != 0 && wordMaskCount.ContainsKey(submask)) {
                    count += wordMaskCount[submask];
                }
            }

            results.Add(count);
        }
        
        return results;
    }
}