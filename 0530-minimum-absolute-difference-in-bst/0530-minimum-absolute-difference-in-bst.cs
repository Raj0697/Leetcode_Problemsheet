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
    int previousNodeValue= -1; 
    int minResult= 100001;
    public int GetMinimumDifference(TreeNode root) {
        Rec(root);
        return minResult;
    }

    // using Inorder traversal to solve the qustion
    public void Rec(TreeNode node) {
      
       if(node == null)
       return;

        // lift node first
        Rec( node.left);

        //check node value
        if(previousNodeValue != -1)
        {
            minResult= Math.Min(minResult,Math.Abs(previousNodeValue-node.val));
        }
        previousNodeValue = node.val;

        //then right node 
        Rec( node.right);
    }
}