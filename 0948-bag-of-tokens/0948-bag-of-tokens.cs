public class Solution {
    public int BagOfTokensScore(int[] tokens, int power) {
        int n = tokens.Length;
        Array.Sort(tokens);
        int fup = 0, fdown = n - 1;
        int bag = 0;
        while(fup <= fdown) {
            if(power >= tokens[fup]) {
                power -= tokens[fup++];
                bag++;
            } else {
                if(bag == 0 || fup == fdown)
                    break;
                power += tokens[fdown--];
                bag--;
            }
        }
        return bag;
    }
}