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
    public TreeNode DeleteNode(TreeNode root, int key) {
        if(root == null)
        {
            return null;
        }

        if(root.val<key)
        {
            root.right = DeleteNode(root.right, key);
        }
        else if(root.val>key)
        {
            root.left = DeleteNode(root.left, key);
        }
        else
        {
            if(root.left == null && root.right==null)
            {
                return null;
            }
            else if(root.left == null)
            {
                return root.right;
            }
            else if(root.right == null)
            {
                return root.left;
            }
            else
            {
                var temp = root.right;
                while(temp.left!=null)
                {
                    temp = temp.left;
                }

                root.val = temp.val;
                root.right = DeleteNode(root.right, temp.val);
            }
        }

        return root;
    }
}