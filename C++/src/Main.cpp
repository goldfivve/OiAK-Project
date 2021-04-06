//
// Created by marta on 2021-04-06.
//

#include <iostream>
#include <cstdio>
#include <vector>
#include <algorithm>
#include <queue>
#include <climits>

#define vertex first
#define weight second
using namespace std;

int verticesNumber, edgesNumber, firstVertex, secondVertex, edgeWeight;
typedef pair<int, int> vertexPair;
const int INF = INT_MAX;    //constant infinity

vector<vector<vertexPair> > graph; //adjacency list
vector<int> dist;  //distances
vector<bool> visited; //to know if the vertex is already visited: visited[v] = false -> not visited, true -> visited
priority_queue<vertexPair, vector<vertexPair>, greater<vertexPair> > Q; //priority queue for getting the smallest weight

int main() {
    scanf("%d%d", &verticesNumber, &edgesNumber); //TODO: reading graphs from a file

    graph.resize(verticesNumber + 1);
    dist.resize(verticesNumber + 1, INF);
    visited.resize(verticesNumber + 1, false); //all vertices are unvisited at the beginning

    for (int i = 0; i < edgesNumber; i++) {
        scanf("%d%d%d", &firstVertex, &secondVertex, &edgeWeight);
        graph[firstVertex].push_back(vertexPair(secondVertex, edgeWeight));
        graph[secondVertex].push_back(vertexPair(firstVertex, edgeWeight)); //delete this line if graphs is directed
    }

    int startingVertex = 1;
    dist[startingVertex] = 0;  //distance from startingVertex to itself is 0

    Q.push(vertexPair(0, startingVertex));

    while (!Q.empty()) {
        int u = (Q.top()).weight;
        Q.pop();

        if (visited[u] == true) {
            continue; //if this vertex is already visited, skip the rest of the loop
        }

        visited[u] = true;

        for (int i = 0; i < graph[u].size(); i++) {
            int v = graph[u][i].vertex;
            int c = graph[u][i].weight;

            if (dist[v] > dist[u] + c) {
                dist[v] = dist[u] + c;
                Q.push(vertexPair(dist[v], v));
            }
        }
    }

    for (int i=1; i<=verticesNumber; i++)
    {
        printf("Distance from startingVertex %d to %d is %d\n.", startingVertex, i, dist[i]);
    }

    return 0;
}

