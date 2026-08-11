public class Solution {
    public int MinNumberOperations(int[] target) {
        var res = target[0];
        for(var i = 1; i < target.Length; i++){
            var cur = target[i];
            var before = target[i - 1];
            if(cur > before) res += cur - before;
        }
        return res;
    }
}