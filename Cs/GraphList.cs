using System;
using System.Collections.Generic;


namespace Cs
{
    public class GraphList
    {
        private int verticesNumber, edgesNumber, startingVertex;
        int INF = Int32.MaxValue;

        List<List<Pair>> adjacencyList;

        int[] dist;
        bool[] visited;

        PriorityQueue<Pair> priorityQueue;

        public GraphList()
        {
            priorityQueue = new PriorityQueue<Pair>();

            createAdjacencyList();

            dist = new int[verticesNumber + 1];
            visited = new bool[verticesNumber + 1];

            for (int i = 0; i <= verticesNumber; i++)
            {
                dist[i] = INF;
                visited[i] = false;
            }

            priorityQueue = new PriorityQueue<Pair>();

            Console.WriteLine(verticesNumber + " " + edgesNumber);

        }

        private void createAdjacencyList()
        {

            bool firstLine = true;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"graph3.txt");
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
                        adjacencyList[i] = new List<Pair>();
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

                for (int i = 0; i < adjacencyList[u].Capacity; i++)
                {
                    int v = adjacencyList[u][i].second;
                    int c = adjacencyList[u][i].first;

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

        public void showAdjacencyList()
        {
            for (int i = 1; i <= verticesNumber; i++)
            {
                Console.WriteLine(i + ": ");
                for (int j = 0; j < adjacencyList[i].Capacity; j++)
                {
                    Console.WriteLine(adjacencyList[i][j].second + " ");
                }
                Console.WriteLine("");
            }
        }

    }
}