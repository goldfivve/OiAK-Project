package src;

public class Main {

    public static void main(String[] args) {
        System.out.println("Graph List");

        GraphList graphList = new GraphList();
//        graphList.showAdjacencyList();

        System.out.println("\nDijkstra:");
        for(int i=0; i<10; i++) {
            graphList.clearDistAndVisited();

            long startTime = System.nanoTime();
            graphList.dijkstra();
            long elapsedTime = System.nanoTime() - startTime;
            System.out.println("Elapsed time: " + elapsedTime);
        }

        //graphList.showDist();
        System.out.println("\nBellman-Ford:");
        for(int i=0; i<10; i++) {
            graphList.clearDistAndVisited();

            long startTime = System.nanoTime();
            graphList.bellmanFord();
            long elapsedTime = System.nanoTime() - startTime;
            System.out.println("Elapsed time: " + elapsedTime);
        }
        System.out.println("\nFloyd-Warshall:");
        for(int i=0; i<10; i++) {
            graphList.clearDistAndVisited();

            long startTime = System.nanoTime();
            graphList.floydWarshall();
            long elapsedTime = System.nanoTime() - startTime;
            System.out.println("Elapsed time: " + elapsedTime);
        }

        System.out.println("\nGraph Matrix");

        GraphMatrix graphMatrix = new GraphMatrix();
//        graphMatrix.showAdjacencyMatrix();

        System.out.println("\nDijkstra:");
        for(int i=0; i<10; i++) {
            graphMatrix.clearDistAndVisited();

            long startTime = System.nanoTime();
            graphMatrix.dijkstra();
            long elapsedTime = System.nanoTime() - startTime;
            System.out.println("Elapsed time: " + elapsedTime);
        }

        //graphList.showDist();
        System.out.println("\nBellman-Ford:");
        for(int i=0; i<10; i++) {
            graphMatrix.clearDistAndVisited();

            long startTime = System.nanoTime();
            graphMatrix.bellmanFord();
            long elapsedTime = System.nanoTime() - startTime;
            System.out.println("Elapsed time: " + elapsedTime);
        }
        System.out.println("\nFloyd-Warshall:");
        for(int i=0; i<10; i++) {
            graphMatrix.clearDistAndVisited();

            long startTime = System.nanoTime();
            graphMatrix.floydWarshall();
            long elapsedTime = System.nanoTime() - startTime;
            System.out.println("Elapsed time: " + elapsedTime);
        }

    }
}
