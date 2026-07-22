/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node CopyRandomList(Node head) {
        if (head == null)
            return null;
         var tracking = new Dictionary<Node, Node>();
        Node cur = head;
        // Copy node without next and random
        while (cur != null)
        {
            tracking.Add(cur, new Node(cur.val));
            cur = cur.next;
        }

        cur = head;
        // Connect all node
        while (cur != null)
        {
            tracking[cur].next = cur.next != null ? tracking[cur.next] : null;
            tracking[cur].random = cur.random != null ? tracking[cur.random] : null;
            cur = cur.next;
        }

        return tracking[head];
    }
}