public class Solution {
    public int CountStudents(int[] students, int[] sandwiches) {
        int[] count = new int[2]; // count[0] for circular sandwiches, count[1] for square sandwiches
        
        foreach (int student in students) {
            count[student]++;
        }
        
        int i = 0;
        while (i < sandwiches.Length) {
            if (count[sandwiches[i]] == 0) {
                break; // No more students who prefer this type of sandwich
            }
            
            count[sandwiches[i]]--; // Mark one sandwich as eaten by a student
            
            i++;
        }
        
        return students.Length - i;
    }
}