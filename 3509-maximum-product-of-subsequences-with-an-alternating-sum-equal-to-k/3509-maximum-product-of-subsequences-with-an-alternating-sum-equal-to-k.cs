using System;

public class Solution
{
    public int MaxProduct(int[] nums, int k, int limit)
    {
        int total = 0;
        bool hasZero = false;
        for (int i = 0; i < nums.Length; i++)
        {
            total += nums[i];
            hasZero |= nums[i] == 0;
        }

        if (k < -total || k > total)
            return -1;

        int positive = MaxPositiveProduct(nums, k, limit, total);
        if (positive > 0)
            return positive;

        return hasZero && CanMakeZeroProduct(nums, k, total) ? 0 : -1;
    }

    private static int MaxPositiveProduct(int[] nums, int k, int limit, int total)
    {
        byte[] possible = new byte[limit + 1];
        possible[1] = 1;

        for (int n = 0; n < nums.Length; n++)
        {
            int x = nums[n];
            if (x <= 1)
                continue;

            for (int p = limit / x; p >= 1; p--)
            {
                if (possible[p] != 0)
                    possible[p * x] = 1;
            }
        }

        int productCount = 0;
        for (int p = 1; p <= limit; p++)
            productCount += possible[p];

        int[] products = new int[productCount];
        short[] productIndex = new short[limit + 1];
        Array.Fill(productIndex, (short)-1);

        for (int p = 1, i = 0; p <= limit; p++)
        {
            if (possible[p] == 0)
                continue;

            products[i] = p;
            productIndex[p] = (short)i;
            i++;
        }

        short[] transitionSource = new short[13 * productCount];
        short[] transitionDestination = new short[13 * productCount];
        short[] transitionCount = new short[13];

        for (int x = 2; x <= 12; x++)
        {
            int write = x * productCount;
            int count = 0;

            for (int i = productCount - 1; i >= 0; i--)
            {
                int q = products[i] * x;
                if (q > limit)
                    continue;

                int j = productIndex[q];
                if (j < 0)
                    continue;

                transitionSource[write + count] = (short)i;
                transitionDestination[write + count] = (short)j;
                count++;
            }

            transitionCount[x] = (short)count;
        }

        int words = ((total << 1) + 64) >> 6;
        int offset = total;

        ulong[] odd = new ulong[productCount * words];
        ulong[] even = new ulong[productCount * words];
        ulong[] oldOdd = new ulong[words];
        ulong[] oldEven = new ulong[words];

        for (int n = 0; n < nums.Length; n++)
        {
            int x = nums[n];

            if (x == 0)
                continue;

            if (x == 1)
            {
                for (int i = 0; i < productCount; i++)
                {
                    int stateOffset = i * words;

                    Array.Copy(odd, stateOffset, oldOdd, 0, words);
                    Array.Copy(even, stateOffset, oldEven, 0, words);

                    ShiftLeftOr(odd, stateOffset, oldEven, 0, words, 1);
                    ShiftRightOr(even, stateOffset, oldOdd, 0, words, 1);
                }

                int oneIndex = productIndex[1];
                SetBit(odd, oneIndex * words, offset + 1);
                continue;
            }

            int transitionBase = x * productCount;
            int count = transitionCount[x];

            for (int t = 0; t < count; t++)
            {
                int source = transitionSource[transitionBase + t];
                int destination = transitionDestination[transitionBase + t];

                int sourceOffset = source * words;
                int destinationOffset = destination * words;

                ShiftLeftOr(
                    odd,
                    destinationOffset,
                    even,
                    sourceOffset,
                    words,
                    x);

                ShiftRightOr(
                    even,
                    destinationOffset,
                    odd,
                    sourceOffset,
                    words,
                    x);
            }

            if (x <= limit)
            {
                int startIndex = productIndex[x];
                if (startIndex >= 0)
                    SetBit(odd, startIndex * words, offset + x);
            }
        }

        int target = offset + k;
        int targetWord = target >> 6;
        ulong targetMask = 1UL << (target & 63);

        for (int i = productCount - 1; i >= 0; i--)
        {
            int stateOffset = i * words + targetWord;

            if (((odd[stateOffset] | even[stateOffset]) & targetMask) != 0)
                return products[i];
        }

        return -1;
    }

    private static bool CanMakeZeroProduct(int[] nums, int k, int total)
    {
        int words = ((total << 1) + 64) >> 6;
        int offset = total;

        ulong[] state = new ulong[words * 8];

        int noZeroOdd = 0;
        int noZeroEven = words;
        int zeroOdd = words * 2;
        int zeroEven = words * 3;

        int oldNoZeroOdd = words * 4;
        int oldNoZeroEven = words * 5;
        int oldZeroOdd = words * 6;
        int oldZeroEven = words * 7;

        for (int n = 0; n < nums.Length; n++)
        {
            int x = nums[n];

            Array.Copy(state, noZeroOdd, state, oldNoZeroOdd, words);
            Array.Copy(state, noZeroEven, state, oldNoZeroEven, words);
            Array.Copy(state, zeroOdd, state, oldZeroOdd, words);
            Array.Copy(state, zeroEven, state, oldZeroEven, words);

            if (x == 0)
            {
                for (int w = 0; w < words; w++)
                {
                    state[zeroOdd + w] |=
                        state[oldZeroEven + w] |
                        state[oldNoZeroEven + w];

                    state[zeroEven + w] |=
                        state[oldZeroOdd + w] |
                        state[oldNoZeroOdd + w];
                }

                SetBit(state, zeroOdd, offset);
                continue;
            }

            ShiftLeftOr(
                state,
                noZeroOdd,
                state,
                oldNoZeroEven,
                words,
                x);

            ShiftRightOr(
                state,
                noZeroEven,
                state,
                oldNoZeroOdd,
                words,
                x);

            SetBit(state, noZeroOdd, offset + x);

            ShiftLeftOr(
                state,
                zeroOdd,
                state,
                oldZeroEven,
                words,
                x);

            ShiftRightOr(
                state,
                zeroEven,
                state,
                oldZeroOdd,
                words,
                x);
        }

        int target = offset + k;
        int word = target >> 6;
        ulong mask = 1UL << (target & 63);

        return ((state[zeroOdd + word] | state[zeroEven + word]) & mask) != 0;
    }

    private static void SetBit(
        ulong[] bits,
        int stateOffset,
        int bit)
    {
        bits[stateOffset + (bit >> 6)] |= 1UL << (bit & 63);
    }

    private static void ShiftLeftOr(
        ulong[] destination,
        int destinationOffset,
        ulong[] source,
        int sourceOffset,
        int words,
        int shift)
    {
        int inverse = 64 - shift;

        for (int w = words - 1; w > 0; w--)
        {
            destination[destinationOffset + w] |=
                (source[sourceOffset + w] << shift) |
                (source[sourceOffset + w - 1] >> inverse);
        }

        destination[destinationOffset] |=
            source[sourceOffset] << shift;
    }

    private static void ShiftRightOr(
        ulong[] destination,
        int destinationOffset,
        ulong[] source,
        int sourceOffset,
        int words,
        int shift)
    {
        int inverse = 64 - shift;
        int last = words - 1;

        for (int w = 0; w < last; w++)
        {
            destination[destinationOffset + w] |=
                (source[sourceOffset + w] >> shift) |
                (source[sourceOffset + w + 1] << inverse);
        }

        destination[destinationOffset + last] |=
            source[sourceOffset + last] >> shift;
    }
}