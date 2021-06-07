using System;
using System.Diagnostics;

namespace Cs
{
    class Program
    {
        static void Main(string[] args)
        {

            int size = 3500;
            
            // Console.WriteLine("utworz (wpisz jakis znak i enter)");
            // Console.ReadLine();
            //
            // GraphList graphList = new GraphList(size);
            // graphList.clearDistAndVisited();
            //
            // Console.WriteLine("lista - dijkstra " + size + " (wpisz jakis znak i enter)");
            // Console.ReadLine();
            //
            // graphList.dijkstra();
            //
            // Console.WriteLine("koniec");


            // Console.WriteLine("utworz (wpisz jakis znak i enter)");
            // Console.ReadLine();
            //
            // GraphList graphList = new GraphList(size);
            // graphList.clearDistAndVisited();
            //
            // Console.WriteLine("lista - bellmanFord " + size + " (wpisz jakis znak i enter)");
            // Console.ReadLine();
            //
            // graphList.bellmanFord();
            //
            // Console.WriteLine("koniec");
            // Console.ReadLine();
            
            
            // Console.WriteLine("utworz (wpisz jakis znak i enter)");
            // Console.ReadLine();
            //
            // GraphList graphList = new GraphList(size);
            // graphList.clearDistAndVisited();
            //
            // Console.WriteLine("lista - floydWarshall " + size + " (wpisz jakis znak i enter)");
            // Console.ReadLine();
            //
            // graphList.floydWarshall();
            // Console.WriteLine("koniec");
            // Console.ReadLine(); 
            
            Console.WriteLine("utworz (wpisz jakis znak i enter)");
            Console.ReadLine();
            
            GraphMatrix graphMatrix = new GraphMatrix(size);
            graphMatrix.clearDistAndVisited();
            
            Console.WriteLine("macierz - dijkstra " + size + " (wpisz jakis znak i enter)");
            Console.ReadLine();
            
            graphMatrix.dijkstra();
            Console.WriteLine("koniec");
            Console.ReadLine();
            
            
            // Console.WriteLine("utworz (wpisz jakis znak i enter)");
            // Console.ReadLine();
            //
            // GraphMatrix graphMatrix = new GraphMatrix(size);
            // graphMatrix.clearDistAndVisited();
            //
            // Console.WriteLine("macierz - bellmanFord " + size + " (wpisz jakis znak i enter)");
            // Console.ReadLine();
            //
            // graphMatrix.bellmanFord();
            // Console.WriteLine("koniec");


            // Console.WriteLine("utworz (wpisz jakis znak i enter)");
            // Console.ReadLine();
            //
            // GraphMatrix graphMatrix = new GraphMatrix(size);
            // graphMatrix.clearDistAndVisited();
            //
            // Console.WriteLine("macierz - floydWarshall " + size + " (wpisz jakis znak i enter)");
            // Console.ReadLine();
            //
            // graphMatrix.floydWarshall();
            // Console.WriteLine("koniec");

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