
public class Solution {
    public long MaxAlternatingSum(int[] nums, int[][] swaps) {
        int n=nums.Length;
        int[] p=new int[n];
        for(int i=0;i<n;i++)p[i]=i;
        int Find(int x){ while(p[x]!=x){ p[x]=p[p[x]]; x=p[x]; } return x; }
        void Union(int a,int b){ a=Find(a); b=Find(b); if(a!=b) p[b]=a; }
        for(int i=0;i<swaps.Length;i++){ Union(swaps[i][0],swaps[i][1]); }
        var comp=new Dictionary<int,List<int>>();
        var oddCount=new Dictionary<int,int>();
        for(int i=0;i<n;i++){
            int r=Find(i);
            if(!comp.ContainsKey(r)){ comp[r]=new List<int>(); oddCount[r]=0; }
            comp[r].Add(nums[i]);
            if((i&1)==1) oddCount[r]++;
            }
        long ans=0;
        foreach(var kv in comp){
            List<int> vals=kv.Value;
            vals.Sort();
            int o=oddCount[kv.Key];
            long sum=0;
            foreach(int v in vals) sum+=v;
            long sumSmall=0;
            for(int i=0;i<o && i<vals.Count;i++) sumSmall+=vals[i];
            ans += sum - 2*sumSmall;
            }
        return ans;
        }
    }