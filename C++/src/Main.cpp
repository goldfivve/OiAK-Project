//
// Created by marta on 2021-04-06.
//

#include <iostream>
#include <cstdio>
#include <vector>
#include <algorithm>
#include <queue>
#include <climits>
#include <chrono>
#include <ratio>
#include <fstream>
#include <sstream>

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
vector<int> predecessor;
vector<vector<int>> dist2D;

priority_queue<vertexPair, vector<vertexPair>, greater<vertexPair> > Q; //priority queue for getting the smallest weight

void createAdjacencyList() {
    int firstVertex, secondVertex, edgeWeight;
    string line;

    //ifstream file("graph3.txt");
    ifstream file("graph_simple.txt");

    getline(file, line);
    stringstream lineStream(line);

    lineStream >> verticesNumber;
    lineStream >> edgesNumber;
    lineStream >> startingVertex;

    adjacencyList.clear();
    dist.clear();
    visited.clear();

    adjacencyList.resize(verticesNumber + 1);
    dist.resize(verticesNumber + 1, INF);
    visited.resize(verticesNumber + 1, false); //all vertices are unvisited at the beginning
    predecessor.resize(verticesNumber + 1, -1);
    dist2D.resize(verticesNumber + 1);
    for (int i = 0; i <= verticesNumber; i++) {
        dist2D[i].resize(verticesNumber + 1, INF);
    }


    while (getline(file, line)) {
        vector<int> lineData;
        stringstream lineStream(line);

        lineStream >> firstVertex;
        lineStream >> secondVertex;
        lineStream >> edgeWeight;

        adjacencyList[firstVertex].push_back(vertexPair(secondVertex, edgeWeight));
        adjacencyList[secondVertex].push_back(
                vertexPair(firstVertex, edgeWeight)); //delete this line if graphs is directed

    }
}

