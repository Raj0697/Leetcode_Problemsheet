public class Solution {
    public int HIndex(int[] citations)
    {
        var citationBuckets = new int[citations.Length + 1];
    
        foreach (var citation in citations)
        {
            if (citation >= citations.Length)
            {
                citationBuckets[citations.Length]++;
            }
            else
            {
                citationBuckets[citation]++;
            }
        }
    
        var papersWithAtLeastCurrentCitations = 0;
    
        for (var currentH = citations.Length; currentH >= 0; currentH--)
        {
            papersWithAtLeastCurrentCitations += citationBuckets[currentH];
    
            if (papersWithAtLeastCurrentCitations >= currentH)
            {
                return currentH;
            }
        }
    
        return 0;
    }
}