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
    public TreeNode SortedArrayToBST(int[] nums) {
        if(nums.Length <= 0)
            return null;

        int mid = nums.Length / 2;
        var tree = new TreeNode(nums[mid]);
        tree.left = SortedArrayToBST(nums[..mid]);
        tree.right = SortedArrayToBST(nums[(mid + 1)..]);

        return tree;
    }
}