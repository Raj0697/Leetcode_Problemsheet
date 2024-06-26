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
    List<TreeNode> nodes = new List<TreeNode>();
    public TreeNode BalanceBST(TreeNode root) 
    {
        Traverse(root);
        nodes.Sort((x, y) => x.val.CompareTo(y.val));  
        return MakeBBST(nodes, 0, nodes.Count - 1);
    }
    
    private TreeNode MakeBBST(List<TreeNode> nodes, int start, int end)
    {
        if(start > end) return null;
        int mid = (start + end) / 2;
        var root = nodes[mid];
        root.left = MakeBBST(nodes, start, mid - 1);
        root.right = MakeBBST(nodes, mid + 1, end);
        return root;
    }
    
    private void Traverse(TreeNode root)
    {
        if(root == null) return;
        nodes.Add(root);
        Traverse(root.left);
        Traverse(root.right);
        root.left = null;
        root.right = null;
    }
}