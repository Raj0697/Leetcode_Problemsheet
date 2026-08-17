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
    public ListNode InsertionSortList(ListNode head) {
         ListNode dummy = new ListNode();
 ListNode curr = head;
 while (curr != null)
 {
     // At each iteration, we insert an element into the resulting list.
     ListNode prev = dummy;
     // find the position to insert the current node
     while (prev.next != null && prev.next.val <= curr.val)
     {
         prev = prev.next;
     }

     ListNode next = curr.next;
     // insert the current node to the new list
     curr.next = prev.next;
     prev.next = curr;
     // moving on to the next iteration
     curr = next;
 }

 return dummy.next;
    }
}