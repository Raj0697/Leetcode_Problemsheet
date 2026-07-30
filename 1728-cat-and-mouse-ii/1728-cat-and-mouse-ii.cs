public class Solution {
    public const int MOUSE_TURN = 0, CAT_TURN = 1;
    public const int UNKNOWN = 0, MOUSE_WIN = 1, CAT_WIN = 2;
    public const int MAX_MOVES = 1000;
    public const char WALL = '#';
    public const char CAT = 'C', MOUSE = 'M', FOOD = 'F';
    private static int[][] dirs = {new int[]{-1, 0}, new int[]{1, 0}, new int[]{0, -1}, new int[]{0, 1}};
    private int rows, cols;
    private string[] grid;
    private int catJump, mouseJump;
    private int food;
    private int[][][] degrees;
    private int[][][][] results;

    public bool CanMouseWin(string[] grid, int catJump, int mouseJump) {
        this.rows = grid.Length;
        this.cols = grid[0].Length;
        this.grid = grid;
        this.catJump = catJump;
        this.mouseJump = mouseJump;
        int mouseStart = -1, catStart = -1;
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                char c = grid[i][j];
                if (c == CAT) {
                    catStart = GetPos(i, j);
                } else if (c == MOUSE) {
                    mouseStart = GetPos(i, j);
                } else if (c == FOOD) {
                    food = GetPos(i, j);
                }
            }
        }
        int total = rows * cols;
        this.degrees = new int[total][][];
        this.results = new int[total][][][];
        for (int i = 0; i < total; i++) {
            degrees[i] = new int[total][];
            results[i] = new int[total][][];
            for (int j = 0; j < total; j++) {
                degrees[i][j] = new int[2];
                results[i][j] = new int[2][];
                results[i][j][0] = new int[2];
                results[i][j][1] = new int[2];
            }
        }
        Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
        for (int mouse = 0; mouse < total; mouse++) {
            int mouseRow = mouse / cols, mouseCol = mouse % cols;
            if (grid[mouseRow][mouseCol] == WALL) {
                continue;
            }
            for (int cat = 0; cat < total; cat++) {
                int catRow = cat / cols, catCol = cat % cols;
                if (grid[catRow][catCol] == WALL) {
                    continue;
                }
                degrees[mouse][cat][MOUSE_TURN]++;
                degrees[mouse][cat][CAT_TURN]++;
                foreach (int[] dir in dirs) {
                    for (int row = mouseRow + dir[0], col = mouseCol + dir[1], jump = 1; row >= 0 && row < rows && col >= 0 && col < cols && grid[row][col] != WALL && jump <= mouseJump; row += dir[0], col += dir[1], jump++) {
                        int nextMouse = GetPos(row, col), nextCat = GetPos(catRow, catCol);
                        degrees[nextMouse][nextCat][MOUSE_TURN]++;
                    }
                    for (int row = catRow + dir[0], col = catCol + dir[1], jump = 1; row >= 0 && row < rows && col >= 0 && col < cols && grid[row][col] != WALL && jump <= catJump; row += dir[0], col += dir[1], jump++) {
                        int nextMouse = GetPos(mouseRow, mouseCol), nextCat = GetPos(row, col);
                        degrees[nextMouse][nextCat][CAT_TURN]++;
                    }
                }
            }
        }
        for (int pos = 0; pos < total; pos++) {
            if (pos == food) {
                continue;
            }
            int row = pos / cols, col = pos % cols;
            if (grid[row][col] == WALL) {
                continue;
            }
            results[pos][pos][MOUSE_TURN][0] = CAT_WIN;
            results[pos][pos][MOUSE_TURN][1] = 0;
            results[pos][pos][CAT_TURN][0] = CAT_WIN;
            results[pos][pos][CAT_TURN][1] = 0;
            queue.Enqueue(new Tuple<int, int, int>(pos, pos, MOUSE_TURN));
            queue.Enqueue(new Tuple<int, int, int>(pos, pos, CAT_TURN));
        }
        for (int mouse = 0; mouse < total; mouse++) {
            int mouseRow = mouse / cols, mouseCol = mouse % cols;
            if (grid[mouseRow][mouseCol] == WALL || mouse == food) {
                continue;
            }
            results[mouse][food][MOUSE_TURN][0] = CAT_WIN;
            results[mouse][food][MOUSE_TURN][1] = 0;
            results[mouse][food][CAT_TURN][0] = CAT_WIN;
            results[mouse][food][CAT_TURN][1] = 0;
            queue.Enqueue(new Tuple<int, int, int>(mouse, food, MOUSE_TURN));
            queue.Enqueue(new Tuple<int, int, int>(mouse, food, CAT_TURN));
        }
        for (int cat = 0; cat < total; cat++) {
            int catRow = cat / cols, catCol = cat % cols;
            if (grid[catRow][catCol] == WALL || cat == food) {
                continue;
            }
            results[food][cat][MOUSE_TURN][0] = MOUSE_WIN;
            results[food][cat][MOUSE_TURN][1] = 0;
            results[food][cat][CAT_TURN][0] = MOUSE_WIN;
            results[food][cat][CAT_TURN][1] = 0;
            queue.Enqueue(new Tuple<int, int, int>(food, cat, MOUSE_TURN));
            queue.Enqueue(new Tuple<int, int, int>(food, cat, CAT_TURN));
        }
        while (queue.Count > 0) {
            Tuple<int, int, int> state = queue.Dequeue();
            int mouse = state.Item1, cat = state.Item2, turn = state.Item3;
            int result = results[mouse][cat][turn][0];
            int steps = results[mouse][cat][turn][1];
            IList<Tuple<int, int, int>> prevStates = GetPrevStates(mouse, cat, turn);
            foreach (Tuple<int, int, int> prevState in prevStates) {
                int prevMouse = prevState.Item1, prevCat = prevState.Item2, prevTurn = prevState.Item3;
                if (results[prevMouse][prevCat][prevTurn][0] == UNKNOWN) {
                    bool winState = (result == MOUSE_WIN && prevTurn == MOUSE_TURN) || (result == CAT_WIN && prevTurn == CAT_TURN);
                    if (winState) {
                        results[prevMouse][prevCat][prevTurn][0] = result;
                        results[prevMouse][prevCat][prevTurn][1] = steps + 1;
                        queue.Enqueue(new Tuple<int, int, int>(prevMouse, prevCat, prevTurn));
                    } else {
                        degrees[prevMouse][prevCat][prevTurn]--;
                        if (degrees[prevMouse][prevCat][prevTurn] == 0) {
                            results[prevMouse][prevCat][prevTurn][0] = result;
                            results[prevMouse][prevCat][prevTurn][1] = steps + 1;
                            queue.Enqueue(new Tuple<int, int, int>(prevMouse, prevCat, prevTurn));
                        }
                    }
                }
            }
        }
        return results[mouseStart][catStart][MOUSE_TURN][0] == MOUSE_WIN && results[mouseStart][catStart][MOUSE_TURN][1] <= MAX_MOVES;
    }

    private IList<Tuple<int, int, int>> GetPrevStates(int mouse, int cat, int turn) {
        IList<Tuple<int, int, int>> prevStates = new List<Tuple<int, int, int>>();
        int mouseRow = mouse / cols, mouseCol = mouse % cols;
        int catRow = cat / cols, catCol = cat % cols;
        int prevTurn = turn == MOUSE_TURN ? CAT_TURN : MOUSE_TURN;
        int maximumJump = prevTurn == MOUSE_TURN ? mouseJump : catJump;
        int startRow = prevTurn == MOUSE_TURN ? mouseRow : catRow;
        int startCol = prevTurn == MOUSE_TURN ? mouseCol : catCol;
        prevStates.Add(new Tuple<int, int, int>(mouse, cat, prevTurn));
        foreach (int[] dir in dirs) {
            for (int i = startRow + dir[0], j = startCol + dir[1], jump = 1; i >= 0 && i < rows && j >= 0 && j < cols && grid[i][j] != WALL && jump <= maximumJump; i += dir[0], j += dir[1], jump++) {
                int prevMouseRow = prevTurn == MOUSE_TURN ? i : mouseRow;
                int prevMouseCol = prevTurn == MOUSE_TURN ? j : mouseCol;
                int prevCatRow = prevTurn == MOUSE_TURN ? catRow : i;
                int prevCatCol = prevTurn == MOUSE_TURN ? catCol : j;
                int prevMouse = GetPos(prevMouseRow, prevMouseCol);
                int prevCat = GetPos(prevCatRow, prevCatCol);
                prevStates.Add(new Tuple<int, int, int>(prevMouse, prevCat, prevTurn));
            }
        }
        return prevStates;
    }

    private int GetPos(int row, int col) {
        return row * cols + col;
    }
}