public class Solution {
    public bool IsTransformable(string s, string t) {
       int len = s.Length;
       Stack<int>[] ids = new Stack<int>[10];
       for(int i = 0; i < 10; i++)
       {
            ids[i] = new Stack<int>();
       }

       for(int i = len-1; i >= 0; i--)
       {
            int id = s[i]-'0';
            ids[id].Push(i);
       }

       for(int i = 0; i < len; i++)
       {
            int d = t[i]-'0';
            if(ids[d].Count == 0)
                return false;

            int idx = ids[d].Pop();
            for(int j = 0; j < d; j++)
            {
                if(ids[j].Count > 0 && ids[j].Peek() < idx)
                    return false;
            }
       }

       return true;
    }
}