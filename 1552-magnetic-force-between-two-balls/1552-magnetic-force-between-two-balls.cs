public class Solution {
    public int MaxDistance(int[] position, int m) {
        Array.Sort(position);
	int low = 1; // Min diff
	int high = position[position.Length - 1] - position[0]; // Max diff

	while(low < high)
	{
		int mid = 1 + low + (high - low)/2;
		int count = 1;

		int previous = position[0];
		for(int i = 1; i < position.Length; i++)
		{
			if(position[i] - previous >= mid)
			{
				previous = position[i];
				count++;
			}
		}

		if(count >= m)
		{
			low = mid;
		}

		else
		{
			high = mid - 1;
		}
	}

	return low;
    }
}