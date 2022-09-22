class Solution {
    public String reverseWords(String s) {
        char[] chs = s.toCharArray();
        int start=0, end=0, k=0;
            while(k<=chs.length) {
                if(k ==chs.length || chs[k] == ' ') {
                    end = k-1;
                    swap(chs, start, end);
                    start = k+1;
                }
                k++;
            }
        return String.valueOf(chs);
    }
    
    public void swap(char[] nums, int i, int j) {
        while(i<j) {
            char temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
            i++;j--;
        }
}
}