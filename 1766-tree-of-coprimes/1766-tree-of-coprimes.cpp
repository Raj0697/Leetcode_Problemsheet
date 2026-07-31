class Solution {
public:
vector<int>ans;
vector<vector<int>>tree;
vector<vector<int>>gcds;
int gcd(int a, int b) {
    while (b) {
        a %= b;
        swap(a, b);
    }
    return a;
}

void f(int curr,int par,int cans,vector<int>& nums,int val){
if(nums[curr]==val){
    ans[curr]=cans;
}
 if(gcds[nums[curr]][val]==1)cans=curr;
for(auto &ele:tree[curr]){
    if(ele==par)continue;
    f(ele,curr,cans,nums,val);
}
}
    vector<int> getCoprimes(vector<int>& nums, vector<vector<int>>& edges) {
        int n=nums.size();
        ans.resize(n);
        tree.resize(n);
        gcds.resize(51,vector<int>(51));
        for(int i=0;i<n-1;i++){
            int u=edges[i][0],v=edges[i][1];
            tree[u].push_back(v);
            tree[v].push_back(u);
        }
        for(int i=1;i<=50;i++){
            for(int j=1;j<=50;j++){
                gcds[i][j]=gcd(i,j);
            }
        }
       for(int i=1;i<=50;i++){
        f(0,-1,-1,nums,i);
       }
       return ans;
    }
};