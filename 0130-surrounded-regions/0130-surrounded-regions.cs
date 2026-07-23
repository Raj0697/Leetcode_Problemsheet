public class Solution {
    public void Solve(char[][] board) {
        int m = board.Length;
        int n = board[0].Length;

        // Mark edge-connected 'O's as safe
        for (int i = 0; i < m; i++) {
            if (board[i][0] == 'O') DFS(board, i, 0);
            if (board[i][n - 1] == 'O') DFS(board, i, n - 1);
        }

        for (int j = 0; j < n; j++) {
            if (board[0][j] == 'O') DFS(board, 0, j);
            if (board[m - 1][j] == 'O') DFS(board, m - 1, j);
        }

        // Flip surrounded 'O's to 'X', and restore safe 'T's to 'O'
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                board[i][j] = board[i][j] != 'T' ? 'X' : 'O';
            }
        }
    }

    private void DFS(char[][] board, int i, int j) {
        int m = board.Length;
        int n = board[0].Length;

        if (i < 0 || j < 0 || i >= m || j >= n || board[i][j] != 'O') return;

        board[i][j] = 'T'; // Temporarily mark as safe

        DFS(board, i + 1, j);
        DFS(board, i - 1, j);
        DFS(board, i, j + 1);
        DFS(board, i, j - 1);
    }
}