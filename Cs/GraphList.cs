using System;
using System.Collections.Generic;
using Medallion.Collections;

namespace Cs
{
    public class GraphList
    {
        private int verticesNumber, edgesNumber, startingVertex;
        int INF = Int32.MaxValue;

        List<List<Pair>> adjacencyList;

        int[] dist;
        bool[] visited;
        int[] predecessor;
        int[][] dist2D;

        PriorityQueue<Pair> priorityQueue;

        public GraphList(int size)
        {
            createAdjacencyList(size);

            dist = new int[verticesNumber + 1];
            visited = new bool[verticesNumber + 1];
            predecessor = new int[verticesNumber + 1];
            dist2D = new int[verticesNumber + 1][];

            for (int i = 0; i <= verticesNumber; i++)
            {
                dist[i] = INF;
                visited[i] = false;
                predecessor[i] = -1;
                dist2D[i] = new int[verticesNumber + 1];
                for (int j = 0; j <= verticesNumber; j++)
                {
                    dist2D[i][j] = INF;
                }
            }

            priorityQueue = new PriorityQueue<Pair>();
        }

        private void createAdjacencyList(int size)
        {

            bool firstLine = true;
            string line;

            // Read the file and display it line by line.  
            //System.IO.StreamReader file =
            //    new System.IO.StreamReader(@"graph_simple.txt");
            String name = $"../../../graph_{size}.txt";

            System.IO.StreamReader file =
                            new System.IO.StreamReader(@name);
            while ((line = file.ReadLine()) != null)
            {
                string[] splited = line.Split(' ');

                if (firstLine)
                {
                    verticesNumber = Int32.Parse(splited[0]);
                    edgesNumber = Int32.Parse(splited[1]);
                    startingVertex = Int32.Parse(splited[2]);
                    firstLine = false;

                    adjacencyList = new List<List<Pair>>(verticesNumber + 1);
                    for (int i = 0; i <= verticesNumber; i++)
                    {
                        adjacencyList.Add(new List<Pair>());
                    }
                    continue;
                }

                int firstVertex = Int32.Parse(splited[0]);
                int secondVertex = Int32.Parse(splited[1]);
                int edgeWeight = Int32.Parse(splited[2]);

                adjacencyList[firstVertex].Add(new Pair(secondVertex, edgeWeight));
                adjacencyList[secondVertex].Add(new Pair(firstVertex, edgeWeight));
            }

            file.Close();
        }

        public void clearDistAndVisited()
        {
            for (int i = 0; i <= verticesNumber; i++)
            {
                dist[i] = INF;
                visited[i] = false;
                predecessor[i] = -1;
                for (int j=0; j<=verticesNumber; j++) {
                    dist2D[i][j] = INF;
                }
            }
        }

        public void dijkstra()
        {
            dist[startingVertex] = 0;  //distance from startingVertex to itself is 0
         
            priorityQueue.Enqueue(new Pair(startingVertex, 0));

            while (priorityQueue.Count != 0)
            {
                int u = (priorityQueue.Dequeue()).first;

                if (visited[u])
                {
                    continue; //if this vertex is already visited, skip the rest of the loop
                }

                visited[u] = true;

                for (int i = 0; i < adjacencyList[u].Count; i++)
                {
                    int v = adjacencyList[u][i].first;
                    int c = adjacencyList[u][i].second;

                    if (dist[v] > dist[u] + c)
                    {
                        dist[v] = dist[u] + c;
                        priorityQueue.Enqueue(new Pair(v, dist[v]));
                    }
                }
            }
        }
        public void bellmanFord()
        {
            dist[startingVertex] = 0;
            int v, w;
            for (int k = 0; k < verticesNumber; k++)
            {
                for (int u = 1; u <= verticesNumber; u++)
                {
                    for (int i = 0; i < adjacencyList[u].Count; i++)
                    {
                        v = adjacencyList[u][i].first;
                        w = adjacencyList[u][i].second;
                        if (dist[u] + w < dist[v])
                        {
                            dist[v] = dist[u] + w;
                            predecessor[v] = u;
                        }
                    }
                }
            }
        }

        public void floydWarshall()
        {

            for (int u = 1; u <= verticesNumber; u++)
            {
                for (int i = 0; i < adjacencyList[u].Count; i++)
                {
                    int v = adjacencyList[u][i].first;
                    dist2D[u][v] = adjacencyList[u][i].second;
                }
            }

            for (int v = 1; v <= verticesNumber; v++)
            {
                dist2D[v][v] = 0;
            }

            for (int k = 1; k <= verticesNumber; k++)
            {
                for (int i = 1; i <= verticesNumber; i++)
                {
                    for (int j = 1; j <= verticesNumber; j++)
                    {
                        if (dist2D[i][j] > dist2D[i][k] + dist2D[k][j])
                        {
                            dist2D[i][j] = dist2D[i][k] + dist2D[k][j];
                        }
                    }
                }
            }
        }

        public void showDist()
        {
            for (int i = 1; i <= verticesNumber; i++)
            {
                Console.WriteLine(dist[i]);
            }
        }

        public void showDist2D()
        {
            for (int i = 1; i <= verticesNumber; i++)
            {
                for (int j = 1; j <= verticesNumber; j++)
                {
                    Console.Write(dist2D[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void showAdjacencyList()
        {
            for (int i = 1; i <= verticesNumber; i++)
            {
                Console.Write(i + ": ");
                for (int j = 0; j < adjacencyList[i].Count; j++)
                {
                    Console.Write(adjacencyList[i][j].first + " ");
                }
                Console.WriteLine("");
            }
        }
    }
}