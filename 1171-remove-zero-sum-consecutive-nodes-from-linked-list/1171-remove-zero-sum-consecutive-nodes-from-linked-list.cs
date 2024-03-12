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
    public ListNode RemoveZeroSumSublists(ListNode head) {
        Dictionary<int, ListNode> dict = new Dictionary<int, ListNode>();
        ListNode node = new ListNode(0, head);       
        int sum = 0;

        ListNode current = node;
        while (current is not null)
        {
            sum += current.val;
            dict[sum] = current;
            current = current.next;
        }
        
        current = node; 
        sum = 0; 
         
        while (current is not null)
        {
            sum += current.val; 
            current.next = dict[sum].next;       
            current = current.next; 
        }
    
        return node.next; 
    }
}