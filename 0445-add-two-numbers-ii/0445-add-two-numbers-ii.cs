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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var stack1 = new Stack<int>();
var stack2 = new Stack<int>();
while (l1 != null)
{
    stack1.Push(l1.val);
    l1 = l1.next;
}
while (l2 != null)
{
    stack2.Push(l2.val);
    l2 = l2.next;
}

var sum = 0;
ListNode current = null;
while (stack1.Count > 0 || stack2.Count > 0 || sum > 0)
{
    if (stack1.Count > 0)
        sum += stack1.Pop();
    if (stack2.Count > 0)
        sum += stack2.Pop();

    var newNode = new ListNode(sum % 10, current);
    current = newNode;
    sum /= 10;
}

return current;
    }
}