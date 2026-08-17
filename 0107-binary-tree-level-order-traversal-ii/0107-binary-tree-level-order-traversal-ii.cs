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
    
        private Queue<TreeNode> queue = new Queue<TreeNode>();
    public IList<IList<int>> LevelOrderBottom(TreeNode root) {
          var results = new List<IList<int>>();
  if (root == null) return results;
  queue.Enqueue(root);

  while (queue.Count > 0)
  {
      var result = new List<int>();

      var levelSize = queue.Count;
      for (int i = 0; i < levelSize; i++)
      {
          var node = queue.Dequeue();
          result.Add(node.val);
          if (node.left != null)
              queue.Enqueue(node.left);
          if (node.right != null)
              queue.Enqueue(node.right);
      }

      results.Add(result);
  }

  results.Reverse();
  return results;
    }
}