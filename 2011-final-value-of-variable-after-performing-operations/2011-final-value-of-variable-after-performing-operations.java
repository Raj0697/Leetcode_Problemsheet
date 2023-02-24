class Solution {
    public int finalValueAfterOperations(String[] operations) {
        int f = 0, n=operations.length;
        for(int i=0; i<n; i++){
            if(operations[i].contains("+"))
                f++;
            else if(operations[i].contains("-"))
                f-=1;
        }
        return f;
    }
}