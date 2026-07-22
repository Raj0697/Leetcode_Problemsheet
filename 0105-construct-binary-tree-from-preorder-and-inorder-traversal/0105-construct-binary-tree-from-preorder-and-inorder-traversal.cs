using System.Collections.Generic;

public class Solution {
    private int i;
    private Dictionary<int, int> inorderMap;
    
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        i = 0;
        inorderMap = new Dictionary<int, int>();
        
        for (int idx = 0; idx < inorder.Length; idx++) {
            inorderMap[inorder[idx]] = idx;
        }
        
        return Helper(preorder, 0, inorder.Length - 1);
    }
    
    private TreeNode Helper(int[] preorder, int j, int k) {
        if (j > k) {
            return null;
        }
        
        int nodeVal = preorder[i++];
        TreeNode node = new TreeNode(nodeVal);
        int idx = inorderMap[nodeVal];
        node.left = Helper(preorder, j, idx - 1);
        node.right = Helper(preorder, idx + 1, k);
        
        return node;
    }
}