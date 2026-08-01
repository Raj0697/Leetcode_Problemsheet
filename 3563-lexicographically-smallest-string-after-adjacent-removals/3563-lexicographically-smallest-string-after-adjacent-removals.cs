public class Solution {
    int len = 0;
    private BitArray[] _removableMap;
    private string[] _smallestStrArray;
    private string strBiggest;
    public static void PrintValues( IEnumerable myList, int myWidth )  {
        int i = myWidth;
        foreach ( Object obj in myList ) {
            if ( i <= 0 )  {
                i = myWidth;
                Console.WriteLine();
            }
            i--;
            Console.Write( "{0,8}", obj );
        }
        Console.WriteLine();
    }
    private void BuildRemovableMap(string s)
    {   
        int len = s.Length;
        for(int i=len-2; i>=0; i--)
        {
            for(int j=i+1; j<len; j++)
            {

                var c1 = s[i];
                var c2 = s[j];
                var index1 = s[j]-'a';
                var index2 = s[i]-'a';


                if(Math.Abs(index1-index2)==1 || (index1==25&&index2==0) || (index1==0&&index2==25))
                {
                    if(i+1==j)
                    {
                       
                        _removableMap[i].Set(j,true);
                        for(int k=j+1+1; k<len; k++)
                        {
                            if(_removableMap[j+1][k]==true)
                            {

                                _removableMap[i][k] = true;
                            }
                        }
                    }else if(j-i>0&&(j-i+1)%2==0)
                    {
                        //Console.WriteLine($"i:{i} j:{j}");
                        if(_removableMap[i+1][j-1]==true)
                        {
                            _removableMap[i].Set(j,true);
                            for(int k=j+1+1; k<len; k++)
                            {
                                if(_removableMap[j+1][k]==true)
                                {

                                    _removableMap[i][k] = true;
                                }
                            }                        
                        }
                    }
                }
            }
        }
    }
    
    private string FindSmallest(string s)
    {
        _smallestStrArray[s.Length] = "";

        for(int i=len-1; i>=0; i--)
        {
            string smallest = s[i].ToString();
            smallest += _smallestStrArray[i+1];
            
            for(int j=i+1; j<len; j++)
            {
                if(_removableMap[i][j]==true)
                {
                    if(string.Compare(smallest, _smallestStrArray[j+1])>0)
                    {
                        smallest = _smallestStrArray[j+1];
                    }
                }
            }

            _smallestStrArray[i] = smallest;
        }
        var res  = _smallestStrArray[0];

        return res;
    }
    public string LexicographicallySmallestString(string s) {
        len =s.Length;
        _removableMap = new BitArray[len];
        _smallestStrArray = new string[len+1];
        strBiggest = new string('z', len);
        for(int i=0; i<len; i++)
        {
            _removableMap[i] = new BitArray(len);
        }

        BuildRemovableMap(s);

        // for(int i=0; i<len; i++)
        // {
        //     PrintValues(_removableMap[i], len);
        // }

        var res = FindSmallest(s);



        return res;
    }
}