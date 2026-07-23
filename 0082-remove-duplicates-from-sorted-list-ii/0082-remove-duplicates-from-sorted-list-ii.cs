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
    public ListNode DeleteDuplicates(ListNode head) {
        var dummyHead = new ListNode(0, head);
        var prev = dummyHead;
        
        while (prev != null)
        {
            // Found value that has duplicates
            if (prev.next != null && prev.next.next != null && prev.next.val == prev.next.next.val)
            {
                var duplicateValue = prev.next.val;
                while (prev.next != null && prev.next.val == duplicateValue) prev.next = prev.next.next;
            }
            else prev = prev.next;
        }

        return dummyHead.next;
    }
}