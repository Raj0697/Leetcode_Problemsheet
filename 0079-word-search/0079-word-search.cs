public class Solution {
    public bool Exist(char[][] board, string word) {
        
        // Create a 'visitied' node matrix to keep track of the
        // items we've already seen
        var rowsVisited = new bool[board.Length][];
        for (int rowIndex = 0; rowIndex < board.Length; ++rowIndex) {
            rowsVisited[rowIndex] = new bool[board[rowIndex].Length];
        }
        
        // Start at the root node and explore as far as possible along each branch
        for (int rowIndex = 0; rowIndex < board.Length; ++rowIndex) {
            for (int colIndex = 0; colIndex < board[rowIndex].Length; ++colIndex) {
                if (DFS(board, rowIndex, colIndex, 0, word, rowsVisited)) {
                    return true;                    
                }
            }
        }
        return false;
    }
    
    bool DFS(char[][] board, int row, int col, int searchIndex, string word, bool[][] rowsVisited) {
        // Make sure the search paramaters are in bounds
        if (searchIndex >= word.Length) {
            return true;            
        }
        if (row < 0 || row >= board.Length || col < 0 || col >= board[row].Length) {
            return false;            
        }       
        if (rowsVisited[row][col]) {
            return false;            
        } 
        if (board[row][col] != word[searchIndex]) {
            return false;            
        }        
        
        // Mark that this row has been visited
        rowsVisited[row][col] = true;
        
        var searchResult = 
            // Search left
            DFS(board, row, col - 1, searchIndex + 1, word, rowsVisited) ||
            
            // Search right
            DFS(board, row, col + 1, searchIndex + 1, word, rowsVisited) ||
            
            // Search top
            DFS(board, row - 1, col, searchIndex + 1, word, rowsVisited) ||
            
            // Search bottom
            DFS(board, row + 1, col, searchIndex + 1, word, rowsVisited);
        
        // Unmark that this row has been visited
        rowsVisited[row][col] = false;
        
        return searchResult;
    }
}