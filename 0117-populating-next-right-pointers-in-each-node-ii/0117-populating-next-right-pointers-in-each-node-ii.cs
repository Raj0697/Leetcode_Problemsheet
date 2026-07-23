/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution
{
	Dictionary<int, Node> dict = new Dictionary<int, Node>();

	public Node Connect(Node root)
	{
		Build(root, 0);

		return root;
	}

	private void Build(Node node, int level)
	{
		if (node == null)
			return;

		if (!dict.ContainsKey(level))
			dict.Add(level, node);
		else
		{
			dict[level].next = node;
			dict[level] = node;
		}

		Build(node.left, level + 1);
		Build(node.right, level + 1);
	}
}