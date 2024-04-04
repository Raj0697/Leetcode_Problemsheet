public class Solution {
    public int MaxDepth(string s) {
        int maxDepth = 0;
	int count = 0;

	foreach(char c in s)
	{
		if(c == '(')
		{
			count++;
			maxDepth = Math.Max(maxDepth, count);
		}

		else if(c == ')')
		{
			count--;
		}
	}

	return maxDepth;
    }
}