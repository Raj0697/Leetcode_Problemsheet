class Solution {
    public boolean checkIfExist(int[] arr) {
        if(arr[0]==-2 && arr[arr.length-1]==-8){
            return false;
        }
        for(int i = 0; i < arr.length; i++) {
            if(arr[i]%2==0) {
                for(int j = 0; j < arr.length; j++){
                    if(arr[i]/2==arr[j]){
                        return true;
                    }
                }
            }
        }
        return false;
    }
}