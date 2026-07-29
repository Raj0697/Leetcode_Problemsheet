public class Solution {
    public int VisiblePoints(IList<IList<int>> points, int angle, IList<int> location) {
        int n = points.Count;
        int locationX = location[0], locationY = location[1];
        List<double> angles = new List<double>();

        // Step 1: Calculate angles for all points, ignoring points at the location
        for (int i = 0; i < n; i++) {
            int x = points[i][0], y = points[i][1];
            if (x == locationX && y == locationY) {
                continue; // Skip points at the observer's location
            }
            double dx = x - locationX;
            double dy = y - locationY;
            double angleToPoint = Math.Atan2(dy, dx) * 180 / Math.PI; // Convert radian to degree
            angles.Add(angleToPoint);
        }

        // Step 2: Sort angles
        angles.Sort();

        // Step 3: Duplicate angles for circular wrap around
        int m = angles.Count;
        List<double> extendedAngles = new List<double>(angles);
        for (int i = 0; i < m; i++) {
            extendedAngles.Add(angles[i] + 360); // Wrap around
        }

        // Step 4: Use two pointers to find the maximum points in the visible range
        int maxVisible = 0;
        int right = 0;

        for (int left = 0; left < m; left++) {
            // Move right pointer to the rightmost angle within the field of view
            while (right < extendedAngles.Count && extendedAngles[right] <= extendedAngles[left] + angle) {
                right++;
            }
            maxVisible = Math.Max(maxVisible, right - left);
        }

        // Step 5: Count points at the location
        int pointsAtLocation = n - angles.Count; // Count of points directly at the observer's location

        // Step 6: Return the total visible points
        return maxVisible + pointsAtLocation;
    }
}