public class Solution {
    public bool JudgeCircle(string moves) {
        int lr = 0;
        int ud = 0;

        foreach(char m in moves){
            if(m=='U'){
                ud++;
            }
            else if(m=='D'){
                ud--;
            }
            else if(m=='R'){
                lr++;
            }
            else{
                lr--;
            }
        }
        return lr == 0 && ud == 0;
    }
}