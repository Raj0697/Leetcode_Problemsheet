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
    public ListNode Partition(ListNode head, int x) {
        ListNode lessHead = new ListNode(); // Head of the list for nodes less than x
        ListNode less = lessHead; // Current pointer for nodes less than x
        ListNode greaterHead = new ListNode(); // Head of the list for nodes greater than or equal to x
        ListNode greater = greaterHead; // Current pointer for nodes greater than or equal to x
        
        while (head != null) {
            if (head.val < x) {
                less.next = head;
                less = less.next;
            } else {
                greater.next = head;
                greater = greater.next;
            }
            head = head.next;
        }
        
        greater.next = null; // Set the end of greater list to null
        less.next = greaterHead.next; // Connect the less list to the greater list
        
        return lessHead.next; // The final partitioned list
    }
}