void createAdjacencyMatrix() {
    int firstVertex, secondVertex, edgeWeight;
    string line;

    //ifstream file("graph3.txt");
    ifstream file("graph_simple.txt");

    getline(file, line);
    stringstream lineStream(line);

    lineStream >> verticesNumber;
    lineStream >> edgesNumber;
    lineStream >> startingVertex;

    adjacencyList.clear();
    dist.clear();
    visited.clear();

    adjacencyMatrix.resize(verticesNumber + 1);
    for (int i = 0; i <= verticesNumber; i++) {
        adjacencyMatrix[i].resize(verticesNumber + 1, INF);
    }
    dist.resize(verticesNumber + 1, INF);
    visited.resize(verticesNumber + 1, false); //all vertices are unvisited at the beginning
    predecessor.resize(verticesNumber + 1, -1);
    dist2D.resize(verticesNumber + 1);
    for (int i = 0; i <= verticesNumber; i++) {
        dist2D[i].resize(verticesNumber + 1, INF);
    }

    while (getline(file, line)) {
        vector<int> lineData;
        stringstream lineStream(line);

        lineStream >> firstVertex;
        lineStream >> secondVertex;
        lineStream >> edgeWeight;

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
            if (adjacencyMatrix[u][i] == INF) {
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

void bellmanFordOnAdjacencyList() {
    dist[startingVertex] = 0;
    int v, w;
    for (int k = 0; k < verticesNumber; k++) {
        for (int u = 1; u <= verticesNumber; u++) {
            for (int i = 0; i < adjacencyList[u].size(); i++) {
                v = adjacencyList[u][i].first;
                w = adjacencyList[u][i].second;
                if (dist[u] + w < dist[v]) {
                    dist[v] = dist[u] + w;
                    predecessor[v] = u;
                }
            }
        }
    }
}

void bellmanFordOnAdjacencyMatrix() {
    dist[startingVertex] = 0;
    int w;
    for (int k = 0; k < verticesNumber; k++) {
        for (int u = 1; u <= verticesNumber; u++) {
            for (int v = 1; v <= verticesNumber; v++) {
                w = adjacencyMatrix[u][v];
                if(w == INF){
                    continue;
                }
                if (dist[u] + w < dist[v]) {
                    dist[v] = dist[u] + w;
                    predecessor[v] = u;
                }
            }
        }
    }
}

void floydWarshallOnAdjacencyList() {
    int v;
    for (int u = 1; u <= verticesNumber; u++) {
        for (int i = 0; i < adjacencyList[u].size(); i++) {
            v = adjacencyList[u][i].first;
            dist2D[u][v] = adjacencyList[u][i].second;
        }
    }

    for (int v = 1; v <= verticesNumber; v++) {
        dist2D[v][v] = 0;
    }

    for (int k = 1; k <= verticesNumber; k++) {
        for (int i = 1; i <= verticesNumber; i++) {
            for (int j = 1; j <= verticesNumber; j++) {
                if (dist2D[i][j] > dist2D[i][k] + dist2D[k][j]) {
                    dist2D[i][j] = dist2D[i][k] + dist2D[k][j];
                }
            }
        }
    }
}

void floydWarshallOnAdjacencyMatrix() {
    for (int u = 1; u <= verticesNumber; u++) {
        for (int v = 1; v <= verticesNumber; v++) {
            dist2D[u][v] = adjacencyMatrix[u][v];
        }
    }

    for (int v = 1; v <= verticesNumber; v++) {
        dist2D[v][v] = 0;
    }

    for (int k = 1; k <= verticesNumber; k++) {
        for (int i = 1; i <= verticesNumber; i++) {
            for (int j = 1; j <= verticesNumber; j++) {
                if (dist2D[i][j] > dist2D[i][k] + dist2D[k][j]) {
                    dist2D[i][j] = dist2D[i][k] + dist2D[k][j];
                }
            }
        }
    }
}

void clearDistAndVisited() {
    dist.clear();
    dist.resize(verticesNumber + 1, INF);

    visited.clear();
    visited.resize(verticesNumber + 1, false);

    predecessor.clear();
    predecessor.resize(verticesNumber + 1, -1);

    dist2D.clear();
    dist2D.resize(verticesNumber + 1);
    for (int i = 0; i <= verticesNumber; i++) {
        dist2D[i].resize(verticesNumber + 1, INF);
    }
}

void createRandomGraph() {
    ofstream myfile("graph3.txt");
    if (myfile.is_open()) {
        srand(time(nullptr));
        int n, m, s, counter, maxEdges;
        n = 2000;
        maxEdges = (n * (n - 1) / 2) / 3;
        m = rand() % maxEdges + 1;
        counter = m;
        s = 1;
        myfile << n << " " << m << " " << s << endl;

        while (counter) {
            for (int i = 1; i <= n; i++) {
                for (int j = i + 1; j <= n; j++) {
                    int b = rand() % 10;
                    if (b > 3) {
                        continue;
                    }
                    if (counter == 0) {
                        break;
                    }
                    counter--;
                    int w = rand() % 100 + 1;
                    myfile << i << " " << j << " " << w << endl;

                }
                if (counter == 0) {
                    break;
                }
            }
        }

        myfile.close();
    } else {
        printf("Doesn't work...\n");
    }
}


int main() {
/*
    createRandomGraph();

    createAdjacencyList();
    for (int i = 0; i < 10; i++) {
        clearDistAndVisited();

        auto start = chrono::high_resolution_clock::now();
        dijkstraOnAdjacencyList();
        auto end = chrono::high_resolution_clock::now();
        chrono::duration<double, std::milli> elapsed_seconds = end - start;
        cout << "Elapsed time for Adjacency List: " << elapsed_seconds.count() << " ms\n";
    }

    cout << endl;

    createAdjacencyMatrix();
    /*
    for (int i = 0; i < 10; i++) {
        clearDistAndVisited();

        auto start = std::chrono::high_resolution_clock::now();
        dijkstraOnAdjacencyMatrix();
        auto end = std::chrono::high_resolution_clock::now();
        chrono::duration<double, std::milli> elapsed_seconds = end - start;
        cout << "Elapsed time for Adjacency Matrix: " << elapsed_seconds.count() << " ms\n";
    }
*/
    cout << verticesNumber << endl;
    clearDistAndVisited();
    createAdjacencyList();

    bellmanFordOnAdjacencyList();
    for (int i = 1; i < dist.size(); i++) {
        cout << dist[i] << " ";
    }
    cout << endl;
    for (int i = 1; i < predecessor.size(); i++) {
        cout << predecessor[i] << " ";
    }
    cout << endl;

    cout << endl;
    clearDistAndVisited();
    createAdjacencyMatrix();

    bellmanFordOnAdjacencyMatrix();
    for (int i = 1; i < dist.size(); i++) {
        cout << dist[i] << " ";
    }
    cout << endl;
    for (int i = 1; i < predecessor.size(); i++) {
        cout << predecessor[i] << " ";
    }
    cout << endl;


    return 0;
}

/*
 Simple graph:

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