package src;

import javax.xml.namespace.QName;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.PriorityQueue;
import java.util.Scanner;

public class GraphMatrix {
    int verticesNumber, edgesNumber, startingVertex;
    int INF = Integer.MAX_VALUE;
    ArrayList<ArrayList<Integer>> adjacencyMatrix;

    int[] dist;
    boolean[] visited;
    int[] predecessor;
    int[][] dist2D;

    PriorityQueue<Pair> priorityQueue;

    GraphMatrix(int size) {
        priorityQueue = new PriorityQueue<Pair>();

        createAdjacencyMatrix(size);

        dist = new int[verticesNumber + 1];
        visited = new boolean[verticesNumber + 1];
        predecessor = new int[verticesNumber+1];
        dist2D = new int[verticesNumber+1][verticesNumber+1];

        for (int i = 0; i <= verticesNumber; i++) {
            dist[i] = INF;
            visited[i] = false;
            predecessor[i] = -1;
            for(int j=0; j<=verticesNumber; j++) {
                dist2D[i][j] = INF;
            }
        }

        priorityQueue = new
                PriorityQueue<Pair>(edgesNumber, new PairComparator());

        //System.out.println(verticesNumber + " " + edgesNumber);

    }

    private void createAdjacencyMatrix(int size) {
        try {
            //File myObj = new File("graph_simple.txt");
            //File myObj = new File("graph3.txt");
            String name = "graph_" + size + ".txt";
            File myObj = new File(name);
            Scanner myReader = new Scanner(myObj);

            boolean firstLine = true;

            while (myReader.hasNextLine()) {
                String data = myReader.nextLine();

                String[] splited = data.split(" ");

                if (firstLine) {
                    verticesNumber = Integer.parseInt(splited[0]);
                    edgesNumber = Integer.parseInt(splited[1]);
                    startingVertex = Integer.parseInt(splited[2]);
                    firstLine = false;
                    System.out.println(verticesNumber + " " + edgesNumber);
                    adjacencyMatrix = new ArrayList<>(verticesNumber + 1);

                    for (int i = 0; i <= verticesNumber; i++) {
                        ArrayList list = new ArrayList<>(verticesNumber + 1);
                        adjacencyMatrix.add(list);
                    }

                    for (int i = 0; i <= verticesNumber; i++) {
                        for (int j = 0; j <= verticesNumber; j++) {
                            adjacencyMatrix.get(i).add(INF);
                        }
                    }
                    continue;
                }

                int firstVertex = Integer.parseInt(splited[0]);
                int secondVertex = Integer.parseInt(splited[1]);
                int edgeWeight = Integer.parseInt(splited[2]);

                adjacencyMatrix.get(firstVertex).set(secondVertex, edgeWeight);
                adjacencyMatrix.get(secondVertex).set(firstVertex, edgeWeight);

            }
            myReader.close();
        } catch (FileNotFoundException e) {
            System.out.println("An error occurred.");
            e.printStackTrace();
        }
    }


    public void dijkstra() {
        dist[startingVertex] = 0;  //distance from startingVertex to itself is 0
        priorityQueue.add(new Pair(startingVertex, 0));

        while (!priorityQueue.isEmpty()) {
            int u = (priorityQueue.poll()).vertex;

            if (visited[u]) {
                continue; //if this vertex is already visited, skip the rest of the loop
            }

            visited[u] = true;

            for (int i = 0; i < adjacencyMatrix.get(u).size(); i++) {
                if (adjacencyMatrix.get(u).get(i) == INF) {
                    continue;
                    //if the distance from this vertex to its i-th neighbour is INF, it means there is no i-th neighbour
                }

                int v = i;
                int c = adjacencyMatrix.get(u).get(i);

                if (dist[v] > dist[u] + c) {
                    dist[v] = dist[u] + c;
                    priorityQueue.add(new Pair(v, dist[v]));
                }
            }
        }
    }

    public void bellmanFord() {
        dist[startingVertex] = 0;
        int w;
        for (int k = 0; k < verticesNumber; k++) {
            for (int u = 1; u <= verticesNumber; u++) {
                for (int v = 1; v <= verticesNumber; v++) {
                    w = adjacencyMatrix.get(u).get(v);
                    if (w == INF) {
                        continue;
                    }
                    if (dist[u] + w < dist[v]) {
                        dist[v] = dist[u] + w;
                        predecessor[v] = u;
                    }
                }
            }
        }
    }

    public void floydWarshall() {

        for (int u = 1; u <= verticesNumber; u++) {
            for (int v = 1; v <= verticesNumber; v++) {
                dist2D[u][v] = adjacencyMatrix.get(u).get(v);
            }
        }

        for (int v = 1; v <= verticesNumber; v++) {
            dist2D[v][v] = 0;
        }

        for (int k = 1; k <= verticesNumber; k++) {
            for (int i = 1; i <= verticesNumber; i++) {
                for (int j = 1; j <= verticesNumber; j++) {
                    if (dist2D[i][j] > dist2D[i][k] + dist2D[k][j]) {
                        dist2D[i][j] = dist2D[i][k] + dist2D[k][j];
                    }
                }
            }
        }
    }

    public void showDist() {
        for (int i = 1; i <= verticesNumber; i++) {
            System.out.print(dist[i] + " ");
        }
        System.out.println();
    }

    public void showDist2D() {
        for(int i=1; i<=verticesNumber; i++) {
            for(int j=1; j<=verticesNumber; j++) {
                System.out.print(dist2D[i][j] + " ");
            }
            System.out.println();
        }
    }

    public void clearDistAndVisited() {
        for (int i = 0; i <= verticesNumber; i++) {
            dist[i] = INF;
            visited[i] = false;
            predecessor[i] = -1;
            for(int j=0; j<=verticesNumber; j++) {
                dist2D[i][j] = INF;
            }

        }
    }

    public void showAdjacencyMatrix() {
        for (int i = 1; i <= verticesNumber; i++) {
            System.out.print(i + ": ");
            for (int j = 0; j < adjacencyMatrix.get(i).size(); j++) {
                if (adjacencyMatrix.get(i).get(j) != INF) {
                    System.out.print(j + " ");
                }
            }
            System.out.println("");
        }
    }
}
