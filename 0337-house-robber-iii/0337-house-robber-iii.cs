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
    public int Rob(TreeNode root) {
       var res = DFS(root);
       return Math.Max(res.rob, res.skip);
    }

    private (int rob, int skip) DFS(TreeNode node){
        if(node == null) return (0, 0);

        var left = DFS(node.left);
        var right = DFS(node.right);

        int rob = node.val + left.skip + right.skip;
        int skip = Math.Max(left.rob, left.skip) + Math.Max(right.rob, right.skip);

        return (rob, skip);
    }
}