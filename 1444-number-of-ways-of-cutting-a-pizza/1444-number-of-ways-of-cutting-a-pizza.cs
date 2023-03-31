public class Solution {
    public int Ways(string[] pizza, int k)
{
	int[,,] d = new int[pizza.Length, pizza[0].Length, k]; 
	for(int i = 0; i < pizza.Length; i++)
	{
		for (int j = 0; j < pizza[i].Length; j++)
		{
			for (int m = 0; m < k; m++)
			{
				d[i, j, m] = -1;
			}
		}
	}
	int[,] suffixApplesSum = new int[pizza.Length + 1, pizza[0].Length + 1];

	for (int r = pizza.Length - 1; r >= 0; r--)
	{
		for (int c = pizza[r].Length - 1; c >= 0; c--)
		{
			if (pizza[r][c] == 'A')
			{
				suffixApplesSum[r, c]++;
			}

			suffixApplesSum[r, c] += suffixApplesSum[r, c + 1];
			suffixApplesSum[r, c] += suffixApplesSum[r + 1, c];
			suffixApplesSum[r, c] -= suffixApplesSum[r + 1, c + 1];
		}
	}

	int result = solve(0, 0, k - 1, suffixApplesSum, d);
	return result;
}

private int solve(int row, int column, int cutsLeft, int[,] suffixApplesSum, int[,,] d)
{
	int MOD = (int)1E9 + 7;

	// No Apples left, so invalid
	if (suffixApplesSum[row, column] == 0)
	{
		return 0;
	}

	// valid after k - 1 cuts
	if (cutsLeft == 0)
	{
		return 1;
	}

	if (d[row, column, cutsLeft] != -1)
	{
		return d[row, column, cutsLeft];
	}

	long ways = 0;

	// Horizontal cuts
	for (int r = row + 1; r < suffixApplesSum.GetLength(0); r++)
	{
		// There should be atleast one apple in range [r to row, column to column]
		if (suffixApplesSum[row, column] - suffixApplesSum[r, column] > 0)
		{
			ways += solve(r, column, cutsLeft - 1, suffixApplesSum, d);
			if (ways >= MOD)
			{
				ways -= MOD;
			}
		}
	}

	// Vertical cuts
	for (int c = column + 1; c < suffixApplesSum.GetLength(1); c++)
	{
		if (suffixApplesSum[row, column] - suffixApplesSum[row, c] > 0)
		{
			ways += solve(row, c, cutsLeft - 1, suffixApplesSum, d);
			if (ways >= MOD)
			{
				ways -= MOD;
			}
		}
	}

	int result = (int)(ways % MOD);
	d[row, column, cutsLeft] = result;
	return result;
}
}