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
    public TreeNode CanMerge(IList<TreeNode> trees) {
        var dict = new Dictionary<int, TreeNode>();
        var leaves = new HashSet<int>();

        // Build dictionary and leaf set
        foreach (var t in trees) {
            dict[t.val] = t;
            if (t.left != null) leaves.Add(t.left.val);
            if (t.right != null) leaves.Add(t.right.val);
        }

        // Find global root
        TreeNode root = null;
        foreach (var t in trees) {
            if (!leaves.Contains(t.val)) {
                root = t;
                break;
            }
        }
        if (root == null) return null;

        var used = new HashSet<int>();
        bool valid = true;

        TreeNode dfs(TreeNode node, int min, int max) {
            if (node == null) return null;
            if (node.val <= min || node.val >= max) {
                valid = false;
                return null;
            }
            // Merge if leaf matches another root
            if (node.left == null && node.right == null && dict.ContainsKey(node.val) && node != dict[node.val]) {
                node.left = dict[node.val].left;
                node.right = dict[node.val].right;
                used.Add(node.val);
            }
            node.left = dfs(node.left, min, node.val);
            node.right = dfs(node.right, node.val, max);
            return node;
        }

        dfs(root, int.MinValue, int.MaxValue);

        if (!valid) return null;
        if (used.Count != trees.Count - 1) return null;
        return root;
    }
}