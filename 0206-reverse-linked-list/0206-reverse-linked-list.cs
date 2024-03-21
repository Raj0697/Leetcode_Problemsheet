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
    public ListNode ReverseList(ListNode head) {
        ListNode resultNode = null;
    while(head != null)
    {
        resultNode = new ListNode(head.val, resultNode);
        head = head.next;
    }
    return resultNode;
    }
}