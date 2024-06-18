public class Solution {
    private struct Job
        {
            public readonly int Difficulty;
            public readonly int Profit;

            public Job(int difficulty, int profit)
            {
                Difficulty = difficulty;
                Profit = profit;
            }
        }

        public int MaxProfitAssignment(int[] difficulties, int[] profits, int[] workers)
        {
            int res = 0;
            Job[] jobs = new Job[difficulties.Length];
            for (int i = 0; i < difficulties.Length; i++)
            {
                jobs[i] = new Job(difficulties[i], profits[i]);
            }
            Array.Sort(jobs, (j1, j2) => j1.Difficulty.CompareTo(j2.Difficulty));
            Array.Sort(workers);

            int lastJobIdx = 0;
            int maxProfit = 0;
            foreach (var w in workers)
            {
                while (lastJobIdx < jobs.Length && w >= jobs[lastJobIdx].Difficulty)
                {
                    maxProfit = Math.Max(maxProfit, jobs[lastJobIdx].Profit);
                    lastJobIdx++;
                }

                res += maxProfit;
            }

            return res;
        }
}