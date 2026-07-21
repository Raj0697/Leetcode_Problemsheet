public class Solution {
    Dictionary<int, HashSet<string>> Possible = [];
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
        int target = LadderLength(beginWord, endWord, wordList);

        if (target == 0)
            return [];

        IList<IList<string>> curr = [[endWord]],
            next = [];
        
        for (int i = target - 1; i > 1; i--) {
            foreach (var list in curr) {
                foreach (var nextWord in Possible[i]) {
                    if (IsOffOne(list[0], nextWord)) {
                        next.Add([nextWord, ..list]);
                    }
                }
            }
            curr.Clear();
            (curr, next) = (next, curr);
        }
        foreach (var list in curr) {
            list.Insert(0, beginWord);
        }
        
        return curr;
    }

    int LadderLength(string beginWord, string endWord, IList<string> wl) {
        List<string> wordList = [..wl];
        if (!wordList.Contains(endWord))
            return 0;
        HashSet<string> currentWords = [beginWord],
            nextWords = [];
        int count = 2, i;
        wordList.Remove(beginWord);
        wordList.Remove(endWord);
        while (currentWords.Count > 0) {
            foreach (string w in currentWords) {
                if (IsOffOne(w, endWord))
                    return count;

                i = 0;
                while (i < wordList.Count) {
                    if (IsOffOne(w, wordList[i])) {
                        nextWords.Add(wordList[i]);
                        wordList.RemoveAt(i);
                    } else {
                        i++;
                    }
                }
            }
                
            Possible[count] = nextWords;
            count++;
            (currentWords, nextWords) = (nextWords, []);
        }
        return 0;
    }

    bool IsOffOne(string a, string b) {
        bool diff = false;
        for (int i = 0; i < a.Length; i++) {
            if (a[i] == b[i])
                continue;
            if (!diff)
                diff = true;
            else
                return false;
        }
        return diff;
    }
}