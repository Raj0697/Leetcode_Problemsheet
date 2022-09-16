class Solution {
    public int maximumWealth(int[][] accounts) {
        // int res = 0;
        // int []arr=new int[accounts.length];
        // for(int i=0; i<accounts.length; i++) {
        //     for(int j=0; j<accounts[i].length; j++) {
        //         res += accounts[i][j];
        //     }
        //     arr[i] = res;
        // }
        // Arrays.sort(arr);
        // return arr[accounts.length-1];
                int []arr=new int[accounts.length];
        for(int i=0;i<accounts.length;i++)
        {
            int count=0;
            for(int j=0;j<accounts[i].length;j++)
            {
                count+=accounts[i][j];
            }
            arr[i]=count;
        }
        Arrays.sort(arr);
        return arr[accounts.length-1];
    }
}