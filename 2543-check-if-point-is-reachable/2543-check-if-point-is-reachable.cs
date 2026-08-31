public class Solution {
    public bool IsReachable(int targetX, int targetY) {
        return targetY != 0 ? IsReachable(targetY, targetX % targetY) : targetX - (targetX & (-targetX)) == 0;        
    }
}