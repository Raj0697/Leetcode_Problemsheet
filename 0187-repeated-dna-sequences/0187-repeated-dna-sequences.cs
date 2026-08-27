public class Solution {
    public IList<string> FindRepeatedDnaSequences(string s) {
        int sLength = s.Length;
        if(sLength<=10) return new List<string>{};
        
        BitArray UniqueDNAs = new BitArray(1048576);
        BitArray UniqueDNAsAdded = new BitArray(1048576);
        IList<string> Results = new List<string>();

        for(int i = 0,DNABitRepresentation = 0; i<sLength; i++){

            
            DNABitRepresentation = DNABitRepresentation<<2;
            switch(s[i]){
                case 'A':
                    break;
                case 'C':
                    DNABitRepresentation+=1;
                    break;
                case 'G':
                    DNABitRepresentation+=2;
                    break;
                case 'T':
                    DNABitRepresentation+=3;
                    break;                    
            }
            if(i>=9){
                DNABitRepresentation = DNABitRepresentation & 0xFFFFF;
                if(UniqueDNAs[DNABitRepresentation] == true){
                    if(UniqueDNAsAdded[DNABitRepresentation] == false){
                        UniqueDNAsAdded[DNABitRepresentation] = true;
                        Results.Add(s.Substring(i-9,10));
                    }
                }
                else UniqueDNAs[DNABitRepresentation] = true;
            }

        }
        return Results;
    }
}