public class Solution {
    public int MinMovesToMakePalindrome(string s) {
        var arr = s.ToArray();
        int ans = 0, i = 0, j = s.Length - 1, idx = -1;
        
        while (i < j){
           var k = j;
            while (arr[k] != arr[i]){
                k--;
            }

            if (k == i){
                idx = i;
                i++;
            }
            else{
                while (k < j){
                    (arr[k], arr[k + 1]) = (arr[k + 1], arr[k]);
                    ans++;
                    k++; 
                }
                i++; j--;
            }
        }

        return ans + (idx != -1 ? (s.Length /2 - idx) : 0);
    }
}