class Solution {
    public int[] kWeakestRows(int[][] mat, int k) {
        ArrayList<Integer>[] counter = new ArrayList[101];
    
 for(int i=0;i<mat.length;i++){
        int sum=0;
        for(int j=0;j<mat[i].length;j++){
            sum=sum+mat[i][j];
        }
      
         if(counter[sum]!=null){
             counter[sum].add(i);
            }
         else{
               ArrayList<Integer> ar= new ArrayList<>();
               ar.add(i);
              counter[sum]=ar;   
         }
 }
    
    int res[]=new int[k]; 
    int x=0;
    for(int i=0;i<101;i++){
       if(counter[i]!=null){
           for(int ele:counter[i]){
               res[x++]=ele;
               if(x==k)
                   return res;
           }
       }
    }
    
    return res;
    }
}