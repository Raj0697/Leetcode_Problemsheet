using System;
using System.Collections.Generic;

public class Solution {
    // Optimized Find with path compression
    private int Find(Dictionary<int, int> parent, int x) {
        if (!parent.ContainsKey(x)) parent[x] = x;
        if (parent[x] != x) parent[x] = Find(parent, parent[x]);
        return parent[x];
    }

    // Optimized Union by rank
    private void Union(Dictionary<int, int> parent, int x, int y) {
        int rootX = Find(parent, x);
        int rootY = Find(parent, y);
        if (rootX != rootY) parent[rootX] = rootY;
    }

    public int[][] MatrixRankTransform(int[][] matrix) {
        int m = matrix.Length;
        int n = matrix[0].Length;

        // Initialize Union-Find structure for each matrix value
        var valueToParent = new Dictionary<int, Dictionary<int, int>>();

        // Union rows and columns
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                int value = matrix[i][j];
                if (!valueToParent.ContainsKey(value)) 
                    valueToParent[value] = new Dictionary<int, int>();
                Union(valueToParent[value], i, ~j);
            }
        }

        // Collect positions grouped by value and their connected components
        var groupedValues = new SortedDictionary<int, Dictionary<int, List<int[]>>>();
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                int value = matrix[i][j];
                if (!groupedValues.ContainsKey(value)) 
                    groupedValues[value] = new Dictionary<int, List<int[]>>();
                int root = Find(valueToParent[value], i);
                if (!groupedValues[value].ContainsKey(root)) 
                    groupedValues[value][root] = new List<int[]>();
                groupedValues[value][root].Add(new[] { i, j });
            }
        }

        // Initialize result matrix and rank trackers
        var result = new int[m][];
        for (int i = 0; i < m; i++) result[i] = new int[n];
        var rowMaxRank = new int[m];
        var colMaxRank = new int[n];

        // Assign ranks to each group of connected components
        foreach (var kvp in groupedValues) {
            foreach (var component in kvp.Value) {
                int rank = 1;
                foreach (var pos in component.Value) {
                    rank = Math.Max(rank, Math.Max(rowMaxRank[pos[0]], colMaxRank[pos[1]]) + 1);
                }
                foreach (var pos in component.Value) {
                    result[pos[0]][pos[1]] = rank;
                    rowMaxRank[pos[0]] = Math.Max(rowMaxRank[pos[0]], rank);
                    colMaxRank[pos[1]] = Math.Max(colMaxRank[pos[1]], rank);
                }
            }
        }

        return result;
    }
}