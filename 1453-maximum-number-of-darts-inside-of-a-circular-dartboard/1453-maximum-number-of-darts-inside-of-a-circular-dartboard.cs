public class Solution
{
    public int NumPoints(int[][] darts, int r)
    {
        int n = darts.Length;
        int maxDarts = 0;
        double rSquared = r * r;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                // Calculate the midpoint between dart i and dart j
                double x1 = darts[i][0];
                double y1 = darts[i][1];
                double x2 = darts[j][0];
                double y2 = darts[j][1];
                
                double midX = (x1 + x2) / 2.0;
                double midY = (y1 + y2) / 2.0;

                // Distance from midpoint to either dart
                double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)) / 2.0;

                // Calculate height from midpoint to the center of the dartboard
                if (distance <= r)
                {
                    double h = Math.Sqrt(rSquared - distance * distance);

                    // Check two potential centers for the dartboard
                    double center1X = midX + (y2 - y1) / (2.0 * distance) * h;
                    double center1Y = midY - (x2 - x1) / (2.0 * distance) * h;
                    double center2X = midX - (y2 - y1) / (2.0 * distance) * h;
                    double center2Y = midY + (x2 - x1) / (2.0 * distance) * h;

                    maxDarts = Math.Max(maxDarts, CountDarts(darts, rSquared, center1X, center1Y));
                    maxDarts = Math.Max(maxDarts, CountDarts(darts, rSquared, center2X, center2Y));
                }
            }
        }

        // Also consider placing the dartboard at the position of each dart
        foreach (var dart in darts)
        {
            maxDarts = Math.Max(maxDarts, CountDarts(darts, rSquared, dart[0], dart[1]));
        }

        return maxDarts;
    }

    private int CountDarts(int[][] darts, double rSquared, double centerX, double centerY)
    {
        int count = 0;
        foreach (var dart in darts)
        {
            double dartX = dart[0];
            double dartY = dart[1];
            if ((dartX - centerX) * (dartX - centerX) + (dartY - centerY) * (dartY - centerY) <= rSquared)
            {
                count++;
            }
        }
        return count;
    }
}