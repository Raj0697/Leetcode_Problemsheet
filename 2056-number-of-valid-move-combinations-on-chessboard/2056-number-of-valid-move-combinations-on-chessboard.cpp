class Solution {
public:
    int dir[8][2] = {{0, 1}, {1, 0}, {0, -1}, {-1, 0}, {1, 1}, {1, -1}, {-1, -1}, {-1, 1}};
int b[4][8][8] = {};
int countCombinations(vector<string>& pieces, vector<vector<int>>& pos, int p = 0) {
    if (p >= pieces.size())
        return 1;
    int i = pos[p][0] - 1, j = pos[p][1] - 1, res = 0;
    for (int d = 0; d < 8; ++d) {
        if ((d < 4 && pieces[p] == "bishop" ) || (d >= 4 && pieces[p] == "rook"))
            continue;
        bool blocked = false;
        for (int step = res == 0 ? 1 : 2; !blocked; ++step) {
            int x = i + (step - 1) * dir[d][0], y = j + (step - 1) * dir[d][1];
            if (min(x, y) < 0 || max(x, y) > 7)
                break;
            bool canStop = true;
            for (int pp = 0; pp < p; ++pp) {
                canStop &= b[pp][x][y] >= 0 && b[pp][x][y] < step;
                blocked |= (b[pp][x][y] < 0 && -b[pp][x][y] <= step) || (b[pp][x][y] == step);
            }
            if (canStop) {
                b[p][x][y] = -step;
                res += countCombinations(pieces, pos, p + 1);
            }
            b[p][x][y] = step;
        }
        fill_n(b[p][0], 64, 0);
    }
    return res;
}
};