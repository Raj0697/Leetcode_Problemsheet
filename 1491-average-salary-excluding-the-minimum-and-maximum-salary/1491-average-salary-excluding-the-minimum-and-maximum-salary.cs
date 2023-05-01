public class Solution {
    public double Average(int[] salary) {
        Array.Sort(salary);
        int count=0;
        double sum = 0;
        for (int i = 1; i < salary.Length - 1; i++){
            sum = sum + salary[i];
            count++;
        }

        return sum /count;
    }
}