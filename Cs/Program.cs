using System;
using System.Diagnostics;

namespace Cs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = {500, 750, 1000, 1250, 1500, 1750, 2000, 2250, 2500};

        
        for(int i=0; i<9; i++) {
            Console.WriteLine("utworz (wpisz jakis znak i enter)");
            Console.ReadLine();

            GraphList graphList = new GraphList(sizes[i]);
            graphList.clearDistAndVisited();

            Console.WriteLine("lista - dijkstra " + sizes[i] + " (wpisz jakis znak i enter)");
            Console.ReadLine();

            graphList.dijkstra();

        }

        for(int i=0; i<9; i++) {
            Console.WriteLine("utworz (wpisz jakis znak i enter)");
            Console.ReadLine();

            GraphList graphList = new GraphList(sizes[i]);
            graphList.clearDistAndVisited();

            Console.WriteLine("lista - bellmanFord " + sizes[i] + " (wpisz jakis znak i enter)");
            Console.ReadLine();

            graphList.bellmanFord();
        }

        for(int i=0; i<9; i++) {
            Console.WriteLine("utworz (wpisz jakis znak i enter)");
            Console.ReadLine();

            GraphList graphList = new GraphList(sizes[i]);
            graphList.clearDistAndVisited();

            Console.WriteLine("lista - floydWarshall " + sizes[i] + " (wpisz jakis znak i enter)");
            Console.ReadLine();

            graphList.floydWarshall();
        }

        for(int i=0; i<9; i++) {
            Console.WriteLine("utworz (wpisz jakis znak i enter)");
            Console.ReadLine();

            GraphMatrix graphMatrix = new GraphMatrix(sizes[i]);
            graphMatrix.clearDistAndVisited();

            Console.WriteLine("macierz - dijkstra " + sizes[i] + " (wpisz jakis znak i enter)");
            Console.ReadLine();

            graphMatrix.dijkstra();
        }

        for(int i=0; i<9; i++) {
            Console.WriteLine("utworz (wpisz jakis znak i enter)");
            Console.ReadLine();

            GraphMatrix graphMatrix = new GraphMatrix(sizes[i]);
            graphMatrix.clearDistAndVisited();

            Console.WriteLine("macierz - bellmanFord " + sizes[i] + " (wpisz jakis znak i enter)");
            Console.ReadLine();

            graphMatrix.bellmanFord();
        }

        for(int i=0; i<9; i++) {
            Console.WriteLine("utworz (wpisz jakis znak i enter)");
            Console.ReadLine();

            GraphMatrix graphMatrix = new GraphMatrix(sizes[i]);
            graphMatrix.clearDistAndVisited();

            Console.WriteLine("macierz - floydWarshall " + sizes[i] + " (wpisz jakis znak i enter)");
            Console.ReadLine();

            graphMatrix.floydWarshall();
        }

        }
    }
}

// Stopwatch sw;

            // Console.WriteLine("Graph List");

            // GraphList graphList = new GraphList();
            // //graphList.showAdjacencyList();

            // Console.WriteLine("\nDijkstra:");
            // for (int i = 0; i < 10; i++)
            // {
            //     graphList.clearDistAndVisited();

            //     sw = Stopwatch.StartNew();
            //     graphList.dijkstra();
            //     sw.Stop();
            //     var elapsedTime = sw.Elapsed.TotalMilliseconds;
            //     Console.WriteLine("Elapsed time: " + elapsedTime);
            // }

            // //graphList.showDist();
            // Console.WriteLine("\nBellman-Ford:");
            // for (int i = 0; i < 10; i++)
            // {
            //     graphList.clearDistAndVisited();

            //     sw = Stopwatch.StartNew();
            //     graphList.bellmanFord();
            //     sw.Stop();
            //     var elapsedTime = sw.ElapsedMilliseconds;
            //     Console.WriteLine("Elapsed time: " + elapsedTime);
            // }
            // Console.WriteLine("\nFloyd-Warshall:");
            // for (int i = 0; i < 10; i++)
            // {
            //     graphList.clearDistAndVisited();

            //     sw = Stopwatch.StartNew();
            //     graphList.floydWarshall();
            //     sw.Stop();
            //     var elapsedTime = sw.Elapsed.TotalMilliseconds;
            //     Console.WriteLine("Elapsed time: " + elapsedTime);
            // }

            // Console.WriteLine("\nGraph Matrix");

            // GraphMatrix graphMatrix = new GraphMatrix();
            // //graphMatrix.showAdjacencyMatrix();

            // Console.WriteLine("\nDijkstra:");
            // for (int i = 0; i < 10; i++)
            // {
            //     graphMatrix.clearDistAndVisited();

            //     sw = Stopwatch.StartNew();
            //     graphMatrix.dijkstra();
            //     sw.Stop();
            //     var elapsedTime = sw.Elapsed.TotalMilliseconds;
            //     Console.WriteLine("Elapsed time: " + elapsedTime);
            // }

            // //graphList.showDist();
            // Console.WriteLine("\nBellman-Ford:");
            // for (int i = 0; i < 10; i++)
            // {
            //     graphMatrix.clearDistAndVisited();

            //     sw = Stopwatch.StartNew();
            //     graphMatrix.bellmanFord();
            //     sw.Stop();
            //     var elapsedTime = sw.Elapsed.TotalMilliseconds;
            //     Console.WriteLine("Elapsed time: " + elapsedTime);
            // }
            // Console.WriteLine("\nFloyd-Warshall:");
            // for (int i = 0; i < 10; i++)
            // {
            //     graphMatrix.clearDistAndVisited();

            //     sw = Stopwatch.StartNew();
            //     graphMatrix.floydWarshall();
            //     sw.Stop();
            //     var elapsedTime = sw.Elapsed.TotalMilliseconds;
            //     Console.WriteLine("Elapsed time: " + elapsedTime);
            // }