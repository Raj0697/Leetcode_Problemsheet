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
public class Solution {
    public TreeNode AddOneRow(TreeNode root, int val, int depth) {
        if (depth is 0 or 1)
        {
            return new TreeNode(val)
            {
                left = depth == 1 ? root : null,
                right = depth == 0 ? root : null
            };
        }

        if (root != null && depth >= 2)
        {
            root.left = AddOneRow(root.left, val, depth > 2 ? depth - 1 : 1);
            root.right = AddOneRow(root.right, val, depth > 2 ? depth - 1 : 0);
        }

        return root;
    }
}