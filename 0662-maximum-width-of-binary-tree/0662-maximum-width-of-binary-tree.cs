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
    public int WidthOfBinaryTree(TreeNode root) {
        var set = new Dictionary<int, int>();
        return DFS(root, 1, 0, set);
    }

    public int DFS(TreeNode node, int index, int level, Dictionary<int, int> set) {
        if (node == null) return 0;

        if (!set.ContainsKey(level)) {
            set[level] = index;
        }

        int cur = index - set[level] + 1;

        int left = DFS(node.left, index*2-1, level+1, set);
        int right = DFS(node.right, index*2, level+1, set);

        return Math.Max(cur, Math.Max(left, right));
    }
}