public class Node
{
    public Node[] next = new Node[2];
    public int minVal = int.MaxValue;
}

public class Trie
{
    Node root = new Node();

    public void CreateTree(int[] nums)
    {
        foreach (var num in nums)
        {
            var temp = root;
            for (int i = 31; i >= 0; i--)
            {
                int mask = (num >> i) & 1;
                if (temp.next[mask] == null)
                {
                    temp.next[mask] = new Node();
                }
                temp = temp.next[mask];
                temp.minVal = Math.Min(temp.minVal, num);
            }
        }
    }

    public int Query(int num, int upperLmt)
    {
        var temp = root;
        int result = 0;
        for (int i = 31; i >= 0; i--)
        {
            int bit = (num >> i) & 1;
            int opposite = bit ^ 1;

            if (temp.next[opposite] != null && temp.next[opposite].minVal <= upperLmt)
            {
                result |= 1 << i;
                temp = temp.next[opposite];
            }
            else if (temp.next[bit] != null && temp.next[bit].minVal <= upperLmt)
            {
                temp = temp.next[bit];
            }
            else
            {
                return -1;
            }
        }
        return result;
    }
}

public class Solution {
    public int[] MaximizeXor(int[] nums, int[][] queries) {
        int[] result = new int[queries.Length];
        Trie trie = new Trie();
        trie.CreateTree(nums);
        for (int i = 0; i < queries.Length; i++)
        {
            result[i] = trie.Query(queries[i][0], queries[i][1]);
        }
        return result;
    }
}