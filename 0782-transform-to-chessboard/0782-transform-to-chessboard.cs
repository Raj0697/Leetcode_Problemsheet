public class Solution {
    public int MovesToChessboard(int[][] board) {
        int n = board.Length;
        
        // Check for the validity of rows and columns
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                if ((board[0][0] ^ board[i][0] ^ board[0][j] ^ board[i][j]) != 0)
                    return -1; // Invalid chessboard pattern
            }
        }

        // Count how many rows and columns we need to swap
        int rowSum = 0, colSum = 0, rowSwap = 0, colSwap = 0;
        
        // Analyze the first row and first column for patterns
        for (int i = 0; i < n; ++i) {
            rowSum += board[0][i]; // Count 1's in the first row
            colSum += board[i][0]; // Count 1's in the first column
            rowSwap += (board[0][i] == i % 2) ? 1 : 0; // How many need to be swapped in rows
            colSwap += (board[i][0] == i % 2) ? 1 : 0; // How many need to be swapped in columns
        }
        
        // Check if the sum of 1s in row and column is valid for a chessboard pattern
        if (rowSum < n / 2 || rowSum > (n + 1) / 2) return -1;
        if (colSum < n / 2 || colSum > (n + 1) / 2) return -1;
        
        // Calculate the minimum number of swaps
        if (n % 2 == 1) {
            if (rowSwap % 2 != 0) rowSwap = n - rowSwap;
            if (colSwap % 2 != 0) colSwap = n - colSwap;
        } else {
            rowSwap = Math.Min(rowSwap, n - rowSwap);
            colSwap = Math.Min(colSwap, n - colSwap);
        }
        
        return (rowSwap + colSwap) / 2;
    }
}