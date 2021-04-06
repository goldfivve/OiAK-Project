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


typedef pair<int, int> vertexPair;
const int INF = INT_MAX;    //constant infinity

int verticesNumber, edgesNumber, startingVertex;

vector<vector<vertexPair> > adjacencyList;
vector<vector<int>> adjacencyMatrix;
vector<int> dist;  //distances
vector<bool> visited; //to know if the vertex is already visited: visited[v] = false -> not visited, true -> visited
priority_queue<vertexPair, vector<vertexPair>, greater<vertexPair> > Q; //priority queue for getting the smallest weight

void createAdjacencyList() {
    int firstVertex, secondVertex, edgeWeight;
    scanf("%d%d%d", &verticesNumber, &edgesNumber, &startingVertex); //TODO: reading graphs from a file

    adjacencyList.clear();
    dist.clear();
    visited.clear();

    adjacencyList.resize(verticesNumber + 1);
    dist.resize(verticesNumber + 1, INF);
    visited.resize(verticesNumber + 1, false); //all vertices are unvisited at the beginning

    for (int i = 0; i < edgesNumber; i++) {
        scanf("%d%d%d", &firstVertex, &secondVertex, &edgeWeight);
        adjacencyList[firstVertex].push_back(vertexPair(secondVertex, edgeWeight));
        adjacencyList[secondVertex].push_back(
                vertexPair(firstVertex, edgeWeight)); //delete this line if graphs is directed
    }
}

void createAdjacencyMatrix() {
    int firstVertex, secondVertex, edgeWeight;
    scanf("%d%d%d", &verticesNumber, &edgesNumber, &startingVertex); //TODO: reading graphs from a file

    adjacencyMatrix.clear();
    dist.clear();
    visited.clear();

    adjacencyMatrix.resize(verticesNumber + 1);
    for (int i = 0; i <= verticesNumber; i++) {
        adjacencyMatrix[i].resize(verticesNumber + 1, INF);
    }
    dist.resize(verticesNumber + 1, INF);
    visited.resize(verticesNumber + 1, false); //all vertices are unvisited at the beginning

    for (int i = 0; i < edgesNumber; i++) {
        scanf("%d%d%d", &firstVertex, &secondVertex, &edgeWeight);
        adjacencyMatrix[firstVertex][secondVertex] = edgeWeight;
        adjacencyMatrix[secondVertex][firstVertex] = edgeWeight; //delete this line if graphs is directed
    }
}

void dijkstraOnAdjacencyList() {
    dist[startingVertex] = 0;  //distance from startingVertex to itself is 0
    Q.push(vertexPair(0, startingVertex));

    while (!Q.empty()) {
        int u = (Q.top()).weight;
        Q.pop();

        if (visited[u] == true) {
            continue; //if this vertex is already visited, skip the rest of the loop
        }

        visited[u] = true;

        for (int i = 0; i < adjacencyList[u].size(); i++) {
            int v = adjacencyList[u][i].vertex;
            int c = adjacencyList[u][i].weight;

            if (dist[v] > dist[u] + c) {
                dist[v] = dist[u] + c;
                Q.push(vertexPair(dist[v], v));
            }
        }
    }
}

void dijkstraOnAdjacencyMatrix() {
    dist[startingVertex] = 0;  //distance from startingVertex to itself is 0
    Q.push(vertexPair(0, startingVertex));

    while (!Q.empty()) {
        int u = (Q.top()).weight;
        Q.pop();

        if (visited[u]) {
            continue; //if this vertex is already visited, skip the rest of the loop
        }

        visited[u] = true;

        for (int i = 0; i < adjacencyMatrix[u].size(); i++) {
            if(adjacencyMatrix[u][i] == INF) {
                continue;
                //if the distance from this vertex to its i-th neighbour is INF, it means there is no i-th neighbour
            }

            int v = i;
            int c = adjacencyMatrix[u][i];

            if (dist[v] > dist[u] + c) {
                dist[v] = dist[u] + c;
                Q.push(vertexPair(dist[v], v));
            }
        }
    }
}

int main() {

    createAdjacencyList();
    dijkstraOnAdjacencyList();

    printf("AdjacencyList:\n");
    for (int i = 1; i <= verticesNumber; i++) {
        printf("Distance from startingVertex %d to %d is %d.\n", startingVertex, i, dist[i]);
    }

    createAdjacencyMatrix();
    dijkstraOnAdjacencyMatrix();

    printf("\nAdjacencyMatrix:\n");
    for (int i = 1; i <= verticesNumber; i++) {
        printf("Distance from startingVertex %d to %d is %d.\n", startingVertex, i, dist[i]);
    }

    return 0;
}

/*
 5 8 1
 1 2 2
 1 3 1
 1 4 7
 1 5 5
 2 4 3
 3 4 2
 3 5 3
 4 5 1
  */