class Solution {
    public boolean isPalindrome(String s) {
        s=s.replaceAll("[^a-zA-Z0-9]","").toLowerCase();
        if(s.isEmpty() || s.length() == 1)
            return true;
        int l = 0, h = s.length() - 1;
        while(l<h)
        {
            if(s.charAt(l) != s.charAt(h))
            {
                return false;
            }
            l++;
            h--;
        }
        return true;
    }
}