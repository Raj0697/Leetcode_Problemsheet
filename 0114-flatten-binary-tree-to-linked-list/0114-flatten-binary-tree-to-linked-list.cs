public class Solution {
    TreeNode last = null;
    
    public void Flatten(TreeNode root) {
        if (root != null) {
            TreeNode cur = root;
        
            helper(cur);
        }     
    }
    
     public void helper(TreeNode node) {      
        if (node.right != null) {
            helper(node.right);
        }
        
        if (node.left != null) {
            helper(node.left);
        }
         
         if (last != null) {
             node.left = null;
             node.right = last;
         }
         
        last = node;
    } 
}