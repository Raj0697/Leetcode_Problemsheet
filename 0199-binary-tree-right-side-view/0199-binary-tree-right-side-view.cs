public class Solution {
    public IList<int> RightSideView(TreeNode root) {
        List<int> result = new List<int>();
        RightSideDFS(root, 1, result);
        return result;
    }
    
    private void RightSideDFS(TreeNode node, int depth, List<int> result) {
        if (node == null)
            return;
        if (result.Count < depth)
            result.Add(node.val);
        RightSideDFS(node.right, depth+1, result);
        RightSideDFS(node.left, depth+1, result);
    }
}