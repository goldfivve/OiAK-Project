using System;
using System.Collections.Generic;

namespace Cs
{
    public class GraphMatrix
    {
        private int verticesNumber, edgesNumber, startingVertex;
        int INF = Int32.MaxValue;

        List<List<int>> adjacencyMatrix;

        int[] dist; //put those structures into algo funtions?S
        bool[] visited;

        PriorityQueue<Pair> priorityQueue;

        public GraphMatrix()
        {
            createAdjacencyMatrix();

            dist = new int[verticesNumber + 1];
            visited = new bool[verticesNumber + 1];

            for (int i = 0; i <= verticesNumber; i++)
            {
                dist[i] = INF;
                visited[i] = false;
            }

            //priorityQueue = new PriorityQueue<Pair>();

            Console.WriteLine(verticesNumber + " " + edgesNumber);

        }

        private void createAdjacencyMatrix()
        {

            bool firstLine = true;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"graph_simple.txt");

            while ((line = file.ReadLine()) != null)
            {
                string[] splited = line.Split(' ');

                if (firstLine)
                {
                    verticesNumber = Int32.Parse(splited[0]);
                    edgesNumber = Int32.Parse(splited[1]);
                    startingVertex = Int32.Parse(splited[2]);
                    firstLine = false;

                    adjacencyMatrix = new List<List<int>>(verticesNumber + 1);

                    for (int i = 0; i <= verticesNumber; i++)
                    {
                        adjacencyMatrix.Add(new List<int>(verticesNumber + 1));
                    }
                    continue;
                }

                for (int i = 0; i <= verticesNumber; i++)
                {
                    for (int j = 0; j <= verticesNumber; j++)
                    {
                        adjacencyMatrix[i].Add(INF);
                    }
                }


                int firstVertex = Int32.Parse(splited[0]);
                int secondVertex = Int32.Parse(splited[1]);
                int edgeWeight = Int32.Parse(splited[2]);

                Console.WriteLine("edge: " + firstVertex + " " + secondVertex + " " + edgeWeight);
                adjacencyMatrix[firstVertex][secondVertex] = edgeWeight;
                adjacencyMatrix[secondVertex][firstVertex] = edgeWeight;
            }

            file.Close();
        }

        public void clearDistAndVisited()
        {
            for (int i = 0; i <= verticesNumber; i++)
            {
                dist[i] = INF;
                visited[i] = false;
            }
        }

        public void dijkstra()
        {
            dist[startingVertex] = 0;  //distance from startingVertex to itself is 0
            Pair p = new Pair(1, 1);
            priorityQueue.add(new Pair(startingVertex, 0));

            while (!priorityQueue.isEmpty())
            {
                int u = (priorityQueue.poll()).second;

                if (visited[u])
                {
                    continue; //if this vertex is already visited, skip the rest of the loop
                }

                visited[u] = true;

                for (int i = 1; i < adjacencyMatrix[u].Capacity; i++)
                {
                    int v = i;
                    int c = adjacencyMatrix[u][i];

                    if (dist[v] > dist[u] + c)
                    {
                        dist[v] = dist[u] + c;
                        priorityQueue.add(new Pair(v, dist[v]));
                    }
                }
            }
        }

        public void BellmanFord()
        {
            return;
        }

        public void FloydWarshall()
        {
            return;
        }

        public void showDist()
        {
            for (int i = 1; i <= verticesNumber; i++)
            {
                Console.WriteLine(dist[i]);
            }
        }

        public void showAdjacencyMatrix()
        {
            for (int i = 1; i <= verticesNumber; i++)
            {
                Console.Write(i + ": ");
                for (int j = 0; j <= verticesNumber; j++)
                {
                    if (adjacencyMatrix[i][j] != INF)
                    {
                        Console.Write(j + " ");
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}