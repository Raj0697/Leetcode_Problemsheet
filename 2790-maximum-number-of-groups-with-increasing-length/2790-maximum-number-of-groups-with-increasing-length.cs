public class Solution {
        public int MaxIncreasingGroups(IList<int> usageLimits){
            //we have our stones
            List<int> StoneBag = usageLimits.ToList();
            //first , let's sort the stones asc so that stones with insufficient quantity shows up early
            StoneBag.Sort();
            int CurrentLines = 0;
            long TotalStonesWeGot = 0;
            //now try to use the stones to build triangle
            foreach (int Quantity in StoneBag)
            {
                //we took out stones ,add it up
                TotalStonesWeGot += Quantity;
                //and check wether the quantity is enough to build a bigger triangle than current
                //by wether the stones we have is more than (LinesPossible) * (LinesPossible+1) / 2 or not
                //note that LinesPossible = CurrentLines+1
                if (TotalStonesWeGot >= (long)(CurrentLines + 1) * (CurrentLines + 2) / 2)
                {
                    //if the stones is enough to build a bigger triangle , add the line
                    CurrentLines++;
                }
                else
                {
                    //if it is not enough , skip and wait until it is enough (but at the cost of the Max line reduced as mentioned)
                }
            }
            return CurrentLines;
        }
}