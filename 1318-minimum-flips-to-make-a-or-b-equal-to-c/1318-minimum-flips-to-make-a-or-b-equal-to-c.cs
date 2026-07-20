public class Solution {
    public int MinFlips(int a, int b, int c) {
        int flips = 0;
        int or = a | b;
        //xor'ing will tell us places where 
        //  1) c is on but neither a or b is
        //  2) c is off but a or b or both is on
        int xor = c ^ or;
        //at least one bit needs flipped for each bit that is on
        flips = this.BitCount(xor);
        //now we just need to count once more
        //the places where both a and b need flipped
        int dblcount = xor & a & b;
        flips += this.BitCount(dblcount);

        return flips;
    }

    public int BitCount(int x) {
        /*
        Brian Kernighan’s Algorithm
        ---------------------------
        Relies on the following observation about what happens 
        when you subtract 1 from a number in binary.
        E.g.
        52: 0011 0100
        51: 0011 0011

        Notice we could describe subtracting 1 in the 
        following way:
        Find the first bit from the right that is set (==1).
        That bit and all the bits to its right will flip.
        Any set bits to the left stay.

        Now, if we AND those two numbers (x AND x-1) together 
        we are left with
        0011 0000

        So we went from 3 set bits to 2. 
        If we repeat this procedure and count how many times we 
        do it before we reach zero, we will have our answer.
        */
        int count = 0;
        while (x > 0){
            count++;
            x &= (x - 1);
        }
        return count;
    }
}