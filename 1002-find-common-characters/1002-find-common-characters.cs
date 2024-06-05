public class Solution {
    public IList<string> CommonChars(string[] A) {
        return A
			// group chars in each word and then select all the groups across all words
            .SelectMany(a => a.GroupBy(c => c))
			// group all the groups again by char again
            .GroupBy(e => e.Key)
			// filtering out groups that don't have a count not matching the number of words
			// if count doesn't match word count that means not all the words have that specific char
            .Where(g => g.Count() == A.Length)
			// for each group we generate a char repeated to minumum of its repeat across words
			// if a word has 1 <o> and another has 2 then the min is 1 so we output only 1 <o>"
            .SelectMany(g => Enumerable.Repeat(g.Key.ToString(), g.Min(h => h.Count())))
            .ToList();
    }
}