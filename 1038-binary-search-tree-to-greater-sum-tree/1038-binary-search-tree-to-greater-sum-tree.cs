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
    private int Helper(TreeNode node, int parentSum)
        {
            if (node == null)
            {
                return parentSum;
            }

            var rightSum = Helper(node.right, parentSum);
            node.val += rightSum;
            return Helper(node.left, node.val);
        }

        public TreeNode BstToGst(TreeNode root)
        {
            Helper(root, 0);
            return root;
        }
}