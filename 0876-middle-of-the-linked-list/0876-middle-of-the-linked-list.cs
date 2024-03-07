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
    public ListNode MiddleNode(ListNode head) {
        //check if head is null pointer to avoid exceptions
        if(head is null) return null;
        
        //fasterPtr walks twice as fast output
        ListNode output = head;
        ListNode fasterPtr = head.next;
        
        //loop through the linked list until fasterPtr becomes null-pointer
        while(fasterPtr is not null)
        {
            output = output.next;
            //check if it has become null to avoid exception (happens with even length)
            fasterPtr = fasterPtr.next;
            if(fasterPtr is not null)
                fasterPtr = fasterPtr.next;
        }
        
        return output;
    }
}