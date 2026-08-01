public class Solution {
    class SegmentTree
    {
        private int[] _init;
        private int[] _storage;
        private int[] _lazy;
        private int _size;
        
        public SegmentTree(int n, int[] init)
        {
            _size = n;
            _init = init;
            _storage = new int[_size*4];
            _lazy = new int[_size*4];

            Build(0, 0, n-1);
        }

        public int Build(int curr, int left, int right)
        {
            if(left==right)
            {
                _storage[curr] = _init[left];
                return _init[left];
            }

            var mid = (left+right)/2;
            var newCurr = curr;
            int vL = Build(2*curr+1, left, mid);
            int vR = Build(2*curr+2, mid+1, right);
            _storage[curr] = Math.Max(vL, vR);
            return _storage[curr];
        }
        public void Update(int left, int right, int val)
        {
            Update(0, 0, _size-1, left, right, val);
        }
        private void Push(int curr, int left, int right)
        {
            if(_lazy[curr] !=0)
            {
                _storage[curr] +=_lazy[curr];
                if(left != right)
                {
                    _lazy[2*curr+1] +=_lazy[curr];
                    _lazy[2*curr+2] +=_lazy[curr];
                }
                _lazy[curr] = 0;
            }
        }
        private int Update(int curr, int left, int right, int upLeft, int upRight, int val)
        {
            Push(curr, left, right);
            if(upLeft<=left &&right<= upRight)
            {
                _lazy[curr] =  val;
                Push(curr, left, right);
                return _storage[curr];
            }
            // if(left==right && upLeft<=left &&right<= upRight)
            // {
            //     _storage[curr] +=val;
            //     return _storage[curr];
            // }
            if(left>upRight || right < upLeft)
            {
                return _storage[curr];
            }

            var mid = (left+right)/2;
            var newCurr = curr;
            int vL = Update(2*curr+1, left, mid, upLeft, upRight, val);
            int vR = Update(2*curr+2, mid+1, right, upLeft, upRight, val);
            _storage[curr] = Math.Max(vL, vR);
            return _storage[curr];
        }
        public int Query(){
            return _storage[0];
        }
    }
    public void SievePrime(int maxLimit, bool[]primes)
    {
        for(int i=2; i<=maxLimit; i++)
        {
            primes[i] = true;
        }
        for(int i=2; i<=maxLimit; i++)
        {
            if(primes[i]==true)
            {
                for(int j=2; j<maxLimit; j++)
                {
                    var nextInd = i*j;
                    if(nextInd<=maxLimit)
                    {
                        primes[nextInd] = false;
                    }else{
                        break;
                    }
                }
            }
        }
    }
    public int[] MaximumCount(int[] nums, int[][] queries) {
        
        int n = nums.Length;
        var numsMap = new Dictionary<int,List<int>>();
        int maxNum = 100000;
        var primes = new bool[maxNum+1];
        SievePrime(maxNum, primes);

        for(int i=0; i<n; i++)
        {
            if(primes[nums[i]]==false)
            {
                continue;
            }

            int ind = nums[i];
            if(numsMap.ContainsKey(ind)==false)
            {
                numsMap.Add(ind, new List<int>());
            }
            numsMap[ind].Add(i);
        }

        var DeltaArray = new int[n];
        foreach(var numList in numsMap)
        {
            var targetList = numList.Value;
            if(targetList.Count>=2)
            {
                var begin = targetList[0]+1;
                var end = targetList[targetList.Count-1]+1;
                DeltaArray[begin] +=1;
                if(end<n)
                {
                    DeltaArray[end] -=1;
                }
            }
        }

        for(int i=1; i<n; i++)
        {
            DeltaArray[i] += DeltaArray[i-1];           
        }        
        var res = new int[queries.Length];
        var sg = new SegmentTree(n, DeltaArray);

        for(int i=0; i<queries.Length; i++)
        {
            var ind = queries[i][0];
            var oldValue  = nums[ind];
            var newValue  = queries[i][1];
            nums[ind] = newValue;

            //process oldValue
            {
                if(primes[oldValue]==true)
                {
                    var tList = numsMap[oldValue];
                    var tCnt = numsMap[oldValue].Count;
                    if(tCnt>=2)
                    {
                     
                        if(tList[0]==ind || tList[tCnt-1]==ind)
                        {
                            sg.Update(tList[0]+1, tList[tCnt-1], -1);
                            tList.Remove(ind);
                            if(tList.Count>=2)
                            {
                                tCnt = tList.Count;
                                sg.Update(tList[0]+1, tList[tCnt-1], +1);
                            }
                        }else{
                            tList.Remove(ind);                            
                        }
                    }else
                    {
                        tList.Remove(ind);
                    }
                    if(tList.Count()==0)
                    {
                        numsMap.Remove(oldValue);
                    }
                }
            }
            {
                //process new Value
                if(primes[newValue]==true)
                {
                    if(numsMap.ContainsKey(newValue)==false)
                    {
                        numsMap.Add(newValue, new List<int>());
                    }
                    var tList = numsMap[newValue];
                    var tCnt = numsMap[newValue].Count;
                    if(tCnt>=2)
                    {
                        if((tList[0]<=ind && tList[tCnt-1]>=ind)==false)
                        {
                            if(ind<tList[0])
                            {
                                sg.Update(ind+1, tList[0], 1);
                            }else{
                                sg.Update(tList[tCnt-1]+1, ind,  1);
                            }
                        }
                        tList.Add(ind);
                        tList.Sort();                        
                    }else{
                        if(tCnt==1)
                        {
                            var left = Math.Min(tList[0], ind);
                            var right = Math.Max(tList[0], ind);
                            sg.Update(left+1, right, 1);
                        }
                        tList.Add(ind);
                        tList.Sort();                         
                    }
                }
            }

            var cnt = numsMap.Count;
            res[i] = sg.Query()+ cnt;
        }

        return res;
    }
}