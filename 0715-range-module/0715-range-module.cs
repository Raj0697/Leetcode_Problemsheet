public class RangeModule {
    private List<(int Start, int End)> intervals = new();
    public RangeModule() {
        
    }
    // left < right, always true
    public void AddRange(int left, int right) {
        if (intervals.Count == 0)
            intervals.Add((left, right - 1));
        else {
            int idx = BSHelper(left);
            if (idx == intervals.Count)
                intervals.Add((left, right - 1));
            else {
                intervals.Insert(idx, (left, right - 1));
            }
            CheckOverlaps(idx);
        }
    }
    
    public bool QueryRange(int left, int right) {
        if (intervals.Count == 0) return false;
        int idx = BSHelper(left);
        if (idx == intervals.Count) return false;
        if (left < intervals[idx].Start || right - 1 > intervals[idx].End) return false;
        return true;
    }
    
    public void RemoveRange(int left, int right) {
        if (left >= right || intervals.Count == 0) return ;
        int idx = BSHelper(left);
        if (idx == intervals.Count) return ;
        if (idx == 0 && left < intervals[0].Start)
            RemoveRange(intervals[0].Start, right);
        else {
            if (left <= intervals[idx].Start && right >= intervals[idx].Start) {
                if (right <= intervals[idx].End)
                    intervals[idx] = (right, intervals[idx].End);
                else {
                    int newLeft = intervals[idx].End + 1;
                    intervals.RemoveAt(idx);
                    RemoveRange(newLeft, right);
                }
            }
            else if (left > intervals[idx].Start) {
                if (right <= intervals[idx].End) {
                    // split into two interval
                    intervals.Insert(idx + 1, (right, intervals[idx].End));
                    intervals[idx] = (intervals[idx].Start, left - 1);
                }
                else {
                    int newLeft = intervals[idx].End + 1;
                    intervals[idx] = (intervals[idx].Start, left - 1);
                    RemoveRange(newLeft, right);
                }
            }
            else {
                // right < intervals[idx].Start, no overlap, skip
            }
        }
    }

    // return i, intervals[i - 1].End < target <= intervals[i].End
    private int BSHelper(int target) {
        int left = 0, right = intervals.Count - 1;
        while (left < right) {
            int mid = (left + right) / 2;
            if (intervals[mid].End == target) return mid;
            if (intervals[mid].End < target) left = mid + 1;
            else right = mid;
        }
        if (left == intervals.Count - 1)
            return intervals[left].End < target ? intervals.Count : left;
        return left;
    }

    // check overlaps and merge intervals if necessary
    private void CheckOverlaps(int cur) {
        // handle corner case, check pervious interval
        if (cur - 1 >= 0 && intervals[cur - 1].End + 1 == intervals[cur].Start) {
            intervals[cur - 1] = (intervals[cur - 1].Start, intervals[cur].End);
            cur = cur - 1;
        }
        // normal case
        int next = cur + 1;
        while (next < intervals.Count && intervals[next].Start - 1 <= intervals[cur].End) {
            intervals[cur] = (Math.Min(intervals[cur].Start, intervals[next].Start), Math.Max(intervals[cur].End, intervals[next].End));
            intervals.RemoveAt(next);
        }
    }
}