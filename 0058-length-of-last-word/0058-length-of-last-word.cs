public class Solution {
    public int LengthOfLastWord(string s) {
        s = s.TrimEnd();                 //or you can use Trim()
        string[] tmp = s.Split(' ');
        return tmp[tmp.Length-1].Length;
    }
}