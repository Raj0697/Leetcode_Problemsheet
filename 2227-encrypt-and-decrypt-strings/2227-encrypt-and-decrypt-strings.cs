public class Encrypter {
    private Dictionary<char,string> mapKeyValue = new Dictionary<char,string>();
    private Dictionary<string,int> encryptDictWords = new Dictionary<string,int>();

    public Encrypter(char[] keys, string[] values, string[] dictionary) {
        for(int i=0; i<keys.Length; i++){
            mapKeyValue.Add(keys[i],values[i]);
        }

        for(int i=0; i<dictionary.Length; i++){
            var word = dictionary[i];
            var encrypted = Encrypt(word);
            if (!encryptDictWords.TryAdd(encrypted, 1)) {
                encryptDictWords[encrypted]++;
            }
        }
    }
    
    public string Encrypt( string word1) {
        var sb = new StringBuilder();
        foreach(char c in word1){
            if(mapKeyValue.ContainsKey(c)){
                sb.Append(mapKeyValue[c]);
            }
            else {
                return "";
            }
        }
        return sb.ToString();
    }
    
    public int Decrypt(string word2) {
        if(encryptDictWords.ContainsKey(word2)){
            return encryptDictWords[word2];
        }
        return 0;
    }
}

/**
 * Your Encrypter object will be instantiated and called as such:
 * Encrypter obj = new Encrypter(keys, values, dictionary);
 * string param_1 = obj.Encrypt(word1);
 * int param_2 = obj.Decrypt(word2);
 */