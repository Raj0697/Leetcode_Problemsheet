class Solution {
    public int numberOfWeakCharacters(int[][] properties) {
        // int t = 0;
        // for(int row=0; row<properties.length; row++)
        // {
        //     for(int col=0; col<properties[row].length; col++)
        //     {
        //         t += properties[row][col];
        //     }
        // }
        // return t;
        Arrays.sort(properties,(a,b)-> (a[0]==b[0])?a[1]-b[1]:b[0]-a[0]);
        int max = -1,res = 0;
        for(int[] property: properties){
            if(property[1] < max)
                res++;
            else
                max = property[1];
        }
        return res;
    }
}