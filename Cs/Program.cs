using System;
using System.Diagnostics;

namespace Cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw;

            Console.WriteLine("Graph List");

            GraphList graphList = new GraphList();
            //graphList.showAdjacencyList();

            Console.WriteLine("\nDijkstra:");
            for (int i = 0; i < 10; i++)
            {
                graphList.clearDistAndVisited();

                sw = Stopwatch.StartNew();
                graphList.dijkstra();
                sw.Stop();
                var elapsedTime = sw.Elapsed.TotalMilliseconds;
                Console.WriteLine("Elapsed time: " + elapsedTime);
            }

            //graphList.showDist();
            Console.WriteLine("\nBellman-Ford:");
            for (int i = 0; i < 10; i++)
            {
                graphList.clearDistAndVisited();

                sw = Stopwatch.StartNew();
                graphList.bellmanFord();
                sw.Stop();
                var elapsedTime = sw.ElapsedMilliseconds;
                Console.WriteLine("Elapsed time: " + elapsedTime);
            }
            Console.WriteLine("\nFloyd-Warshall:");
            for (int i = 0; i < 10; i++)
            {
                graphList.clearDistAndVisited();

                sw = Stopwatch.StartNew();
                graphList.floydWarshall();
                sw.Stop();
                var elapsedTime = sw.Elapsed.TotalMilliseconds;
                Console.WriteLine("Elapsed time: " + elapsedTime);
            }

            Console.WriteLine("\nGraph Matrix");

            GraphMatrix graphMatrix = new GraphMatrix();
            //graphMatrix.showAdjacencyMatrix();

            Console.WriteLine("\nDijkstra:");
            for (int i = 0; i < 10; i++)
            {
                graphMatrix.clearDistAndVisited();

                sw = Stopwatch.StartNew();
                graphMatrix.dijkstra();
                sw.Stop();
                var elapsedTime = sw.Elapsed.TotalMilliseconds;
                Console.WriteLine("Elapsed time: " + elapsedTime);
            }

            //graphList.showDist();
            Console.WriteLine("\nBellman-Ford:");
            for (int i = 0; i < 10; i++)
            {
                graphMatrix.clearDistAndVisited();

                sw = Stopwatch.StartNew();
                graphMatrix.bellmanFord();
                sw.Stop();
                var elapsedTime = sw.Elapsed.TotalMilliseconds;
                Console.WriteLine("Elapsed time: " + elapsedTime);
            }
            Console.WriteLine("\nFloyd-Warshall:");
            for (int i = 0; i < 10; i++)
            {
                graphMatrix.clearDistAndVisited();

                sw = Stopwatch.StartNew();
                graphMatrix.floydWarshall();
                sw.Stop();
                var elapsedTime = sw.Elapsed.TotalMilliseconds;
                Console.WriteLine("Elapsed time: " + elapsedTime);
            }

        }
    }
}
