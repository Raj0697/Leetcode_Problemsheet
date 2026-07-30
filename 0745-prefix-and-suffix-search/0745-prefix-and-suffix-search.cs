public class WordFilter {
    private Dictionary<string, int> map;

    public WordFilter(string[] words) {
        map = new Dictionary<string, int>();

        for (int i = 0; i < words.Length; i++) {
            string w = words[i];
            int n = w.Length;

            // Generate all prefixes
            for (int p = 1; p <= n; p++) {
                string pref = w.Substring(0, p);

                // Generate all suffixes
                for (int s = 0; s < n; s++) {
                    string suff = w.Substring(s, n - s);

                    string key = pref + "#" + suff;
                    // Overwrite to ensure we store the largest index
                    map[key] = i;
                }
            }
        }
    }

    public int F(string pref, string suff) {
        string key = pref + "#" + suff;
        return map.ContainsKey(key) ? map[key] : -1;
    }
}