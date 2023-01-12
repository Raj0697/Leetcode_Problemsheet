class Solution(object):
    def countSubTrees(self, n, edges, labels):
        def dfs(root):                                      
		cnt = Counter([labels[root]])
		for u in g[root]:
			g[u].discard(root)
			cnt += dfs(u)   
		ans[root] = cnt[labels[root]]
		return cnt
	g = defaultdict(set)
	for u, v in edges: g[u].add(v); g[v].add(u)
	ans = [0]*n; dfs(0)        
	return ans 