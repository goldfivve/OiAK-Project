package src;

public class Main {

    public static void main(String[] args) {
        System.out.println("Graph List");

        GraphList graphList = new GraphList();
        graphList.showAdjacencyList();
        System.out.println("\nDijkstra:");
        graphList.dijkstra();
        graphList.showDist();
        graphList.clearDistAndVisited();
        System.out.println("\nBellman-Ford:");
        graphList.bellmanFord();
        graphList.showDist();
        graphList.clearDistAndVisited();
        System.out.println("\nFloyd-Warshall:");
        graphList.floydWarshall();
        graphList.showDist2D();

        System.out.println("\nGraph Matrix");

        GraphMatrix graphMatrix = new GraphMatrix();
        graphMatrix.showAdjacencyMatrix();
        System.out.println("\nDijkstra:");
        graphMatrix.dijkstra();
        graphMatrix.showDist();
        graphMatrix.clearDistAndVisited();
        System.out.println("\nBellman-Ford:");
        graphMatrix.bellmanFord();
        graphMatrix.showDist();
        graphMatrix.clearDistAndVisited();
        System.out.println("\nFloyd-Warshall:");
        graphMatrix.floydWarshall();
        graphMatrix.showDist2D();

    }
}
