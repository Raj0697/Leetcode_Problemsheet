public class MajorityChecker {
    private readonly Dictionary<int, List<int>> _positions;
    
    public MajorityChecker(int[] arr) {
        _positions = new Dictionary<int, List<int>>();
        
        for (int i = 0; i < arr.Length; i++) {
            if (!_positions.ContainsKey(arr[i])) {
                _positions[arr[i]] = new List<int>();
            }
            _positions[arr[i]].Add(i);
        }
    }
    
    public int Query(int left, int right, int threshold) {
        foreach (var kvp in _positions) {
            int num = kvp.Key;
            var indices = kvp.Value;
            
            int leftIndex = BinarySearch(indices, left);
            int rightIndex = BinarySearch(indices, right + 1) - 1;
            
            if (leftIndex < indices.Count && indices[leftIndex] <= right && rightIndex >= 0) {
                int count = rightIndex - leftIndex + 1;
                if (count >= threshold) {
                    return num;
                }
            }
        }
        return -1;
    }

    private int BinarySearch(List<int> list, int target) {
        int low = 0, high = list.Count;
        while (low < high) {
            int mid = (low + high) / 2;
            if (list[mid] < target) {
                low = mid + 1;
            } else {
                high = mid;
            }
        }
        return low;
    }
}