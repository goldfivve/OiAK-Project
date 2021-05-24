package src;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        int[] sizes = {500, 750, 1000, 1250, 1500, 1750, 2000, 2250, 2500};

        Scanner myObj = new Scanner(System.in);  // Create a Scanner object
        String trash;

        for(int i=0; i<9; i++) {
            System.out.println("utworz (wpisz jakis znak i enter)");
            trash = myObj.nextLine();  // Read user input

            GraphList graphList = new GraphList(sizes[i]);
            graphList.clearDistAndVisited();

            System.out.println("lista - dijkstra " + sizes[i] + " (wpisz jakis znak i enter)");
            trash = myObj.nextLine();  // Read user input

            graphList.dijkstra();

        }

        for(int i=0; i<9; i++) {
            System.out.println("utworz (wpisz jakis znak i enter)");
            trash = myObj.nextLine();  // Read user input

            GraphList graphList = new GraphList(sizes[i]);
            graphList.clearDistAndVisited();

            System.out.println("lista - bellmanFord " + sizes[i] + " (wpisz jakis znak i enter)");
            trash = myObj.nextLine();  // Read user input

            graphList.bellmanFord();
        }

        for(int i=0; i<9; i++) {
            System.out.println("utworz (wpisz jakis znak i enter)");
            trash = myObj.nextLine();  // Read user input

            GraphList graphList = new GraphList(sizes[i]);
            graphList.clearDistAndVisited();

            System.out.println("lista - floydWarshall " + sizes[i] + " (wpisz jakis znak i enter)");
            trash = myObj.nextLine();  // Read user input

            graphList.floydWarshall();
        }

        for(int i=0; i<9; i++) {
            System.out.println("utworz (wpisz jakis znak i enter)");
            trash = myObj.nextLine();  // Read user input

            GraphMatrix graphMatrix = new GraphMatrix(sizes[i]);
            graphMatrix.clearDistAndVisited();

            System.out.println("macierz - dijkstra " + sizes[i] + " (wpisz jakis znak i enter)");
            trash = myObj.nextLine();  // Read user input

            graphMatrix.dijkstra();
        }

        for(int i=0; i<9; i++) {
            System.out.println("utworz (wpisz jakis znak i enter)");
            trash = myObj.nextLine();  // Read user input

            GraphMatrix graphMatrix = new GraphMatrix(sizes[i]);
            graphMatrix.clearDistAndVisited();

            System.out.println("macierz - bellmanFord " + sizes[i] + " (wpisz jakis znak i enter)");
            trash = myObj.nextLine();  // Read user input

            graphMatrix.bellmanFord();
        }

        for(int i=0; i<9; i++) {
            System.out.println("utworz (wpisz jakis znak i enter)");
            trash = myObj.nextLine();  // Read user input

            GraphMatrix graphMatrix = new GraphMatrix(sizes[i]);
            graphMatrix.clearDistAndVisited();

            System.out.println("macierz - floydWarshall " + sizes[i] + " (wpisz jakis znak i enter)");
            trash = myObj.nextLine();  // Read user input

            graphMatrix.floydWarshall();
        }


        /*        System.out.println("Graph List");

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
        }*/

    }
}
