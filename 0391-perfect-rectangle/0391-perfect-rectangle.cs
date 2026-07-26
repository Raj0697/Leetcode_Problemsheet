public class Solution {
    public bool IsRectangleCover(int[][] rectangles) {
        long totalIndividualArea = 0;
int minX = int.MaxValue;
int minY = int.MaxValue;
int maxX = int.MinValue;
int maxY = int.MinValue;

// Using ValueTuple<(int, int)> as keys for the HashSet.
// This is highly efficient in terms of both speed and memory for compound keys in C#.
HashSet<(int, int)> cornerPoints = new HashSet<(int, int)>();

for (int i = 0; i < rectangles.Length; ++i)
{
    var rect = rectangles[i];
    int x1 = rect[0];
    int y1 = rect[1];
    int x2 = rect[2];
    int y2 = rect[3];

    minX = Math.Min(minX, x1);
    minY = Math.Min(minY, y1);
    maxX = Math.Max(maxX, x2);
    maxY = Math.Max(maxY, y2);

    totalIndividualArea += (long)(x2 - x1) * (long)(y2 - y1);

    (int, int) p_bottom_left = (x1, y1);
    (int, int) p_bottom_right = (x2, y1);
    (int, int) p_top_left = (x1, y2);
    (int, int) p_top_right = (x2, y2);

    if (!cornerPoints.Add(p_bottom_left)) cornerPoints.Remove(p_bottom_left);
    if (!cornerPoints.Add(p_bottom_right)) cornerPoints.Remove(p_bottom_right);
    if (!cornerPoints.Add(p_top_left)) cornerPoints.Remove(p_top_left);
    if (!cornerPoints.Add(p_top_right)) cornerPoints.Remove(p_top_right);
}

long expectedBoundingBoxArea = (long)(maxX - minX) * (long)(maxY - minY);
if (totalIndividualArea != expectedBoundingBoxArea)
{
    return false;
}

if (cornerPoints.Count != 4)
{
    return false;
}

if (!cornerPoints.Contains((minX, minY))) return false;
if (!cornerPoints.Contains((maxX, minY))) return false;
if (!cornerPoints.Contains((minX, maxY))) return false;
if (!cornerPoints.Contains((maxX, maxY))) return false;

return true;
    }
}