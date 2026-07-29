public sealed class Solution
{
    public bool IsPossible(int[] target)
    {
        long totalSum = 0; // Initialize the total sum of the array elements
        var pq = new PriorityQueue<long, long>(Comparer<long>.Create((a, b) => b.CompareTo(a))); // Max-heap for the largest element

        // Populate the total sum and the priority queue
        foreach (var num in target)
        {
            totalSum += num; // Sum up all elements
            pq.Enqueue(num, num); // Enqueue each element into the priority queue
        }

        while (true)
        {
            long largest = pq.Dequeue(); // Get the largest element from the heap
            totalSum -= largest; // Subtract it from the total sum

            // Check if we can achieve the target condition
            if (largest == 1 || totalSum == 1)
                return true; // If largest or total sum is 1, we can construct the target

            // Check if it's impossible to reach the target
            if (largest < totalSum || totalSum == 0 || largest % totalSum == 0)
                return false; // Impossible conditions

            // Calculate the new value based on the largest and remaining sum
            long newVal = largest % totalSum; // New value to replace the largest

            // Check for edge cases
            if (newVal == 0 || newVal == largest)
                return false; // If new value is 0 or equal to largest, it's impossible

            pq.Enqueue(newVal, newVal); // Enqueue the new value back into the heap
            totalSum += newVal; // Update the total sum with the new value
        }
    }
}