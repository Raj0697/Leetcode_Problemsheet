func closestMeetingNode(edges []int, node1 int, node2 int) int {
    return bellmanFord(edges, node1,node2)
}
func bellmanFord(edges []int, node1 int, node2 int) int {
    bf1 := calculateBellmanFord(node1, edges)
    bf2 := calculateBellmanFord(node2,edges)
    
	//max Integer
    minPath := 1 << 31
    result := -1
    for i:=range bf1 {
        if bf1[i] == 1 << 31 || bf2[i] == 1 << 31{
            continue
        }
        
        v := max(bf1[i],bf2[i])
        if v < minPath{
            minPath = v
            result = i
        }
    }
    
    return result
}

func calculateBellmanFord(root int, edges []int) []int{
    distances := make([]int, len(edges))
    for i:=range distances {
        distances[i]=1 << 31
    }
    distances[root]=0
    
    node := root
    for edges[node] != -1 {
        next := edges[node]
        if distances[next] > distances[node] + 1 {
            distances[next]=distances[node] + 1
            node = next
        }else{
            break
        }
    }
    
    return distances
}

func max(a,b int) int {
    if a > b {
        return a
    }
    
    return b
}