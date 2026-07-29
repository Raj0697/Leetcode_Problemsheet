using System;
using System.Collections.Generic;

public class DinnerPlates
{
    private int capacity;
    private List<Stack<int>> stacks;
    private SortedSet<int> availableStacks;

    public DinnerPlates(int capacity)
    {
        this.capacity = capacity;
        this.stacks = new List<Stack<int>>();
        this.availableStacks = new SortedSet<int>();
    }

    public void Push(int val)
    {
        // If no available stacks, create a new one
        if (availableStacks.Count == 0){
            Stack<int> newStack = new Stack<int>();
            newStack.Push(val);
            stacks.Add(newStack);

            // If the new stack is not full, add it to available stacks
            if (newStack.Count < capacity) 
                availableStacks.Add(stacks.Count - 1);
        }
        else  {
            int index = availableStacks.Min; // Get the leftmost available stack

            // Check if the index is valid before accessing
            if (index >= 0 && index < stacks.Count){
                stacks[index].Push(val);

                // If the stack is now full, remove it from available stacks
                if (stacks[index].Count == capacity)  availableStacks.Remove(index); 
            }
            else {
                // If the index is invalid, create a new stack
                Stack<int> newStack = new Stack<int>();
                newStack.Push(val);
                stacks.Add(newStack);

                // If the new stack is not full, add it to available stacks
                if (newStack.Count < capacity) 
                    availableStacks.Add(stacks.Count - 1);
            }
        }
    }

    public int Pop()
    {
        // Remove empty stacks from the end
        while (stacks.Count > 0 && stacks[stacks.Count - 1].Count == 0){
            stacks.RemoveAt(stacks.Count - 1);
        }

        if (stacks.Count == 0) return -1;

        int val = stacks[stacks.Count - 1].Pop();

        // If the stack is not full after popping, add it to available stacks
        if (stacks[stacks.Count - 1].Count > 0) availableStacks.Add(stacks.Count - 1);
        return val;
    }

    public int PopAtStack(int index)
    {
        if (index < 0 || index >= stacks.Count || stacks[index].Count == 0)
            return -1; // Invalid stack index or empty stack

        int val = stacks[index].Pop();

        // Add this index to available stacks as it's not full now
        if (stacks[index].Count < capacity) availableStacks.Add(index);
        return val;
    }
}

/**
 * Your DinnerPlates object will be instantiated and called as such:
 * DinnerPlates obj = new DinnerPlates(capacity);
 * obj.Push(val);
 * int param_2 = obj.Pop();
 * int param_3 = obj.PopAtStack(index);
 */
