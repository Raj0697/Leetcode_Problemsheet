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
    private int maxDepth = -1;
    private int leftmostValue = -1;
    public int FindBottomLeftValue(TreeNode root) {
        DFS(root, 0);
        return leftmostValue;
    }

    private void DFS(TreeNode node, int depth) {
        if (node == null) {
            return;
        }

        // Update leftmostValue and maxDepth when encountering a deeper level
        if (depth > maxDepth) {
            leftmostValue = node.val;
            maxDepth = depth;
        }

        // Recursive calls for left and right children
        DFS(node.left, depth + 1);
        DFS(node.right, depth + 1);
    }
}