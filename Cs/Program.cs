using System;

namespace Cs
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphList graphList = new GraphList();
            graphList.showAdjacencyList();

            GraphMatrix graphMatrix = new GraphMatrix();
            graphMatrix.showAdjacencyMatrix();
        }
    }
}
