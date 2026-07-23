/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public int CountNodes(TreeNode n)
    {
        if (n is null) return 0;
        int h = GetHeight(n, toLeft: true);
        return h == GetHeight(n, toLeft: false)
            ? (1 << h) - 1
            : 1 + CountNodes(n.left) + CountNodes(n.right);
        
        int GetHeight(TreeNode n, bool toLeft)
        {
            if (n is null) return 0;
            int res = 1;
            while ((n = toLeft ? n.left : n.right) is not null) res++;
            return res;
        }
    }
}