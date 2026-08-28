public class Solution {
    public int CountPalindromes(string s) {
        if(s.Length < 5)
            return 0;

        // Consider a length gap
        // int[,] prevPrevCounts = new int[s.Length,3]; // ppc[i][j] is the number of palindromes of length 2j+1 you can make from the substring that starts at i with length gap-2
        // int[,] prevCounts = new int[s.Length,3];     //  pc[i][j] is the number of palindromes of length 2j+1 you can make from the substring that starts at i with length gap-1
        // int[,] curCounts = new int[s.Length,3];      //  cc[i][j] is the number of palindromes of length 2j+1 you can make from the substring that starts at i with length gap
        // Same idea but im gonna try putting it in one 3D array to avoid copying because I am still getting TLE...
        // prevPrevCount is (index + 1) % 3
        // prevCounts is (index + 2) % 3
        // curCounts is index % 3
        int[,,] counts = new int[3,s.Length,3];
        int index = 0;

        for(int gap = 0; gap < s.Length; gap++) {
            for(int i = 0; i + gap < s.Length; i++) {
                if(gap == 0)
                    counts[index%3,i,0] = 1; // You can make one palindrome of length 1 from a single character
                else {
                    // GENERAL APPROACH
                    // The number of palindrome subsequences from substrings starting at i of length gap is equal to... 
                    // The number of palindrome subsequences from substrings starting at i+1 of length gap-1 PLUS
                    // The number of palindrome subsequences from substrings starting at i of length gap-1 MINUS
                    // The number of palindrome subsequences from substrings starting at i+1 of length gap-2 
                    // If the endpoint digits are the same we also add
                    // The number of palindrome subsequences OF SHORTER LENGTH from substrings starting at i+1 of length gap-2

                    // Update length 1
                    counts[index%3,i,0] = ModuloSubtraction(ModuloAddition(counts[(index+2)%3,i+1,0], counts[(index+2)%3,i,0]), counts[(index+1)%3,i+1,0]);

                    // Update length 3
                    counts[index%3,i,1] = ModuloSubtraction(ModuloAddition(counts[(index+2)%3,i+1,1], counts[(index+2)%3,i,1]), counts[(index+1)%3,i+1,1]);
                    if(s[i] == s[i+gap])
                        counts[index%3,i,1] = ModuloAddition(counts[index%3,i,1], counts[(index+1)%3,i+1,0]);

                    // Update length 5
                    counts[index%3,i,2] = ModuloSubtraction(ModuloAddition(counts[(index+2)%3,i+1,2], counts[(index+2)%3,i,2]), counts[(index+1) % 3,i+1,2]);
                    if(s[i] == s[i+gap])
                        counts[index%3,i,2] = ModuloAddition(counts[index%3,i,2], counts[(index+1)%3,i+1,1]);
                }
            }
            index++;
        }

        // Once the loop is done curCounts[0, 2] holds the amount of subsequences of the entire string that are length 5 palindromes
        return counts[(index - 1)%3,0,2];
    }

    public int ModuloAddition(int a, int b) {
        return (a + b) >= 1000000007 ? a + b - 1000000007 : a + b;
    }

    public int ModuloSubtraction(int a, int b) {
        return (a - b) < 0 ? a - b + 1000000007 : a - b;
    }
}