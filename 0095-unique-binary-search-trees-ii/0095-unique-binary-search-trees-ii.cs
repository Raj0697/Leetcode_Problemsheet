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
    public IList<TreeNode> GenerateTrees(int n) {
        return GenerateTrees(1, n);
    }

    public IList<TreeNode> GenerateTrees(int left, int right)
    {
        var res = new List<TreeNode>();

        if(left > right)
        {
            res.Add(null);
            return res;
        }

        for(var i = left; i <= right; i++)
        {
            var leftNodes = GenerateTrees(left, i - 1);
            var rightNodes = GenerateTrees(i + 1, right);
            
            foreach(var leftNode in leftNodes)
            {
                foreach(var rightNode in rightNodes)
                {
                    var node = new TreeNode(i, leftNode, rightNode);
                    res.Add(node);
                }
            }
        }
        return res;
    }
}