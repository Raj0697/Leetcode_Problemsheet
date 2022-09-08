class Solution {
    public double average(int[] salary) {
        Arrays.sort(salary);
        double t = 0;
        int count = 0;
        for(int i=1; i<=salary.length-2; i++) {
            t += salary[i];
            count++;
        }
        t /= count;
        return t;
        //newarray(salary, 0, n2);
    }
    // public void newarray(int[] ar, int first, int last)
    // {
    //     int[] arr = new int[ar.length-1]
    // }
}