/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public void ReorderList(ListNode head)
    {
        if (head == null)
		{
			return;
		}
        ReorderList(head.next, head);
    }
    
    private ListNode ReorderList(ListNode curr, ListNode parent)
    {
		/* Base case - reaching end of the list, returning the parent (root) node passed in */
        if (curr == null)
        {
            return parent;
        }
        
		/* Otherwise, keep traversing to the end of the list first */
        ListNode nextParent = ReorderList(curr.next, parent);
		
		/* Result is null, meaning list is already in order, so keep returning null */
        if (nextParent == null)
        {
            return null;
        }
        
		/* Unlink the current node to its original next node to avoid cycle */
        curr.next = null;
		
		/* If the resulting parent node or its next node equals the current node in the call stack,
		 * it means we have reached the middle of the list, returning null to end the traversal */
        if (curr == nextParent || curr == nextParent.next)
        {
            return null;
        }
        
		/* Otherwise, re-link the current node with the resulting parent node */
        curr.next = nextParent.next;
        nextParent.next = curr;
		
		// Return the next parent node to the previous call stack
        return curr.next;
    }
}
