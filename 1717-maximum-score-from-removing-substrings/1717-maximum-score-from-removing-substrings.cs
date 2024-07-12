public class Solution {
    public int MaximumGain(string s, int x, int y) {
        Stack<char> st = new Stack<char>();
        char first = 'a', second = 'b';
        int score = 0, point = Math.Max(x,y);
        if(y > x) (first,second) = (second,first);

        for(int i = 0; i < s.Length;i++){
            if(st.Count > 0 && st.Peek() == first && s[i] == second){
                st.Pop();
                score+= point;
            }else st.Push(s[i]);
        }
        point = Math.Min(x,y);
        Stack<char> st2 = new Stack<char>();
        while(st.Count > 0){
            char top = st.Pop();
            if(st2.Count > 0 && top == second && st2.Peek() == first){
                st2.Pop();
                score+= point;
            }else st2.Push(top);
        }
        return score;
    }
}