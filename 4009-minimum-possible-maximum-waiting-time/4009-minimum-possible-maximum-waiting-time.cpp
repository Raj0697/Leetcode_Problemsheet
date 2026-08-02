class Solution {
    map<tuple<int, int, int, int, int>, pair<int, int>> memo;
    vector<int> demand;

    pair<int, int> dfs(int i, int f0, int f1, int w0, int w1) {
        int res0 = 0, res1 = 0, c0 = 0, c1 = 0;
        int n = demand.size();
        if (i == n) {
            return {0, 0};
        }

        auto state = make_tuple(i, f0, f1, w0, w1);
        if (memo.count(state)) {
            return memo[state];
        }

        int d = demand[i];

        if (f0 >= d) {
            auto p = dfs(i + 1, f0 - d, f1, d, max(0, w1 - w0));
            c0 = p.first + 1;
            res0 = max(p.second, w0);
        }
        if (f1 >= d) {
            auto p = dfs(i + 1, f0, f1 - d, max(0, w0 - w1), d);
            c1 = p.first + 1;
            res1 = max(p.second, w1);
        }

        if (c0 < c1) {
            return memo[state] = {c1, res1};
        } else if (c0 > c1) {
            return memo[state] = {c0, res0};
        } else {
            return memo[state] = {c0, min(res0, res1)};
        }
    }

public:
    int minMaxWaitingTime(vector<int>& demand, vector<int>& fuel) {
        this->demand = demand;
        memo.clear();
        auto p = dfs(0, fuel[0], fuel[1], 0, 0);
        return p.first > 0 ? p.second : -1;
    }
};