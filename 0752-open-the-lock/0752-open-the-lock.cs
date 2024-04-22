public class Solution {
    public int OpenLock(string[] deadends, string target) {
        var deads = new HashSet<string>(deadends);
        if (deadends.Contains("0000") || deadends.Contains(target)) return -1;
        
        var directions = new int[] { 1, -1 };
        int steps = 0;
        var q = new Queue<string>();
        q.Enqueue("0000");
        var visited = new HashSet<string>();
        visited.Add("0000");
        
        while (q.Count > 0) {
            var size = q.Count;
            
            for (int i=0; i<size; i++) {
                var node = q.Dequeue();
                if (node == target) return steps;
                var digitArr = node.ToCharArray();
                for (int k=0; k<4; k++) {
                    var tmp = digitArr[k];
                    int digit = digitArr[k] - '0';
                    foreach (var dir in directions) {
                        var newdigit = digit + dir;
                        if (newdigit == 10) newdigit = 0;
                        if (newdigit == -1) newdigit = 9;
                        digitArr[k] = (char)(newdigit + '0');
                        var news = new string(digitArr);
                        if (!deads.Contains(news) && !visited.Contains(news)) {
                            q.Enqueue(news);
                            visited.Add(news);
                        }
                    }
                    digitArr[k] = tmp;
                }
                
            }
            steps++;
        }
        return -1;
    }
}