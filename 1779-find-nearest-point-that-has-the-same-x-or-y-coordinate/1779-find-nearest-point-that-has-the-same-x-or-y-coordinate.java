class Solution {
    public int nearestValidPoint(int x, int y, int[][] points) {
        int dist=0; int index=-1; int min=Integer.MAX_VALUE;
        
        for(int i=0;i<points.length;i++){
            
                if(points[i][0]==x||points[i][1]==y){
                    
                    dist=Math.abs(x-points[i][0])+Math.abs(y-points[i][1]);
                    
                    if(dist<min){
                        min=dist;
                        index=i;
                    }
                }
        }return index;
    }
}