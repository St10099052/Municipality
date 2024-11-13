using System.Collections.Generic;

public class Graph
{
    private Dictionary<int, List<int>> adjList;

    public Graph()
    {
        adjList = new Dictionary<int, List<int>>();
    }

    public void AddDependency(int requestId, int dependsOnId)
    {
        if (!adjList.ContainsKey(requestId))
            adjList[requestId] = new List<int>();

        adjList[requestId].Add(dependsOnId);
    }

    public List<int> GetDependencies(int requestId)
    {
        if (adjList.ContainsKey(requestId))
            return adjList[requestId];

        return new List<int>();
    }
}
