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
    public ListNode DeleteDuplicates(ListNode head)
    {
        ListNode n = head;

        while (n is not null)
        {
            while (n.val == n.next?.val)
            {
                n.next = n.next.next;
            }
            n = n.next;
        }

        return head;
    }
}